// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OracleDatabase.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OracleDatabase.Tests.Models
{
    [TestFixture]
    public class ExaScaleTest : OracleDatabaseManagementTestBase
    {
        private ResourceIdentifier _vnetId;
        private ResourceIdentifier _subnetId;
        private string _displayName;
        private int _enabledEcpuCount;
        private ResourceIdentifier _exascaleDBStorageVaultId;
        private string _hostname;
        private int _nodeCount;
        private string _shape;
        private List<string> _sshPublicKeys;
        private int _totalEcpuCount;
        private ExadbVmClusterStorageDetails _vmFileSystemStorage;
        private ExadbVmClusterCollection _exadbVmClusterCollection;
        private string _exadbVmClusterName;
        private static ExadbVmClusterResource _exadbVmClusterResource;

        private const string DefaultSSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDAIdCVcZiGBSybKTvFBfrfVhYWRImneQB9ovsU/GYqPLyDpXkpdGusYc5OL6zHq27uKtJ+//0wCoENJmvBjiRMUWMKZ4NcUkxVWj+ipJTFDO1t3KRkpDCLQEBEihOaNHHN9j2ZggUxOQBgCIwjjH+B+6Z1KpvpmvDhbMhmmZJ6R4yJI+fE80SFCV0G5sZuq38W+eK6FQRNINCmayWLNYw8sk1cBzqxMTo7OeVRxjyfQYRS1o+sC1CkxT7BYw30qY/xzR45yxkRZ5FkugPR5MQ1NApRPGNOuZD1MRwcG1AZ5JfiX9ckz5xaKjfm0hhfwh/qT7mH6fXiX7nAmkvLxu6Xnzy3aign4e99QSWPkpjJ0X1gluLzR7/gwYMjA6sfflRNe/FP937kJTIa1F5BonWe9eS580IXoTUNaiAanOEf5fBdji4JEDk7nXKV7kTECkCX9ZDWwB8q/ayIXwmNMCgxCpdx2F6UWOGvF5UWJkyD3BxTgMOiPwxMMEvCGIIdaGU= generated-by-azure";

        public ExaScaleTest() : base(true, RecordedTestMode.Playback)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }

            _vnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName));
            _subnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName));
            _displayName = "TestExadbVmCluster";
            _enabledEcpuCount = 8;
            _exascaleDBStorageVaultId = new ResourceIdentifier($"/subscriptions/{DefaultSubscription.Data.Id}/resourceGroups/{DefaultResourceGroupName}/providers/Microsoft.OracleDatabase/exadbStorageVaults/test-vault");
            _hostname = "test-exadb-hostname";
            _nodeCount = 3;
            _shape = "EXADBXS";
            _sshPublicKeys = new List<string> { DefaultSSHKey };
            _totalEcpuCount = 16;
            _vmFileSystemStorage = new ExadbVmClusterStorageDetails(1024);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        public void Constructor_WithRequiredParameters_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var properties = new ExadbVmClusterProperties(
                _vnetId,
                _subnetId,
                _displayName,
                _enabledEcpuCount,
                _exascaleDBStorageVaultId,
                _hostname,
                _nodeCount,
                _shape,
                _sshPublicKeys,
                _totalEcpuCount,
                _vmFileSystemStorage);

            // Assert
            Assert.AreEqual(_vnetId, properties.VnetId);
            Assert.AreEqual(_subnetId, properties.SubnetId);
            Assert.AreEqual(_displayName, properties.DisplayName);
            Assert.AreEqual(_enabledEcpuCount, properties.EnabledEcpuCount);
            Assert.AreEqual(_exascaleDBStorageVaultId, properties.ExascaleDBStorageVaultId);
            Assert.AreEqual(_hostname, properties.Hostname);
            Assert.AreEqual(_nodeCount, properties.NodeCount);
            Assert.AreEqual(_shape, properties.Shape);
            CollectionAssert.AreEqual(_sshPublicKeys, properties.SshPublicKeys);
            Assert.AreEqual(_totalEcpuCount, properties.TotalEcpuCount);
            Assert.AreEqual(_vmFileSystemStorage.TotalSizeInGbs, properties.VmFileSystemStorageTotalSizeInGbs);
            Assert.IsNotNull(properties.NsgCidrs);
            Assert.IsEmpty(properties.NsgCidrs);
            Assert.IsNotNull(properties.ScanIPIds);
            Assert.IsEmpty(properties.ScanIPIds);
            Assert.IsNotNull(properties.VipIds);
            Assert.IsEmpty(properties.VipIds);
        }

        public void Constructor_SetOptionalProperties_SetsPropertiesCorrectly()
        {
            // Arrange
            string domain = "example.com";
            OracleLicenseModel licenseModel = OracleLicenseModel.LicenseIncluded;
            string systemVersion = "19.0.0.0";
            string timeZone = "UTC";
            int scanListenerPortTcp = 1521;
            int scanListenerPortTcpSsl = 2484;

            // Act
            var properties = new ExadbVmClusterProperties(
                _vnetId,
                _subnetId,
                _displayName,
                _enabledEcpuCount,
                _exascaleDBStorageVaultId,
                _hostname,
                _nodeCount,
                _shape,
                _sshPublicKeys,
                _totalEcpuCount,
                _vmFileSystemStorage)
            {
                Domain = domain,
                LicenseModel = licenseModel,
                SystemVersion = systemVersion,
                TimeZone = timeZone,
                ScanListenerPortTcp = scanListenerPortTcp,
                ScanListenerPortTcpSsl = scanListenerPortTcpSsl,
                ClusterName = "exadb-cluster"
            };

            // Assert
            Assert.AreEqual(domain, properties.Domain);
            Assert.AreEqual(licenseModel, properties.LicenseModel);
            Assert.AreEqual(systemVersion, properties.SystemVersion);
            Assert.AreEqual(timeZone, properties.TimeZone);
            Assert.AreEqual(scanListenerPortTcp, properties.ScanListenerPortTcp);
            Assert.AreEqual(scanListenerPortTcpSsl, properties.ScanListenerPortTcpSsl);
            Assert.AreEqual("exadb-cluster", properties.ClusterName);
        }

        public void VmFileSystemStorageTotalSizeInGbs_SetAndGet_WorksCorrectly()
        {
            // Arrange
            var properties = new ExadbVmClusterProperties(
                _vnetId,
                _subnetId,
                _displayName,
                _enabledEcpuCount,
                _exascaleDBStorageVaultId,
                _hostname,
                _nodeCount,
                _shape,
                _sshPublicKeys,
                _totalEcpuCount,
                _vmFileSystemStorage);

            // Act
            int newSize = 2048;
            properties.VmFileSystemStorageTotalSizeInGbs = newSize;

            // Assert
            Assert.AreEqual(newSize, properties.VmFileSystemStorageTotalSizeInGbs);
        }

        public void VmFileSystemStorageTotalSizeInGbs_SetToNull_SetsPropertyToNull()
        {
            // Arrange
            var properties = new ExadbVmClusterProperties(
                _vnetId,
                _subnetId,
                _displayName,
                _enabledEcpuCount,
                _exascaleDBStorageVaultId,
                _hostname,
                _nodeCount,
                _shape,
                _sshPublicKeys,
                _totalEcpuCount,
                _vmFileSystemStorage);

            // Act
            properties.VmFileSystemStorageTotalSizeInGbs = null;

            // Assert
            Assert.IsNull(properties.VmFileSystemStorageTotalSizeInGbs);
        }

        public void NsgCidrs_AddItem_AddsToCollection()
        {
            // Arrange
            var properties = new ExadbVmClusterProperties(
                _vnetId,
                _subnetId,
                _displayName,
                _enabledEcpuCount,
                _exascaleDBStorageVaultId,
                _hostname,
                _nodeCount,
                _shape,
                _sshPublicKeys,
                _totalEcpuCount,
                _vmFileSystemStorage);

            // Act
            var nsgCidr = new CloudVmClusterNsgCidr("10.0.0.0/16");
            properties.NsgCidrs.Add(nsgCidr);

            // Assert
            Assert.AreEqual(1, properties.NsgCidrs.Count);
            Assert.AreEqual(nsgCidr, properties.NsgCidrs[0]);
        }

        public async Task TestExadbVmClusterOperations()
        {
            // Create the ExadbVmCluster resource
            _exadbVmClusterResource = await CreateExadbVmClusterScenario();

            // Delete the ExadbVmCluster resource
            await DeleteExadbVmClusterScenario(_exadbVmClusterResource);
        }

        private async Task<ExadbVmClusterResource> CreateExadbVmClusterScenario()
        {
            _exadbVmClusterCollection = await GetExadbVmClusterCollectionAsync(DefaultResourceGroupName);
            _exadbVmClusterName = Recording.GenerateAssetName("OFake_NetSdkTestExadbVmCluster");

            // Create
            var createExadbVmClusterOperation = await _exadbVmClusterCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                _exadbVmClusterName, GetDefaultExadbVmClusterData(_exadbVmClusterName));
            await createExadbVmClusterOperation.WaitForCompletionAsync();
            Assert.IsTrue(createExadbVmClusterOperation.HasCompleted);
            Assert.IsTrue(createExadbVmClusterOperation.HasValue);

            // Get
            Response<ExadbVmClusterResource> getExadbVmClusterResponse = await _exadbVmClusterCollection.GetAsync(_exadbVmClusterName);
            ExadbVmClusterResource exadbVmClusterResource = getExadbVmClusterResponse.Value;
            Assert.IsNotNull(exadbVmClusterResource);
            return exadbVmClusterResource;
        }

        private async Task DeleteExadbVmClusterScenario(ExadbVmClusterResource exadbVmClusterResource)
        {
            if (exadbVmClusterResource != null)
            {
                var deleteExadbVmClusterOperation = await exadbVmClusterResource.DeleteAsync(WaitUntil.Completed);
                await deleteExadbVmClusterOperation.WaitForCompletionResponseAsync();
                Assert.IsTrue(deleteExadbVmClusterOperation.HasCompleted);
            }
        }

        private ExadbVmClusterData GetDefaultExadbVmClusterData(string clusterName)
        {
            var exadbVmClusterProperties = new ExadbVmClusterProperties(
                _vnetId,
                _subnetId,
                clusterName,
                _enabledEcpuCount,
                _exascaleDBStorageVaultId,
                _hostname,
                _nodeCount,
                _shape,
                _sshPublicKeys,
                _totalEcpuCount,
                _vmFileSystemStorage)
            {
                ClusterName = "ExadbClust",
                LicenseModel = OracleLicenseModel.LicenseIncluded,
                TimeZone = "UTC",
                Domain = "example.com",
                SystemVersion = "19.2.12.0.0.200317",
                ScanListenerPortTcp = 1521,
                ScanListenerPortTcpSsl = 2484
            };

            exadbVmClusterProperties.NsgCidrs.Add(new CloudVmClusterNsgCidr("10.0.0.0/16"));

            return new ExadbVmClusterData(_location)
            {
                Properties = exadbVmClusterProperties
            };
        }
    }
}
