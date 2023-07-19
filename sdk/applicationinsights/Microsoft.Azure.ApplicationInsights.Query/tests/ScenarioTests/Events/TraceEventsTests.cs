using System.Threading.Tasks;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;
using System;

namespace Data.ApplicationInsights.Tests.Events
{
    public class TraceEventsTests : EventsTestBase
    {
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6135")]
        public async Task GetTraceEvents()
        {
            using (var ctx = MockContext.Start(this.GetType()))
            {
                var timespan = "PT12H";
                var top = 10;

                var client = GetClient(ctx);
                var events = await client.Events.GetTraceEventsAsync(DefaultAppId, timespan, top: top);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count > 0);
                Assert.True(events.Value.Count <= top);

                foreach (var e in events.Value)
                {
                    AssertEvent(e, EventType.Traces);
                }

                Assert.True(!string.IsNullOrEmpty(events.Value[0].Id));

                var evnt = await client.Events.GetTraceEventAsync(DefaultAppId, events.Value[0].Id, timespan);

                Assert.NotNull(evnt);
                Assert.NotNull(evnt.Value);
                Assert.True(evnt.Value.Count == 1);

                Assert.Equal(JsonConvert.SerializeObject(evnt.Value[0]),
                    JsonConvert.SerializeObject(events.Value[0]));
            }
        }
    }
}
