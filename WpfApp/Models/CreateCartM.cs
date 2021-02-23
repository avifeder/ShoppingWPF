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
    public class CreateCartM
    {
        IBL BL;
        public CreateCartM()
        {
            BL = new BLImp(((App)Application.Current).Currents.LoggedUser);
        }

        #region getters
        public IEnumerable<string> GetItems()
        {
            return BL.GetAllItems().Select(item => item.Name).Distinct().OrderBy(item => item);
        }
        public IEnumerable<Item> GetItemsByName(string ItemName)
        {
            return BL.GetAllItems(item => item.Name == ItemName);
        }

        public string GetCheapestBranch(string itemName)
        {
            List<string> branchesList = BL.GetPriceComparison(itemName).ToList();
            string cheapestBranch = branchesList[0];
            float cheapestPrice = float.Parse(cheapestBranch.Split('\n')[1].Substring(1));
            foreach (var shop in branchesList)
            {
                float price = float.Parse(shop.Split('\n')[1].Substring(1));
                if (price < cheapestPrice)
                {
                    cheapestBranch = shop;
                    cheapestPrice = price;
                }

            };
            return cheapestBranch;
        }

        public Dictionary<string, List<string>> GetBuyingOffer(List<string> itemsName)
        {
            return BL.AnalizeHistory(itemsName);
        }
        #endregion

        #region other tools
        public void CreatePDF(List<object[]> items)
        {
            BL.CreatePDF(items);
        }
        #endregion
    }

}
