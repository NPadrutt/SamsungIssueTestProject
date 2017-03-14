using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendsAppDate.Foundation.Models
{
    public class RequestViewModel : INotifyPropertyChanged
    {
        private long id;
        private string phonenumberFrom;
        private string phonenumberTo;
        private bool isEstablished;
        private string displayName;

        public long Id
        {
            get { return id; }
            set
            {
                if (id == value) return;
                id = value;
                RaisePropertyChanged();
            }
        }

        public string DisplayName
        {
            get { return displayName; }
            set
            {
                if(displayName == value) return;
                displayName = value; 
                RaisePropertyChanged();
            }
        }

        public string UserFromNumber
        {
            get { return phonenumberFrom; }
            set
            {
                if (phonenumberFrom == value) return;
                phonenumberFrom = value;
                RaisePropertyChanged();
            }
        }

        public string UserToNumber
        {
            get { return phonenumberTo; }
            set
            {
                if (phonenumberTo == value) return;
                phonenumberTo = value;
                RaisePropertyChanged();
            }
        }

        public bool IsEstablished
        {
            get { return isEstablished; }
            set
            {
                if (isEstablished == value) return;
                isEstablished = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}