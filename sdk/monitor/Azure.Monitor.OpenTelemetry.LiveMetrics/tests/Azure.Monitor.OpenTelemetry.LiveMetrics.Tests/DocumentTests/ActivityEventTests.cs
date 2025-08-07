// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
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
            using var listener = new ActivityListener
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
                activity.AddException(ex, new TagList
                {
                    {"customKey1", "customValue1"},
                    {"customKey2", "customValue2"},
                    {"customKey3", "customValue3"},
                    {"customKey4", "customValue4"},
                    {"customKey5", "customValue5"},
                    {"customKey6", "customValue6"},
                    {"customKey7", "customValue7"},
                    {"customKey8", "customValue8"},
                    {"customKey9", "customValue9"},
                    {"customKey10", "customValue10"},
                    {"customKey11", "customValue11"},
                });
            }

            var exceptionDocument = DocumentHelper.ConvertToExceptionDocument(activity.Events.First());

            // ASSERT
            Assert.Equal(DocumentType.Exception, exceptionDocument.DocumentType);
            Assert.Equal(typeof(System.Exception).FullName, exceptionDocument.ExceptionType);
            Assert.Equal("Test exception", exceptionDocument.ExceptionMessage);

            VerifyCustomProperties(exceptionDocument);

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
            using var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);

            // ACT
            using var activity = activitySource.StartActivity(name: "HelloWorld");
            Assert.NotNull(activity);

            activity.AddEvent(new ActivityEvent("This is a log message", tags: new ActivityTagsCollection( new[]{
                    new KeyValuePair<string, object?>("customKey1", "customValue1"),
                    new KeyValuePair<string, object?>("customKey2", "customValue2"),
                    new KeyValuePair<string, object?>("customKey3", "customValue3"),
                    new KeyValuePair<string, object?>("customKey4", "customValue4"),
                    new KeyValuePair<string, object?>("customKey5", "customValue5"),
                    new KeyValuePair<string, object?>("customKey6", "customValue6"),
                    new KeyValuePair<string, object?>("customKey7", "customValue7"),
                    new KeyValuePair<string, object?>("customKey8", "customValue8"),
                    new KeyValuePair<string, object?>("customKey9", "customValue9"),
                    new KeyValuePair<string, object?>("customKey10", "customValue10"),
                    new KeyValuePair<string, object?>("customKey11", "customValue11"),
                })));

            var logDocument = DocumentHelper.ConvertToLogDocument(activity.Events.First());

            // ASSERT
            Assert.Equal(DocumentType.Trace, logDocument.DocumentType);
            Assert.Equal("This is a log message", logDocument.Message);

            VerifyCustomProperties(logDocument);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            // These properties are not used for Exception and should be default values.
            Assert.Equal(default, logDocument.Extension_Duration);
            Assert.False(logDocument.Extension_IsSuccess);
        }
    }
}
