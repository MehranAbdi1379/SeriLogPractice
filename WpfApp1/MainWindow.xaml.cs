using Microsoft.AspNetCore.Components.Web;
using Raven.Client.Documents;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;
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
                .MinimumLevel.Verbose()
            .WriteTo
            .File("log.txt")
            .WriteTo
            .MSSqlServer(
             connectionString: "Server=(localdb)\\MSSQLLocalDB;Database=Log;Integrated Security=SSPI;",
             sinkOptions: new MSSqlServerSinkOptions() { AutoCreateSqlTable = true , TableName = "Log"})
            .Enrich.WithProperty("Application name" , "New Application")
            .CreateLogger();

        }

        private void sum_Click(object sender, RoutedEventArgs e)
        {
            var contextLog = Log.Logger.ForContext("programmer" , 15);
            

            contextLog.Verbose("Getting the values");
            contextLog.Debug("Attempting to sum {number} with {number2}", int.Parse(Number1.Text), int.Parse(Number2.Text));
            Log.Information("This is information");

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
