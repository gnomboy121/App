using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public class QuestLists
        {
            
            public ObservableCollection<Quest> questToDo = new ObservableCollection<Quest>();

            public ObservableCollection<Quest> questDone = new ObservableCollection<Quest>();
            //Метод додавання нового завдання до списку
            public void AddNewQuest(Quest quest)
            {
                questToDo.Add(quest);
            }
            //Метод додавання виконаного завдання до списку
            public void AddDoneQuest(Quest quest)
            {
                questDone.Add(quest);
            }
        }

        public static QuestLists questLists = new QuestLists();


        public Page1()
        {
            InitializeComponent();
            QuestsToDoView.ItemsSource = questLists.questToDo;
            QuestsDoneView.ItemsSource = questLists.questDone;

            questLists.AddNewQuest(new Quest { text = "Вийти на пробіжку", parametr = new int[3] { 1, 0, 0 } });
            questLists.AddNewQuest(new Quest { text = "Зробити свіжий салат на вечерю", parametr = new int[3] { 0, 1, 0 } });
            questLists.AddNewQuest(new Quest { text = "Прочитати 20 сторінок книги", parametr = new int[3] { 0, 0, 1 } });

        }

        public class Quest
        {
            public string text { get; set; }
            public string time { get; set; }

            public int[] parametr = new int[3] { 0, 0, 0 }; 
        }
        //Кнопка для створення нової сторінки
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewQuestPage());
        }
        //Кнопка опрацювання виконаного завдання
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var quest = button?.BindingContext as Quest;
            Page2.person.strength += quest.parametr[0]; //Додавання характеристик персонажу 
            Page2.person.health += quest.parametr[1];
            Page2.person.brain += quest.parametr[2];
            Page2.person.xp += 10;//Додавання опиту персонажу
            Page2.Charts();//Оновлення діаграм характеристик персонажу
            //Додавання виконаного завдання до списку виконаних завдань
            quest.time = DateTime.Now.ToString("d");
            questLists.AddDoneQuest(quest);
            questLists.questToDo.Remove(quest);//Видалення виконаного завдання із списку завдань

        }
    }
}