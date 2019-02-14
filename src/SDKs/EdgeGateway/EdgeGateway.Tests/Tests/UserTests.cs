using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;

namespace EdgeGateway.Tests
{
    public class UserTests : EdgeGatewayTestBase
    {
        #region Constructor
        public UserTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_UserManagement()
        {
            // Create the encrypted password for the user
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName,  "Password1", TestConstants.ActivationKey);
            User user = new User() { EncryptedPassword = encryptedSecret };

            // Create user.
            Client.Users.CreateOrUpdate(TestConstants.GatewayResourceName, "user1", user, TestConstants.DefaultResourceGroupName);
            Client.Users.CreateOrUpdate(TestConstants.GatewayResourceName, "user2", user, TestConstants.DefaultResourceGroupName);

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
