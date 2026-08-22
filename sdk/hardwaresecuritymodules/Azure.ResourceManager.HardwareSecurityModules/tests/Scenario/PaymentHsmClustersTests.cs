// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.HardwareSecurityModules.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.HardwareSecurityModules.Tests
{
#if NETFRAMEWORK
    [Ignore("Generating the Payment HSM trusted issuer certificates requires .NET Core or later.")]
#endif
    public class PaymentHsmClustersTests : HardwareSecurityModulesManagementTestBase
    {
        private string _applicationTrustedIssuer;
        private string _managementTrustedIssuer;

        public PaymentHsmClustersTests(bool isAsync)
        : base(isAsync)
        {
        }

        [SetUp]
        protected async Task SetUp()
        {
            await BaseSetUpForTests(isPaymentHsm: true);
            _applicationTrustedIssuer = Recording.GetVariable("PAYMENT_HSM_APPLICATION_TRUSTED_ISSUER", GetValidClientTrustCaBase64());
            _managementTrustedIssuer = Recording.GetVariable("PAYMENT_HSM_MANAGEMENT_TRUSTED_ISSUER", GetValidClientTrustCaBase64());
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdatePaymentHsmClusterTest()
        {
            string resourceName = Recording.GenerateAssetName("sdkT");

            PaymentHsmClusterData paymentHsmClusterBody = new PaymentHsmClusterData(Location)
            {
                Sku = new PaymentHsmClusterSku(PaymentHsmClusterSkuFamily.B, PaymentHsmClusterSkuName.PaymentsV2),
                Properties = new PaymentHsmClusterProperties(_applicationTrustedIssuer, _managementTrustedIssuer),
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                    ["UseMockHfc"] = "true",
                    ["MockHfcDelayInMs"] = "1"
                },
            };

            PaymentHsmClusterCollection collection = ResourceGroupResource.GetPaymentHsmClusters();
            var createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, paymentHsmClusterBody);
            PaymentHsmClusterResource paymentHsmClusterResult = createOperation.Value;

            Assert.AreEqual(resourceName, paymentHsmClusterResult.Data.Name);
            ValidatePaymentHsmResource(
                paymentHsmClusterResult.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                PaymentHsmClusterSkuFamily.B.ToString(),
                PaymentHsmClusterSkuName.PaymentsV2.ToString(),
                new Dictionary<string, string>(paymentHsmClusterBody.Tags));

            var getOperation = await collection.GetAsync(resourceName);

            Assert.IsNotNull(getOperation.Value);
            ValidatePaymentHsmResource(
                getOperation.Value.Data,
                DefaultSubscription.Data.SubscriptionId,
                ResourceGroupResource.Data.Name,
                resourceName,
                Location.Name,
                PaymentHsmClusterSkuFamily.B.ToString(),
                PaymentHsmClusterSkuName.PaymentsV2.ToString(),
                new Dictionary<string, string>(paymentHsmClusterBody.Tags));

            var getAllOperation = collection.GetAllAsync();
            int paymentHsmCount = 0;
            await foreach (PaymentHsmClusterResource paymentHsmResource in getAllOperation)
            {
                if (paymentHsmResource.Id == paymentHsmClusterResult.Id)
                {
                    paymentHsmCount++;
                    break;
                }
            }
            Assert.AreEqual(paymentHsmCount, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task UpdatePaymentHsmClusterTagsTest()
        {
            PaymentHsmClusterResource paymentHsmClusterResource = await CreatePaymentHsmClusterResourceAsync();

            PaymentHsmClusterPatch patch = new PaymentHsmClusterPatch()
            {
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "test",
                    ["UseMockHfc"] = "true",
                    ["MockHfcDelayInMs"] = "1"
                },
            };

            var updateOperation = await paymentHsmClusterResource.UpdateAsync(WaitUntil.Completed, patch);

            Assert.IsNotNull(updateOperation.Value);
            Assert.AreEqual("test", updateOperation.Value.Data.Tags["Env"]);
        }

        [TestCase]
        [RecordedTest]
        public async Task DeletePaymentHsmClusterTest()
        {
            PaymentHsmClusterResource paymentHsmClusterResource = await CreatePaymentHsmClusterResourceAsync();
            PaymentHsmClusterCollection collection = ResourceGroupResource.GetPaymentHsmClusters();

            Assert.IsTrue(await collection.ExistsAsync(paymentHsmClusterResource.Data.Name));

            await paymentHsmClusterResource.DeleteAsync(WaitUntil.Completed);

            Assert.IsFalse(await collection.ExistsAsync(paymentHsmClusterResource.Data.Name));
        }

        protected async Task<PaymentHsmClusterResource> CreatePaymentHsmClusterResourceAsync()
        {
            string resourceName = Recording.GenerateAssetName("PaymentHsmSDKTest");
            PaymentHsmClusterData paymentHsmClusterBody = new PaymentHsmClusterData(Location)
            {
                Sku = new PaymentHsmClusterSku(PaymentHsmClusterSkuFamily.B, PaymentHsmClusterSkuName.PaymentsV2),
                Properties = new PaymentHsmClusterProperties(_applicationTrustedIssuer, _managementTrustedIssuer),
                Tags =
                {
                    ["Dept"] = "SDK Testing",
                    ["Env"] = "df",
                    ["UseMockHfc"] = "true",
                    ["MockHfcDelayInMs"] = "1"
                },
            };

            PaymentHsmClusterCollection collection = ResourceGroupResource.GetPaymentHsmClusters();
            var createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, paymentHsmClusterBody);
            return createOperation.Value;
        }

        private void ValidatePaymentHsmResource(
            PaymentHsmClusterData paymentHsmClusterData,
            string expectedSubId,
            string expectedRgName,
            string expectedResourceName,
            string expectedResourceLocation,
            string expectedSkuFamily,
            string expectedSkuName,
            Dictionary<string, string> expectedTags)
        {
            string resourceIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.HardwareSecurityModules/paymentHsmClusters/{2}";
            string expectedResourceId = string.Format(resourceIdFormat, expectedSubId, expectedRgName, expectedResourceName);

            Assert.NotNull(paymentHsmClusterData);
            Assert.AreEqual(expectedResourceId, paymentHsmClusterData.Id.ToString());
            Assert.AreEqual(expectedResourceLocation, paymentHsmClusterData.Location.Name);
            Assert.AreEqual(expectedResourceName, paymentHsmClusterData.Name);
            Assert.NotNull(paymentHsmClusterData.Sku);
            Assert.AreEqual(expectedSkuFamily, paymentHsmClusterData.Sku.Family.ToString());
            Assert.AreEqual(expectedSkuName, paymentHsmClusterData.Sku.Name.ToString());
            Assert.NotNull(paymentHsmClusterData.Properties);
            Assert.IsNull(paymentHsmClusterData.Properties.ApplicationTrustedIssuer);
            Assert.IsNull(paymentHsmClusterData.Properties.ManagementTrustedIssuer);
            Assert.NotNull(paymentHsmClusterData.Tags);
            Assert.True(expectedTags.Count == paymentHsmClusterData.Tags.Count && !expectedTags.Except(paymentHsmClusterData.Tags).Any());
        }
    }
}
