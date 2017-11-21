using System.Net;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ProvisioningServices.Tests.Helpers;

namespace ProvisioningServices.Tests
{
    public class DeviceProvisioningTestBase : TestBase
    {
        protected IotDpsClient provisioningClient;
        protected ResourceManagementClient resourcesClient;
        protected ResourceGroup resourceGroup;
        protected TestEnvironment testEnv;

        protected bool initialized = false;
        protected object locker = new object();
        

        protected void Initialize(MockContext context)
        {
            if (!initialized)
            {
                lock (locker)
                {
                    if (!initialized)
                    {
                        testEnv = TestEnvironmentFactory.GetTestEnvironment();
                        resourcesClient = GetClient<ResourceManagementClient>(context);
                        provisioningClient = GetClient<IotDpsClient>(context);
                        resourceGroup = this.GetResourceGroup();
                    }
                }
            }
        }

        protected T GetClient<T>(MockContext context, RecordedDelegatingHandler handler = null) where T:class 
        {
            if (handler == null)
            {
                handler = new RecordedDelegatingHandler
                {
                    StatusCodeToReturn = HttpStatusCode.OK,
                    IsPassThrough = true
                };
            }
            var client = context.GetServiceClient<T>(handlers: handler);
            return client;
        }

        protected ResourceGroup GetResourceGroup(string resourceGroupName = null, string resourceGroupLocation = null)
        {
            if (string.IsNullOrEmpty(resourceGroupName))
            {
                resourceGroupName = Constants.DefaultResourceGroupName;
            }

            if (string.IsNullOrEmpty(resourceGroupLocation))
            {
                resourceGroupLocation = Constants.DefaultLocation;
            }

            return this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup {Location = resourceGroupLocation});
        }
    }
}
