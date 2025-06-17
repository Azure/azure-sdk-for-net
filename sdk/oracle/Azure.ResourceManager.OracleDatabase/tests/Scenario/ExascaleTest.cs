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
            _exadbVmClusterName = "OfakeSdkNet2";
            _vnetId = new ResourceIdentifier(string.Format(VnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName));
            _subnetId = new ResourceIdentifier(string.Format(SubnetIdFormat, DefaultSubscription.Data.Id, DefaultResourceGroupName, DefaultVnetName, DefaultSubnetName));
            _enabledEcpuCount = 16;
            _exascaleDBStorageVaultId = new ResourceIdentifier($"{DefaultSubscription.Data.Id}/resourceGroups/{DefaultResourceGroupName}/providers/Oracle.Database/exascaleDbStorageVaults/OfakeStorageNet2641");
            _hostname = "testSdkHost";
            _nodeCount = 2;
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

        [TestCase]
        [RecordedTest]
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
            string gridImageOcid = "ocid1.dbpatch.oc1.iad.anuwcljtt5t4sqqaoajnkveobp3ryw7zlfrrcf6tb2ndvygp54z2gbds2hxa";
            // "ocid1.dbpatch.oc1.iad.anuwcljtt5t4sqqaoajnkveobp3ryw7zlfrrcf6tb2ndvygp54z2gbds2hxa";

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
                DisplayName = clusterName,
                LicenseModel = OracleLicenseModel.LicenseIncluded,
                Domain = "ocidelegated.ocinetsdk.oraclevcn.com",
                GridImageOcid = gridImageOcid
            };

            var data = new ExadbVmClusterData(_location)
            {
                Properties = exadbVmClusterProperties,
            };
            data.Zones.Add(DefaultZone);

            return data;
        }
    }
}
