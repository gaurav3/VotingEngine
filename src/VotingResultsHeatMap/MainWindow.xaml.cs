using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VotingEngineCommon;

namespace VotingResultsHeatMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;

        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;

            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var details = (GroupDetails)btn.DataContext;

            viewModel.UpdateGroupId(details.GroupId);
        }

        private void ParentButtonClick(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            var details = (GroupDetails)btn.DataContext;

            string groupId;
            if (string.IsNullOrEmpty(details.ParentGroupId))
                groupId = details.GroupId;
            else
                groupId = details.ParentGroupId;

            viewModel.UpdateGroupId(groupId);
        }

    }
}
