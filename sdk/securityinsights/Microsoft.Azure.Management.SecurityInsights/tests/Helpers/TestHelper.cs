using System.Net;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.SecurityInsights.Tests.Helpers
{
    internal class TestHelper
    {
        public const string ResourceGroup = "asi-sdk-tests-rg";
        public const string OperationalInsightsResourceProvider = "Microsoft.OperationalInsights";
        public const string WorkspaceName = "asi-sdk-tests-ws";
        public const string ActionLAResourceID = "/subscriptions/9023f5b5-df22-4313-8fbf-b4b75af8a6d9/resourceGroups/asi-sdk-tests-rg/providers/Microsoft.Logic/workflows/DotNetSDKTestsPlaybook";
        public const string ActionLATriggerUri = "https://prod-21.westus2.logic.azure.com:443/workflows/e26c9f2e051e40eebaba9ed9b065c491/triggers/When_Azure_Sentinel_incident_creation_rule_was_triggered/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2FWhen_Azure_Sentinel_incident_creation_rule_was_triggered%2Frun&sv=1.0&sig=6sGE8BueGEYWNZ0mY8-JYrse4mTk3obUBib9BF5PciQ";

        public static TestEnvironment TestEnvironment { get; private set; }

        public static SecurityInsights GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var SecurityInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityInsights>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityInsights>(handlers: handler);

            return SecurityInsightsClient;
        }
    }
}
