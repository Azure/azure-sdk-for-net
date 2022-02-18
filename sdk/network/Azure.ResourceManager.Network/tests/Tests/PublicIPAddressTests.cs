// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class PublicIPAddressTests : NetworkServiceClientTestBase
    {
        public PublicIPAddressTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [Test]
        [RecordedTest]
        public async Task PublicIPAddressApiTest()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the parameter for PUT PublicIPAddress
            string publicIPName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");

            var publicIP = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIPAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(true, publicIPName, publicIP);
            Response<PublicIPAddress> putPublicIPAddressResponse = await putPublicIPAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIPAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIPAddressResponse = await publicIPAddressCollection.GetAsync(publicIPName);
            Assert.AreEqual(4, getPublicIPAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIPAddressResponse.Value.Data.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIPAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddress> getPublicIPAddressListResponse = await getPublicIPAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIPAddressListResponse);
            ArePublicIPAddressesEqual(getPublicIPAddressResponse.Value.Data, getPublicIPAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIPAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIPAddressListSubscriptionResponse = await getPublicIPAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIPAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIPAddressResponse.Value.DeleteAsync(true);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIPAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIPAddressListResponse = await getPublicIPAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIPAddressListResponse);
        }

        [Test]
        [RecordedTest]
        public async Task PublicIPAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the parameter for PUT PublicIPAddress
            string publicIPName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");
            string reverseFqdn;

            var publicIP = new PublicIPAddressData()
            {
                Location = TestEnvironment.Location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel, },
                IdleTimeoutInMinutes = 16,
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIPAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(true, publicIPName, publicIP);
            Response<PublicIPAddress> putPublicIPAddressResponse = await putPublicIPAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIPAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIPAddressResponse = await publicIPAddressCollection.GetAsync(publicIPName);

            // Add Reverse FQDN
            reverseFqdn = getPublicIPAddressResponse.Value.Data.DnsSettings.Fqdn;
            getPublicIPAddressResponse.Value.Data.DnsSettings.ReverseFqdn = reverseFqdn;

            putPublicIPAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(true, publicIPName, getPublicIPAddressResponse.Value.Data);
            putPublicIPAddressResponse = await putPublicIPAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIPAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            getPublicIPAddressResponse = await publicIPAddressCollection.GetAsync(publicIPName);
            Assert.AreEqual(16, getPublicIPAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.AreEqual(reverseFqdn, getPublicIPAddressResponse.Value.Data.DnsSettings.ReverseFqdn);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIPAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddress> getPublicIPAddressListResponse = await getPublicIPAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIPAddressListResponse);
            ArePublicIPAddressesEqual(getPublicIPAddressResponse.Value.Data, getPublicIPAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIPAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIPAddressListSubscriptionResponse = await getPublicIPAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIPAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIPAddressResponse.Value.DeleteAsync(true);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIPAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIPAddressListResponse = await getPublicIPAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIPAddressListResponse);
        }

        [Test]
        [RecordedTest]
        public async Task PublicIPAddressApiTestIPv6()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the parameter for PUT PublicIPAddress
            string ipv6PublicIPName = Recording.GenerateAssetName("csmipv6publicip");
            string domainNameLabel = Recording.GenerateAssetName("csmdnslabelpublicip");

            var ipv6PublicIP = new PublicIPAddressData()
            {
                Location = TestEnvironment.Location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = IPVersion.IPv6
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIPAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(true, ipv6PublicIPName, ipv6PublicIP);
            Response<PublicIPAddress> putPublicIPAddressResponse = await putPublicIPAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIPAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIPAddressResponse = await publicIPAddressCollection.GetAsync(ipv6PublicIPName);
            Assert.NotNull(getPublicIPAddressResponse);

            Assert.AreEqual(IPVersion.IPv6, getPublicIPAddressResponse.Value.Data.PublicIPAddressVersion);
            Assert.AreEqual(4, getPublicIPAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIPAddressResponse.Value.Data.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIPAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddress> getPublicIPAddressListResponse = await getPublicIPAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIPAddressListResponse);
            ArePublicIPAddressesEqual(getPublicIPAddressResponse.Value.Data, getPublicIPAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIPAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIPAddressListSubscriptionResponse = await getPublicIPAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIPAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIPAddressResponse.Value.DeleteAsync(true);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIPAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIPAddressListResponse = await getPublicIPAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIPAddressListResponse);

            // Also check IPv4 PublicIP
            // Create the parameter for PUT PublicIPAddress
            string ipv4PublicIPName = Recording.GenerateAssetName("csmipv4publicip");

            var ipv4PublicIP = new PublicIPAddressData()
            {
                Location = TestEnvironment.Location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = IPVersion.IPv4,
            };

            // Put PublicIPAddress
            var putIPv4PublicIPAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(true, ipv4PublicIPName, ipv4PublicIP);
            Response<PublicIPAddress> putIPv4PublicIPAddressResponse = await putIPv4PublicIPAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putIPv4PublicIPAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getIPv4PublicIPAddressResponse = await publicIPAddressCollection.GetAsync(ipv4PublicIPName);
            Assert.NotNull(getIPv4PublicIPAddressResponse);

            Assert.AreEqual(IPVersion.IPv4, getIPv4PublicIPAddressResponse.Value.Data.PublicIPAddressVersion);
            Assert.AreEqual(4, getIPv4PublicIPAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getIPv4PublicIPAddressResponse.Value.Data.ResourceGuid);

            // Delete PublicIPAddress
            await getIPv4PublicIPAddressResponse.Value.DeleteAsync(true);
        }

        private static void ArePublicIPAddressesEqual(PublicIPAddressData publicIPAddress1, PublicIPAddressData publicIPAddress2)
        {
            Assert.AreEqual(publicIPAddress1.Name, publicIPAddress2.Name);
            Assert.AreEqual(publicIPAddress1.Location, publicIPAddress2.Location);
            // TODO
            //Assert.AreEqual(publicIPAddress1.Id, publicIPAddress2.Id);
            Assert.AreEqual(publicIPAddress1.DnsSettings.DomainNameLabel, publicIPAddress2.DnsSettings.DomainNameLabel);
            Assert.AreEqual(publicIPAddress1.DnsSettings.Fqdn, publicIPAddress2.DnsSettings.Fqdn);
            Assert.AreEqual(publicIPAddress1.IdleTimeoutInMinutes, publicIPAddress2.IdleTimeoutInMinutes);
            Assert.AreEqual(publicIPAddress1.Tags.Count, publicIPAddress2.Tags.Count);
            Assert.AreEqual(publicIPAddress1.PublicIPAddressVersion, publicIPAddress2.PublicIPAddressVersion);
        }
    }
}
