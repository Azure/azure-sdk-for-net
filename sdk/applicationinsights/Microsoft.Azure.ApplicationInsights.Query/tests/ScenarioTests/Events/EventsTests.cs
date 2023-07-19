using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Data.ApplicationInsights.Tests.Events
{
    public class EventsTests : EventsTestBase
    {
        private const int TopCount = 10;
        private readonly string Timespan = "P1D";

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetAllEvents()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var client = GetClient(ctx);
                var events = await client.Events.GetByTypeAsync(DefaultAppId, EventType.All, timespan: Timespan, top: TopCount);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count <= TopCount);

                foreach (var evnt in events.Value)
                {
                    var eventType = GetEventType(evnt);
                    if (eventType != null) continue; // This means there is a new type that we don't support here yet
                    AssertEvent(evnt, eventType);
                }
            }
        }

        [Theory(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        [InlineData(EventType.Traces)]
        [InlineData(EventType.CustomEvents)]
        [InlineData(EventType.PageViews)]
        [InlineData(EventType.BrowserTimings)]
        [InlineData(EventType.Requests)]
        [InlineData(EventType.Dependencies)]
        [InlineData(EventType.Exceptions)]
        [InlineData(EventType.AvailabilityResults)]
        [InlineData(EventType.PerformanceCounters)]
        [InlineData(EventType.CustomMetrics)]
        public async Task GetEventsByType(string eventType)
        {
            using (var ctx = MockContext.Start(this.GetType(), $"GetByType.{eventType}"))
            {
                var client = GetClient(ctx);
                var traces = await client.Events.GetByTypeAsync(DefaultAppId, eventType, timespan: Timespan, top: TopCount);

                Assert.NotNull(traces);
                Assert.NotNull(traces.Value);
                Assert.True(traces.Value.Count <= TopCount);

                var evnt = traces.Value[0];

                AssertEvent(evnt, eventType);

                traces = await client.Events.GetAsync(DefaultAppId, eventType, evnt.Id);

                Assert.NotNull(traces);
                Assert.NotNull(traces.Value);
                Assert.Equal(1, traces.Value.Count);

                evnt = traces.Value[0];

                AssertEvent(evnt, eventType);
            }
        }
    }
}
