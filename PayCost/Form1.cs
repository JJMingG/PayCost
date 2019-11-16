using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayCost
{
    public partial class payCostPage : Form
    {
        public payCostPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void EmployeeFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void SpecEditButton_Click(object sender, EventArgs e)
        {
            // Makes the following textboxes editable
            PaycheckVal.ReadOnly = false;
            EmployeeBenefitsVal.ReadOnly = false;
            DependentsBenfitsVal.ReadOnly = false;
            NumPaychecks.ReadOnly = false;
            DiscountVal.ReadOnly = false;
        }

        private void AddDependentsButton_Click(object sender, EventArgs e)
        {
            // Validates all necessary info are inputted
            if(String.IsNullOrEmpty(DependentFirstName1.Text) || 
                String.IsNullOrEmpty(DependentLastName1.Text) || 
                String.IsNullOrEmpty(DependentRelation1.Text))
            {
                MessageBox.Show("Please fill out all textboxes in order to add dependent!");
            }
            // Creates and inputs ListView item from the given inputs
            else
            {
                string[] listItem = { DependentFirstName1.Text, DependentLastName1.Text, DependentRelation1.Text};
                DependentsListView.Items.Add(new ListViewItem(listItem));
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // Clears all text fields for the next inputs
            DependentsListView.Items.Clear();
            DependentFirstName1.Text = "";
            DependentLastName1.Text = "";
            DependentRelation1.Text = "";
            EmployeeFirstName.Text = "";
            EmployeeLastName.Text = "";
            EmployeePosition.Text = "";
            CostPaycheckCalc.Text = "$$$";
            CostYearCalc.Text = "$$$";
            PaycheckVal.ReadOnly = true;
            EmployeeBenefitsVal.ReadOnly = true;
            DependentsBenfitsVal.ReadOnly = true;
            NumPaychecks.ReadOnly = true;
            DiscountVal.ReadOnly = true;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Validates all necessary info are inputted
            if (String.IsNullOrEmpty(EmployeeFirstName.Text) ||
                String.IsNullOrEmpty(EmployeeLastName.Text) ||
                String.IsNullOrEmpty(EmployeePosition.Text))
            {
                MessageBox.Show("Please fill out all employee info!");
            }
            // Extracts necessary info for database input and calculations
            else
            {
                Employee NewEmployee = new Employee(EmployeeFirstName.Text, EmployeeLastName.Text, 
                    EmployeePosition.Text, DependentsListView);
                CostCalculations Cost = new CostCalculations(NewEmployee, Convert.ToDouble(PaycheckVal.Text),
                    Convert.ToDouble(EmployeeBenefitsVal.Text), Convert.ToDouble(DependentsBenfitsVal.Text),
                    Convert.ToInt32(NumPaychecks.Text), Convert.ToDouble(DiscountVal.Text));

                // Display calculations
                CostPaycheckCalc.Text = "$" + Convert.ToString(Cost.CalculatePaycheckCost());
                CostYearCalc.Text = "$" + Convert.ToString(Cost.CalculateAnnualCost());

            }
        }
    }
}
