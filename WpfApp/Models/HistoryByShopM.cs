﻿using BL;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Models
{
    public class HistoryByShopM
    {
        IBL BL;
        public HistoryByShopM()
        {
            BL = new BLImp(((App)Application.Current).Currents.LoggedUser);
        }
        #region getters
        public IEnumerable<double> GetHistoryByShop(string ShopName, string[] Mounths)
        {

            return BL.GetHistoryByShop(ShopName, Mounths);
        }

        public IEnumerable<string> GetShops()
        {
            return BL.GetAllShops();
        }
        #endregion
    }
}
