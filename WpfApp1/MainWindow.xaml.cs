using Microsoft.AspNetCore.Components.Web;
using Raven.Client.Documents;
using Serilog;
using Serilog.Sinks.MSSqlServer;
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

namespace SeriLogPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Log.Logger = new LoggerConfiguration()
    .WriteTo
    .MSSqlServer(
        connectionString: "Server=(localdb)\\MSSQLLocalDB;Database=Log;Integrated Security=SSPI;",
        sinkOptions: new MSSqlServerSinkOptions() { AutoCreateSqlTable = true , TableName = "Log"})
    .CreateLogger();

        }

        private void sum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Result.Text = (int.Parse(Number1.Text) + int.Parse(Number2.Text)).ToString();
                Log.Information("sum of {firstNumber:0.0} and {secondNumber} is {result}", int.Parse(Number1.Text)
                    , int.Parse(Number2.Text)
                    , int.Parse(Result.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter right values");
                Log.Warning(ex , "The sum operation was unsuccessful");
            }
            
        }

        private void subtraction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void division_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    
}
