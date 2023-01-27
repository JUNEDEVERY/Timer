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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcher;
        private int counter = 61;
        public MainWindow()
        {
            InitializeComponent();
            dispatcher = new DispatcherTimer();
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Tick += new EventHandler(TimerEnd);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartAthorization();
         
          

        }
        private void TimerEnd(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                btnNewCode.IsEnabled = true;
                btnNewCode.Visibility = Visibility.Visible;
                
                dispatcher.Stop();
                tbNewCode.Visibility = Visibility.Collapsed;
            }
            else
            {
                tbNewCode.Text = "Новый код доступен через " + counter + " секунд ";
            }
            counter--;

        }
        public static int countOutput = 0;
        public static int successfullyCode = LoginConfirmation.;
    

        void StartAthorization()
        {

          
           
            Random random = new Random();
            int generationCode = random.Next(0, 100000);
            MessageBox.Show("Код для входа -" + generationCode.ToString());
            LoginConfirmation login = new LoginConfirmation(generationCode);
            login.ShowDialog();
           
           
                if(successfullyCode == generationCode)
                {
                    stackLoginPassword.Visibility = Visibility.Visible;
                    stackGenerate.Visibility = Visibility.Collapsed;
                }
           
            if (countOutput < 5)
            {
                MessageBox.Show("Введите код, состоящий из пятизначных цифр");
                this.Close();
            }
            else
            {
                btnAuth.Visibility = Visibility.Collapsed;
                btnNewCode.Visibility = Visibility.Collapsed;
                tbLogin.IsEnabled = false;
                tbPassword.IsEnabled = false;
                tbNewCode.Text = "Получение нового кода доступно через " + counter + " секунд";
                tbNewCode.Visibility = Visibility.Visible;
                dispatcher.Start();

            }

        }

        private void btnNewCode_Click(object sender, RoutedEventArgs e)
        {
            StartAthorization();
        }

        private void btnAuthorizationTwo_Click(object sender, RoutedEventArgs e)
        {
            stackLoginPassword.Visibility = Visibility.Collapsed;
            authSucc.Visibility = Visibility.Visible;
            btnAuth.Visibility = Visibility.Visible;
            btnNewCode.Visibility = Visibility.Visible;
            tbLogin.IsEnabled = true;
            tbPassword.IsEnabled = true;
        }
    }
}
