using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.ChartEntry;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public static Person person = new Person();
        public static Chart chart1 = new DonutChart();
        public static Chart chart2 = new BarChart() { LabelTextSize = 60f , LabelOrientation = Orientation.Horizontal, };

        public static void Charts()
        {
            //Створення параметрів 1 діаграми
            ObservableCollection<Entry> Entries1()
            {
                ObservableCollection<Entry> entries1 = new ObservableCollection<Entry>
        {
            new Entry(person.xp)
            {
                Color = SKColor.Parse("#008000"),
            },
            new Entry(200-person.xp)
            {
                Color = SKColor.Parse("#FF0000"),
            }
        };
                return entries1;
            }
            //Створення параметрів 2 діаграми
            ObservableCollection<Entry> Entries2()
            {
                ObservableCollection<Entry> entries2 = new ObservableCollection<Entry>
        {
            new Entry(person.strength)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="Сила",
                ValueLabel = person.strength.ToString()
            },
            new Entry(person.health)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "Здоров'я",
                ValueLabel = person.health.ToString()
            },
            new Entry(person.brain)
            {
                Color =  SKColor.Parse("#00CED1"),
                Label = "Інтелект",
                ValueLabel = person.brain.ToString()
            }
        };

                return entries2;
            }
            chart1.Entries = Entries1();
            chart2.Entries = Entries2();
        }
        public Page2()
        {
            InitializeComponent();
            SetPersonName(person.name);
            Charts();
            chartView1.Chart = chart1;
            chartView2.Chart = chart2;
            labelLevel.Text = person.level.ToString();
        }


        public class Person
        {
            public string name = "Олександр";
            public int level = 1;
            public int xp = 0;
            public int health = 1;
            public int strength = 1;
            public int brain = 1;
        }
        //Метод для оновлення імені
        public void SetPersonName(string name)
        {
            PersonNameLabel.Text = name;
        }
        //Метод для введеня нового імені
        private async void NewPersonName(object sender, EventArgs e)
        {
            SetPersonName(await DisplayPromptAsync("","Як вас звати?"));
        }
    }
}