using Microsoft.Azure.ApplicationInsights.Query;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace Data.ApplicationInsights.Tests
{
    public abstract class DataPlaneTestBase
    {
        protected const string DefaultAppId = "DEMO_APP";
        protected const string DefaultApiKey = "DEMO_KEY";

        protected ApplicationInsightsDataClient GetClient(MockContext ctx, string appId = DefaultAppId, string apiKey = DefaultApiKey)
        {
            var credentials = new ApiKeyClientCredentials(apiKey);
            var client = new ApplicationInsightsDataClient(credentials, HttpMockServer.CreateInstance());
            client.BaseUri = new Uri("https://api.applicationinsights.io/v1");

            return client;
        }
    }
}
