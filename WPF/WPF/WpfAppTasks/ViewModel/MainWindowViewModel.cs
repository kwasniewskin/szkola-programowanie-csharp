using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitisWPF;

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
            set { secondValue = value; OnPropertyChanged();}
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

        private ICommand _asyncSumCommand;
        public ICommand AsyncSumCommand
        {
            get
            {
                if (_asyncSumCommand == null)
                {
                    _asyncSumCommand = new RelayCommand<object>(async arg =>
                    {
                        await Task.Run(() =>
                        {
                            int result = firstValue + secondValue;
                            Thread.Sleep(10000);
                            sumResult = result;
                        }
                        );

                        OperationMessage = "Operacja zakonczona (z innego wątku)";
                    });
                }
                return _asyncSumCommand;
            }
        }

        object lockObject = new object();
        private ICommand _sum_v2Command;
        public ICommand Sum_v2Command
        {
            get
            {
                if (_sum_v2Command == null)
                {
                    _sum_v2Command = new RelayCommand<object>(arg =>
                    {
                        Task.Run(() =>
                        {
                            lock (lockObject)
                            {
                                int localValue = FirstValue;
                                Thread.Sleep(500);
                                localValue += 2;
                                FirstValue = localValue;
                            }
                        });

                        Task.Run(() =>
                        {
                            lock (lockObject)
                            {
                                int localValue = FirstValue;
                                Thread.Sleep(500);
                                localValue *= 2;
                                FirstValue = localValue;
                            }
                        });
                    });
                }
                return _sum_v2Command;
            }
        }
    }
}
