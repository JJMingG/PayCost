using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayCost
{
    class CostCalculations
    {
        public Employee NewEmployee { get; private set; }
        public double PreDeductionPaycheck { get; private set; }
        public double BenefitsEmployee { get; private set; }
        public double BenefitsDependents { get; private set; }
        public int NumPaychecks { get; private set; }
        public double Discount { get; private set; }

        public CostCalculations(Employee NewEmployee, double PreDeductionPaycheck, double BenefitsEmployee,
            double BenefitsDependents, int NumPaychecks, double Discount)
        {
            this.NewEmployee = NewEmployee;
            this.PreDeductionPaycheck = PreDeductionPaycheck;
            this.BenefitsEmployee = BenefitsEmployee;
            this.BenefitsDependents = BenefitsDependents;
            this.NumPaychecks = NumPaychecks;
            this.Discount = Discount;
        }

        public double CalculateAnnualCost()
        {
            double Cost = 0;
            double Weight = 1.0;
            double EmployeeWeighted = Weight;
            double SumDependentsWeighted = 0;
        
            // Calculate weights
            if (Conditions.ConditionStartsWithA(NewEmployee.FirstName))
            {
                EmployeeWeighted = Weight - Discount;
            }
            SumDependentsWeighted = SumDependentWeights();

            // Calculate cost
            Cost = PreDeductionPaycheck * NumPaychecks + BenefitsEmployee * EmployeeWeighted + 
                BenefitsDependents * SumDependentsWeighted;

            return Cost;
        }

        public double CalculatePaycheckCost()
        {
            return Math.Round(CalculateAnnualCost()/NumPaychecks, 2);
        }

        private double SumDependentWeights()
        {
            // Find weights of each dependent and sum all dependent weights
            double Sum = 0;
            double Weight = 1.0;

            foreach (ListViewItem Item in NewEmployee.Dependents.Items)
            {
                if (Conditions.ConditionStartsWithA((Item.SubItems[0].Text)))
                {
                    Sum += Weight - Discount;
                }
                else
                {
                    Sum += Weight;
                }

            }

            return Sum;
        }
    }
}
