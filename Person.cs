using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    class Person
    {
        private string _Name;
        public string PersName
        {
            get
            {
                return _Name;
            }
        }
        private string _Surname;
        public string PersonSurname
        {
            get { return _Surname; }

        }
        private System.DateTime _Birthday;
        public DateTime PersonBirthday
        {
            get { return _Birthday; }

        }
        public int intBirthday
        {
            get { return Convert.ToInt32(_Birthday); }
            set { _Birthday = Convert.ToDateTime(value); }
        }
        public Person(string Name, string Surname, DateTime Birthday)
        {
            _Name = Name;
            _Surname = Surname;
            _Birthday = Birthday;
        }
        public Person() : this("Jon", "Milton", new DateTime(1998, 11, 12))
        {
        }
        public override string ToString()
        {
            return string.Format("{0} {1} was born {2}", _Name, _Surname, _Birthday);
        }
        public string ToShortString()
        {
            return string.Format("{0} {1}", _Name, _Surname);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Person objPers = obj as Person;
            if (obj as Person == null)
            {
                return false;
            }
            return objPers.PersName == _Name && objPers.PersonSurname == _Surname && objPers.PersonBirthday == _Birthday;
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = _Name.ToCharArray();

            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            char[] SurnameChar = _Surname.ToCharArray();
            foreach (char ch in SurnameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += _Birthday.Year * _Birthday.Month;
            return hashcode;
        }
        public static bool operator ==(Person lpers, Person rpers)
        {
            if (ReferenceEquals(lpers, rpers))
            {
                return true;
            }
            if ((object)lpers == null || (object)rpers == null)
            {
                return false;
            }
            return lpers.PersName == rpers.PersName && lpers.PersonBirthday == rpers.PersonBirthday && lpers.PersonSurname == rpers.PersonSurname;
        }
        public static bool operator !=(Person lpers, Person rpers)
        {
            return !(lpers == rpers);
        }
        public virtual object DeepCopy()
        {
            Person persCopy = new Person(this.PersName, this.PersonSurname, this.PersonBirthday);
            return persCopy;
        }
        
    }
}
