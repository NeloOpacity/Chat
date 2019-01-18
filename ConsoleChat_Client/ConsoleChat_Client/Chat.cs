using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChat_Client
{
    public class Chat:INotifyPropertyChanged
    {
        string _messages;
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Messages
        {
            get => _messages;
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }
    }
}
