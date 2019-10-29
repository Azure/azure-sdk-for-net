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
    public class DeleteFileShareTests : StorSimpleTestBase
    {
        #region Construtor
        public DeleteFileShareTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion #region Construtor

        #region Test methods

        /// <summary>
        /// Test method to create, update and delete filshare
        /// </summary>
        [Fact]
        public void TestDeleteFileShare()
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

                var fileSharesByDevice = this.Client.FileShares.ListByDevice(
                    fileServer.Name,
                    this.ResourceGroupName,
                    this.ManagerName);

                // Delete Fileshares
                foreach (var fileShare in fileSharesByDevice)
                {
                    TestUtilities.DeleteAndValidateFileShare(
                        this.Client,
                        this.ResourceGroupName,
                        this.ManagerName,
                        fileShare.Name,
                        fileServer.Name,
                        fileServer.Name);
                }
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
            #endregion Test methods
        }
    }
}
