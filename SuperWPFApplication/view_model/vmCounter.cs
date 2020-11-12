using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;

namespace SuperWPFApplication.view_model
{
    public class vmCounter : INotifyPropertyChanged
    {
        private model.Counter selected_counter;
        private RelayCommand addCommand;
        public ObservableCollection<model.Counter> Counters { get; set; }
        public model.Counter SelectedCounter
        {
            get { return selected_counter; }
            set
            {
                selected_counter = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand AddCommand
        {
            get
            {
                Console.WriteLine("Button Pressed");
                RelayCommand ret = addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      selected_counter.calculate();
                  }));
                return ret;
            }
        }

        public vmCounter()
        {
            Counters = new ObservableCollection<model.Counter>
            {
                new model.Counter { number_arg = 0, a_argument = 0, b_argument = 0, c_argument = 0 },
                new model.Counter { number_arg = 1, a_argument = 1, b_argument = 1, c_argument = 1 },
                new model.Counter { number_arg = 2, a_argument = -5, b_argument = 2, c_argument = 4 },
                new model.Counter { number_arg = 3, a_argument = 8, b_argument = -20, c_argument = 1 },
            };
            SelectedCounter = Counters[3];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
