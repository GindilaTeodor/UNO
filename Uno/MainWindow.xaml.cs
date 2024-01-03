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
using Uno.Factory;
using Uno.Model;
using Uno.ViewModel;
using Uno.Views;

namespace Uno
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void Start_Pressed(object sender, RoutedEventArgs e)
        {
            CardsVM _cardsVm = new CardsVM();
            GameView a = new GameView(_cardsVm);
            a.Show();
            this.Close();
        }

        void Credit_Pressed(object sender, RoutedEventArgs e)
        {
            CreditsWindow a = new CreditsWindow();
            a.Show();
            this.Close();
        }
        void Exit_Pressed(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
