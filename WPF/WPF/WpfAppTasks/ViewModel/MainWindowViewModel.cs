using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFUtilities;

namespace WpfAppTasks.ViewModel
{
    class MainWindowViewModel : ObserverVM
    {



        private int firstValue;
        public int FirstValue
        {
            get { return firstValue; }
            set { firstValue = value; OnPropertyChanged();}
        }

        private int secondValue;
        public int SecondValue
        {
            get { return secondValue; }
            set { secondValue = value; OnPropertyChanged(); }
        }

        private string _operationMessage;

        public string OperationMessage
        {
            get { return _operationMessage; }
            set
            {
                _operationMessage = value;
                OnPropertyChanged();
            }
        }


        private int sumResult;
        public int SumResult
        {
            get { return sumResult; }
            set { sumResult = value; OnPropertyChanged(); }
        }


        private ICommand _synchrounousSumCommand;
        public ICommand SynchronousSumCommand
        {
            get
            {
                if (_synchrounousSumCommand == null) 
                {
                    _synchrounousSumCommand = new RelayCommand<object>(arg =>
                    {
                        int result = firstValue + secondValue;
                        Thread.Sleep(10000);
                        SumResult = result;
                        OperationMessage = "Operacja zakonczona";
                    });
                }
                return _synchrounousSumCommand;
            }
        }

        private ICommand _taskSumCommand;
        public ICommand TaskSumCommand
        {
            get
            {
                if (_taskSumCommand == null)
                {
                    _taskSumCommand = new RelayCommand<object>(arg =>
                    {
                        /*
                        Task newTask = new Task(()=> 
                        {
                            int result = firstValue + secondValue;
                            Thread.Sleep(10000);
                            SumResult = result;
                        }
                        );

                        newTask.Start();
                        */

                        Task.Run(() =>
                        {
                            int result = firstValue + secondValue;
                            Thread.Sleep(10000);
                            SumResult = result;
                        });
                         
                        OperationMessage = "Operacja zakonczona (z wątku)";
                    });
                }
                return _taskSumCommand;
            }
        }

        private ICommand _taskSumTaskMessageCommand;
        public ICommand TaskSumTaskMessageCommand
        {
            get
            {
                if (_taskSumTaskMessageCommand == null)
                {
                    _taskSumTaskMessageCommand = new RelayCommand<object>(arg =>
                    {

                        Task newTask = new Task(()=> 
                        {
                            int result = firstValue + secondValue;
                            Thread.Sleep(10000);
                            SumResult = result;
                        }
                        );
                        newTask.Start();

                        Task.Run(() =>
                        {
                            newTask.Wait();
                            OperationMessage = "Operacja zakonczona (z wątku2)";
                        }
                        );


                    });
                }
                return _taskSumTaskMessageCommand;
            }
        }
    }
}
