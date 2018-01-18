using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.ApplicationInsights.Tests.Events;
using Microsoft.Azure.ApplicationInsights;
using Microsoft.Azure.ApplicationInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;

namespace Data.ApplicationInsights.Tests.ScenarioTests.Events
{
    public class EventsExtensionTests : EventsTestBase
    {
        [Theory]
        [MemberData(nameof(TraceData))]
        [MemberData(nameof(CustomEventsData))]
        [MemberData(nameof(PageViewsData))]
        [MemberData(nameof(BrowserTimingsData))]
        [MemberData(nameof(RequestsData))]
        [MemberData(nameof(DependenciesData))]
        [MemberData(nameof(ExceptionsData))]
        [MemberData(nameof(AvailabilityResultsData))]
        [MemberData(nameof(PerformanceCountersData))]
        [MemberData(nameof(CustomMetricsData))]
        public async Task GetEventsAsync<T>(EventType eventType, MultiQueryAsync<T> multiQueryAsync, SingleQueryAsync<T> singleQueryAsync,
            object unused1, object unused2) where T : EventsResultData
        {
            using (var ctx = MockContext.Start(GetType().FullName, $"GetEvents.{eventType}"))
            {
                var timespan = "PT12H";
                var top = 10;

                var client = GetClient(ctx);
                var events = await multiQueryAsync(client, timespan, top);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count > 0);
                Assert.True(events.Value.Count <= top);

                foreach (var e in events.Value)
                {
                    AssertEvent(e, eventType);
                }

                Assert.True(events.Value[0].Id.HasValue);

                var evnt = await singleQueryAsync(client, events.Value[0].Id.Value, timespan);

                Assert.NotNull(evnt);
                Assert.NotNull(evnt.Value);
                Assert.True(evnt.Value.Count == 1);

                Assert.Equal(JsonConvert.SerializeObject(evnt.Value[0]),
                    JsonConvert.SerializeObject(events.Value[0]));
            }
        }

        [Theory]
        [MemberData(nameof(TraceData))]
        [MemberData(nameof(CustomEventsData))]
        [MemberData(nameof(PageViewsData))]
        [MemberData(nameof(BrowserTimingsData))]
        [MemberData(nameof(RequestsData))]
        [MemberData(nameof(DependenciesData))]
        [MemberData(nameof(ExceptionsData))]
        [MemberData(nameof(AvailabilityResultsData))]
        [MemberData(nameof(PerformanceCountersData))]
        [MemberData(nameof(CustomMetricsData))]
        public void GetEvents<T>(EventType eventType, object unused1, object unused2,
            MultiQuery<T> multiQuery, SingleQuery<T> singleQuery) where T : EventsResultData
        {
            using (var ctx = MockContext.Start(GetType().FullName, $"GetEvents.{eventType}"))
            {
                var timespan = "PT12H";
                var top = 10;

                var client = GetClient(ctx);
                var events = multiQuery(client, timespan, top);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count > 0);
                Assert.True(events.Value.Count <= top);

                foreach (var e in events.Value)
                {
                    AssertEvent(e, eventType);
                }

                Assert.True(events.Value[0].Id.HasValue);

                var evnt = singleQuery(client, events.Value[0].Id.Value, timespan);

                Assert.NotNull(evnt);
                Assert.NotNull(evnt.Value);
                Assert.True(evnt.Value.Count == 1);

                Assert.Equal(JsonConvert.SerializeObject(evnt.Value[0]),
                    JsonConvert.SerializeObject(events.Value[0]));
            }
        }

        public delegate Task<EventsResults<T>> MultiQueryAsync<T>(ApplicationInsightsDataClient client, string timespan, int top) where T : EventsResultData;
        public delegate Task<EventsResults<T>> SingleQueryAsync<T>(ApplicationInsightsDataClient client, Guid id, string timespan) where T : EventsResultData;

        public delegate EventsResults<T> MultiQuery<T>(ApplicationInsightsDataClient client, string timespan, int top) where T : EventsResultData;
        public delegate EventsResults<T> SingleQuery<T>(ApplicationInsightsDataClient client, Guid id, string timespan) where T : EventsResultData;

        private static readonly object[] TraceParams = new object[]
        {
            EventType.Traces,
            new MultiQueryAsync<EventsTraceResult>(async (client, timespan, top) => await client.GetTraceEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsTraceResult>(async (client, id, timespan) => await client.GetTraceEventAsync(id, timespan)),
            new MultiQuery<EventsTraceResult>((client, timespan, top) => client.GetTraceEvents(timespan, top: top)),
            new SingleQuery<EventsTraceResult>((client, id, timespan) => client.GetTraceEvent(id, timespan)),
        };

        private static readonly object[] CustomEventsParams = new object[]
        {
            EventType.CustomEvents,
            new MultiQueryAsync<EventsCustomEventResult>(async (client, timespan, top) => await client.GetCustomEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsCustomEventResult>(async (client, id, timespan) => await client.GetCustomEventAsync(id, timespan)),
            new MultiQuery<EventsCustomEventResult>((client, timespan, top) => client.GetCustomEvents(timespan, top: top)),
            new SingleQuery<EventsCustomEventResult>((client, id, timespan) => client.GetCustomEvent(id, timespan)),
        };

        private static readonly object[] PageViewsParams = new object[]
        {
            EventType.PageViews,
            new MultiQueryAsync<EventsPageViewResult>(async (client, timespan, top) => await client.GetPageViewEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsPageViewResult>(async (client, id, timespan) => await client.GetPageViewEventAsync(id, timespan)),
            new MultiQuery<EventsPageViewResult>((client, timespan, top) => client.GetPageViewEvents(timespan, top: top)),
            new SingleQuery<EventsPageViewResult>((client, id, timespan) => client.GetPageViewEvent(id, timespan)),
        };

        private static readonly object[] BrowserTimingsParams = new object[]
        {
            EventType.BrowserTimings,
            new MultiQueryAsync<EventsBrowserTimingResult>(async (client, timespan, top) => await client.GetBrowserTimingEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsBrowserTimingResult>(async (client, id, timespan) => await client.GetBrowserTimingEventAsync(id, timespan)),
            new MultiQuery<EventsBrowserTimingResult>((client, timespan, top) => client.GetBrowserTimingEvents(timespan, top: top)),
            new SingleQuery<EventsBrowserTimingResult>((client, id, timespan) => client.GetBrowserTimingEvent(id, timespan)),
        };

        private static readonly object[] RequestsParams = new object[]
        {
            EventType.Requests,
            new MultiQueryAsync<EventsRequestResult>(async (client, timespan, top) => await client.GetRequestEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsRequestResult>(async (client, id, timespan) => await client.GetRequestEventAsync(id, timespan)),
            new MultiQuery<EventsRequestResult>((client, timespan, top) => client.GetRequestEvents(timespan, top: top)),
            new SingleQuery<EventsRequestResult>((client, id, timespan) => client.GetRequestEvent(id, timespan)),
        };

        private static readonly object[] DependenciesParams = new object[]
        {
            EventType.Dependencies,
            new MultiQueryAsync<EventsDependencyResult>(async (client, timespan, top) => await client.GetDependencyEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsDependencyResult>(async (client, id, timespan) => await client.GetDependencyEventAsync(id, timespan)),
            new MultiQuery<EventsDependencyResult>((client, timespan, top) => client.GetDependencyEvents(timespan, top: top)),
            new SingleQuery<EventsDependencyResult>((client, id, timespan) => client.GetDependencyEvent(id, timespan)),
        };

        private static readonly object[] ExceptionsParams = new object[]
        {
            EventType.Exceptions,
            new MultiQueryAsync<EventsExceptionResult>(async (client, timespan, top) => await client.GetExceptionEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsExceptionResult>(async (client, id, timespan) => await client.GetExceptionEventAsync(id, timespan)),
            new MultiQuery<EventsExceptionResult>((client, timespan, top) => client.GetExceptionEvents(timespan, top: top)),
            new SingleQuery<EventsExceptionResult>((client, id, timespan) => client.GetExceptionEvent(id, timespan)),
        };

        private static readonly object[] AvailabilityResultsParams = new object[]
        {
            EventType.AvailabilityResults,
            new MultiQueryAsync<EventsAvailabilityResultResult>(async (client, timespan, top) => await client.GetAvailabilityResultEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsAvailabilityResultResult>(async (client, id, timespan) => await client.GetAvailabilityResultEventAsync(id, timespan)),
            new MultiQuery<EventsAvailabilityResultResult>((client, timespan, top) => client.GetAvailabilityResultEvents(timespan, top: top)),
            new SingleQuery<EventsAvailabilityResultResult>((client, id, timespan) => client.GetAvailabilityResultEvent(id, timespan)),
        };

        private static readonly object[] PerformanceCountersParams = new object[]
        {
            EventType.PerformanceCounters,
            new MultiQueryAsync<EventsPerformanceCounterResult>(async (client, timespan, top) => await client.GetPerformanceCounterEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsPerformanceCounterResult>(async (client, id, timespan) => await client.GetPerformanceCounterEventAsync(id, timespan)),
            new MultiQuery<EventsPerformanceCounterResult>((client, timespan, top) => client.GetPerformanceCounterEvents(timespan, top: top)),
            new SingleQuery<EventsPerformanceCounterResult>((client, id, timespan) => client.GetPerformanceCounterEvent(id, timespan)),
        };

        private static readonly object[] CustomMetricsParams = new object[]
        {
            EventType.CustomMetrics,
            new MultiQueryAsync<EventsCustomMetricResult>(async (client, timespan, top) => await client.GetCustomMetricEventsAsync(timespan, top: top)),
            new SingleQueryAsync<EventsCustomMetricResult>(async (client, id, timespan) => await client.GetCustomMetricEventAsync(id, timespan)),
            new MultiQuery<EventsCustomMetricResult>((client, timespan, top) => client.GetCustomMetricEvents(timespan, top: top)),
            new SingleQuery<EventsCustomMetricResult>((client, id, timespan) => client.GetCustomMetricEvent(id, timespan)),
        };

        public static IEnumerable<object[]> TraceData { get { yield return TraceParams; } }

        public static IEnumerable<object[]> CustomEventsData { get { yield return CustomEventsParams; } }

        public static IEnumerable<object[]> PageViewsData { get { yield return PageViewsParams; } }

        public static IEnumerable<object[]> BrowserTimingsData { get { yield return BrowserTimingsParams; } }

        public static IEnumerable<object[]> RequestsData { get { yield return RequestsParams; } }

        public static IEnumerable<object[]> DependenciesData { get { yield return DependenciesParams; } }

        public static IEnumerable<object[]> ExceptionsData { get { yield return ExceptionsParams; } }

        public static IEnumerable<object[]> AvailabilityResultsData { get { yield return AvailabilityResultsParams; } }

        public static IEnumerable<object[]> PerformanceCountersData { get { yield return PerformanceCountersParams; } }

        public static IEnumerable<object[]> CustomMetricsData { get { yield return CustomMetricsParams; } }
    }
}
