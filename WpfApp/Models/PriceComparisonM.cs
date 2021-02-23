using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Models
{
    public class PriceComparisonM
    {
        IBL BL;
        public PriceComparisonM()
        {
            BL = new BLImp(((App)Application.Current).Currents.LoggedUser);
        }
        #region getters
        public IEnumerable<string> GetPriceComparison(string ItemName)
        {
            return BL.GetPriceComparison(ItemName);
        }

        public IEnumerable<string> GetItems()
        {
            return BL.GetAllItems().Select(item => item.Name).Distinct().OrderBy(item => item);
        }
        public IEnumerable<string> GetBranches()
        {
            return BL.GetAllBranches();
        }

        public IEnumerable<Item> GetItemsByName(string ItemName)
        {
            return BL.GetAllItems(item => item.Name == ItemName);
        }

        public IEnumerable<double> GetCartSize(string[] Carts, IEnumerable<string> itemsList)
        {
            List<double> CartsSize = new List<double>();
            foreach (var Cart in Carts)
            {
                CartsSize.Add(BL.GetCartPriceByShopName(Cart, itemsList));
            }
            return CartsSize;
        }
        #endregion
    }
}
