using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FriendsAppDate.Foundation.Models
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private long id;
        private long idService;
        private long idAddressbook;
        private byte[] image;
        private bool isMe;
        private bool isAllowedToReceiveMyInfos;
        private string prefix;
        private string prename;
        private string middlename;
        private string name;
        private string suffix;
        private UserViewModel user;
        private List<ContactInfoViewModel> infos;
        private List<ContactAddressViewModel> addresses;
        private List<ContactEventViewModel> events;

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

        public byte[] Image
        {
            get { return image; }
            set
            {
                if (image == value) return;

                image = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Indicates, whether this contact is me or someone else.
        /// </summary>
        public bool IsMe
        {
            get { return isMe; }
            set
            {
                if (isMe == value) return;

                isMe = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///     Indicates, whether this contact is allowed to receive my infos or not.
        /// </summary>
        public bool IsAllowedToReceiveMyInfos
        {
            get { return isAllowedToReceiveMyInfos; }
            set
            {
                if (isAllowedToReceiveMyInfos == value) return;

                isAllowedToReceiveMyInfos = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The prefix part of the name of the contact.
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
            set
            {
                if (prefix == value) return;

                prefix = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The prename of the contact.
        /// </summary>
        public string Prename
        {
            get { return prename; }
            set
            {
                if (prename == value) return;

                prename = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The middle name of the contact.
        /// </summary>
        public string MiddleName
        {
            get { return middlename; }
            set
            {
                if (middlename == value) return;

                middlename = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The name of the contact.
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

        public string DisplayName => string.IsNullOrWhiteSpace(MiddleName) ? string.Join(" ", Prefix, Prename, Name, Suffix).Trim()
                                                                           : string.Join(" ", Prefix, Prename, MiddleName, Name, Suffix).Trim();

        /// <summary>
        /// The suffix part of the name of the contact.
        /// </summary>
        public string Suffix
        {
            get { return suffix; }
            set
            {
                if (suffix == value) return;

                suffix = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The list of associated contact infos.
        /// </summary>
        public List<ContactInfoViewModel> Infos
        {
            get { return infos; }
            set
            {
                if (Equals(infos, value)) return;

                infos = value;
                RaisePropertyChanged();
            }
        }

        public UserViewModel User
        {
            get { return user; }
            set
            {
                if (Equals(user, value)) return;

                user = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The list of associated addresses.
        /// </summary>
        public List<ContactAddressViewModel> Addresses
        {
            get { return addresses; }
            set
            {
                if (Equals(addresses, value)) return;

                addresses = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The list of associated events. For example a birthday, a wedding anniversary, and so on.
        /// </summary>
        public List<ContactEventViewModel> Events
        {
            get { return events; }
            set
            {
                if (Equals(events, value)) return;

                events = value;
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

        public override string ToString()
        {
            var parts = new[]
            {
                Prefix?.Trim(),
                Prename?.Trim(),
                MiddleName?.Trim(),
                Name?.Trim()
            };

            return
                $"{string.Join(" ", parts.Where(part => !string.IsNullOrWhiteSpace(part)))} ({string.Join(", ", Infos.Where(info => info.InfoType.ToString().Contains("Number")).Select(info => $"{info.Info}"))})";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (IsInitialized && propertyName != nameof(HasUnsavedChanges) && !HasUnsavedChanges) HasUnsavedChanges = true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ContactViewModel);
        }

        public bool Equals(ContactViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            //return id == other.id && Equals(image, other.image) && isMe == other.isMe && isAllowedToReceiveMyInfos == other.isAllowedToReceiveMyInfos && string.Equals(prefix, other.prefix) && string.Equals(prename, other.prename) && string.Equals(middlename, other.middlename) && string.Equals(name, other.name) && string.Equals(suffix, other.suffix) && Equals(infos, other.infos) && Equals(addresses, other.addresses) && Equals(events, other.events);
            return id == other.id;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = id.GetHashCode();
                //hashCode = (hashCode*397) ^ (image?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ isMe.GetHashCode();
                //hashCode = (hashCode*397) ^ isAllowedToReceiveMyInfos.GetHashCode();
                //hashCode = (hashCode*397) ^ (prefix?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (prename?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (middlename?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (name?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (suffix?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (infos?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (addresses?.GetHashCode() ?? 0);
                //hashCode = (hashCode*397) ^ (events?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(ContactViewModel left, ContactViewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ContactViewModel left, ContactViewModel right)
        {
            return !Equals(left, right);
        }
    }
}