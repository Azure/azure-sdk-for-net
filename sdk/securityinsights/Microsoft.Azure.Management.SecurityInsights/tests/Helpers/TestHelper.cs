using System.Net;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System;

namespace Microsoft.Azure.Management.SecurityInsights.Tests.Helpers
{
    internal class TestHelper
    {
        public const string ResourceGroup = "aspstestdqxnul";
        public const string OperationalInsightsResourceProvider = "Microsoft.OperationalInsights";
        public const string WorkspaceName = "asptestltb1a4";
        public const string ActionLAResourceID = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/aspstestdqxnul/providers/Microsoft.Logic/workflows/Block-AADUser-Incident";
        public const string ActionLATriggerUri = "https://prod-13.centralus.logic.azure.com:443/workflows/6f7e6a2b44c944d38bc05a8555d9cfac/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=m3QgR_GOY29-AFc-2MaP987Nca_9zlfdXB8DEhrfLxA";

        public static TestEnvironment TestEnvironment { get; private set; }

        public static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var SecurityInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityInsightsClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityInsightsClient>(handlers: handler);

            return SecurityInsightsClient;
        }
    }
}
