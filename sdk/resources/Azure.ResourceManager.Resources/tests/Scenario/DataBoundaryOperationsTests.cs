// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
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
            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-GetTenantBoundary-");

            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            var tenant = client.GetTenants().GetAllAsync().GetAsyncEnumerator().Current;

            var dataBoundaryTenantGet = (await tenant.GetTenantDataBoundaryAsync(dataBoundaryName)).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Data.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Data.Properties.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDataBoundaryScoped()
        {
            ResourceIdentifier r = new ResourceIdentifier("/subscriptions/1200d73d-d350-413a-98c5-e77ca51245de/providers/Microsoft.Resources/dataBoundaries");
            SubscriptionResource subscription = Client.GetSubscriptionResource(r);

            string dataBoundaryName = Recording.GenerateAssetName("dataBoundary-GetSubscriptionBoundary-");

            var dataBoundaryTenantGet = (await Client.GetDataBoundaryAsync(r, dataBoundaryName)).Value;

            Assert.AreEqual("EU", dataBoundaryTenantGet.Data.Properties.DataBoundary);
            Assert.AreEqual("Created", dataBoundaryTenantGet.Data.Properties.ProvisioningState);
        }
    }
}
