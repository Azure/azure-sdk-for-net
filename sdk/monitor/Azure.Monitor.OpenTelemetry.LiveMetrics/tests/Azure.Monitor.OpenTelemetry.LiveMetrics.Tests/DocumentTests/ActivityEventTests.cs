// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class ActivityEventTests : DocumentTestBase
    {
        public ActivityEventTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void VerifyActivityWithExceptions()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            // TODO: Replace this ActivityListener with an OpenTelemetry provider.
            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var activity = activitySource.StartActivity(name: "HelloWorld");
            Assert.NotNull(activity);

            try
            {
                throw new System.Exception("Test exception");
            }
            catch (System.Exception ex)
            {
                activity.SetStatus(ActivityStatusCode.Error);
                activity.RecordException(ex, new TagList
                {
                    { "someKey", "someValue" },
                });
            }

            var exceptionDocument = DocumentHelper.ConvertToExceptionDocument(activity.Events.First());

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.Exception, exceptionDocument.DocumentType);
            Assert.Equal(typeof(System.Exception).FullName, exceptionDocument.ExceptionType);
            Assert.Equal("Test exception", exceptionDocument.ExceptionMessage);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            // These properties are not used for Exception and should be default values.
            Assert.Equal(default, exceptionDocument.Extension_Duration);
            Assert.False(exceptionDocument.Extension_IsSuccess);
        }

        [Fact]
        public void VerifyActivityWithLogs()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);
            // TODO: Replace this ActivityListener with an OpenTelemetry provider.
            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var activity = activitySource.StartActivity(name: "HelloWorld");
            Assert.NotNull(activity);

            activity.AddEvent(new ActivityEvent("This is a log message"));

            var logDocument = DocumentHelper.ConvertToLogDocument(activity.Events.First());

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.Trace, logDocument.DocumentType);
            Assert.Equal("This is a log message", logDocument.Message);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            // These properties are not used for Exception and should be default values.
            Assert.Equal(default, logDocument.Extension_Duration);
            Assert.False(logDocument.Extension_IsSuccess);
        }
    }
}
