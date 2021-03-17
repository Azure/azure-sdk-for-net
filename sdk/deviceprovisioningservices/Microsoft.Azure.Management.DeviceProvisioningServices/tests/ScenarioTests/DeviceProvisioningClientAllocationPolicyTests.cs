using DeviceProvisioningServices.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientAllocationPolicyTests : DeviceProvisioningTestBase
    {
        [Fact]
        public async Task Get()
        {
            using var context = MockContext.Start(GetType());
            var testName = "unitTestingUpdateAllocationPolicyGet";
            Initialize(context);
            ResourceGroup resourceGroup = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription testedService = await GetServiceAsync(resourceGroup.Name, testName).ConfigureAwait(false);

            Constants.AllocationPolicies.Should().Contain(testedService.Properties.AllocationPolicy);
        }

        [Fact]
        public async Task Update()
        {
            using var context = MockContext.Start(GetType());
            var testName = "unitTestingDPSAllocationPolicyUpdate";
            Initialize(context);
            ResourceGroup resourceGroup = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription testedService = await GetServiceAsync(testName, testName).ConfigureAwait(false);

            // get a different allocation policy
            var newAllocationPolicy = Constants.AllocationPolicies
                .Except(new[] { testedService.Properties.AllocationPolicy })
                .First();

            int attempts = Constants.ArmAttemptLimit;
            while (attempts > 0
                && testedService.Properties.AllocationPolicy != newAllocationPolicy)
            {
                testedService.Properties.AllocationPolicy = newAllocationPolicy;
                try
                {
                    var updatedInstance = await _provisioningClient.IotDpsResource
                        .CreateOrUpdateAsync(
                            resourceGroup.Name,
                            testName,
                            testedService)
                        .ConfigureAwait(false);
                    newAllocationPolicy.Should().Be(updatedInstance.Properties.AllocationPolicy);

                    testedService.Properties.AllocationPolicy = updatedInstance.Properties.AllocationPolicy;
                }
                catch
                {
                    // Let ARM finish
                    await Task.Delay(Constants.ArmAttemptWaitMs).ConfigureAwait(false);

                    attempts--;
                }
            }
        }
    }
}
