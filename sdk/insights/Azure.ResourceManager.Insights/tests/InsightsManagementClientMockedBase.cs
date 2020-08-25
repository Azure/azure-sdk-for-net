// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.Insights.Tests
{
    public class InsightsManagementClientMockedBase : InsightsManagementClientBase
    {
        protected InsightsManagementClientMockedBase(bool isAsync) : base(isAsync, RecordedTestMode.Live) { }

        protected InsightsManagementClient GetInsightsManagementClient(string expectedResponse)
        {
            var options = new InsightsManagementClientOptions();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(Encoding.UTF8.GetBytes(expectedResponse));
            var transport = new MockTransport(mockResponse);
            options.Transport = transport;
            return new InsightsManagementClient(TestEnvironment.SubscriptionId, new DefaultAzureCredential(), options);
        }
    }
}
