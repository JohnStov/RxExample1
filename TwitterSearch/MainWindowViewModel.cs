using System;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using ReactiveUI;

namespace TwitterSearch
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            Changed.Throttle(TimeSpan.FromSeconds(1)).Subscribe(
                x =>
                {
                    if (x.PropertyName == "SearchText")
                        SearchFor = Reverse(SearchText);
                });
        }


        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { this.RaiseAndSetIfChanged(ref searchText, value); }
        }

        private string searchFor;
        public string SearchFor
        {
            get { return searchFor; }
            set { this.RaiseAndSetIfChanged(ref searchFor, value); }
        }

        private string Reverse(string str)
        {
            var chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
}