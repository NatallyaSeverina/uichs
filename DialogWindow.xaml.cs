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
using System.Windows.Shapes;
using UICHS.ViewModel;

namespace UICHS
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        UserControl uc;
        public DialogWindow(UserControl _uc)
        {
            InitializeComponent();
            uc = _uc;
            DataContext = new DialogWindowVM(uc, this);
        }
    }
}
