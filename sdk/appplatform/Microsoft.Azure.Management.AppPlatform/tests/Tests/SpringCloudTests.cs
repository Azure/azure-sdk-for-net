
using Microsoft.Azure.Management.AppPlatform.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.AppPlatform.Tests.Tests
{
    public class SpringCloudTests
    {
        [Fact]
        public void TestServiceLifeCycle()
        {
            using (var context = MockContext.Start(GetType()))
            {
                string rgName = CreateName("appplatform-sdk-test-rg");
                string serviceName = CreateName("appplatform-sdk-test-asc");
                string appName = CreateName("appplatform-sdk-test-app");

                CreateResourceGroup(context, rgName);
                ServiceResource service = CreateService(context, rgName, serviceName);
                Assert.NotNull(service);

                DeleteService(context, rgName, serviceName);
                AssertNoService(context, rgName);

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
                    Location = "eastus"
                });
        }

        private void DeleteResourceGroup(MockContext context, String rgName)
        {
            ResourceManagementClient client = GetResourceManagementClient(context);
            client.ResourceGroups.Delete(rgName);
        }

        private ServiceResource CreateService(MockContext context, string rgName, string serviceName)
        {
            AppPlatformManagementClient client = GetSpringManagementClient(context);
            return client.Services.CreateOrUpdate(
                rgName,
                serviceName,
                new ServiceResource(type: "Microsoft.AppPlatform/Spring", location: "eastus")
            );
        }

        private void DeleteService(MockContext context, string rgName, string serviceName)
        {
            AppPlatformManagementClient client = GetSpringManagementClient(context);
            client.Services.Delete(rgName, serviceName);
        }

        private void AssertNoService(MockContext context, string rgName)
        {
            IPage<ServiceResource> services = ListServices(context, rgName);
            Assert.Null(services.GetEnumerator().Current);
        }

        private IPage<ServiceResource> ListServices(MockContext context, string rgName)
        {
            AppPlatformManagementClient client = GetSpringManagementClient(context);
            return client.Services.List(rgName);
        }

        private String CreateName(String prefix) => TestUtilities.GenerateName(prefix);

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        private AppPlatformManagementClient GetSpringManagementClient(MockContext context)
        {
            return context.GetServiceClient<AppPlatformManagementClient>();
        }
    }
}
