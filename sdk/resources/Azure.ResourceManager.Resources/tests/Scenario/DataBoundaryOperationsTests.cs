// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
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
        public async Task GetDataBoundaryTenant()
        {
            DataBoundaryName name = DataBoundaryName.Default;
            ResourceIdentifier tenantDataBoundaryResourceId = TenantDataBoundaryResource.CreateResourceIdentifier(name);
            TenantDataBoundaryResource tenantDataBoundary = Client.GetTenantDataBoundaryResource(tenantDataBoundaryResourceId);

            TenantDataBoundaryResource result = await tenantDataBoundary.GetAsync();

            DataBoundaryData resourceData = result.Data;

            Assert.AreEqual(DataBoundaryRegion.EU, resourceData.Properties.DataBoundary);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScoped()
        {
            DataBoundaryName name = DataBoundaryName.Default;
            string scope = "/subscriptions/2145a411-d149-4010-84d4-40fe8a55db44";
            ResourceIdentifier resourceId = DataBoundaryResource.CreateResourceIdentifier(scope, name);
            DataBoundaryResource dataBoundary = Client.GetDataBoundaryResource(resourceId);
            DataBoundaryResource result = await dataBoundary.GetAsync(name);
            DataBoundaryData resourceData = result.Data;
            Assert.AreEqual(DataBoundaryRegion.Global, resourceData.Properties.DataBoundary);
            Assert.AreEqual(DataBoundaryProvisioningState.Succeeded, resourceData.Properties.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScopedCollection()
        {
            DataBoundaryName name = DataBoundaryName.Default;
            string scope = "subscriptions/2145a411-d149-4010-84d4-40fe8a55db44";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("/{0}", scope));
            DataBoundaryCollection collection = Client.GetDataBoundaries(scopeId);

            DataBoundaryResource result = await collection.GetAsync(name);

            DataBoundaryData resourceData = result.Data;

            Assert.AreEqual(DataBoundaryRegion.Global, resourceData.Properties.DataBoundary);
            Assert.AreEqual(DataBoundaryProvisioningState.Succeeded, resourceData.Properties.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public void PutDataBoundary()
        {
            DataBoundaryName name = DataBoundaryName.Default;
            ResourceIdentifier tenantDataBoundaryResourceId = TenantDataBoundaryResource.CreateResourceIdentifier(name);
            TenantDataBoundaryResource tenantDataBoundary = Client.GetTenantDataBoundaryResource(tenantDataBoundaryResourceId);

            DataBoundaryData data = new DataBoundaryData()
            {
                Properties = new DataBoundaryProperties()
                {
                    DataBoundary = DataBoundaryRegion.EU,
                }
            };

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await tenantDataBoundary.UpdateAsync(WaitUntil.Completed, data));
            Assert.IsTrue(ex.Message.Contains("does not have authorization to perform action"));
        }
    }
}
