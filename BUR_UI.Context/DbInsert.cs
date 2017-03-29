using System;
using System.Data.SqlClient;
using BUR_UI.Entities;
using BUR_UI.Interface;
using System.Windows.Forms;

namespace BUR_UI.Context
{
    public class DbInsert
    {
        public void InsertBUR(BURModel BUR)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Resources.ConnectionStringLocal;

            using (conn)
            {
                conn.Open();

                //Insert BUR Metadata.
                SqlCommand comm = new SqlCommand(
                    "INSERT INTO dbo.tbl_BUR VALUES " +
                    "('" + BUR.BURNumber + "', '" + BUR.Date + "', '" + BUR.OfficeCode +
                    "', '20030210', '" + BUR.BStaff_Number + "', '" + BUR.Payee_Number +
                    "', '" + BUR.PRNumber + "', '" + BUR.Description + "', '" + BUR.SignatoryOfficeCode + "')", conn);

                comm.ExecuteNonQuery();

                //Insert PR Number.
                comm.CommandText = 
                    "INSERT INTO dbo.tbl_PR VALUES " +
                    "('" + BUR.PRNumber + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "')";

                comm.ExecuteNonQuery();

                //Insert items first.
                foreach (var item in BUR.Particulars)
                {
                    SqlCommand _comm = new SqlCommand(
                        "INSERT INTO dbo.tbl_Item (Item_Amount, Acct_Code, BUR_No) " +
                        "VALUES (" + item.Amount + ", " + item.Code + ", '" + item.BUR_Number +
                        "')",
                        conn);

                    _comm.ExecuteNonQuery();
                }

               



                
            }
        }
        public void UpdateBUR(BURModel BUR)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Resources.ConnectionStringLocal;

            using (conn)
            {
                conn.Open();

                //Insert items first.
                foreach (var item in BUR.Particulars)
                {
                    SqlCommand _comm = new SqlCommand(
                        "UPDATE dbo.tbl_Item " +
                        "SET Item_Amount = " + item.Amount + ", Acct_Code = '" + item.Code + "', BUR_No = '" + item.BUR_Number +
                        "' WHERE BUR_No = '" + item.BUR_Number + "'",
                        conn);

                    _comm.ExecuteNonQuery();
                }

                //Insert BUR Metadata.
                SqlCommand comm = new SqlCommand(
                    "UPDATE dbo.tbl_BUR SET " +
                    "BUR_No = '" + BUR.BURNumber + "', BUR_FDate = '" + BUR.Date + "', Office_Code = '" + BUR.OfficeCode +
                    "', BDHead_Number = '20030210', BStaff_Number = '" + BUR.BStaff_Number + "', Employee_Number = '" + BUR.Payee_Number +
                    "', PR_Code = '" + BUR.PRNumber + "', Description = '" + BUR.Description + "'" +
                    "WHERE BUR_No = '" + BUR.BURNumber + "'", conn);

                comm.ExecuteNonQuery();
            }
        }

        public void EditAccount(AccountGridModel acct)
        {
            DbLink link = new DbLink();

            using (SqlConnection conn = link.InitSql())
            {
                // Insert to the AB table.
                SqlCommand comm = new SqlCommand("UPDATE dbo.tbl_AB SET AB_Amount = " + acct.AB + " WHERE Acct_Code = '" + acct.AcctCode + "'", conn);
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }

        public void InsertOffice(string officeNameFull, string officeNameAbbr, string officehead, string officeheadPos)
        {
            DbLink Link = new DbLink();
            Typer SqlTyper = new Typer();

            using (SqlConnection conn = Link.InitSql())
            {
                int officeCode = 31;
                int officeheadId = 22;

                conn.Open();

                SqlCommand comm = new SqlCommand("SELECT TOP 1 Office_Code FROM dbo.tbl_A_Certified ORDER BY Office_Code DESC", conn);
                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        officeCode = int.Parse(reader.GetString(0));
                        officeCode++;
                    }
                }

                reader.Close();

                comm.CommandText = "INSERT INTO dbo.tbl_Officehead (Officehead_Name, Officehead_Pos) " +
                    "VALUES ('" + officehead + "', '" + officeheadPos + "'); SELECT SCOPE_IDENTITY();";

                try
                {
                    officeheadId = int.Parse(comm.ExecuteScalar().ToString());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "SqlException occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                comm.CommandText = "INSERT INTO dbo.tbl_A_Certified (Office_Code, Office_NameFull, Office_NameAbbr, OfficeheadId) " +
                    "VALUES ('" + officeCode + "', '" + officeNameFull + "', '" + officeNameAbbr + "', " + officeheadId + ")";

                comm.ExecuteNonQuery();
            }
        }
    }
}
