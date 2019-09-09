namespace StorSimple1200Series.Tests
{
    using System;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    using Microsoft.Azure.Management.StorSimple1200Series;
    using Microsoft.Azure.Management.StorSimple1200Series.Models;

    /// <summary>
    /// Class represents StorageAccountCredential(SAC) and 
    /// AccessControlRecord(ACR) tests
    /// </summary>
    public class ServiceConfigurationTests : StorSimpleTestBase
    {
        #region Constructor

        public ServiceConfigurationTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Test method to create/update/delete SAC and ACR
        /// </summary>
        [Fact]
        public void TestServiceConfiguration()
        {
            try
            {
                //Check if atleast a device is registered to the manager.
                var devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.ReadyToSetup, 1);

                if (devices == null || devices.Count() < 1)
                {
                    devices = Helpers.CheckAndGetDevicesByStatus(this, DeviceStatus.Online, 1);
                }

                Assert.True(devices != null && devices.FirstOrDefault() != null,
                        "No devices were found to be registered in the manger:" + this.ManagerName);

                //Create SAC
                var sacToCreate = new StorageAccountCredential(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    "Dummy" + TestConstants.DefaultSacName);

                sacToCreate.Initialize();
                var sac = sacToCreate.CreateOrUpdate();

                //Create ACR
                var acrToCreate = new AccessControlRecord(
                    this.Client,
                    this.ResourceGroupName,
                    this.ManagerName,
                    TestConstants.DefaultAcrName);
                acrToCreate.Initialize();
                var acr = acrToCreate.CreateOrUpdate();

                //delete above created entities
                sac.Delete();
                acr.Delete();
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        #endregion Test Methods
    }
}

