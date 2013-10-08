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
        public void SequenceValueIs8After8Seconds()
        {
            var seq = new MonotonicTick();
            
            int value = 0;

            seq.Ticker.Subscribe(x => value = x);

            Thread.Sleep(8500);

            Assert.Equal(8, value);
        }

        [Fact]
        public void SequenceValueIs8After8SimulatedSeconds()
        {
            var scheduler = new TestScheduler();
            var seq = new MonotonicTick(scheduler);

            int value = 0;

            seq.Ticker.Subscribe(x => value = x);

            scheduler.AdvanceTo(8500 * TimeSpan.TicksPerMillisecond);

            Assert.Equal(8, value);
        }
    }
}