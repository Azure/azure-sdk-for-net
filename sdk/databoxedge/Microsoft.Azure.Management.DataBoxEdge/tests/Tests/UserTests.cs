using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for user operations
    /// </summary>
    public class UserTests : DataBoxEdgeTestBase
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
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "Password1", TestConstants.EdgeDeviceCIK);
            User user = new User() { EncryptedPassword = encryptedSecret, UserType = UserType.Share };

            // Create user.
            Client.Users.CreateOrUpdate(TestConstants.EdgeResourceName, "user1", user, TestConstants.DefaultResourceGroupName);
            Client.Users.CreateOrUpdate(TestConstants.EdgeResourceName, "user2", user, TestConstants.DefaultResourceGroupName);

            // Get user by name
            var retrievedUser = Client.Users.Get(TestConstants.EdgeResourceName, "user1", TestConstants.DefaultResourceGroupName);

            // List users in the device
            string continuationToken = null;
            var usersInDevice = TestUtilities.ListUsers(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);
            if (continuationToken != null)
            {
                usersInDevice.ToList().AddRange(TestUtilities.ListUsers(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken));
            }

            // Delete user
            Client.Users.Delete(TestConstants.EdgeResourceName, "user2", TestConstants.DefaultResourceGroupName);

        }

        /// <summary>
        /// Tests user management APIs
        /// </summary>
        [Fact]
        public void Test_ARMUserPasswordUpdate()
        {
            // Get user by name
            var retrievedUser = Client.Users.Get(TestConstants.EdgeResourceName, TestConstants.ARMLiteUserName, TestConstants.DefaultResourceGroupName);

            // Create the encrypted password for the user
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "Password1", TestConstants.EdgeDeviceCIK);
            retrievedUser.EncryptedPassword = encryptedSecret;

            // Create user.
            Client.Users.CreateOrUpdate(TestConstants.EdgeResourceName, TestConstants.ARMLiteUserName, retrievedUser, TestConstants.DefaultResourceGroupName);
        }
        #endregion Test Methods
    }
}

