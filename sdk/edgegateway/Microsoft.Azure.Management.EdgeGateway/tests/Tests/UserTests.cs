using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for user operations
    /// </summary>
    public class UserTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Initializes an instance to test user operations
        /// </summary>
        public UserTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests user management APIs
        /// </summary>
        [Fact]
        public void Test_UserManagement()
        {
            // Create the encrypted password for the user
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecretUsingActivationKey(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, "Password1", TestConstants.GatewayActivationKey);
            User user = new User() { EncryptedPassword = encryptedSecret };

            // Create user.
            Client.Users.CreateOrUpdate(TestConstants.GatewayResourceName, "user1", TestConstants.DefaultResourceGroupName, encryptedSecret);
            Client.Users.CreateOrUpdate(TestConstants.GatewayResourceName, "user2", TestConstants.DefaultResourceGroupName, encryptedSecret);

            // Get user by name
            var retrievedUser = Client.Users.Get(TestConstants.GatewayResourceName, "user1", TestConstants.DefaultResourceGroupName);

            // List users in the device
            string continuationToken = null;
            var usersInDevice = TestUtilities.ListUsers(Client, TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);
            if (continuationToken != null)
            {
                usersInDevice.ToList().AddRange(TestUtilities.ListUsers(Client, TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, out continuationToken));
            }

            // Delete user
            Client.Users.Delete(TestConstants.GatewayResourceName, "user2", TestConstants.DefaultResourceGroupName);

        }

        #endregion Test Methods


    }
}

