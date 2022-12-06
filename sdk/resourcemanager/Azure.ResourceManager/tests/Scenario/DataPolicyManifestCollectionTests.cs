// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class DataPolicyManifestCollectionTests : ResourceManagerTestBase
    {
        public DataPolicyManifestCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                await foreach (var tempDataPolicyManifest in tenant.GetDataPolicyManifests().GetAllAsync())
                {
                    Assert.AreEqual(tempDataPolicyManifest.Data.ResourceType, "Microsoft.Authorization/dataPolicyManifests");
                }
            }
        }
        
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                DataPolicyManifestResource dataPolicyManifest = await tenant.GetDataPolicyManifests().GetAsync("Microsoft.Network.Data");
                Assert.AreEqual(dataPolicyManifest.Data.ResourceType, "Microsoft.Authorization/dataPolicyManifests");
                Assert.AreEqual(dataPolicyManifest.Data.PolicyMode, "Microsoft.Network.Data");
            }
        }
    }
}
