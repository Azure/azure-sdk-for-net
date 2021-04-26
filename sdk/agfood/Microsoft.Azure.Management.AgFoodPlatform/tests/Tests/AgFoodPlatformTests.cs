
using Microsoft.Azure.Management.AgFoodPlatform.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.AgFoodPlatform.Tests
{
    public class AgFoodPlatformTests
    {
        [Fact]
        public void TestResourceLifeCycle()
        {    
            {
                var context = MockContext.Start(GetType());
                string rgName = CreateName("agFoodPlatform-sdk-test-rg");
                string resourceName = CreateName("agFoodPlatform-sdk-test-resource8350");
              
                CreateResourceGroup(context, rgName);
                OrganizationResource rp = CreateResource(context, rgName, resourceName);
                Assert.NotNull(rp);

                // DeleteResource(context, rgName, resourceName);
                DeleteResourceGroup(context, rgName);
            }
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

        private void DeleteResourceGroup(MockContext context, string rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            client.ResourceGroups.Delete(rgName);
        }

        private OrganizationResource CreateResource(MockContext context, string rgName, string resourceName)
        {
            AgFoodPlatformManagementClient client = GetAgFoodPlatformManagementClient(context);
            return client.Organization.Create(
                rgName,
                resourceName,
                new OrganizationResource(
                    name: resourceName,
                    type: "Microsoft.AgFoodPlatform/organizations",
                    offerDetail: new OrganizationResourcePropertiesOfferDetail(publisherId: "isvtestuklegacy", id: "liftr_cf_dev", planId: "payg", planName: "Pay as you go", termUnit: "P1M"),
                    userDetail: new OrganizationResourcePropertiesUserDetail(firstName: "Srinivas", lastName: "Alluri", emailAddress: "sralluri@microsoft.com"),
                    location: "westus2"
                    )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            AgFoodPlatformManagementClient client = GetAgFoodPlatformManagementClient(context);
            client.Organization.Delete(rgName, resourceName);
        }

        private IPage<OrganizationResource> ListResources(MockContext context, string rgName)
        {
            AgFoodPlatformManagementClient client = GetAgFoodPlatformManagementClient(context);
            return client.Organization.ListByResourceGroup(rgName);
        }

        private string CreateName(string prefix) => TestUtilities.GenerateName(prefix);

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private AgFoodPlatformManagementClient GetAgFoodPlatformManagementClient(MockContext context)
        {
            return context.GetServiceClient<AgFoodPlatformManagementClient>();
        }
    }
}
