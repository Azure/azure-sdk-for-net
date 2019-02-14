using Microsoft.Azure.Management.EdgeGateway.Models;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeGateway;
using System.Linq;

namespace EdgeGateway.Tests
{
    public class RoleTests : EdgeGatewayTestBase
    {
        #region Constructor
        public RoleTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_IoTRoles()
        {
            AsymmetricEncryptedSecret iotDevicesecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "IotDeviceConnectionString", TestConstants.EdgeDeviceActivationKey);
            AsymmetricEncryptedSecret iotEdgeDevicesecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "IotEdgeDeviceConnectionString", TestConstants.EdgeDeviceActivationKey);

            var iotRole = TestUtilities.GetIoTRole(iotDevicesecret, iotEdgeDevicesecret);

            // Create an iot role
            Client.Roles.CreateOrUpdate(TestConstants.EdgeResourceName, "iot-1", iotRole, TestConstants.DefaultResourceGroupName);

            // Get an iot role by name
            Client.Roles.Get(TestConstants.EdgeResourceName, "iot-1", TestConstants.DefaultResourceGroupName);

            // List iot Roles in the device
            string continuationToken = null;
            TestUtilities.ListRoles(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            // Delete iot role
            Client.Roles.Delete(TestConstants.EdgeResourceName, "iot-1", TestConstants.DefaultResourceGroupName);
        }

        #endregion Test Methods

    }
}
