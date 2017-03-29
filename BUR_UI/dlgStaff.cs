using System;
using System.Windows.Forms;

namespace BUR_UI
{
    public partial class dlgStaff : Form
    {
        public bool PasswordEdit = false;

        public dlgStaff()
        {
            InitializeComponent();
        }

        private void dlgStaff_Load(object sender, EventArgs e)
        {

        }

        private void btnStaffOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPayee.SelectedItem == null) throw new MissingFieldException("Please select an existing Payee to add as a BO Staff.");
                if (cmbStaffType.SelectedItem == null) throw new MissingFieldException("Please specify a BO Staff type.");
                if (PasswordEdit)
                {
                    if (txtPassword.Text == "" || txtConfirmPassword.Text == "")
                    {
                        throw new MissingFieldException("Please ensure that both password fields are filled in.");
                    } else
                    {
                        if (txtPassword.Text != txtConfirmPassword.Text) throw new InvalidOperationException("Please ensure that the password fields match.");
                    }
                }

                DialogResult = DialogResult.OK;
            } catch (MissingFieldException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "MissingFieldException occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "InvalidOperationException occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordEdit = true;
            pnlPasswordConceal.Visible = false;
        }
    }
}
