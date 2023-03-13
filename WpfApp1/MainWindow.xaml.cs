using Microsoft.AspNetCore.Components.Web;
using Serilog;
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

            const string customTemplate = "Will be logged: {Timestamp:yyyy-MMM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";

            ILogger logger = new LoggerConfiguration()
                .Destructure.ByTransforming<Color>(c => new {c.Red , c.Green})
                .WriteTo
                .File("log.txt" , outputTemplate: customTemplate)
                .CreateLogger();

            Log.Logger = logger;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            int age = int.Parse(Age.Text);
            var faveColor = new Color
            {
                Blue = 132,
                Green = 13,
                Red = 24
            };

            Log.Information("User Added {UserName} , Age {UserAge}. Favorites: {@Colors}" , name, age , faveColor);

        }
    }

    public class Color
    {
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Red { get; set; }
    }
}
