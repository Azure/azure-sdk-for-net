
using Microsoft.Azure.Management.Confluent.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.Confluent.Tests
{
    public class ConfluentTests
    {
        [Fact]
        public void TestResourceLifeCycle()
        {    
            {
                var context = MockContext.Start(GetType());
                string rgName = CreateName("confluent-sdk-test-rg");
                string resourceName = CreateName("confluent-sdk-test-resource8350");
              
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
            ConfluentManagementClient client = GetConfluentManagementClient(context);
            return client.Organization.Create(
                rgName,
                resourceName,
                new OrganizationResource(
                    name: resourceName,
                    type: "Microsoft.Confluent/organizations",
                    offerDetail: new OrganizationResourcePropertiesOfferDetail(publisherId: "isvtestuklegacy", id: "liftr_cf_dev", planId: "payg", planName: "Pay as you go", termUnit: "P1M"),
                    userDetail: new OrganizationResourcePropertiesUserDetail(firstName: "Srinivas", lastName: "Alluri", emailAddress: "sralluri@microsoft.com"),
                    location: "westus2"
                    )
            );
        }

        private void DeleteResource(MockContext context, string rgName, string resourceName)
        {
            ConfluentManagementClient client = GetConfluentManagementClient(context);
            client.Organization.Delete(rgName, resourceName);
        }

        private IPage<OrganizationResource> ListResources(MockContext context, string rgName)
        {
            ConfluentManagementClient client = GetConfluentManagementClient(context);
            return client.Organization.ListByResourceGroup(rgName);
        }

        private string CreateName(string prefix) => TestUtilities.GenerateName(prefix);

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private ConfluentManagementClient GetConfluentManagementClient(MockContext context)
        {
            return context.GetServiceClient<ConfluentManagementClient>();
        }
    }
}
