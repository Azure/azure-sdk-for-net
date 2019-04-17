// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System.Linq;
    using Microsoft.Azure.ServiceBus.Diagnostics;
    using Xunit;

    public class ExtractActivityTests
    {
        [Fact]
        [DisplayTestMethodName]
        void ValidIdAndContextAreExtracted()
        {
            var message = new Message();
            message.UserProperties["Diagnostic-Id"] = "diagnostic-id";
            message.UserProperties["Correlation-Context"] = "k1=v1";

            var activity = message.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);
            
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Single(baggage);
            Assert.Contains("k1", baggage.Keys);
            Assert.Equal("v1", baggage["k1"]);
        }

        [Fact]
        [DisplayTestMethodName]
        void ValidIdAndMultipleContextAreExtracted()
        {
            var message = new Message();
            message.UserProperties["Diagnostic-Id"] = "diagnostic-id";
            message.UserProperties["Correlation-Context"] = "k1=v1,k2=v2,k3=v3";

            var activity = message.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);

            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Equal(3, baggage.Count);
            Assert.Contains("k1", baggage.Keys);
            Assert.Contains("k2", baggage.Keys);
            Assert.Contains("k3", baggage.Keys);
            Assert.Equal("v1", baggage["k1"]);
            Assert.Equal("v2", baggage["k2"]);
            Assert.Equal("v3", baggage["k3"]);
        }

        [Fact]
        [DisplayTestMethodName]
        void ActivityNameCouldBeChanged()
        {
            var message = new Message();
            message.UserProperties["Diagnostic-Id"] = "diagnostic-id";

            var activity = message.ExtractActivity("My activity");

            Assert.Equal("My activity", activity.OperationName);
        }

        [Fact]
        [DisplayTestMethodName]
        void ValidIdAndNoContextAreExtracted()
        {
            var message = new Message();
            message.UserProperties["Diagnostic-Id"] = "diagnostic-id";

            var activity = message.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Empty(baggage);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("not valid context")]
        [InlineData("not,valid,context")]
        [DisplayTestMethodName]
        void ValidIdAndInvalidContextAreExtracted(string context)
        {
            var message = new Message();
            message.UserProperties["Diagnostic-Id"] = "diagnostic-id";
            message.UserProperties["Correlation-Context"] = context;

            var activity = message.ExtractActivity();

            Assert.Equal("diagnostic-id", activity.ParentId);
            Assert.Equal("diagnostic-id", activity.RootId);
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Assert.Empty(baggage);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [DisplayTestMethodName]
        void EmptyIdResultsInActivityWithoutParent(string id)
        {
            var message = new Message();
            message.UserProperties["Diagnostic-Id"] = id;
            message.UserProperties["Correlation-Context"] = "k1=v1,k2=v2";

            var activity = message.ExtractActivity();

            Assert.Null(activity.ParentId);
            Assert.Null(activity.RootId);
            Assert.Null(activity.Id);

            var baggage = activity.Baggage.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            // baggage is ignored in absence of Id
            Assert.Empty(baggage);
        }
    }
}
