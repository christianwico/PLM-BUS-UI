using BUR_UI.Entities;
using BUR_UI.Interface;
using System.Collections.Generic;
using System;

namespace BUR_UI.Logic
{
    public class Builder
    {
        public List<SAAOModel> FillSAAOModel(List<AccountsModel> acct, List<ABModel> ab)
        {
            List<SAAOModel> SAAO = new List<SAAOModel>();

            for (int i = 0; i < ab.Count; i++)
            {
                SAAO.Insert(i, new SAAOModel()
                {
                    AB = ab[i].ApprovedBudget,
                    Code = ab[i].AccountCode,
                });

                for (int j = 0; j < acct.Count; j++)
                {
                    if (SAAO[i].Code == acct[j].AccountCode)
                        SAAO[i].Amount += acct[j].Amount;
                }
            }

            return SAAO;
        }
        public List<SAAOModel> FillMonthlyModel(List<AccountsModel> acct, List<ABModel> ab)
        {
            List<SAAOModel> Monthly = new List<SAAOModel>();

            for (int i = 0; i < ab.Count; i++)
            {
                Monthly.Insert(i, new SAAOModel()
                {
                    AB = ab[i].ApprovedBudget,
                    Code = ab[i].AccountCode,
                });

                for (int j = 0; j < acct.Count; j++)
                {
                    if (Monthly[i].Code == acct[j].AccountCode)
                        Monthly[i].Amount += acct[j].Amount;
                }
            }

            return Monthly;
        }

        public List<RAOModel> FillRAOModel()
        {
            DbLink link = new DbLink();
            List<RAOModel> RAO = new List<RAOModel>();
            string janThisYear = DateTime.Today.Year + "-01-01";

            RAO = link.FillRAOModel(janThisYear, DateTime.Today.ToString("yyyy-MM-dd"));

            return RAO;
        }
    }
}
