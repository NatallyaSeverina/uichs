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
using UICHS.ViewModel;

namespace UICHS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //// Установка перечеркнутых (blackout) дат на элементе Calendar
            //DateTime dt = DateTime.Now;
            //CalendarDateRange range = new CalendarDateRange(dt.Add(new TimeSpan(2, 0, 0, 0)), dt.Add(new TimeSpan(4, 0, 0, 0)));
            //calendar.BlackoutDates.Add(range);


        }


    }
}
