// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OracleDatabase;
using Azure.ResourceManager.OracleDatabase.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class ExascaleDbStorageTest : OracleDatabaseManagementTestBase
    {
        private string _exascaleDbStorageVaultName;
        private static ExascaleDBStorageVaultResource _exaScaleStorageResource;
        private ExascaleDBStorageVaultCollection _collection;

        public ExascaleDbStorageTest() : base(true, RecordedTestMode.Playback)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestExascaleStorageVaultOperations()
        {
            _exaScaleStorageResource = await CreateExascaleDbStorageVault();
        }

        private async Task<ExascaleDBStorageVaultResource> CreateExascaleDbStorageVault()
        {
            _exascaleDbStorageVaultName = Recording.GenerateAssetName("OfakeStorageNet");
            TestContext.Progress.WriteLine($"Starting CreateExascaleDbStorageVault test for vault: {_exascaleDbStorageVaultName}");

            _collection = await GetExascaleDBStorageVaultCollectionAsync(DefaultResourceGroupName);

            var createOperation = await _collection.CreateOrUpdateAsync(WaitUntil.Completed, _exascaleDbStorageVaultName, GetDefaultExascaleDbStorageVaultData(_exascaleDbStorageVaultName));

            Assert.IsTrue(createOperation.HasCompleted);
            Assert.IsTrue(createOperation.HasValue);

            // Get
            Response<ExascaleDBStorageVaultResource> getExaDbStorageResponse = await _collection.GetAsync(_exascaleDbStorageVaultName);
            ExascaleDBStorageVaultResource exaScaleStorage = getExaDbStorageResponse.Value;
            Assert.IsNotNull(exaScaleStorage);
            return exaScaleStorage;
        }

          private ExascaleDBStorageVaultData GetDefaultExascaleDbStorageVaultData(string vaultName)
        {
            return new ExascaleDBStorageVaultData(_location)
            {
                Properties = new ExascaleDBStorageVaultProperties
                {
                    Description = "This is a test Exascale DB Storage Vault created by the .NET SDK tests.",
                    DisplayName = vaultName,
                    HighCapacityDatabaseStorageInput = new ExascaleDBStorageInputDetails(300),
                },
                Zones = { "2" },
                Tags = { { "env", "test" }, { "purpose", "sdk-test" } }
            };
        }
    }
}
