using System.Collections.Generic;
using Microsoft.Azure.ApplicationInsights.Query.Models;
using Newtonsoft.Json;
using Xunit;

namespace Data.ApplicationInsights.Tests.Events
{
    public class EventsTestBase : DataPlaneTestBase
    {
        protected string GetEventType(EventsResultData evnt)
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

        protected void AssertEvent(EventsResultData evnt, string expectedType)
        {
            Assert.NotNull(evnt);
            Assert.True(!string.IsNullOrEmpty(evnt.Id));

            if (expectedType != EventType.PerformanceCounters && expectedType != EventType.CustomMetrics)
            {
                Assert.True(evnt.Count > 0);
            }

            Assert.NotNull(evnt.Timestamp);
            // CustomDimensions & CustomMeasurements can be null
            if (evnt.CustomDimensions != null && evnt.CustomDimensions.TryGetValue("ProcessId", out var customDimensionsValue)) {
                Assert.False(string.IsNullOrWhiteSpace(customDimensionsValue));
            }
            if (evnt.CustomMeasurements != null && evnt.CustomMeasurements.TryGetValue("FirstChanceExceptions", out var customMeasurementsValue)) {
                Assert.False(string.IsNullOrWhiteSpace(customMeasurementsValue));
            }

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

        protected void VerifyTrace(EventsResultData evnt)
        {
            Assert.True(evnt is EventsTraceResult);
            var trace = evnt as EventsTraceResult;
            Assert.NotNull(trace.Trace);
            Assert.False(string.IsNullOrWhiteSpace(trace.Trace.Message));
            Assert.True(trace.Trace.SeverityLevel >= 0 && trace.Trace.SeverityLevel <= 5);
        }

        protected void VerifyCustomEvent(EventsResultData evnt)
        {
            Assert.True(evnt is EventsCustomEventResult);
            var customEvent = evnt as EventsCustomEventResult;
            Assert.NotNull(customEvent.CustomEvent);
            Assert.False(string.IsNullOrWhiteSpace(customEvent.CustomEvent.Name));
        }

        protected void VerifyPageView(EventsResultData evnt)
        {
            Assert.True(evnt is EventsPageViewResult);
            var pageView = evnt as EventsPageViewResult;
            Assert.NotNull(pageView.PageView);
            Assert.False(string.IsNullOrWhiteSpace(pageView.PageView.Name));
            // All other page view fields can be null
        }

        protected void VerifyBrowserTiming(EventsResultData evnt)
        {
            Assert.True(evnt is EventsBrowserTimingResult);
            var browserTiming = evnt as EventsBrowserTimingResult;

            Assert.NotNull(browserTiming.BrowserTiming);
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.Name));
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.Url));
            Assert.True(browserTiming.BrowserTiming.TotalDuration >= 0);
            Assert.False(string.IsNullOrWhiteSpace(browserTiming.BrowserTiming.PerformanceBucket));
            Assert.True(browserTiming.BrowserTiming.NetworkDuration >= 0);
            Assert.True(browserTiming.BrowserTiming.SendDuration >= 0);
            Assert.True(browserTiming.BrowserTiming.ReceiveDuration >= 0);
            Assert.True(browserTiming.BrowserTiming.ProcessingDuration >= 0);
        }

        protected void VerifyRequest(EventsResultData evnt)
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

        protected void VerifyDependency(EventsResultData evnt)
        {
            Assert.True(evnt is EventsDependencyResult);
            var dependency = evnt as EventsDependencyResult;
            Assert.NotNull(dependency.Dependency);
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Target));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Data));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Success));
            Assert.True(dependency.Dependency.Duration >= 0);
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.PerformanceBucket));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Type));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Name));
            Assert.False(string.IsNullOrWhiteSpace(dependency.Dependency.Id));
            // ResultCode can be null
        }

        protected void VerifyException(EventsResultData evnt)
        {
            Assert.True(evnt is EventsExceptionResult);
            var exception = evnt as EventsExceptionResult;
            Assert.NotNull(exception.Exception);
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.ProblemId));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Assembly));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Type));
            Assert.NotNull(exception.Exception.Details);
            Assert.True(exception.Exception.Details.Count >= 0);
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].Id));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].OuterId));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].Type));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].Message));
            Assert.NotNull(exception.Exception.Details[0].ParsedStack);
            Assert.True(exception.Exception.Details[0].ParsedStack.Count >= 0);
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].ParsedStack[0].Assembly));
            Assert.False(string.IsNullOrWhiteSpace(exception.Exception.Details[0].ParsedStack[0].Method));
            Assert.True(exception.Exception.Details[0].ParsedStack[0].Level >= 0);
            Assert.True(exception.Exception.Details[0].ParsedStack[0].Line >= 0);
            // SeverityLevel, HandledAt, Message, Outer* & Inner* can be null
        }

        protected void VerifyAvailabilityResult(EventsResultData evnt)
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

        protected void VerifyPerformanceCounter(EventsResultData evnt)
        {
            Assert.True(evnt is EventsPerformanceCounterResult);
            var customEvent = evnt as EventsPerformanceCounterResult;
            Assert.NotNull(customEvent.PerformanceCounter);
            // Value can be any int value
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Name));
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Category));
            Assert.False(string.IsNullOrWhiteSpace(customEvent.PerformanceCounter.Counter));
            Assert.NotNull(customEvent.PerformanceCounter.Instance);
            // InstanceName can be null
        }

        protected void VerifyCustomMetric(EventsResultData evnt)
        {
            Assert.True(evnt is EventsCustomMetricResult);
            var customEvent = evnt as EventsCustomMetricResult;
            Assert.NotNull(customEvent.CustomMetric);
            Assert.False(string.IsNullOrWhiteSpace(customEvent.CustomMetric.Name));
            // The other values can be any int value
        }
    }
}
