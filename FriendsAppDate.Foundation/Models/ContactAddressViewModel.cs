using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendsAppDate.Foundation.Models
{
    public class ContactAddressViewModel : INotifyPropertyChanged
    {
        private long id;
        private long idService;
        private long idAddressbook;
        private long contactId;
        private string co;
        private string pobox;
        private string street;
        private string city;
        private string postcode;
        private string country;
        private bool hasUnsavedChanges;

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
        ///     The c/o ('care of') part of the address.
        /// </summary>
        public string Co
        {
            get { return co; }
            set
            {
                if (co == value) return;

                co = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The postal box part of the address.
        /// </summary>
        public string PoBox
        {
            get { return pobox; }
            set
            {
                if (pobox == value) return;

                pobox = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The name of the street, including housenumber and an optional housenumber appendix.
        /// </summary>
        public string Street
        {
            get { return street; }
            set
            {
                if (street == value) return;

                street = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The name of the city.
        /// </summary>
        public string City
        {
            get { return city; }
            set
            {
                if (city == value) return;

                city = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     The postcode of the city.
        /// </summary>
        public string Postcode
        {
            get { return postcode; }
            set
            {
                if (postcode == value) return;

                postcode = value;
                RaisePropertyChanged();
            }
        }

        public string CityPostcode => string.Join(" ", Postcode, City);

        /// <summary>
        ///     The name of the country.
        /// </summary>
        public string Country
        {
            get { return country; }
            set
            {
                if (country == value) return;

                country = value;
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