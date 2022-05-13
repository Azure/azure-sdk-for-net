using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Dynatrace;
using Microsoft.Azure.Management.Dynatrace.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Dynatrace.Tests.Tests
{
    public class DynatraceTest
    {

        [Fact]
        public void TestResourceLifeCycle()
        {

            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("dynatrace-sdk-test-rg");
                string resourceName = CreateName("dynatrace-sdk-test-resource");

                CreateResourceGroup(context, rgName);
                MonitorResource rp = CreateResource(context, rgName, resourceName);
                Assert.NotNull(rp);
            }
        }

        private MonitorResource CreateResource(MockContext context, string rgName, string resourceName)
        {
            DynatraceObservabilityClient client = GetDynatraceObservabilityClient(context);
            return client.Monitors.CreateOrUpdate(
                rgName,
                resourceName,
                new MonitorResource(
                    name: resourceName,
                    type: "Dynatrace.Observability/monitors",
                    location: "eastus",
                    userInfo: new UserInfo
                    {
                        FirstName = "Divyansh",
                        LastName = "Agarwal",
                        PhoneNumber = "1234567890",
                        Country = "US",
                        EmailAddress = "agarwald@microsoft.com"
                    },
                    planData: new PlanData
                    {
                        UsageType = "COMMITTED",
                        BillingCycle = "Monthly",
                        PlanDetails = "azureportalintegration_privatepreview",
                        EffectiveDate = System.DateTime.Now
                    },
                    dynatraceEnvironmentProperties: new DynatraceEnvironmentProperties
                    {
                        SingleSignOnProperties = new DynatraceSingleSignOnProperties
                        {
                            AadDomains = new List<string>()
                        }
                    }
                )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            DynatraceObservabilityClient client = GetDynatraceObservabilityClient(context);
            client.Monitors.Delete(rgName, resourceName);
        }


        private ResourceGroup CreateResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            return client.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = "westus2"
                });
        }

        private string CreateName(string prefix) => TestUtilities.GenerateName(prefix);

        private void DeleteResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            client.ResourceGroups.Delete(rgName);
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private DynatraceObservabilityClient GetDynatraceObservabilityClient(MockContext context)
        {
            return context.GetServiceClient<DynatraceObservabilityClient>();
        }

    }
}
