using System.Net;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using DeviceProvisioningServices.Tests.Helpers;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningTestBase : TestBase
    {
        protected IotDpsClient provisioningClient;
        protected ResourceManagementClient resourcesClient;
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
                    }
                    initialized = true;
                }
            }
        }

        protected ProvisioningServiceDescription GetService(string serviceName, string resourceGroupName)
        {
            var availabilityInfo =
                this.provisioningClient.IotDpsResource.CheckProvisioningServiceNameAvailability(new OperationInputs(serviceName));
            if (!availabilityInfo.NameAvailable ?? true)
            {
                this.provisioningClient.IotDpsResource.Get(serviceName,
                    resourceGroupName);
            }
            var createServiceDescription = new ProvisioningServiceDescription(Constants.DefaultLocation,
                new IotDpsPropertiesDescription(),
                new IotDpsSkuInfo(Constants.DefaultSku.Name,
                Constants.DefaultSku.Tier,
                Constants.DefaultSku.Capacity
            ));

            return this.provisioningClient.IotDpsResource.CreateOrUpdate(
                resourceGroupName,
                serviceName, createServiceDescription);
        }

        protected T GetClient<T>(MockContext context, RecordedDelegatingHandler handler = null) where T : class
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

        protected ResourceGroup GetResourceGroup(string resourceGroupName, string resourceGroupLocation = null)
        {

            if (string.IsNullOrEmpty(resourceGroupLocation))
            {
                resourceGroupLocation = Constants.DefaultLocation;
            }

            return this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup { Location = resourceGroupLocation });
        }
    }
}

