// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceOnboarding.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceOnboarding.Tests.Scenario
{
    [TestFixture]
    public class DiscoveryServiceTests : DeviceOnboardingManagementTestBase
    {
        public DiscoveryServiceTests() : base(true, RecordedTestMode.Playback)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDiscoveryServiceCRUD()
        {
            //create
            string subscriptionId = TestEnvironment.DeviceOnboardingSubscription;
            string resourceGroupName = TestEnvironment.DeviceOnboardingResourceGroup;
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            DiscoveryServiceCollection collection = resourceGroupResource.GetDiscoveryServices();
            string discoveryServiceName = "testDiscoveryService";
            DiscoveryServiceData data = new DiscoveryServiceData(new AzureLocation("westus3"))
            {
                Properties = new DiscoveryServiceProperties(),
                Tags =
                {
                    ["key4985"] = "ohlusfqwktu"
                },
            };
            ArmOperation<DiscoveryServiceResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, discoveryServiceName, data);
            Assert.IsTrue(createOperation.HasCompleted);

            //read
            collection = resourceGroupResource.GetDiscoveryServices();
            NullableResponse<DiscoveryServiceResource> result = await collection.GetIfExistsAsync(discoveryServiceName);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value.Data.Tags["key4985"], "ohlusfqwktu");

            //update
            ResourceIdentifier discoveryServiceResourceId = DiscoveryServiceResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, discoveryServiceName);
            DiscoveryServiceResource discoveryService = Client.GetDiscoveryServiceResource(discoveryServiceResourceId);
            DiscoveryServiceResource updated = await discoveryService.AddTagAsync("key6682", "vsuqfaifoynihslbsoals");
            DiscoveryServiceData resourceData = updated.Data;
            Assert.AreEqual(resourceData.Tags["key6682"], "vsuqfaifoynihslbsoals");

            //delete
            ArmOperation deleteOperation = await discoveryService.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteOperation.HasCompleted);
            collection = resourceGroupResource.GetDiscoveryServices();
            bool checkExistence = await collection.ExistsAsync(discoveryServiceName);
            Assert.IsFalse(checkExistence);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestOwnerShipVoucher()
        {
            //discovery service setup
            string subscriptionId = TestEnvironment.DeviceOnboardingSubscription;
            string resourceGroupName = TestEnvironment.DeviceOnboardingResourceGroup;
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            DiscoveryServiceCollection dsCollection = resourceGroupResource.GetDiscoveryServices();
            string discoveryServiceName = "testOV";
            DiscoveryServiceData dsData = new DiscoveryServiceData(new AzureLocation("westus3"))
            {
                Properties = new DiscoveryServiceProperties()
            };
            ArmOperation<DiscoveryServiceResource> dsCreateOperation = await dsCollection.CreateOrUpdateAsync(WaitUntil.Completed, discoveryServiceName, dsData);
            Assert.IsTrue(dsCreateOperation.HasCompleted);

            //create
            DiscoveryServiceResource discoveryService = await resourceGroupResource.GetDiscoveryServiceAsync(discoveryServiceName);
            OwnershipVoucherPublicKeyCollection collection = discoveryService.GetOwnershipVoucherPublicKeys();
            string ownershipVoucherPublicKeyName = "ovpublickey";
            OwnershipVoucherPublicKeyData data = new OwnershipVoucherPublicKeyData(new AzureLocation("westus3"))
            {
                Properties = new OwnershipVoucherPublicKeyProperties(new X5ChainPublicKeyDetails(new byte[][] { Convert.FromBase64String("MIIDLjCCAhagAwIBAgIQMWp0aK40S/eHugyBeiK9CTANBgkqhkiG9w0BAQsFADAUMRIwEAYDVQQDEwl0ZXN0c2Rrb3YwHhcNMjUwMzIxMjExNTI2WhcNMjYwMzIxMjEyNTI2WjAUMRIwEAYDVQQDEwl0ZXN0c2Rrb3YwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDiTc1kjN9mWlW/Jjgp81hqGNFoNbbFjmxB2oOA6Bcqlh0+kZcwgqjMOHukr8QLMbxCaR/ROsXOTC+77dYnUR1BSu33sBM+CT0BDWSomaFwapx9O+42+JJMQcaN50KLQjwfbEv0AyOTrLZO8jgP4Uxp6fYZ7PrTME64pcJMog8U6A4FZX3hlkSWh1tMDPI8yY9lSPtpc7roLZMJS59H5XQ/0HiLTp1wqcnjv/lzCGFkONr97Cp4headknk+3bqFKRjGhaPOozWCTzPqSdICjZzXvg8QH522fZS2r9dIKh9+F/d+f8PDeA17Mf+Stg3liT5WkpBBZf8x2DdasgizdXdZAgMBAAGjfDB6MA4GA1UdDwEB/wQEAwIFoDAJBgNVHRMEAjAAMB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjAfBgNVHSMEGDAWgBRaUZ4Bvp6qAc2epLXt/P25BoeNcTAdBgNVHQ4EFgQUWlGeAb6eqgHNnqS17fz9uQaHjXEwDQYJKoZIhvcNAQELBQADggEBAAgrSySqUfmuWu5LLn+R82NBOZ/U2MWOdRKaFpMS2ZU5J845ydtlP46nyCdOyej+k+RwP7IMyivbxLsIEK5BoDDAiAKdDsepTwc3N2x1ScKbZenUqdaFRF+ueiYv35cALYoV8ljOTyG1tY1T2xu8ZiEP0pqosw3SZKWzYBHUMwQBL3YmM3Gq0YfaSC+SD1zUZBf4LS2gWz3DUm4DtqnMromQbQhyvjKyj4jrUj9HIWAxK+2RYsn6UZrsDiIi3KBiykKsfJcg/z1J1gW/QNf1C6m5VbG34PRRMASUFujz1+DTQmoWagHYDKAIlU38cdFsoJzX4u95hAUCpgSkQ96FNw8=") })),
                Tags =
                    {
                        ["key8073"] = "btlbjprbskpohvkzagksq"
                    },
            };
            ArmOperation<OwnershipVoucherPublicKeyResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ownershipVoucherPublicKeyName, data);
            Assert.IsTrue(createOperation.HasCompleted);

            //read
            collection = discoveryService.GetOwnershipVoucherPublicKeys();
            NullableResponse<OwnershipVoucherPublicKeyResource> result = await collection.GetIfExistsAsync(ownershipVoucherPublicKeyName);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual(result.Value.Data.Tags["key8073"], "btlbjprbskpohvkzagksq");

            //update (bug in lro for update not returning)
            //ResourceIdentifier discoveryServiceResourceId = OwnershipVoucherPublicKeyResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, discoveryServiceName, ownershipVoucherPublicKeyName);
            //OwnershipVoucherPublicKeyResource ownershipVoucherPublicKey = Client.GetOwnershipVoucherPublicKeyResource(discoveryServiceResourceId);
            //OwnershipVoucherPublicKeyResource updated = await ownershipVoucherPublicKey.AddTagAsync("key1947", "qixhvgmpfuo");
            //Assert.AreEqual(updated.Data.Tags["key1947"], "qixhvgmpfuo");

            //delete
            ArmOperation deleteOperation = await result.Value.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteOperation.HasCompleted);
            collection = discoveryService.GetOwnershipVoucherPublicKeys();
            bool checkExistence = await collection.ExistsAsync(ownershipVoucherPublicKeyName);
            Assert.IsFalse(checkExistence);

            //cleanup discoveryservice
            ArmOperation dsDeleteOperation = await discoveryService.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(dsDeleteOperation.HasCompleted);
            dsCollection = resourceGroupResource.GetDiscoveryServices();
            bool dsCheckExistence = await dsCollection.ExistsAsync(discoveryServiceName);
            Assert.IsFalse(dsCheckExistence);
        }
    }
}
