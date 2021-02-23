using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class HistoryBySCartVM : BaseViewModel
    {
        public HistoryBySCartVM()
        {
            NumberOfMounths = "5";
            SeriesCollection = new SeriesCollection();
            HistoryBySCartM = new HistoryBySCartM();
            YFormatter = value => value.ToString("C");
            NumOfMonthsList = new ObservableCollection<string>(new Tools.MonthsListTool().GetNumOfMonthsList());
            updateGraph();
        }
        #region properties
        public HistoryBySCartM HistoryBySCartM { get; set; }
        public ObservableCollection<string> NumOfMonthsList { get; set; }
        private string numberOfMounths { get; set; }
        public string NumberOfMounths
        {
            get { return numberOfMounths; }
            set
            {
                numberOfMounths = value.Split(' ')[0];
                Labels = new Tools.GetMounthsLabels().GetLabels(int.Parse(NumberOfMounths));
                updateGraph();
                OnPropertyRaised("NumberOfMounths");
            }
        }
        #endregion       
        #region chart properties

        private SeriesCollection seriesCollection { get; set; }
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

        public void updateGraph()
        {
            if (SeriesCollection == null)
                return;
            SeriesCollection.Clear();
            SeriesCollection.Add(new LineSeries
            {
                Title = "סל הקניות שלך",
                Values = new ChartValues<double>(HistoryBySCartM.GetHistoryBySCart(Labels)),
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 15
            });            
        }
        #endregion
    }
}
