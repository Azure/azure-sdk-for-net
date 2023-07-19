using System;
using Microsoft.Azure.Management.StorSimple8000Series;
using System.Collections.Generic;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Xunit;
using System.Linq;
using Xunit.Abstractions;
using SSModels = Microsoft.Azure.Management.StorSimple8000Series.Models;

namespace StorSimple8000Series.Tests
{
    public class ServiceConfigurationTests : StorSimpleTestBase
    {
        public ServiceConfigurationTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestServiceConfiguration()
        {
            //check prerequisite - a device exists.
            Helpers.CheckAndGetConfiguredDevices(this, 1);

            //initialize entity names
            var sacName = "SACForTest";
            var sacAccessKey = "DummyAccessKeyForTest";
            var acrName = "ACRForTest";
            var acrInitiatorName = "iqn.2017-06.com.contoso:ForTest";
            var bwsName = "BWSForTest";

            try
            {
                //Create SAC
                var sac = CreateStorageAccountCredential(sacName, sacAccessKey);

                //Create ACR
                var acr = CreateAccessControlRecord(acrName, acrInitiatorName);

                //Create Bandwidth Setting
                var bws = CreateBandwidthSetting(bwsName);

                //delete above created entities
                DeleteStorageAccountCredentialAndValidate(sac.Name);
                DeleteAccessControlRecordAndValidate(acr.Name);
                DeleteBandwidthSettingAndValidate(bws.Name);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        /// <summary>
        /// Create storage account credential.
        /// </summary>
        public StorageAccountCredential CreateStorageAccountCredential(string sacNameWithoutDoubleEncoding, string sacAccessKeyInPlainText)
        {
            StorageAccountCredential sacToCreate = new StorageAccountCredential()
            {
                EndPoint = TestConstants.DefaultStorageAccountEndPoint,
                SslStatus = SslStatus.Enabled,
                AccessKey = this.Client.Managers.GetAsymmetricEncryptedSecret(
                    this.ResourceGroupName,
                    this.ManagerName,
                    sacAccessKeyInPlainText)
            };

            var sac = this.Client.StorageAccountCredentials.CreateOrUpdate(
                sacNameWithoutDoubleEncoding.GetDoubleEncoded(),
                sacToCreate,
                this.ResourceGroupName,
                this.ManagerName);

            Assert.True(sac != null && sac.Name.Equals(sacNameWithoutDoubleEncoding) &&
                        sac.SslStatus.Equals(SslStatus.Enabled) &&
                        sac.EndPoint.Equals(TestConstants.DefaultStorageAccountEndPoint),
                        "Creation of SAC was not successful.");

            return sac;
        }

        /// <summary>
        /// Creates Access control record.
        /// </summary>
        public AccessControlRecord CreateAccessControlRecord(string acrNameWithoutDoubleEncoding, string initiatorName)
        {
            var acrToCreate = new AccessControlRecord()
            {
                InitiatorName = initiatorName
            };

            var acr = this.Client.AccessControlRecords.CreateOrUpdate(
                acrNameWithoutDoubleEncoding.GetDoubleEncoded(),
                acrToCreate,
                ResourceGroupName,
                ManagerName);


            Assert.True(acr != null && acr.Name.Equals(acrNameWithoutDoubleEncoding) &&
                acr.InitiatorName.Equals(initiatorName),
                "Creation of ACR was not successful.");

            return acr;
        }

        /// <summary>
        /// Creates bandwidth setting.
        /// </summary>
        public BandwidthSetting CreateBandwidthSetting(string bwsName)
        {
            //bandwidth schedule
            var rateInMbps = 10;
            var days = new List<SSModels.DayOfWeek?>() { SSModels.DayOfWeek.Saturday, SSModels.DayOfWeek.Sunday };
            var bandwidthSchedule1 = new BandwidthSchedule()
            {
                Start = new Time(10, 0, 0),
                Stop = new Time(20, 0, 0),
                RateInMbps = rateInMbps,
                Days = days
            };

            //bandwidth Setting
            var bwsToCreate = new BandwidthSetting()
            {
                Schedules = new List<BandwidthSchedule>() { bandwidthSchedule1 }
            };

            var bws = this.Client.BandwidthSettings.CreateOrUpdate(
                bwsName.GetDoubleEncoded(),
                bwsToCreate,
                this.ResourceGroupName,
                this.ManagerName);

            //validation
            Assert.True(bws != null && bws.Name.Equals(bwsName) &&
                        bws.Schedules != null && bws.Schedules.Count != 0, "Creation of Bandwidth Setting was not successful.");

            return bws;
        }

        /// <summary>
        /// Deletes and validates deletion of the specified storage account credential.
        /// </summary>
        public void DeleteStorageAccountCredentialAndValidate(string storageAccountCredentialName)
        {
            var sacToDelete = this.Client.StorageAccountCredentials.Get(
                storageAccountCredentialName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            this.Client.StorageAccountCredentials.Delete(
                sacToDelete.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var storageAccountCredentials = this.Client.StorageAccountCredentials.ListByManager(
                this.ResourceGroupName,
                this.ManagerName);

            var sac = storageAccountCredentials.FirstOrDefault(s => s.Name.Equals(sacToDelete.Name));

            Assert.True(sac == null, "Deletion of storage account credential was not successful.");
        }

        /// <summary>
        /// Deletes and validates deletion of the specified access control record.
        /// </summary>
        public void DeleteAccessControlRecordAndValidate(string acrName)
        {
            var acrToDelete = this.Client.AccessControlRecords.Get(
                acrName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            this.Client.AccessControlRecords.Delete(
                acrToDelete.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var accessControlRecords = this.Client.AccessControlRecords.ListByManager(
                this.ResourceGroupName,
                this.ManagerName);

            var acr = accessControlRecords.FirstOrDefault(a => a.Name.Equals(acrToDelete.Name));

            Assert.True(acr == null, "Access control record deletion was not successful.");
        }

        /// <summary>
        /// Deletes and validates deletion of the specified bandwidth setting.
        /// </summary>
        public void DeleteBandwidthSettingAndValidate(string bwsName)
        {
            var bwsToDelete = this.Client.BandwidthSettings.Get(
                bwsName.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            this.Client.BandwidthSettings.Delete(
                bwsToDelete.Name.GetDoubleEncoded(),
                this.ResourceGroupName,
                this.ManagerName);

            var bandwidthSettings = this.Client.BandwidthSettings.ListByManager(
                this.ResourceGroupName,
                this.ManagerName);

            var bws = bandwidthSettings.FirstOrDefault(b => b.Name.Equals(bwsToDelete.Name));

            Assert.True(bws == null, "Bandwidth setting deletion was not successful.");
        }
    }
}

