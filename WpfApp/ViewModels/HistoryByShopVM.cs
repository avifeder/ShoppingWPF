using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using WpfApp.Commands;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class HistoryByShopVM : BaseViewModel
    {
        public HistoryByShopVM()
        {
            NumberOfMounths = "5";
            HistoryByShopM = new HistoryByShopM();
            ShopList = new ObservableCollection<string>(HistoryByShopM.GetShops().OrderBy(x => x));
            NumOfMonthsList = new ObservableCollection<string>(new Tools.MonthsListTool().GetNumOfMonthsList());
            SeriesCollection = new SeriesCollection();

            Labels = new Tools.GetMounthsLabels().GetLabels(int.Parse(NumberOfMounths));
            YFormatter = value => value.ToString("C");
        }
        #region collections
        public ObservableCollection<string> ShopList { get; set; }
        public ObservableCollection<string> NumOfMonthsList { get; set; }
        #endregion
        #region properties
        public HistoryByShopM HistoryByShopM { get; set; }
        private string numberOfMounths { get; set; }
        public string NumberOfMounths
        {
            get { return numberOfMounths; }
            set
            {
                numberOfMounths = value.Split(' ')[0];
                Labels = new Tools.GetMounthsLabels().GetLabels(int.Parse(NumberOfMounths));
                normelizeGraph();
                OnPropertyRaised("NumberOfMounths");
            }
        }
        #endregion        
        #region commands
        public ICommand UpdateGraphCommand
        {
            get
            {
                return new UpdateGraphCommand(this);
            }
        }
        #endregion
        #region chart properties

        public SeriesCollection seriesCollection { get; set; }
        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set
            {
                seriesCollection = value;
                OnPropertyRaised("SeriesCollection");
            }
        }
        private string[] labels { get; set; }
        public string[] Labels
        {
            get { return labels; }
            set
            {
                labels = value;
                OnPropertyRaised("Labels");
            }
        }

        public Func<double, string> YFormatter { get; set; }
        #endregion
        #region other
        public void updateGraph(string ShopName)
       {
            foreach (var line in seriesCollection)
            {
                if (line.Title == ShopName)
                {
                    seriesCollection.Remove(line);
                    return;
                }
            }

            SeriesCollection.Add
                (new LineSeries
                {
                    Title = ShopName,
                    Values = new ChartValues<double>(HistoryByShopM.GetHistoryByShop(ShopName, Labels)),
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 15
                });
       }
        public void normelizeGraph()
        {
            if (SeriesCollection == null)
                return;
            List<string> SeriesCollectionLineTitles = SeriesCollection.Select(line => line.Title).ToList<string>();
            SeriesCollection.Clear();
            foreach (var LineTitle in SeriesCollectionLineTitles)
            {
                updateGraph(LineTitle);
            }
        }
        #endregion

    }
}
