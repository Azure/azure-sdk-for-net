// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DataBoundaryOperationsTests : ResourcesTestBase
    {
        public DataBoundaryOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task PutDataBoundary()
        {
            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-CreateOrUpdate-");
            var dataBoundaryData = CreateDataBoundary();
            var dataBoundary = (await GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryName, dataBoundaryData)).Value;

            Assert.AreEqual("EU", dataBoundary.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundary.Properties.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryTenant()
        {
            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-CreateOrUpdate-");
            var dataBoundaryData = CreateDataBoundary();
            var dataBoundary = (await GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryName, dataBoundaryData)).Value;

            var dataBoundaryTenantGet = (await GetTenantDataBoundaryAsync()).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Properties.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScoped()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-CreateOrUpdate-");
            var dataBoundaryData = CreateDataBoundary();
            var dataBoundary = (await GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryName, dataBoundaryData)).Value;

            var dataBoundaryTenantGet = (await GetScopedDataBoundaryAsync(subscription)).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Properties.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }
    }
}
