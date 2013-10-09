using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace TestExample
{
    public class MonotonicTick
    {
        public MonotonicTick(IScheduler scheduler = null)
        {
            if (scheduler == null)
                scheduler = DefaultScheduler.Instance;
            
            Ticker = Observable
                        .Interval(TimeSpan.FromSeconds(1), scheduler)
                        .Zip(Enumerable.Range(1, 10), (tick, index) => index);
        }


        public IObservable<int> Ticker { get; private set; }
    }
}
