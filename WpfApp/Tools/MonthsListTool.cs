using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Tools
{
    public class MonthsListTool
    {
        public IEnumerable<string> GetNumOfMonthsList()
        {
            List<string> returnList = new List<string>();
            for (int i = 3; i <= 12; i++)
            {
                returnList.Add(i + " חודשים");
            }
            return returnList;
        }
    }
}
