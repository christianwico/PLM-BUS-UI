using System;
using System.Windows.Forms;

namespace BUR_UI
{
    public partial class dlgPayee : Form
    {
        public dlgPayee()
        {
            InitializeComponent();
        }

        private void btnOfficeOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPayeeNumber.Text == "") throw new MissingFieldException("Please specify an Employee Number.");
                if (txtPayeeName.Text == "") throw new MissingFieldException("Please specify the Employee's Name.");
                if (txtPayeePos.Text == "") throw new MissingFieldException("Please specify the Employee's Organizational Position.");
                if (cmbPayeeOffice.SelectedItem == null) throw new MissingFieldException("Please select the Office to assign the Employee to.");

                DialogResult = DialogResult.OK;
            }
            catch (MissingFieldException ex)
            {
                MessageBox.Show(ex.Message, "MissingFieldException occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
