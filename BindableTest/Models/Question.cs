using System.ComponentModel;
using System.Diagnostics;
using BindableTest.Helpers;

namespace BindableTest.Models
{
    public class Question : INotifyPropertyChanged
    {
        public Label Label { get; set; }

        public string Key { get; set; }

        public bool IsValid { get; set; }

        public bool IsVisible { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine("It works here");
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class Sections : TrulyObservableCollectionGroup<Question>
    {
        public Label Label { get; set; }
        public string Key { get; set; }
        public bool IsValid { get; set; }
    }
}
