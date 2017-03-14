using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendsAppDate.Foundation.Models
{
    public class ContactEventViewModel : INotifyPropertyChanged
    {
        private long id;
        private long idService;
        private long idAddressbook;
        private long contactId;
        private DateTime? now;
        private DateTime start;
        private string name;

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

        /// <summary>
        ///     The current date.
        /// </summary>
        public DateTime Now
        {
            get { return now ?? DateTime.Now; }
            set
            {
                if (now == value) return;

                now = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     First date of occurence of this event.
        /// </summary>
        public DateTime Start
        {
            get { return start; }
            set
            {
                if (start == value) return;

                start = value;
                RaisePropertyChanged();
            }
        }
        
        /// <summary>
        ///     The name of this event.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) return;

                name = value;
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