using System.Linq;
using DeviceProvisioningServices.Tests.Helpers;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientAllocationPolicyTests : DeviceProvisioningTestBase
    {
        [Fact]
        public void Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var testName = "unitTestingUpdateAllocationPolicyGet";
                this.Initialize(context);
                var resourceGroup = this.GetResourceGroup(testName);
                var testedService = GetService(testName, resourceGroup.Name);

                
                Assert.Contains(Constants.AllocationPolicies, x => x.Equals(testedService.Properties.AllocationPolicy));
            }
        }
        [Fact]
        public void Update()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var testName = "unitTestingDPSAllocationPolicyUpdate";
                this.Initialize(context);
                var resourceGroup = this.GetResourceGroup(testName);
                var testedService = GetService(testName, testName);

                //get a different Allocation policy
                var newAllocationPolicy = Constants.AllocationPolicies
                    .Except(new[] { testedService.Properties.AllocationPolicy }).First();

                var attempts = Constants.ArmAttemptLimit;
                while (attempts > 0 && testedService.Properties.AllocationPolicy != newAllocationPolicy)
                {
                    testedService.Properties.AllocationPolicy = newAllocationPolicy;
                    try
                    {
                        var updatedInstance =
                            this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, testName,
                                testedService);
                        Assert.Equal(newAllocationPolicy, updatedInstance.Properties.AllocationPolicy);

                        testedService.Properties.AllocationPolicy = updatedInstance.Properties.AllocationPolicy;
                    }
                    catch
                    {
                        //Let ARM finish
                        System.Threading.Thread.Sleep(Constants.ArmAttemptWaitMS);

                        attempts--;
                    }
                }
            }
        }
        
    }
}
