using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUR_UI.Entities
{
    public class RAOModel
    {
        public string BURNumber { get; set; }
        public DateTime BURFDate { get; set; }
        public List<AccountsModel> Particulars { get; set; }
    }
}
