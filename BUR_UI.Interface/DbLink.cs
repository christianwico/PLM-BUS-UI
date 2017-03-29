﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BUR_UI.Entities;
using System.Security.Cryptography;

namespace BUR_UI.Interface
{
    public class DbLink
    {
        Typer GetId = new Typer();

        public List<AccountsModel> FillAccountsModel()
        {
            List<AccountsModel> Acct = new List<AccountsModel>();
            string yearStart = DateTime.Today.Year.ToString() + "-01-01";
            string dateNow = DateTime.Now.Year.ToString() + "-" +
                DateTime.Now.Month.ToString("D2") + "-" +
                DateTime.Now.AddDays(1).Day.ToString("D2");

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT A.Item_Amount, A.Acct_Code " +
                    "FROM dbo.tbl_Item AS A " +
                    "INNER JOIN dbo.tbl_BUR AS B " +
                    "ON A.BUR_No = B.BUR_No " +
                    "WHERE B.BUR_FDate BETWEEN '" + yearStart + "' AND '" + dateNow + "'", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Acct.Add(
                            new AccountsModel()
                            {
                                Amount = reader.GetDecimal(0),
                                AccountCode = reader.GetString(1)
                            });
                    }
                }
            }

            return Acct;
        }

        public List<AccountsModel> FillAccountsModel(string janThisYear, string dateToday, string BURNumber)
        {
            List<AccountsModel> Acct = new List<AccountsModel>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT A.Item_Amount, A.Acct_Code, C.Acct_ClassId " +
                    "FROM dbo.tbl_Item AS A " +
                    "INNER JOIN dbo.tbl_BUR AS B " +
                    "ON A.BUR_No = B.BUR_No " +
                    "INNER JOIN dbo.tbl_Particulars AS C ON A.Acct_Code = C.Acct_Code " +
                    "WHERE B.BUR_No = '" + BURNumber + "'", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Acct.Add(
                            new AccountsModel()
                            {
                                Amount = reader.GetDecimal(0),
                                AccountCode = reader.GetString(1),
                                ClassId = reader.GetInt32(2)
                            });
                    }
                }
            }

            return Acct;
        }

        public void PushLog(string log)
        {
            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand("INSERT INTO dbo.tbl_Log (Msg) VALUES ('" + log + "')", conn);

                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<String> FillOffice()
        {
            List<string> Offices = new List<string>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT Office_NameAbbr FROM dbo.tbl_A_Certified",
                    conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                        Offices.Add(reader.GetString(0));
                }

                reader.Close();
            }

            return Offices;
        }
        public void ChangePassword(string staffNumber, string newPassword)
        {
            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "UPDATE dbo.tbl_BO_Staff " +
                    "SET Password = '" + newPassword + "' " +
                    "WHERE BStaff_Number = '" + staffNumber + "'", conn);

                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
        public bool userValidate(string User, string Pass)
        {

            Object hasher = MD5.Create();

            

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT * FROM dbo.tbl_BO_Staff " +
                    "WHERE BStaff_Number = '" + User + "' AND Password = '" + Pass + "'",
                    conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }

                return false;
            }
        }
        public List<string> FillPR()
        {
            List<string> PRs = new List<string>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT PR_Code FROM dbo.tbl_PR",
                    conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                        PRs.Add(reader.GetString(0));
                }

                reader.Close();
            }

            return PRs;
        }
        public List<string> FillPayeeByOffice(string Office_Name)
        {
            Typer Typer = new Typer();

            List<string> Payee = new List<string>();

            if (Office_Name != "External")
            {
                using (SqlConnection conn = InitSql())
                {
                    SqlCommand comm = new SqlCommand(
                        "SELECT Employee_Name " +
                        "FROM dbo.tbl_Payee " +
                        "WHERE Office_Code = '" + Typer.GetSelectedOfficeCode(Office_Name) + "'",
                        conn);

                    conn.Open();

                    SqlDataReader reader = comm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            Payee.Add(reader.GetString(0));
                    }

                    reader.Close();
                }
            } else
            {
                using (SqlConnection conn = InitSql())
                {
                    SqlCommand comm = new SqlCommand(
                        "SELECT Employee_Name " +
                        "FROM dbo.tbl_Ext_Payee",
                        conn);

                    conn.Open();

                    SqlDataReader reader = comm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            Payee.Add(reader.GetString(0));
                    }

                    reader.Close();
                }
            }

            return Payee;
        }     
        public List<string> FillClass()
        {
            List<string> Classes = new List<string>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT Acct_Class_Name FROM dbo.tbl_Classification",
                    conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                        Classes.Add(reader.GetString(0));
                }

                reader.Close();
            }

            return Classes;
        }
        public List<string> FillCodeByClass(string Class_Name)
        {
            Typer Typer = new Typer();

            List<string> Code = new List<string>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT Acct_Code, Acct_Name " +
                    "FROM dbo.tbl_Particulars " +
                    "WHERE Acct_ClassId = '" + Typer.GetSelectedClassCode(Class_Name) + "'",
                    conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Code.Add(reader.GetString(0) + ": " + reader.GetString(1));
                    }  
                }

                reader.Close();
            }

            return Code;
        }
        public string FillNameByCode(string Acct_Code)
        {
            string name = "";

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT Acct_Name " +
                    "FROM dbo.tbl_Particulars " +
                    "WHERE Acct_Code = '" + Acct_Code + "'",
                    conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        name = reader.GetString(0);
                    }
                }

                reader.Close();
            }

            return name;
        }
        public List<Entities.BURModel> FillGrid()
        {
            List<Entities.BURModel> BUR = new List<Entities.BURModel>();
            Typer Typer = new Typer();

            SqlConnection conn = InitSql();

            using (conn)
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT * FROM dbo.tbl_BUR ORDER BY BUR_FDate ASC", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BUR.Add(
                            new Entities.BURModel()
                            {
                                BURNumber = reader.GetString(1),
                                Date = reader.GetDateTime(2).ToString(),
                                Office = Typer.GetSelectedOfficeName(reader.GetString(3)),
                                Staff = Typer.GetSelectedStaffName(reader.GetString(5)),
                                Payee = Typer.GetSelectedPayeeName(reader.GetString(6))
                            });
                    }
                }
            }

            return BUR;
        }
        public SqlConnection InitSql()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Resources.ConnectionStringLocal;

            return conn;
        }
        public List<ABModel> FillABModel()
        {
            List<ABModel> AB = new List<ABModel>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT AB_Amount, Acct_Code " +
                    "FROM dbo.tbl_AB", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AB.Add(
                            new ABModel()
                            {
                                ApprovedBudget = reader.GetDecimal(0),
                                AccountCode = reader.GetString(1)
                            });
                    }
                }
            }

            return AB;
        }
        public List<AccountsModel> FillAccountsModel(int ClassId, string startDate, string endDate)
        {
            List<AccountsModel> Acct = new List<AccountsModel>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT A.Item_Amount, A.Acct_Code " +
                    "FROM dbo.tbl_Item AS A " +
                    "INNER JOIN dbo.tbl_BUR AS B ON A.BUR_No = B.BUR_No " +
                    "INNER JOIN dbo.tbl_Particulars AS C ON A.Acct_Code = C.Acct_Code " +
                    "INNER JOIN dbo.tbl_Classification AS D ON D.Acct_ClassId = C.Acct_ClassId " +
                    "WHERE B.BUR_FDate BETWEEN '" + startDate + "' AND '" + endDate + "' " +
                    "AND D.Acct_ClassId = " + ClassId, conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Acct.Add(
                            new AccountsModel()
                            {
                                Amount = reader.GetDecimal(0),
                                AccountCode = reader.GetString(1)
                            });
                    }
                }
            }

            return Acct;
        }

        public List<ABModel> FillABModel(int ClassId)
        {
            List<ABModel> AB = new List<ABModel>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT A.AB_Amount, A.Acct_Code " +
                    "FROM dbo.tbl_AB AS A " +
                    "INNER JOIN dbo.tbl_Particulars AS B ON A.Acct_Code = B.Acct_Code " +
                    "INNER JOIN dbo.tbl_Classification AS C ON B.Acct_ClassId = C.Acct_ClassId " +
                    "WHERE C.Acct_ClassId = " + ClassId, conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        AB.Add(
                            new ABModel()
                            {
                                ApprovedBudget = reader.GetDecimal(0),
                                AccountCode = reader.GetString(1)
                            });
                    
                    }
                }
            }

            return AB;
        }
        public List<BURModel> FillGrid(string text)
        {
            Typer typer = new Typer();
            List<BURModel> BUR = new List<BURModel>();
            Typer Typer = new Typer();

            SqlConnection conn = InitSql();

            using (conn)
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT * FROM dbo.tbl_BUR " +
                    "WHERE BUR_No LIKE '%" + text + "%'" /* "OR " +
                    "Office_Code LIKE '%" + typer.GetSelectedOfficeCode(text) + "%' OR " +
                    "Employee_Number LIKE '%" + typer.GetPayeeId(text) + "%' OR " +
                    "BStaff_Number LIKE '%" + typer.GetSelectedStaffCode(text) + "%'" */, conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BUR.Add(
                            new BURModel()
                            {
                                BURNumber = reader.GetString(1),
                                Date = reader.GetDateTime(2).ToString(),
                                Office = Typer.GetSelectedOfficeName(reader.GetString(3)),
                                Staff = Typer.GetSelectedStaffName(reader.GetString(5)),
                                Payee = Typer.GetSelectedPayeeName(reader.GetString(6))
                            });
                    }
                }
            }

            return BUR;
        }
        public List<UserModel> FillUserModel(List<UserModel> users)
        {
            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT * FROM dbo.tbl_BO_Staff", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel()
                        {
                            User_Number = reader.GetString(1),
                            User_Name = reader.GetString(2),
                            Discriminator = reader.GetString(3),
                            Position = reader.GetString(5),
                            Picture = reader.GetString(6)
                        });
                    }
                }
            }

            return users;
        }
        public List<AccountGridModel> FillAccountGridModel(List<AccountGridModel> accounts)
        {
            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand(
                    "SELECT A.Acct_Code, A.Acct_Name, B.Acct_Class_Name, C.AB_Amount FROM" +
                    " dbo.tbl_Particulars AS A" +
                    " INNER JOIN dbo.tbl_Classification AS B ON A.Acct_ClassId = B.Acct_ClassId" +
                    " INNER JOIN dbo.tbl_AB AS C ON A.Acct_Code = C.Acct_Code" +
                    " ORDER BY A.Acct_Code ASC", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        accounts.Add(new AccountGridModel()
                        {
                            AcctCode = reader.GetString(0),
                            AcctName = reader.GetString(1),
                            AcctClass = reader.GetString(2),
                            AB = reader.GetDecimal(3)
                        });
                    }
                }
            }

            return accounts;
        }

        public string FillLogs()
        {
            string logs = "";
            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand("SELECT Msg FROM dbo.tbl_Log ORDER BY Id DESC", conn);
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        logs += reader.GetString(0) + "\r\n";
                    }
                }
            }

            return logs;
        }

        public List<RAOModel> FillRAOModel(string janThisYear, string dateToday)
        {
            DbLink link = new DbLink();
            List<RAOModel> RAO = new List<RAOModel>();

            using (SqlConnection conn = InitSql())
            {
                SqlCommand comm = new SqlCommand("SELECT BUR_No, BUR_FDate FROM dbo.tbl_BUR WHERE BUR_FDate BETWEEN '" + janThisYear + "' AND '" + dateToday + "' ORDER BY BUR_No ASC", conn);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RAO.Add(new RAOModel()
                        {
                            BURNumber = reader.GetString(0),
                            BURFDate = reader.GetDateTime(1),
                            Particulars = link.FillAccountsModel(janThisYear, dateToday, reader.GetString(0))
                        });
                    }
                }
            }

            return RAO;
        }

        public List<OfficeModel> FillOfficeModel(List<OfficeModel> offices)
        {
            using (SqlConnection conn = InitSql())
            {
                conn.Open();

                SqlCommand comm = new SqlCommand("SELECT A.Office_Code, A.Office_NameFull, A.Office_NameAbbr, B.Officehead_Name, B.Officehead_Pos " +
                    "FROM dbo.tbl_A_Certified AS A " +
                    "INNER JOIN dbo.tbl_Officehead AS B ON A.OfficeheadId = B.OfficeheadId", conn);

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        offices.Add(new OfficeModel() {
                            OfficeCode = reader.GetString(0),
                            OfficeName = reader.GetString(1),
                            OfficeNameAbbr = reader.GetString(2),
                            Officehead = reader.GetString(3),
                            OfficeheadPos = reader.GetString(4)
                        });
                    }
                }
            }

            return offices;
        }

        public List<string> FillPayees()
        {
            List<string> payees = new List<string>();

            using (SqlConnection conn = InitSql())
            {
                conn.Open();

                SqlCommand comm = new SqlCommand("SELECT Employee_Name FROM dbo.tbl_Payee ORDER BY Employee_Name ASC", conn);

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        payees.Add(reader.GetString(0));
                    }
                }
            }

            return payees;
        }

        public List<PayeeModel> FillPayeeModel(List<PayeeModel> payees)
        {
            using (SqlConnection conn = InitSql())
            {
                conn.Open();

                SqlCommand comm = new SqlCommand("SELECT Employee_Number, Employee_Name, Employee_Pos, Office_Code " +
                    "FROM dbo.tbl_Payee", conn);

                SqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows) {
                    while (reader.Read())
                    {
                        payees.Add(new PayeeModel()
                        {
                            PayeeNumber = reader.GetString(0),
                            PayeeName = reader.GetString(1),
                            PayeePos = reader.GetString(2),
                            PayeeOfficeCode = reader.GetString(3)
                        });
                    }
                }
            }

            return payees;
        }
    }
}
