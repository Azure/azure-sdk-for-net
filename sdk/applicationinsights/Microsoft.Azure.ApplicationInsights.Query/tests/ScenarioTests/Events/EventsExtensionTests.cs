using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.ApplicationInsights.Tests.Events;
using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Xunit;

namespace Data.ApplicationInsights.Tests.ScenarioTests.Events
{
    public class EventsExtensionTests : EventsTestBase
    {
        [Theory]
        [MemberData(nameof(TraceDataAsync))]
        [MemberData(nameof(CustomEventsDataAsync))]
        [MemberData(nameof(PageViewsDataAsync))]
        [MemberData(nameof(BrowserTimingsDataAsync))]
        [MemberData(nameof(RequestsDataAsync))]
        [MemberData(nameof(DependenciesDataAsync))]
        [MemberData(nameof(ExceptionsDataAsync))]
        [MemberData(nameof(AvailabilityResultsDataAsync))]
        [MemberData(nameof(PerformanceCountersDataAsync))]
        [MemberData(nameof(CustomMetricsDataAsync))]
        public async Task GetEventsAsync<T>(string eventType, MultiQueryAsync<T> multiQueryAsync, SingleQueryAsync<T> singleQueryAsync) where T : EventsResultData
        {
            using (var ctx = MockContext.Start(this.GetType(), $"GetByTypeAsync.{eventType}"))
            {
                var timespan = "P1D";
                var top = 1;

                var client = GetClient(ctx);
                var events = await multiQueryAsync(client, timespan, top);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count >= 0);
                Assert.True(events.Value.Count <= top);

                foreach (var e in events.Value)
                {
                    AssertEvent(e, eventType);
                }

                Assert.True(!string.IsNullOrEmpty(events.Value[0].Id));

                var evnt = await singleQueryAsync(client, events.Value[0].Id, timespan);

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
        public void GetByType<T>(string eventType, MultiQuery<T> multiQuery, SingleQuery<T> singleQuery) where T : EventsResultData
        {
            using (var ctx = MockContext.Start(this.GetType(), $"GetByType.{eventType}"))
            {
                var timespan = "P1D";
                var top = 10;

                var client = GetClient(ctx);
                var events = multiQuery(client, timespan, top);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count >= 0);
                Assert.True(events.Value.Count <= top);

                foreach (var e in events.Value)
                {
                    AssertEvent(e, eventType);
                }

                Assert.True(!string.IsNullOrEmpty(events.Value[0].Id));

                var evnt = singleQuery(client, events.Value[0].Id, timespan);

                Assert.NotNull(evnt);
                Assert.NotNull(evnt.Value);
                Assert.True(evnt.Value.Count == 1);

                Assert.Equal(JsonConvert.SerializeObject(evnt.Value[0]),
                    JsonConvert.SerializeObject(events.Value[0]));
            }
        }

        public delegate Task<EventsResults<T>> MultiQueryAsync<T>(ApplicationInsightsDataClient client, string timespan, int top) where T : EventsResultData;
        public delegate Task<EventsResults<T>> SingleQueryAsync<T>(ApplicationInsightsDataClient client, string id, string timespan) where T : EventsResultData;

        public delegate EventsResults<T> MultiQuery<T>(ApplicationInsightsDataClient client, string timespan, int top) where T : EventsResultData;
        public delegate EventsResults<T> SingleQuery<T>(ApplicationInsightsDataClient client, string id, string timespan) where T : EventsResultData;

        private static readonly object[] TraceParamsAsync = new object[]
        {
            EventType.Traces,
            new MultiQueryAsync<EventsTraceResult>(async (client, timespan, top) => await client.Events.GetTraceEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsTraceResult>(async (client, id, timespan) => await client.Events.GetTraceEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] CustomEventsParamsAsync = new object[]
        {
            EventType.CustomEvents,
            new MultiQueryAsync<EventsCustomEventResult>(async (client, timespan, top) => await client.Events.GetCustomEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsCustomEventResult>(async (client, id, timespan) => await client.Events.GetCustomEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] PageViewsParamsAsync = new object[]
        {
            EventType.PageViews,
            new MultiQueryAsync<EventsPageViewResult>(async (client, timespan, top) => await client.Events.GetPageViewEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsPageViewResult>(async (client, id, timespan) => await client.Events.GetPageViewEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] BrowserTimingsParamsAsync = new object[]
        {
            EventType.BrowserTimings,
            new MultiQueryAsync<EventsBrowserTimingResult>(async (client, timespan, top) => await client.Events.GetBrowserTimingEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsBrowserTimingResult>(async (client, id, timespan) => await client.Events.GetBrowserTimingEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] RequestsParamsAsync = new object[]
        {
            EventType.Requests,
            new MultiQueryAsync<EventsRequestResult>(async (client, timespan, top) => await client.Events.GetRequestEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsRequestResult>(async (client, id, timespan) => await client.Events.GetRequestEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] DependenciesParamsAsync = new object[]
        {
            EventType.Dependencies,
            new MultiQueryAsync<EventsDependencyResult>(async (client, timespan, top) => await client.Events.GetDependencyEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsDependencyResult>(async (client, id, timespan) => await client.Events.GetDependencyEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] ExceptionsParamsAsync = new object[]
        {
            EventType.Exceptions,
            new MultiQueryAsync<EventsExceptionResult>(async (client, timespan, top) => await client.Events.GetExceptionEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsExceptionResult>(async (client, id, timespan) => await client.Events.GetExceptionEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] AvailabilityResultsParamsAsync = new object[]
        {
            EventType.AvailabilityResults,
            new MultiQueryAsync<EventsAvailabilityResultResult>(async (client, timespan, top) => await client.Events.GetAvailabilityResultEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsAvailabilityResultResult>(async (client, id, timespan) => await client.Events.GetAvailabilityResultEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] PerformanceCountersParamsAsync = new object[]
        {
            EventType.PerformanceCounters,
            new MultiQueryAsync<EventsPerformanceCounterResult>(async (client, timespan, top) => await client.Events.GetPerformanceCounterEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsPerformanceCounterResult>(async (client, id, timespan) => await client.Events.GetPerformanceCounterEventAsync(DefaultAppId, id, timespan)),
        };

        private static readonly object[] CustomMetricsParamsAsync = new object[]
        {
            EventType.CustomMetrics,
            new MultiQueryAsync<EventsCustomMetricResult>(async (client, timespan, top) => await client.Events.GetCustomMetricEventsAsync(DefaultAppId, timespan, top: top)),
            new SingleQueryAsync<EventsCustomMetricResult>(async (client, id, timespan) => await client.Events.GetCustomMetricEventAsync(DefaultAppId, id, timespan)),
        };
        
        private static readonly object[] TraceParams = new object[]
        {
            EventType.Traces,
            new MultiQuery<EventsTraceResult>((client, timespan, top) => client.Events.GetTraceEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsTraceResult>((client, id, timespan) => client.Events.GetTraceEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] CustomEventsParams = new object[]
        {
            EventType.CustomEvents,
            new MultiQuery<EventsCustomEventResult>((client, timespan, top) => client.Events.GetCustomEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsCustomEventResult>((client, id, timespan) => client.Events.GetCustomEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] PageViewsParams = new object[]
        {
            EventType.PageViews,
            new MultiQuery<EventsPageViewResult>((client, timespan, top) => client.Events.GetPageViewEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsPageViewResult>((client, id, timespan) => client.Events.GetPageViewEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] BrowserTimingsParams = new object[]
        {
            EventType.BrowserTimings,
            new MultiQuery<EventsBrowserTimingResult>((client, timespan, top) => client.Events.GetBrowserTimingEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsBrowserTimingResult>((client, id, timespan) => client.Events.GetBrowserTimingEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] RequestsParams = new object[]
        {
            EventType.Requests,
            new MultiQuery<EventsRequestResult>((client, timespan, top) => client.Events.GetRequestEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsRequestResult>((client, id, timespan) => client.Events.GetRequestEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] DependenciesParams = new object[]
        {
            EventType.Dependencies,
            new MultiQuery<EventsDependencyResult>((client, timespan, top) => client.Events.GetDependencyEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsDependencyResult>((client, id, timespan) => client.Events.GetDependencyEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] ExceptionsParams = new object[]
        {
            EventType.Exceptions,
            new MultiQuery<EventsExceptionResult>((client, timespan, top) => client.Events.GetExceptionEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsExceptionResult>((client, id, timespan) => client.Events.GetExceptionEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] AvailabilityResultsParams = new object[]
        {
            EventType.AvailabilityResults,
            new MultiQuery<EventsAvailabilityResultResult>((client, timespan, top) => client.Events.GetAvailabilityResultEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsAvailabilityResultResult>((client, id, timespan) => client.Events.GetAvailabilityResultEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] PerformanceCountersParams = new object[]
        {
            EventType.PerformanceCounters,
            new MultiQuery<EventsPerformanceCounterResult>((client, timespan, top) => client.Events.GetPerformanceCounterEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsPerformanceCounterResult>((client, id, timespan) => client.Events.GetPerformanceCounterEvent(DefaultAppId, id, timespan)),
        };

        private static readonly object[] CustomMetricsParams = new object[]
        {
            EventType.CustomMetrics,
            new MultiQuery<EventsCustomMetricResult>((client, timespan, top) => client.Events.GetCustomMetricEvents(DefaultAppId, timespan, top: top)),
            new SingleQuery<EventsCustomMetricResult>((client, id, timespan) => client.Events.GetCustomMetricEvent(DefaultAppId, id, timespan)),
        };

        public static IEnumerable<object[]> TraceDataAsync { get { yield return TraceParamsAsync; } }

        public static IEnumerable<object[]> CustomEventsDataAsync { get { yield return CustomEventsParamsAsync; } }

        public static IEnumerable<object[]> PageViewsDataAsync { get { yield return PageViewsParamsAsync; } }

        public static IEnumerable<object[]> BrowserTimingsDataAsync { get { yield return BrowserTimingsParamsAsync; } }

        public static IEnumerable<object[]> RequestsDataAsync { get { yield return RequestsParamsAsync; } }

        public static IEnumerable<object[]> DependenciesDataAsync { get { yield return DependenciesParamsAsync; } }

        public static IEnumerable<object[]> ExceptionsDataAsync { get { yield return ExceptionsParamsAsync; } }

        public static IEnumerable<object[]> AvailabilityResultsDataAsync { get { yield return AvailabilityResultsParamsAsync; } }

        public static IEnumerable<object[]> PerformanceCountersDataAsync { get { yield return PerformanceCountersParamsAsync; } }

        public static IEnumerable<object[]> CustomMetricsDataAsync { get { yield return CustomMetricsParamsAsync; } }

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
