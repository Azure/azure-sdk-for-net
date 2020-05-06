using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for share APIs
    /// </summary>
    public class ShareTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test share APIs
        /// </summary>
        public ShareTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests share management APIs
        /// </summary>
        [Fact]
        public void Test_ShareOperations()
        {
            string userId = null;
            string sacId = null;
            // Get the user details
            var user = Client.Users.Get(TestConstants.GatewayResourceName, "user1", TestConstants.DefaultResourceGroupName);
            if (user != null)
            {
                userId = user.Id;
            }

            // Get SAC details
            var sac = Client.StorageAccountCredentials.Get(TestConstants.GatewayResourceName, "sac1", TestConstants.DefaultResourceGroupName);
            if (sac != null)
            {
                sacId = sac.Id;
            }

            // Get SMB share object
            Share smbShare = TestUtilities.GetSMBShareObject(sacId, userId);

            // Create SMB share 
            Client.Shares.CreateOrUpdate(TestConstants.GatewayResourceName, "smb1", smbShare, TestConstants.DefaultResourceGroupName);

            // Get NFS share object
            Share nfsShare = TestUtilities.GetNFSShareObject(sacId, "10.150.76.81");

            // Create NFS share 
            Client.Shares.CreateOrUpdate(TestConstants.GatewayResourceName, "nfs1", nfsShare, TestConstants.DefaultResourceGroupName);

            // Get share by name
            var share = Client.Shares.Get(TestConstants.GatewayResourceName, "smb1", TestConstants.DefaultResourceGroupName);

            // List shares in the device
            string continuationToken = null;
            var shares = TestUtilities.ListShares(Client, TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            if (continuationToken != null)
            {
                shares.ToList().AddRange(TestUtilities.ListSharesNext(Client, continuationToken, out continuationToken));
            }

            // Refresh a share
            // Client.Shares.Refresh(TestConstants.GatewayResourceName, "smb1", TestConstants.DefaultResourceGroupName);

            // Delete a share
            Client.Shares.Delete(TestConstants.GatewayResourceName, "smb1", TestConstants.DefaultResourceGroupName);

        }

        /// <summary>
        /// Tests share refresh API
        /// </summary>
        [Fact]
        public void Test_RefreshShare()
        {
          

            // Refresh a share
            Client.Shares.Refresh(TestConstants.GatewayResourceName, "nfs1", TestConstants.DefaultResourceGroupName);

        }
        #endregion Test Methods

    }
}

