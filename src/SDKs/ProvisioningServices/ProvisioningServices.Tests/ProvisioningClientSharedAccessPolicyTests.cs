using System.Linq;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
namespace ProvisioningServices.Tests
{
    public class ProvisioningClientSharedAccessPolicyTests : DeviceProvisioningTestBase
    {
        [Fact]
        public void Get()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);
                var testName = "unitTestingDPSSharedAccessKeys";
                this.GetResourceGroup(testName);
                var testedService = GetService(testName, testName);

                //verify owner has been created
                var ownerKey = this.provisioningClient.IotDpsResource.GetKeysForKeyName(
                    testedService.Name,
                    Constants.AccessKeyName, testName);
                Assert.Equal(Constants.AccessKeyName, ownerKey.KeyName);

            }
        }
    }
}