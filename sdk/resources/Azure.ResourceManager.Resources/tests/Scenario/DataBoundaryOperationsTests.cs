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
            // get tenant object (usingtesting tenat id) and call create or update on tenant object (collection)
            // var tenant = GetTenant();
            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-CreateOrUpdate-");
            var dataBoundaryData = CreateDataBoundary();
            //Get using tenant like below
            var dataBoundary = (await tenant.GetTenantDataBoundary().CreateOrUpdateAsync(WaitUntil.Completed, dataBoundaryName, dataBoundaryData)).Value;

            //Check that dataBoundary returns proper reponse. 

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryTenant()
        {
            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-CreateOrUpdate-");
            // get tenant object (usingtesting tenat id) and
            // var tenant = GetTenant();

            var dataBoundaryTenantGet = (await tenant.GetTenantDataBoundaryAsync()).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Properties.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScoped()
        {
            // get tenant object (using testing tenant id) and
            // var tenant = GetTenant();

            // using subscription id from subcription under existing testing tenant
            var dataBoundaryTenantGet = (await tenant.GetScopedDataBoundaryAsync(subscriptionId)).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Properties.ProvisioningState);

            await dataBoundary.DeleteAsync(WaitUntil.Completed);
        }
    }
}
