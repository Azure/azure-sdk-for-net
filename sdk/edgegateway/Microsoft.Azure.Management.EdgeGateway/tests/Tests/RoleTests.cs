using Microsoft.Azure.Management.EdgeGateway.Models;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeGateway;
using System.Linq;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for role APIs
    /// </summary>
    public class RoleTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to thes role APIs
        /// </summary>
        public RoleTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests IoT role management APIs
        /// </summary>
        [Fact]
        public void Test_IoTRoles()
        {
            AsymmetricEncryptedSecret iotDevicesecret = Client.Devices.GetAsymmetricEncryptedSecretUsingActivationKey(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "IotDeviceConnectionString", TestConstants.EdgeDeviceActivationKey);
            AsymmetricEncryptedSecret iotEdgeDevicesecret = Client.Devices.GetAsymmetricEncryptedSecretUsingActivationKey(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "IotEdgeDeviceConnectionString", TestConstants.EdgeDeviceActivationKey);

            var iotRole = TestUtilities.GetIoTRoleObject(iotDevicesecret, iotEdgeDevicesecret);

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

