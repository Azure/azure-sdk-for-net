namespace StorSimple1200Series.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series.Models;
    using System.Linq;

    /// <summary>
    /// Class represents Manager tests
    /// </summary>
    public class ManagerTests : StorSimpleTestBase
    {
        #region Constructor
        public ManagerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test methods

        /// <summary>
        /// Test method to create manager
        /// </summary>
        [Fact]
        public void TestManager()
        {
            try
            {
                this.ManagerName = string.Empty;

                //Create StorSimple Manager
                var manager = new Manager(
                    this.Client,
                    this.ResourceGroupName,
                    TestConstants.ManagerForManagerOperationTests);
                manager.Initialize();
                manager = manager.CreateOrUpdate(this.Client, this.ResourceGroupName);

                //Update tag for Storsimple Manager
                manager.Tags = new Dictionary<string, string>();
                manager.Tags.Add("TagName", "Demo manager for SDK test");
                manager = manager.CreateOrUpdate(this.Client, this.ResourceGroupName);

                //List all StorSimple managers in subscription
                var managersInSubscriptions = TestUtilities.ListManagerBySubscription(this.Client);

                //List all StorSimple managers in resourceGroup
                var managersInResourceGroup = TestUtilities.ListManagerByResourceGroup(
                    this.Client,
                    this.ResourceGroupName);

                // Generate the Key from the portal and proceed with execution
                //Get and update ExtendedInfo
                var updatedExtendedInfo = manager.GetAndUpdateExtendedInfo(
                    this.Client,
                    this.ResourceGroupName);

                //Delete ExtendedInfo
                manager.DeleteExtendedInfo(this.Client, this.ResourceGroupName);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }


        /// <summary>
        /// Test to delete a given manager and any device
        /// </summary>
        [Fact]
        public void TestDeleteManager()
        {
            var manager = TestUtilities.GetManager(
                this.Client,
                this.ResourceGroupName,
                TestConstants.ManagerForDeleteOperation);

            var devices = manager.ListDevices(this.Client, this.ResourceGroupName);

            Assert.True(devices != null && devices.Any() && devices.Count() == 1, 
                "No devices were found in the given manager:" + manager.Name);

            var device = devices.First();

            // Deactivate and delete device
            TestUtilities.DeactivateDevice(this.Client, this.ResourceGroupName, manager.Name, device.Name);
            TestUtilities.DeleteDevice(this.Client, this.ResourceGroupName, manager.Name, device.Name);

            //Delete StorSimple Manager and validate deletion
            manager.Delete(this.Client, this.ResourceGroupName);
        }

        #endregion Test methods
    }
}
