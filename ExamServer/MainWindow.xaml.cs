using JP.ExamSystem.ExamCommons;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;

namespace JP.ExamSystem.ExamServer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TesterInfo> TesterInfos; 
       
        public MainWindow()
        {
            InitializeComponent();
           // this.DataContext = this;
            
            TesterInfos = new ObservableCollection<TesterInfo>();
            //订阅考生信息改变事件
            TesterInfoManager.TesterInfosChanged += TesterInfoManager_TesterInfosChanged;
            dgMonitor.ItemsSource = TesterInfos;
           // this.dgMonitor.DataContext = TesterInfos;
            //var bb = new Binding();
            //bb.Path="ID"
            //(dgMonitor.Columns[0] as DataGridTextColumn).Binding = new Binding();

            ////var dataGrid = new DataGrid { AutoGenerateColumns = false };
            ////foreach (var node in first)
            ////{
            ////    dataGrid.Columns.Add(new DataGridTextColumn { Header = node.Key, Binding = new Binding(string.Format("[{0}]", node.Key)) });
            ////}
            //dgMonitor.ItemsSource = TesterInfoList;
        }

        void TesterInfoManager_TesterInfosChanged(object sender, TesterInfosChangedEventArgs e)
        {
            this.TesterInfos.Add(e.ChangedItem);
        }
        private void InitMonitor()
        {
            //this.dgMonitor.Columns.Add(new DataGridTextColumn(){ Header="准考证号", });
        }
        /// <summary>
        /// 启动考试服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchServiceClick(object sender, RoutedEventArgs e)
        {
            var serviceHosts = new ServiceHostCollection();
            serviceHosts.Open();
        }
    }
}
