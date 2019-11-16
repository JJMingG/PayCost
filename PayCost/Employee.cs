using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayCost
{
    public class Employee
    {
        public String FirstName { get; private set; }
        public String LastName { get; private set; }
        public String Position { get; private set; }
        public ListView Dependents { get; private set; }
        
        public Employee(String FirstName, String LastName, String Position,
            ListView Dependents)
        {
            /* 
                In a real world scenario, these parameters would be inputted into a database first.
                This way, we would be able to keep a running database of all of our employees and their info.
             */

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Position = Position;
            this.Dependents = Dependents;

            Console.WriteLine("Employee added to database");
        }
    }
}
