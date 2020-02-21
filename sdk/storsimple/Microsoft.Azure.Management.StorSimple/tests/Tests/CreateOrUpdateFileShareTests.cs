namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    
    /// <summary>
    /// Class represents tests for fileshare
    /// </summary>
    public class CreateOrUpdateFileShareTests : StorSimpleTestBase
    {
        #region Construtor
        public CreateOrUpdateFileShareTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion #region Construtor

        #region Test methods

        /// <summary>
        /// Test method to create, update and delete filshare
        /// </summary>
        [Fact]
        public void TestCreateOrUpdateFileShare()
        {
            try
            {
                var fileServers = TestUtilities.GetFileServers(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName);

                Assert.True(
                    fileServers != null && fileServers.Any(),
                    $"No fileservers were found in the manger {this.ManagerName}");

                // Select the first fileserver
                var fileServer = fileServers.First();

                // Create a FileShare with Tiered data policy
                var fileShare = new FileShare(
                    this.Client, 
                    this.ResourceGroupName, 
                    this.ManagerName,
                    "Auto-TestFileShare1");
                fileShare.Initialize(DataPolicy.Tiered);

                var fileShareCreated = fileShare.CreateOrUpdate(
                    fileServer.Name,
                    fileServer.Name);

                // Create a FileShare with Local data policy
                var fileShare2 = new FileShare(
                    this.Client, 
                    this.ResourceGroupName, 
                    this.ManagerName, 
                    "Auto-TestFileShare2");
                fileShare2.Initialize(DataPolicy.Local);
                
                var fileShareCreated2 = fileShare2.CreateOrUpdate(
                    fileServer.Name,
                    fileServer.Name);

                // Update Description and ShareStatus
                fileShareCreated.Description = "Updated: " + fileShareCreated.Description;
                fileShareCreated.ShareStatus = ShareStatus.Offline;
                fileShareCreated = fileShareCreated.CreateOrUpdate(
                    fileServer.Name,
                    fileServer.Name);

                // Validate FileShares by Managers
                var fileSharesByFileServer = this.Client.FileShares.ListByFileServer(
                    fileServer.Name,
                    fileServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);

                var fileSharesByDevice = this.Client.FileShares.ListByDevice(
                    fileServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
            #endregion Test methods
        }
    }
}
