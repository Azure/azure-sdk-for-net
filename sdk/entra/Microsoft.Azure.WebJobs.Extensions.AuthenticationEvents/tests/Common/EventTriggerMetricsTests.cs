﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;

using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
    public class EventTriggerMetricsTests
    {
        [Test]
        [Description ("Verify it does not throw if response message is null")]
        public void TestSetMetricHeadersNull()
        {
            HttpResponseMessage message = null;
            Assert.DoesNotThrow(() => EventTriggerMetrics.Instance.SetMetricHeaders(message));
            Assert.IsNull(
                anObject: message,
                message: "Verify AuthenticationEventRequestBase is not set to anything when null.");
        }

        [Test]
        [Description("Verify it sets the headers to the correct default values")]
        public  void TestSetMetricHeaders()
        {
            HttpResponseMessage message = new() { };
            EventTriggerMetrics.Instance.SetMetricHeaders(message);

            Assert.IsNotEmpty(EventTriggerMetrics.Framework, "Framework should note be empty");
            Assert.IsNotEmpty(EventTriggerMetrics.ProductVersion, "ProductVersion should not be empty");
            Assert.IsNotEmpty(EventTriggerMetrics.Platform, "Platform should not be empty");

            var headers = message.Headers;
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.MetricsHeader));
            
            string headerValue = headers.GetValues(EventTriggerMetrics.MetricsHeader).First();
            Assert.IsNotEmpty(headerValue, "Header value should not be empty or null");
        }

        [Test]
        [Description("Verify if sets the headers is in the correct format")]
        public void TestSetMetricFormat()
        {
            HttpResponseMessage message = new() { };
            EventTriggerMetrics.Instance.SetMetricHeaders(message);

            var headers = message.Headers;
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.MetricsHeader));

            string headerValue = headers.GetValues(EventTriggerMetrics.MetricsHeader).First();

            Assert.AreEqual(GetTestHeaderValue(), headerValue, "Verify format of header values matches");
        }

        [Test]
        [Description("Verify it sets the headers to the correct default values when there is already a value")]
        public void TestAppendMetricHeaders()
        {
            HttpResponseMessage message = new() { };
            message.Headers.Add(EventTriggerMetrics.MetricsHeader, "test");

            EventTriggerMetrics.Instance.SetMetricHeaders(message);

            var headers = message.Headers;
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.MetricsHeader));

            string headerValue = headers.GetValues(EventTriggerMetrics.MetricsHeader).First();
            Assert.AreEqual("test " + GetTestHeaderValue(), headerValue, "Verify default header values match");
        }

        private static string GetTestHeaderValue(
            string framework = null,
            string version = null,
            string platform = null)
        {
            framework ??= EventTriggerMetrics.Framework;
            version ??= EventTriggerMetrics.ProductVersion;
            platform ??= EventTriggerMetrics.Platform;

            return $"azsdk-net-{EventTriggerMetrics.ProductName}/{version} ({framework}; {platform.Trim()})";
        }
    }
}
