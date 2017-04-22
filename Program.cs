using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    enum TimeFrame { Year, TwoYears, Long }
    class Program
    {
        static void Main(string[] args)
        {
            Team MyTeam1 = new Team("IRE",7);
            Team MyTeam2 = new Team("IRE", 7);
            Console.WriteLine(MyTeam1.Equals(MyTeam2));
            Console.WriteLine(MyTeam1==MyTeam2);
            Console.WriteLine(string.Format(" MyTeam1: {0}, MyTeam2: {1} ", MyTeam1.GetHashCode(),MyTeam2.GetHashCode()));
            try {
                MyTeam2.RegistrationNumber = -2;
            }
            catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.Message);
            }
            ResearchTeam MyTeam3 = new ResearchTeam();
            MyTeam3.AddMembers(new Person[3] { new Person("Ann","Boguslavska",new DateTime(1992,01,13)),new Person("Some", "Person", new DateTime(1990, 11, 13)),new Person()});
            MyTeam3.AddPapers(new Paper[2] { new Paper("SP", new Person("Ann", "Boguslavska", new DateTime(1992, 01, 13)),new DateTime(2016,11,13)), new Paper() });
            //Console.WriteLine(MyTeam3.getTeamType.ToString());
            ResearchTeam MyTeam4 = (ResearchTeam)MyTeam3.DeepCopy();
            MyTeam3.Organisation = "SoftServe";
            MyTeam3.RegistrationNumber = 7;
           // Console.WriteLine(MyTeam3.ToString());
            //Console.WriteLine(MyTeam4.ToString());
            
            foreach (Person pers in MyTeam3.MembersWithoutPublications()) {
                Console.WriteLine(pers);
            }
            foreach (Paper pap in MyTeam3.LastPapers(2))
            {
                Console.WriteLine(pap);
            }

            Console.ReadKey();
        }
    }
}
