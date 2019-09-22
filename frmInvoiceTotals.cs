using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotals : Form
    {
        public frmInvoiceTotals()
        {
            InitializeComponent();
        }

        int numberOfInvoices = 0;
        decimal totalOfInvoices = 0m;
        decimal invoiceAverage = 0m;

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            /***********************************
             * this method calculates the total
             * for an invoice depending on a
             * discount that's based on the subtotal
            ************************************/

            // get the subtotal amount from the Subtotal text box
            decimal invoiceSubtotal = Decimal.Parse(txtEnterSubtotal.Text);

            // set the discountPercent variable based
            // on the value of the subtotal variable
            decimal discountPercent = 0m;        // the m indicates a decimal value
            if (invoiceSubtotal >= 500)
            {
                discountPercent = .2m;
            }
            else if (invoiceSubtotal >= 250 && invoiceSubtotal < 500)
            {
                discountPercent = .15m;
            }
            else if (invoiceSubtotal >= 100 && invoiceSubtotal < 250)
            {
                discountPercent = .1m;
            }

            // calculate and assign the values for the
            // discountAmount and invoiceTotal variables
            decimal discountAmount = Math.Round(invoiceSubtotal * discountPercent, 2);
            decimal invoiceTotal = Math.Round(invoiceSubtotal - discountAmount, 2);

            // add necessary information to the history boxes
            numberOfInvoices++; // count invoices
            txtNumberOfInvoices.Text =
                numberOfInvoices.ToString(); // output new field for counting
            
            totalOfInvoices += invoiceSubtotal; // sum invoice totals
            txtTotalOfInvoices.Text =
                totalOfInvoices.ToString("c"); // output totals

            invoiceAverage = Math.Round(totalOfInvoices / numberOfInvoices, 2); // get average of invoices
            txtInvoiceAverage.Text =
                invoiceAverage.ToString("c"); 

            // format the values and display them in their text boxes
            txtSubtotal.Text =
                invoiceSubtotal.ToString();
            txtDiscountPercent.Text =           // percent format
                discountPercent.ToString("p1"); // with 1 decimal place
            txtDiscountAmount.Text =
                discountAmount.ToString();   // currency format
            txtTotal.Text =
                invoiceTotal.ToString();

            // move the focus to the EnterSubtotal text box and clear it
            txtEnterSubtotal.Text = "";
            txtEnterSubtotal.Focus();
        }

        private void BtxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnClearTotals_Click(object sender, EventArgs e)
        {
            numberOfInvoices = 0;
            totalOfInvoices = 0m;
            invoiceAverage = 0m;

            txtNumberOfInvoices.Text = "";
            txtTotalOfInvoices.Text = "";
            txtInvoiceAverage.Text = "";
            txtSubtotal.Text = "";
            txtDiscountPercent.Text = "";
            txtDiscountAmount.Text = "";
            txtTotal.Text = "";

            txtEnterSubtotal.Focus();
        }
    }
}
