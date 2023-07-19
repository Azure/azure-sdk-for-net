using Microsoft.Azure.Management.DataBoxEdge.Models;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.DataBoxEdge;
using System.Linq;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for role APIs
    /// </summary>
    public class RoleTests : DataBoxEdgeTestBase
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
            AsymmetricEncryptedSecret iotDevicesecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "IotDeviceConnectionString", TestConstants.EdgeDeviceCIK);
            AsymmetricEncryptedSecret iotEdgeDevicesecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "IotEdgeDeviceConnectionString", TestConstants.EdgeDeviceCIK);

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

            // Create iot role again as we want to persist it for further testing
            Client.Roles.CreateOrUpdate(TestConstants.EdgeResourceName, "iot-1", iotRole, TestConstants.DefaultResourceGroupName);

        }

        [Fact]
        public void Test_K8Roles()
        {
            var k8RoleObj = TestUtilities.GetK8RoleObject("k8role1");

            var role = Client.Roles.CreateOrUpdate(TestConstants.EdgeResourceName, k8RoleObj.Name, k8RoleObj, TestConstants.DefaultResourceGroupName);

            // Get an iot role by name
            Client.Roles.Get(TestConstants.EdgeResourceName, k8RoleObj.Name, TestConstants.DefaultResourceGroupName);

            // List iot Roles in the device
            string continuationToken = null;
            TestUtilities.ListRoles(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            // Delete iot role
            Client.Roles.Delete(TestConstants.EdgeResourceName, k8RoleObj.Name, TestConstants.DefaultResourceGroupName);

        }

        #endregion Test Methods

    }
}

