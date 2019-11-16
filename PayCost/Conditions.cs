using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCost
{
    class Conditions
    {
        /* 
         * This class is intended to be used for various conditions that may be required in the future.
         * For now, the only function/condition this class has is if a string input (in this case, a name)
         * starts with an 'A'.
         * 
         */

        // Condition: if input starts with 'A'
        public static bool ConditionStartsWithA(String input)
        {
            if (input.StartsWith("A"))
            {
                return true;
            }

            return false;
        }
    }
}
