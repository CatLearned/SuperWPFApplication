using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace SuperWPFApplication.model
{
    public class Counter: INotifyPropertyChanged
    {
        private int number;
        private int a = 0;
        private int b = 0;
        private int c = 0;
        private int? d = null;
        private double? x1 = null;
        private double? x2 = null;


        public int number_arg
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged();
            }
        }
        public int a_argument
        {
            get { return a; }
            set 
            { 
                a = value;
                OnPropertyChanged();
            }
        }

        public int b_argument
        {
            get { return b; }
            set 
            {
                OnPropertyChanged();
                b = value; 
            }
        }

        public int c_argument
        {
            get { return c; }
            set 
            {
                OnPropertyChanged(); 
                c = value; 
            }
        }

        public int? d_result
        {
            get { return d; }
        }

        public double? x1_result
        {
            get { return x1; }
        }

        public double? x2_result
        {
            get { return x2; }
        }

        public void calculate()
        {
                d = b * b - 4 * a * c;
                OnPropertyChanged("d_result");
                if (d < 0)
                    return;
                if (d == 0)
                {
                    x1 = -b / (2 * a);
                    OnPropertyChanged("x1_result");
                    x2 = null;
                    OnPropertyChanged("x2_result");
                    return;
                }
                x1 = (-b + Math.Sqrt(Convert.ToDouble(d))) / (2 * a);
                OnPropertyChanged("x1_result");
                x2 = (-b - Math.Sqrt(Convert.ToDouble(d))) / (2 * a);
                OnPropertyChanged("x2_result");

                return; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
