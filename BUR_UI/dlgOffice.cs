using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUR_UI
{
    public partial class dlgOffice : Form
    {
        public dlgOffice()
        {
            InitializeComponent();
        }

        private void btnOfficeOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOfficeNameFull.Text == "") throw new InvalidOperationException("Please specify a full name for the Office.");
                if (txtOfficeNameAbbr.Text == "") throw new InvalidOperationException("Please specify a short name for the Office.");
                if (cmbOfficeHead.SelectedItem == null) throw new InvalidOperationException("Please select a staff head for the Office.");
                if (txtOfficeheadPos.Text == "") throw new InvalidOperationException("Please specify the staff head's Organizational Position.");

                DialogResult = DialogResult.OK;
            } catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "InvalidOperationException occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
