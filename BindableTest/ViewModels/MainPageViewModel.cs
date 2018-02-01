#region Using Libraries

using Prism.Navigation;
using BindableTest.Models;
using BindableTest.Helpers;
using Prism.Commands;
using System.Diagnostics;
using System;
using System.ComponentModel;

#endregion

namespace BindableTest.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {

        public DelegateCommand TestCommand { get; set; }

        public TrulyObservableCollectionGroup<Sections> _questionnaireList;
        public TrulyObservableCollectionGroup<Sections> QuestionnaireList { get { return _questionnaireList; } set { _questionnaireList = value; } }

        public MainPageViewModel()
        {
            TestCommand = new DelegateCommand(TestCommandClicked);

            QuestionnaireList = GetList();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine("It needs to work from here, I need to Recheck The List");

            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public TrulyObservableCollectionGroup<Sections> GetList()
        {
            var sectionList = GetSections();

            Random rnd = new Random();

            foreach (var item in sectionList)
            {
                for (int i = 0; i < GetQuestionItems().Count; i++)
                {
                    item.Add(GetQuestionItems()[i]);
                }

            }
            return sectionList;
        }



        #region Command Clicks

        public void TestCommandClicked()
        {

            foreach (var item in QuestionnaireList)
            {
                foreach (var item2 in item)
                {
                    item2.Label.Name = "adsadasdsa";
                }

            }
            Debug.WriteLine(QuestionnaireList[0][0].Label.Name);
        }

        #endregion


        TrulyObservableCollectionGroup<Sections> GetSections()
        {
            return new TrulyObservableCollectionGroup<Sections>
            {
                 new Sections()
                    {
                        Label = new Label()
                        {
                            Name = "Morning",
                            Type = "string"
                        },
                        Key = "",
                    },
                 new Sections()
                    {
                        Label = new Label()
                        {
                            Name = "Afternoon",
                            Type = "string"
                        },
                        Key = ""
                    }
            };
        }

        public TrulyObservableCollectionGroup<Question> GetQuestionItems()
        {

            return new TrulyObservableCollectionGroup<Question>
            {
                new Question() {
                        Label = new Label() {
                            Name = "How Did you sleep",
                            Type = "string" },
                            Key = "",
                            IsVisible = true },
                new Question() {
                        Label = new Label() {
                            Name = "How Did you sleep2",
                            Type = "string" },
                            Key = "",
                            IsVisible = true },
                new Question() {
                        Label = new Label() {
                            Name = "How Did you sleep3",
                            Type = "string" },
                            Key = "",
                            IsVisible = true }
            };
        }

        #region Navigation

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // OnNavigatedFrom
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // OnNavigatedTo
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // OnNavigatingTo
        }

        #endregion
    }
}

