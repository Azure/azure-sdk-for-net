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
        [TestCase("test", new string[] { "foo" }, "test")]
        [TestCase("", new string[] { "foo" }, "foo")]
        public void UserAgentOverride(string userAgentOverride, string[] customHeaders, string expect)
        {
            var requestMock = new MockRequest();
            var message = new HttpMessage(requestMock, new ResponseClassifier());
            if (!string.IsNullOrEmpty(userAgentOverride))
            {
                message.SetProperty("UserAgentOverride", userAgentOverride);
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
