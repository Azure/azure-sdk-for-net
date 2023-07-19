using DeviceProvisioningServices.Tests.Helpers;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using System.Threading.Tasks;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningTestBase : TestBase
    {
        protected IotDpsClient _provisioningClient;
        protected ResourceManagementClient _resourcesClient;
        protected TestEnvironment _testEnv;

        protected bool _isInitialized = false;
        protected object _initLock = new object();

        protected void Initialize(MockContext context)
        {
            if (!_isInitialized)
            {
                lock (_initLock)
                {
                    if (!_isInitialized)
                    {
                        _testEnv = TestEnvironmentFactory.GetTestEnvironment();
                        _resourcesClient = GetClient<ResourceManagementClient>(context);
                        _provisioningClient = GetClient<IotDpsClient>(context);
                    }
                    _isInitialized = true;
                }
            }
        }

        protected async Task<ProvisioningServiceDescription> GetServiceAsync(string resourceGroupName, string serviceName)
        {
            NameAvailabilityInfo availabilityInfo = await _provisioningClient.IotDpsResource
                .CheckProvisioningServiceNameAvailabilityAsync(serviceName)
                .ConfigureAwait(false);
            if (availabilityInfo.NameAvailable.HasValue && !availabilityInfo.NameAvailable.Value)
            {
                _provisioningClient.IotDpsResource.Get(serviceName, resourceGroupName);
            }

            var createServiceDescription = new ProvisioningServiceDescription(
                Constants.DefaultLocation,
                new IotDpsPropertiesDescription(),
                new IotDpsSkuInfo(
                    Constants.DefaultSku.Name,
                    Constants.DefaultSku.Tier,
                    Constants.DefaultSku.Capacity));

            return await _provisioningClient.IotDpsResource
                .CreateOrUpdateAsync(
                    resourceGroupName,
                    serviceName,
                    createServiceDescription)
                .ConfigureAwait(false);
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
            return context.GetServiceClient<T>(handlers: handler);
        }

        protected Task<ResourceGroup> GetResourceGroupAsync(string resourceGroupName, string resourceGroupLocation = null)
        {
            if (string.IsNullOrEmpty(resourceGroupLocation))
            {
                resourceGroupLocation = Constants.DefaultLocation;
            }

            return _resourcesClient.ResourceGroups.CreateOrUpdateAsync(
                resourceGroupName,
                new ResourceGroup { Location = resourceGroupLocation });
        }
    }
}

