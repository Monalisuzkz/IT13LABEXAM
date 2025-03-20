using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT13LABEXAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the salary input
                double salary = double.Parse(txtSalary.Text);

                // Initialize variables for contributions
                double regEmployerContribution = 0;
                double regEmployeeContribution = 0;
                double wispEmployerContribution = 0;
                double wispEmployeeContribution = 0;
                double totalEmployerContribution = 0;
                double totalEmployeeContribution = 0;
                double totalContribution = 0;

                if (salary >= 20000)
                {
                    // Salaries of 20,000 and above (include WISP)
                    regEmployerContribution = Math.Round(salary * 0.09, 2); // 9%
                    regEmployeeContribution = Math.Round(salary * 0.045, 2); // 4.5%
                    wispEmployerContribution = Math.Round(salary * 0.006, 2); // 0.6%
                    wispEmployeeContribution = Math.Round(salary * 0.003, 2); // 0.3%

                    totalEmployerContribution = regEmployerContribution + wispEmployerContribution;
                    totalEmployeeContribution = regEmployeeContribution + wispEmployeeContribution;
                    totalContribution = totalEmployerContribution + totalEmployeeContribution;

                    lblOutput.Text =
                        $"Employer Contributions:\n" +
                        $"- Regular: {regEmployerContribution:C}\n" +
                        $"- WISP: {wispEmployerContribution:C}\n" +
                        $"Employee Contributions:\n" +
                        $"- Regular: {regEmployeeContribution:C}\n" +
                        $"- WISP: {wispEmployeeContribution:C}\n" +
                        $"Total Contributions:\n" +
                        $"- Employer Total: {totalEmployerContribution:C}\n" +
                        $"- Employee Total: {totalEmployeeContribution:C}\n" +
                        $"- Grand Total: {totalContribution:C}";
                }
                else
                {
                    // Salaries below 20,000 (no WISP)
                    regEmployerContribution = Math.Round(salary * 0.09675, 2); // 9.675%
                    regEmployeeContribution = Math.Round(salary * 0.045, 2); // 4.5%

                    totalEmployerContribution = regEmployerContribution;
                    totalEmployeeContribution = regEmployeeContribution;
                    totalContribution = totalEmployerContribution + totalEmployeeContribution;

                    lblOutput.Text =
                        $"Employer Contributions:\n" +
                        $"- Regular: {regEmployerContribution:C}\n" +
                        $"Employee Contributions:\n" +
                        $"- Regular: {regEmployeeContribution:C}\n" +
                        $"Total Contributions:\n" +
                        $"- Employer Total: {totalEmployerContribution:C}\n" +
                        $"- Employee Total: {totalEmployeeContribution:C}\n" +
                        $"- Grand Total: {totalContribution:C}";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid salary!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
