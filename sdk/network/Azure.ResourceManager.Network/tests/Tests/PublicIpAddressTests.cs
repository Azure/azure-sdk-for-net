// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Azure.Test;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class PublicIpAddressTests : NetworkServiceClientTestBase
    {
        public PublicIpAddressTests(bool isAsync) : base(isAsync)
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
        public async Task PublicIpAddressApiTest()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = TestEnvironment.Location;
            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the parameter for PUT PublicIPAddress
            string publicIpName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");

            var publicIp = new PublicIPAddressData()
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
            var putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(publicIpName);
            Assert.AreEqual(4, getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIpAddressResponse.Value.Data.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIpAddressResponse.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);
        }

        [Test]
        [RecordedTest]
        public async Task PublicIpAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the parameter for PUT PublicIPAddress
            string publicIpName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");
            string reverseFqdn;

            var publicIp = new PublicIPAddressData()
            {
                Location = TestEnvironment.Location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel, },
                IdleTimeoutInMinutes = 16,
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(publicIpName);

            // Add Reverse FQDN
            reverseFqdn = getPublicIpAddressResponse.Value.Data.DnsSettings.Fqdn;
            getPublicIpAddressResponse.Value.Data.DnsSettings.ReverseFqdn = reverseFqdn;

            putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(publicIpName, getPublicIpAddressResponse.Value.Data);
            putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(publicIpName);
            Assert.AreEqual(16, getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.AreEqual(reverseFqdn, getPublicIpAddressResponse.Value.Data.DnsSettings.ReverseFqdn);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIpAddressResponse.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);
        }

        [Test]
        [RecordedTest]
        public async Task PublicIpAddressApiTestIPv6()
        {
            var subscription = await ArmClient.GetDefaultSubscriptionAsync();
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            var resourceGroup = await CreateResourceGroup(resourceGroupName);

            // Create the parameter for PUT PublicIPAddress
            string ipv6PublicIpName = Recording.GenerateAssetName("csmipv6publicip");
            string domainNameLabel = Recording.GenerateAssetName("csmdnslabelpublicip");

            var ipv6PublicIp = new PublicIPAddressData()
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
            var putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(ipv6PublicIpName, ipv6PublicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(ipv6PublicIpName);
            Assert.NotNull(getPublicIpAddressResponse);

            Assert.AreEqual(IPVersion.IPv6, getPublicIpAddressResponse.Value.Data.PublicIPAddressVersion);
            Assert.AreEqual(4, getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIpAddressResponse.Value.Data.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIpAddressResponse.Value.DeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);

            // Also check IPv4 PublicIP
            // Create the parameter for PUT PublicIPAddress
            string ipv4PublicIpName = Recording.GenerateAssetName("csmipv4publicip");

            var ipv4PublicIp = new PublicIPAddressData()
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
            var putIpv4PublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(ipv4PublicIpName, ipv4PublicIp);
            Response<PublicIPAddress> putIpv4PublicIpAddressResponse = await putIpv4PublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putIpv4PublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getIpv4PublicIpAddressResponse = await publicIPAddressCollection.GetAsync(ipv4PublicIpName);
            Assert.NotNull(getIpv4PublicIpAddressResponse);

            Assert.AreEqual(IPVersion.IPv4, getIpv4PublicIpAddressResponse.Value.Data.PublicIPAddressVersion);
            Assert.AreEqual(4, getIpv4PublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getIpv4PublicIpAddressResponse.Value.Data.ResourceGuid);

            // Delete PublicIPAddress
            await getIpv4PublicIpAddressResponse.Value.DeleteAsync();
        }

        private static void ArePublicIpAddressesEqual(PublicIPAddressData publicIpAddress1, PublicIPAddressData publicIpAddress2)
        {
            Assert.AreEqual(publicIpAddress1.Name, publicIpAddress2.Name);
            Assert.AreEqual(publicIpAddress1.Location, publicIpAddress2.Location);
            // TODO
            //Assert.AreEqual(publicIpAddress1.Id, publicIpAddress2.Id);
            Assert.AreEqual(publicIpAddress1.DnsSettings.DomainNameLabel, publicIpAddress2.DnsSettings.DomainNameLabel);
            Assert.AreEqual(publicIpAddress1.DnsSettings.Fqdn, publicIpAddress2.DnsSettings.Fqdn);
            Assert.AreEqual(publicIpAddress1.IdleTimeoutInMinutes, publicIpAddress2.IdleTimeoutInMinutes);
            Assert.AreEqual(publicIpAddress1.Tags.Count, publicIpAddress2.Tags.Count);
            Assert.AreEqual(publicIpAddress1.PublicIPAddressVersion, publicIpAddress2.PublicIPAddressVersion);
        }
    }
}
