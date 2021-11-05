using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewQuestPage : ContentPage
    {
        public NewQuestPage()
        {
            InitializeComponent();
        }
        public string text;
        //Кнопка створення нового завдання
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            text = NewQuestText.Text;//Текст завдання
            Page1.Quest quest = new Page1.Quest();//Створення нового завдання
            quest.text = text;
            //Визначення характеристик персонажу
            if (strengthButton.IsChecked)
            {
                quest.parametr[0]++;
            }
            if (healthButton.IsChecked)
            {
                quest.parametr[1]++;
            }
            if (brainButton.IsChecked)
            {
                quest.parametr[2]++;
            }
            Page1.questLists.AddNewQuest(quest);//Додавання завдання до списку
            await Navigation.PopToRootAsync();//Повернення до старої сторінки
        }
    }
}