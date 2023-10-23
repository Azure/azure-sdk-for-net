// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            Assert.DoesNotThrow(() => new EventTriggerMetrics().SetMetricHeaders(message));
            Assert.IsNull(
                anObject: message,
                message: "Verify AuthenticationEventRequestBase is not set to anything when null.");
        }

        [Test]
        [Description("Verify it sets the headers to the correct default values")]
        public  void TestSetMetricHeaders()
        {
            HttpResponseMessage message = new() { };
            new EventTriggerMetrics().SetMetricHeaders(message);

            var headers = message.Headers;
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.MetricsHeader));
            
            string headerValue = headers.GetValues(EventTriggerMetrics.MetricsHeader).First();
            Assert.AreEqual(GetTestHeaderValue(), headerValue, "Verify default header values match");
        }

        [Test]
        [Description("Verify it sets the headers to the correct default values when there is already a value")]
        public void TestAppendMetricHeaders()
        {
            HttpResponseMessage message = new() { };
            message.Headers.Add(EventTriggerMetrics.MetricsHeader, "test");

            new EventTriggerMetrics().SetMetricHeaders(message);

            var headers = message.Headers;
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.MetricsHeader));

            string headerValue = headers.GetValues(EventTriggerMetrics.MetricsHeader).First();
            Assert.AreEqual("test " + GetTestHeaderValue(), headerValue, "Verify default header values match");
        }

        private static string GetTestHeaderValue(
            string framework = ".NETStandard,Version=v2.0",
            string version = "1.0.0.0",
            string platform = "Microsoft Windows 10.0.22621")
        {
            return $"azsdk-net-{EventTriggerMetrics.ProductName}/{version} ({framework}; {platform})";
        }
    }
}
