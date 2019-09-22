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

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            /***********************************
             * this method calculates the total
             * for an invoice depending on a
             * discount that's based on the subtotal
            ************************************/

            // get the subtotal amount from the Subtotal text bo
            decimal invoiceSubtotal = Convert.ToDecimal(txtSubtotal.Text);

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
            decimal discountAmount = invoiceSubtotal * discountPercent;
            decimal invoiceTotal = invoiceSubtotal - discountAmount;

            // format the values and display them in their text boxes
            txtDiscountPercent.Text =           // percent format
                discountPercent.ToString("p1"); // with 1 decimal place
            txtDiscountAmount.Text =
                discountAmount.ToString("c");   // currency format
            txtTotal.Text =
                invoiceTotal.ToString("c");

            // move the focus to the Subtotal text box
            txtSubtotal.Focus();
        }

        private void BtxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
