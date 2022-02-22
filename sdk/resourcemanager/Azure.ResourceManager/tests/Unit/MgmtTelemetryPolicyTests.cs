// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Tests
{
    public class MgmtTelemetryPolicyTests
    {
        [TestCase("test", new string[] { }, "test")]
        [TestCase("test", new string[] { "foo" }, "test foo")]
        [TestCase("test", new string[] { "foo", "bar" }, "test foo bar")]
        // default header pattern: azsdk-net-ResourceManager.Tests/1.0.0-alpha.20220124.1 (.NET Framework 4.8.4420.0; Microsoft Windows 10.0.19043 )
        [TestCase("", new string[] { }, "azsdk-net-ResourceManager.Tests\\/[a-zA-Z0-9.\\-]+ \\(.*\\)")]
        [TestCase("", new string[] { "foo" }, "azsdk-net-ResourceManager.Tests\\/[a-zA-Z0-9.\\-]+ \\(.*\\) foo")]
        [TestCase("", new string[] { "foo", "bar" }, "azsdk-net-ResourceManager.Tests\\/[a-zA-Z0-9.\\-]+ \\(.*\\) foo bar")]
        public void UserAgentOverride(string userAgentOverride, string[] customHeaders, string expect)
        {
            var requestMock = new MockRequest();
            var message = new HttpMessage(requestMock, new ResponseClassifier());
            if (!string.IsNullOrEmpty(userAgentOverride))
            {
                message.SetProperty("SDKUserAgent", userAgentOverride);
            }
            if (customHeaders.Length > 0)
            {
                foreach (var header in customHeaders)
                {
                    requestMock.Headers.Add(HttpHeader.Names.UserAgent, header);
                }
            }

            var policy = new MgmtTelemetryPolicy(this, ClientOptions.Default);

            policy.OnSendingRequest(message);

            string actual;
            Assert.IsTrue(requestMock.Headers.TryGetValue(HttpHeader.Names.UserAgent, out actual));
            Assert.That(actual, Does.Match(expect));

            IEnumerable<string> actualValues;
            Assert.IsTrue(requestMock.Headers.TryGetValues(HttpHeader.Names.UserAgent, out actualValues));
            Assert.That(actualValues.ToArray(), Has.Length.EqualTo(1));
        }
    }
}
