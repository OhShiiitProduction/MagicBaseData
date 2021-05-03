using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using MagicBaseData.Enums;
using MagicBaseData.Interfaces;

namespace MagicBaseData.Models
{
    public class Magician: INotifyPropertyChanged, System.ComponentModel.IDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double power;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Power
        {
            get { return power; }
            set
            {
                power = value;
                OnPropertyChanged("Title");
            }
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public double Speed { get; set; }
        public double HitPoints { get; set; }
        public KindOfMagic KindOfMagic { get; set; }
        public override string ToString()
        {
            return Id+","+Name + "," + power + "," + Speed + "," + HitPoints + "," + KindOfMagic.ToString();
        }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string Error => throw new NotImplementedException();
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        {

                            break;
                        }
                    case "Power":
                        {
                            if (string.IsNullOrWhiteSpace(Name))
                                error = "Power Not be Empty";
                        
                            break;
                        }

                }
                if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = error;
                else if (error != null)
                    ErrorCollection.Add(columnName, error);

                //OnPropertyChanged("ErrorCollection");
                
                return error;
            }

        }
    }
}
