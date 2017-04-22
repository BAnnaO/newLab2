using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    class Team:InameAndCopy
    {
        protected string _Organisation;
        public string Organisation { get { return _Organisation; } set { _Organisation = value; } }
        protected int _RegistrationNumber;
        public int RegistrationNumber {
            get { return _RegistrationNumber; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be more than 0 ");
                }
                else {
                    _RegistrationNumber = value;
                }
            }
        }

        string InameAndCopy.Name
        {
            get
            {
                return string.Format("Team of organisation {0} with registration number {1}",_Organisation,_RegistrationNumber);
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Team(string Organisation, int RegistrationNumber) {
            _Organisation = Organisation;
            _RegistrationNumber = RegistrationNumber;
        }
        public Team():this("Unknown organisation",1) {
        }
        public virtual object DeepCopy(){
            return new Team(this._Organisation,this._RegistrationNumber);
            }
        public virtual bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
           Team objAsTeam = obj as Team;
            if (objAsTeam as Team == null) {
                return false;
            }
            return objAsTeam.Organisation == this.Organisation && objAsTeam.RegistrationNumber == this.RegistrationNumber;

        }
        static public bool operator ==(Team l_Team,Team r_Team) {
            if (ReferenceEquals(l_Team, r_Team)) {
                return true;
            }
            if ((((object)l_Team)==null)||(((object)r_Team)==null)) {
                return false;
            }
            return false; //(l_Team.Organisation == r_Team.Organisation);// && (l_Team.RegistrationNumber==r_Team.RegistrationNumber);

        }
        static public bool operator !=(Team l_Team, Team r_Team)
        {
            return !(l_Team==r_Team);
        }

        public virtual new int GetHashCode() {
            int HashCode = 0;
            foreach (char ch in _Organisation.ToCharArray()) {
                HashCode += (int) Convert.ToUInt32(ch);
            }           
                HashCode += _RegistrationNumber;
            return HashCode;
        }
        public virtual new string ToString() {
            return string.Format("Team of organisation {0} with registration number {1}",_Organisation,_RegistrationNumber);
            }
        }
}
