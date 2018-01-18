using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights;
using Microsoft.Azure.ApplicationInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;

namespace Data.ApplicationInsights.Tests.Events
{
    public class TraceEventsTests : EventsTestBase
    {
        [Fact]
        public async Task GetTraceEvents()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                var timespan = "PT12H";
                var top = 10;

                var client = GetClient(ctx);
                var events = await client.GetTraceEventsAsync(timespan, top: top);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count > 0);
                Assert.True(events.Value.Count <= top);

                foreach (var e in events.Value)
                {
                    AssertEvent(e, EventType.Traces);
                }

                Assert.True(events.Value[0].Id.HasValue);

                var evnt = await client.GetTraceEventAsync(events.Value[0].Id.Value, timespan);

                Assert.NotNull(evnt);
                Assert.NotNull(evnt.Value);
                Assert.True(evnt.Value.Count == 1);

                Assert.Equal(JsonConvert.SerializeObject(evnt.Value[0]),
                    JsonConvert.SerializeObject(events.Value[0]));
            }
        }
    }
}
