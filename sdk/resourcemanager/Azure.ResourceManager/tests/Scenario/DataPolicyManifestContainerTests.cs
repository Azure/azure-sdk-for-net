// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class DataPolicyManifestContainerTests : ResourceManagerTestBase
    {
        public DataPolicyManifestContainerTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        
        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            await foreach(var tempTenant in Client.GetTenants().GetAllAsync())
            {
                await foreach(var tempDataPolicyManifest in tempTenant.GetDataPolicyManifests().GetAllAsync())
                {
                    Assert.AreEqual(tempDataPolicyManifest.Data.Type, "Microsoft.Authorization/dataPolicyManifests");
                }
            }
        }
        
        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            await foreach (var tempTenant in Client.GetTenants().GetAllAsync())
            {
                DataPolicyManifest dataPolicyManifest = await tempTenant.GetDataPolicyManifests().GetAsync("Microsoft.Network.Data");
                Assert.AreEqual(dataPolicyManifest.Data.Type, "Microsoft.Authorization/dataPolicyManifests");
                Assert.AreEqual(dataPolicyManifest.Data.PolicyMode, "Microsoft.Network.Data");
            }
        }
    }
}
