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
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            DataBoundaryName name = DataBoundaryName.Default;
            ResourceIdentifier tenantDataBoundaryResourceId = TenantDataBoundaryResource.CreateResourceIdentifier(name);
            TenantDataBoundaryResource tenantDataBoundary = client.GetTenantDataBoundaryResource(tenantDataBoundaryResourceId);

            TenantDataBoundaryResource result = await tenantDataBoundary.GetAsync();

            DataBoundaryData resourceData = result.Data;

            Assert.AreEqual(DataBoundaryRegion.EU, resourceData.Properties.DataBoundary);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScoped()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            DataBoundaryName name = DataBoundaryName.Default;
            string scope = "/subscriptions/2145a411-d149-4010-84d4-40fe8a55db44";
            ResourceIdentifier resourceId = DataBoundaryResource.CreateResourceIdentifier(scope, name);
            DataBoundaryResource dataBoundary = client.GetDataBoundaryResource(resourceId);
            DataBoundaryResource result = await dataBoundary.GetAsync(name);
            DataBoundaryData resourceData = result.Data;
            Assert.AreEqual(DataBoundaryRegion.Global, resourceData.Properties.DataBoundary);
            Assert.AreEqual(DataBoundaryProvisioningState.Succeeded, resourceData.Properties.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScopedCollection()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            DataBoundaryName name = DataBoundaryName.Default;
            string scope = "subscriptions/2145a411-d149-4010-84d4-40fe8a55db44";
            ResourceIdentifier scopeId = new ResourceIdentifier(string.Format("/{0}", scope));
            DataBoundaryCollection collection = client.GetDataBoundaries(scopeId);

            DataBoundaryResource result = await collection.GetAsync(name);

            DataBoundaryData resourceData = result.Data;

            Assert.AreEqual(DataBoundaryRegion.Global, resourceData.Properties.DataBoundary);
            Assert.AreEqual(DataBoundaryProvisioningState.Succeeded, resourceData.Properties.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public async Task PutDataBoundary()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            DataBoundaryName name = DataBoundaryName.Default;
            ResourceIdentifier tenantDataBoundaryResourceId = TenantDataBoundaryResource.CreateResourceIdentifier(name);
            TenantDataBoundaryResource tenantDataBoundary = client.GetTenantDataBoundaryResource(tenantDataBoundaryResourceId);

            DataBoundaryData data = new DataBoundaryData()
            {
                Properties = new DataBoundaryProperties()
                {
                    DataBoundary = DataBoundaryRegion.EU,
                }
            };

            try {
                ArmOperation<TenantDataBoundaryResource> result = await tenantDataBoundary.UpdateAsync(WaitUntil.Completed, data);
                throw new Exception();
            } catch (Exception e)
            {
                e.ToString().Contains("does not have authorization to perform action");
            }
        }
    }
}
