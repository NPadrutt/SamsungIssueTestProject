using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendsAppDate.Foundation.Models
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private long id;
        private long idService;
        private string phoneNumber;
        private List<ContactViewModel> contacts;

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

        public long IdService
        {
            get { return idService; }
            set
            {
                if (idService == value) return;

                idService = value;
                RaisePropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber == value) return;

                phoneNumber = value;
                RaisePropertyChanged();
            }
        }

        public List<ContactViewModel> Contacts
        {
            get { return contacts; }
            set
            {
                if (contacts == value) return;

                contacts = value;
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