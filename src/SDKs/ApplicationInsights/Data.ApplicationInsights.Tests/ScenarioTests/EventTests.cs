using Microsoft.Azure.ApplicationInsights;
using Microsoft.Azure.ApplicationInsights.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Threading.Tasks;
using Xunit;

namespace Data.ApplicationInsights.Tests
{
    public class EventTests : DataPlaneTestBase
    {
        private const int TopCount = 10;
        private const string Timespan = "P1D";

        [Fact]
        public async Task GetAllEvents()
        {
            using (var ctx = MockContext.Start(GetType().FullName))
            {
                var client = GetClient(ctx);
                var events = await client.GetEventsAsync(EventType.All, timespan: Timespan, top: TopCount);

                Assert.NotNull(events);
                Assert.NotNull(events.Value);
                Assert.True(events.Value.Count <= TopCount);

                foreach (var evnt in events.Value)
                {
                    var eventType = GetEventType(evnt);
                    if (!eventType.HasValue) continue; // This means there is a new type that we don't support here yet
                    VerifyCommon(evnt, eventType.Value);
                }
            }
        }

        [Theory]
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
        public async Task GetEventsByType(EventType eventType)
        {
            using (var ctx = MockContext.Start(GetType().FullName, $"GetEventsByType.{eventType}"))
            {
                var client = GetClient(ctx);
                var traces = await client.GetEventsAsync(eventType, timespan: Timespan, top: TopCount);

                Assert.NotNull(traces);
                Assert.NotNull(traces.Value);
                Assert.True(traces.Value.Count <= TopCount);

                var evnt = traces.Value[0];

                VerifyCommon(evnt, eventType);

                traces = await client.GetEventAsync(eventType, evnt.Id.Value);

                Assert.NotNull(traces);
                Assert.NotNull(traces.Value);
                Assert.Equal(1, traces.Value.Count);

                evnt = traces.Value[0];

                VerifyCommon(evnt, eventType);
            }
        }

        private EventType? GetEventType(EventsResultData evnt)
        {
            if (evnt is EventsTraceResult) return EventType.Traces;
            else if (evnt is EventsCustomEventResult) return EventType.CustomEvents;
            else if (evnt is EventsPageViewResult) return EventType.PageViews;
            else if (evnt is EventsBrowserTimingResult) return EventType.BrowserTimings;
            else if (evnt is EventsRequestResult) return EventType.Requests;
            else if (evnt is EventsDependencyResult) return EventType.Dependencies;
            else if (evnt is EventsExceptionResult) return EventType.Exceptions;
            else if (evnt is EventsAvailabilityResultResult) return EventType.AvailabilityResults;
            else if (evnt is EventsPerformanceCounterResult) return EventType.PerformanceCounters;
            else if (evnt is EventsCustomMetricResult) return EventType.CustomMetrics;

            return null;
        }

        private void VerifyCommon(EventsResultData evnt, EventType expectedType)
        {
            Assert.NotNull(evnt);
            Assert.NotNull(evnt.Id.Value);

            if (expectedType != EventType.PerformanceCounters && expectedType != EventType.CustomMetrics)
            {
                Assert.True(evnt.Count > 0);
            }
            
            Assert.NotNull(evnt.Timestamp);
            // CustomDimensions & CustomMeasurements can be null

            // Operation
            if (expectedType != EventType.CustomEvents && expectedType != EventType.PageViews &&
                expectedType != EventType.BrowserTimings && expectedType != EventType.AvailabilityResults &&
                expectedType != EventType.Exceptions && expectedType != EventType.CustomMetrics &&
                expectedType != EventType.PerformanceCounters)
            {
                Assert.NotNull(evnt.Operation);
                Assert.False(string.IsNullOrWhiteSpace(evnt.Operation.Id));
                Assert.False(string.IsNullOrWhiteSpace(evnt.Operation.ParentId));
                // Name & SyntheticSource can be null
            }

            // Session
            Assert.NotNull(evnt.Session);
            // Id can be null

            // User
            Assert.NotNull(evnt.User);
            // Id, AccountId & AuthenticatedId can be null

            // Cloud
            Assert.NotNull(evnt.Cloud);
            // RoleName & RoleInstance can be null

            // AI
            Assert.NotNull(evnt.Ai);
            Assert.False(string.IsNullOrWhiteSpace(evnt.Ai.IKey));
            Assert.False(string.IsNullOrWhiteSpace(evnt.Ai.AppName));
            Assert.False(string.IsNullOrWhiteSpace(evnt.Ai.AppId));
            // SdkVersion can be null

            // Application
            Assert.NotNull(evnt.Application);
            // Version can be null

            // Client
            Assert.NotNull(evnt.Client);
            Assert.False(string.IsNullOrWhiteSpace(evnt.Client.Type));
            Assert.False(string.IsNullOrWhiteSpace(evnt.Client.Ip));
            // All other client fields can be empty

            switch (expectedType)
            {
                case EventType.Traces:
                    VerifyTrace(evnt);
                    break;
                case EventType.CustomEvents:
                    VerifyCustomEvent(evnt);
                    break;
                case EventType.PageViews:
                    VerifyPageView(evnt);
                    break;
                case EventType.BrowserTimings:
                    VerifyBrowserTiming(evnt);
                    break;
                case EventType.Requests:
                    VerifyRequest(evnt);
                    break;
                case EventType.Dependencies:
                    VerifyDependency(evnt);
                    break;
                case EventType.Exceptions:
                    VerifyException(evnt);
                    break;
                case EventType.AvailabilityResults:
                    VerifyAvailabilityResult(evnt);
                    break;
                case EventType.PerformanceCounters:
                    VerifyPerformanceCounter(evnt);
                    break;
                case EventType.CustomMetrics:
                    VerifyCustomMetric(evnt);
                    break;
                default:
                    Assert.True(false, $"Don't have verification method for EventType {evnt.GetType()}");
                    break;
            }
        }

        private void VerifyTrace(EventsResultData evnt)
        {
            Assert.True(evnt is EventsTraceResult);
            var trace = evnt as EventsTraceResult;
            Assert.NotNull(trace.Trace);
            Assert.False(string.IsNullOrWhiteSpace(trace.Trace.Message));
            Assert.True(trace.Trace.SeverityLevel >= 0 && trace.Trace.SeverityLevel <= 5);
        }

        private void VerifyCustomEvent(EventsResultData evnt)
        {
            Assert.True(evnt is EventsCustomEventResult);
            var customEvent = evnt as EventsCustomEventResult;
            Assert.NotNull(customEvent.CustomEvent);
            Assert.False(string.IsNullOrWhiteSpace(customEvent.CustomEvent.Name));
        }

        private void VerifyPageView(EventsResultData evnt)
        {
            Assert.True(evnt is EventsPageViewResult);
            var pageView = evnt as EventsPageViewResult;
            Assert.NotNull(pageView.PageView);
            Assert.False(string.IsNullOrWhiteSpace(pageView.PageView.Name));
            // All other page view fields can be null
        }

        private void VerifyBrowserTiming(EventsResultData evnt)
        {
            Assert.True(evnt is EventsBrowserTimingResult);
            var browserTiming = evnt as EventsBrowserTimingResult;

            Assert.NotNull(browserTiming.BrowserTiming);
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.UrlPath));
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.UrlHost));
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.Name));
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.Url));
            Assert.True(browserTiming.BrowserTiming.TotalDuration >= 0);
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.PerformanceBucket));
            Assert.True(browserTiming.BrowserTiming.NetworkDuration >= 0);
            Assert.True(browserTiming.BrowserTiming.SendDuration >= 0);
            Assert.True(browserTiming.BrowserTiming.ReceiveDuration >= 0);
            Assert.True(browserTiming.BrowserTiming.ProcessingDuration >= 0);

            Assert.NotNull(browserTiming.ClientPerformance);
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.ClientPerformance.Name));
        }

        private void VerifyRequest(EventsResultData evnt)
        {
            Assert.True(evnt is EventsRequestResult);
            var request = evnt as EventsRequestResult;
            Assert.NotNull(request.Request);
            Assert.False(string.IsNullOrWhiteSpace(request.Request.Name));
            Assert.False(string.IsNullOrWhiteSpace(request.Request.Url));
            Assert.False(string.IsNullOrWhiteSpace(request.Request.Success));
            Assert.True(request.Request.Duration >= 0);
            Assert.False(string.IsNullOrWhiteSpace(request.Request.PerformanceBucket));
            Assert.False(string.IsNullOrWhiteSpace(request.Request.ResultCode));
            Assert.False(string.IsNullOrWhiteSpace(request.Request.Id));
            // Source can be null
        }

        private void VerifyDependency(EventsResultData evnt)
        {
            Assert.True(evnt is EventsDependencyResult);
            var dependency = evnt as EventsDependencyResult;
            Assert.NotNull(dependency.Dependency);
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Target));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Data));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Success));
            Assert.True(dependency.Dependency.Duration >=0);
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.PerformanceBucket));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Type));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Name));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Id));
            // ResultCode can be null
        }

        private void VerifyException(EventsResultData evnt)
        {
            Assert.True(evnt is EventsExceptionResult);
            var exception = evnt as EventsExceptionResult;
            Assert.NotNull(exception.Exception);
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.ProblemId));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Assembly));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Type));
            Assert.NotNull(exception.Exception.Details);
            Assert.True(exception.Exception.Details.Count >=0);
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].Id));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].OuterId));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].Type));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].Message));
            Assert.NotNull(exception.Exception.Details[0].ParsedStack);
            Assert.True(exception.Exception.Details[0].ParsedStack.Count >=0);
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].ParsedStack[0].Assembly));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].ParsedStack[0].Method));
            Assert.True(exception.Exception.Details[0].ParsedStack[0].Level >= 0);
            Assert.True(exception.Exception.Details[0].ParsedStack[0].Line>= 0);
            // SeverityLevel, HandledAt, Message, Outer* & Inner* can be null
        }

        private void VerifyAvailabilityResult(EventsResultData evnt)
        {
            Assert.True(evnt is EventsAvailabilityResultResult);
            var availabilityResult = evnt as EventsAvailabilityResultResult;
            Assert.NotNull(availabilityResult.AvailabilityResult);
            Assert.False(string.IsNullOrWhiteSpace(availabilityResult.AvailabilityResult.Name));
            Assert.False(string.IsNullOrWhiteSpace(availabilityResult.AvailabilityResult.Success));
            Assert.True(availabilityResult.AvailabilityResult.Duration >= 0);
            Assert.False(string.IsNullOrWhiteSpace(availabilityResult.AvailabilityResult.Message));
            Assert.False(string.IsNullOrWhiteSpace(availabilityResult.AvailabilityResult.Location));
            Assert.False(string.IsNullOrWhiteSpace(availabilityResult.AvailabilityResult.Id));
            // PerformanceBucket & Size can be null
        }

        private void VerifyPerformanceCounter(EventsResultData evnt)
        {
            Assert.True(evnt is EventsPerformanceCounterResult);
            var customEvent = evnt as EventsPerformanceCounterResult;
            Assert.NotNull(customEvent.PerformanceCounter);
            // Value can be any int value
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Name));
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Category));
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Counter));
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Instance));
            // InstanceName can be null
        }

        private void VerifyCustomMetric(EventsResultData evnt)
        {
            Assert.True(evnt is EventsCustomMetricResult);
            var customEvent = evnt as EventsCustomMetricResult;
            Assert.NotNull(customEvent.CustomMetric);
            Assert.False(string.IsNullOrWhiteSpace(customEvent.CustomMetric.Name));
            // The other values can be any int value
        }
    }
}
