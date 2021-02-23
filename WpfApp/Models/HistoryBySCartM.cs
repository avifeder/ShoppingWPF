using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Models
{
    public class HistoryBySCartM
    {
        IBL BL;
        public HistoryBySCartM()
        {
            BL = new BLImp(((App)Application.Current).Currents.LoggedUser);
        }
        public IEnumerable<double> GetHistoryBySCart(string[] labels)
        {
            return BL.GetHistoryBySCart(labels);
        }
    }
}
