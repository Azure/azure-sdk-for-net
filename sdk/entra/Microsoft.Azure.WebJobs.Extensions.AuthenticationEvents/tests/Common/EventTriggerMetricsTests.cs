// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Linq;
using System.Net.Http;

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
            Assert.DoesNotThrow(() => EventTriggerMetrics.SetMetricHeaders(message));
            Assert.IsNull(message, "Verify AuthenticationEventRequestBase is not set to anything when null.");
        }

        [Test]
        [Description("Verify it sets the headers to the correct default values")]
        public  void TestSetMetricHeaders()
        {
            HttpResponseMessage message = new() { };
            EventTriggerMetrics.SetMetricHeaders(message);

            var headers = message.Headers;
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.HeaderKeys.Platform));
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.HeaderKeys.ProductVersion));
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.HeaderKeys.Runtime));

            Assert.AreEqual("windows", headers.GetValues(EventTriggerMetrics.HeaderKeys.Platform).First(), "Verify the platform");
            Assert.AreEqual("1.0.0.0", headers.GetValues(EventTriggerMetrics.HeaderKeys.ProductVersion).First(), "Verify the version. Needs to be updated when version is updated.");
            Assert.AreEqual(".NET", headers.GetValues(EventTriggerMetrics.HeaderKeys.Runtime).First(), "Verify the runtime.");
        }

        [Test]
        [Description("Verify it sets the headers to the correct custom override values")]
        public void TestSetMetricHeadersOverride()
        {
            HttpResponseMessage message = new() { };

            EventTriggerMetrics.Platform = "linux";
            EventTriggerMetrics.ProductVersion = "10.0.0";
            EventTriggerMetrics.RunTime = "JS";

            EventTriggerMetrics.SetMetricHeaders(message);

            var headers = message.Headers;

            Assert.IsTrue(headers.Contains(EventTriggerMetrics.HeaderKeys.Platform));
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.HeaderKeys.ProductVersion));
            Assert.IsTrue(headers.Contains(EventTriggerMetrics.HeaderKeys.Runtime));

            Assert.AreEqual("linux", headers.GetValues(EventTriggerMetrics.HeaderKeys.Platform).First(), "Verify the platform");
            Assert.AreEqual("10.0.0", headers.GetValues(EventTriggerMetrics.HeaderKeys.ProductVersion).First(), "Verify the version. Needs to be updated when version is updated.");
            Assert.AreEqual("JS", headers.GetValues(EventTriggerMetrics.HeaderKeys.Runtime).First(), "Verify the runtime.");
        }
    }
}
