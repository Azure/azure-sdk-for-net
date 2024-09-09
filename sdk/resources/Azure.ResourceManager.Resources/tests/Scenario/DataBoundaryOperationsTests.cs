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
            var dataBoundaryData = CreateDataBoundary();
            var dataBoundary = (await GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryData)).Value;

            Assert.AreEqual("EU", dataBoundary.Data.DataBoundary);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryTenant()
        {
            var dataBoundaryData = CreateDataBoundary();
            var dataBoundary = (await GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryData)).Value;

            var dataBoundaryTenantGet = (await GetTenantDataBoundaryAsync()).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Data.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Data.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScoped()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            var dataBoundaryData = CreateDataBoundary();
            var dataBoundary = (await GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryData)).Value;

            var dataBoundaryTenantGet = (await GetScopedDataBoundaryAsync(subscription)).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Data.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Data.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }
    }
}
