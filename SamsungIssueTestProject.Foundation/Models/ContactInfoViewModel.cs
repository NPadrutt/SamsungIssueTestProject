using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendsAppDate.Foundation.Models
{
    /// <summary>
    ///     Interface for a contact info.
    /// </summary>
    public class ContactInfoViewModel : INotifyPropertyChanged
    {
        private long id;
        private long idService;
        private long idAddressbook;
        private long contactId;
        private string info;

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

        public long IdAddressbook
        {
            get { return idAddressbook; }
            set
            {
                if (idAddressbook == value) return;

                idAddressbook = value;
                RaisePropertyChanged();
            }
        }

        public long ContactId
        {
            get { return contactId; }
            set
            {
                if (contactId == value) return;

                contactId = value;
                RaisePropertyChanged();
            }
        }

        public string Info
        {
            get { return info; }
            set
            {
                if (info == value) return;

                info = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// true, if data changed since reading out of address book
        /// </summary>
        public bool HasUnsavedChanges { get; set; } = false;

        /// <summary>
        /// true, if object is completely initialized (after then, changes to this object affect the HasUnsavedChanges flag!)
        /// </summary>
        public bool IsInitialized { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (IsInitialized && propertyName != nameof(HasUnsavedChanges) && !HasUnsavedChanges) HasUnsavedChanges = true;
        }
    }
}