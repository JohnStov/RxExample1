using System;
using System.Reactive.Linq;
using System.Threading;
using Microsoft.Reactive.Testing;
using Xunit;

namespace TestExample
{
    public class MonotonicTickTest
    {
        [Fact]
        public void SequenceValueIs8After9Seconds()
        {
            var seq = new MonotonicTick();
            
            int value = 0;

            seq.Ticker.Subscribe(x => value = x);

            Thread.Sleep(9100);

            Assert.Equal(8, value);
        }

        [Fact]
        public void SequenceValueIs8After9SecondsFaked()
        {
            var scheduler = new TestScheduler();
            var seq = new MonotonicTick(scheduler);

            int value = 0;

            seq.Ticker.Subscribe(x => value = x);

            scheduler.Schedule()

            Assert.Equal(8, value);
        }
    }
}