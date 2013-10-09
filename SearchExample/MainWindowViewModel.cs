using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

using ReactiveUI;

namespace SearchExample
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            Changed.Throttle(TimeSpan.FromSeconds(1)).ObserveOn(ThreadPoolScheduler.Instance).Subscribe(
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
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            return new string(chars);
        }

    }
}