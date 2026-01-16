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
    [ClientTestFixture(true, "2021-04-01", "2018-11-01")]
    public class PublicIpAddressTests : NetworkServiceClientTestBase
    {
        public PublicIpAddressTests(bool isAsync, string apiVersion)
        : base(isAsync, PublicIPAddressResource.ResourceType, apiVersion)
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
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, publicIpName, publicIp);
            Response<PublicIPAddressResource> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.That(putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get PublicIPAddress
            Response<PublicIPAddressResource> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(publicIpName);
            Assert.That(getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes, Is.EqualTo(4));
            Assert.That(getPublicIpAddressResponse.Value.Data.ResourceGuid, Is.Not.Null);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddressResource> getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddressResource> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddressResource in a subscription
            AsyncPageable<PublicIPAddressResource> getPublicIpAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddressResource> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.That(getPublicIpAddressListSubscriptionResponse, Is.Not.Empty);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIpAddressResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.That(getPublicIpAddressListResponse, Is.Empty);
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
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel, },
                IdleTimeoutInMinutes = 16,
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, publicIpName, publicIp);
            Response<PublicIPAddressResource> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.That(putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get PublicIPAddress
            Response<PublicIPAddressResource> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(publicIpName);

            // Add Reverse FQDN
            reverseFqdn = getPublicIpAddressResponse.Value.Data.DnsSettings.Fqdn;
            getPublicIpAddressResponse.Value.Data.DnsSettings.ReverseFqdn = reverseFqdn;

            putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, publicIpName, getPublicIpAddressResponse.Value.Data);
            putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.That(putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get PublicIPAddress
            getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(publicIpName);
            Assert.That(getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes, Is.EqualTo(16));
            Assert.That(getPublicIpAddressResponse.Value.Data.DnsSettings.ReverseFqdn, Is.EqualTo(reverseFqdn));

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddressResource> getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddressResource> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddressResource in a subscription
            AsyncPageable<PublicIPAddressResource> getPublicIpAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddressResource> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.That(getPublicIpAddressListSubscriptionResponse, Is.Not.Empty);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIpAddressResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.That(getPublicIpAddressListResponse, Is.Empty);
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
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = NetworkIPVersion.IPv6
            };

            // Put PublicIPAddress
            var publicIPAddressCollection = resourceGroup.GetPublicIPAddresses();
            var putPublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, ipv6PublicIpName, ipv6PublicIp);
            Response<PublicIPAddressResource> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.That(putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get PublicIPAddress
            Response<PublicIPAddressResource> getPublicIpAddressResponse = await publicIPAddressCollection.GetAsync(ipv6PublicIpName);
            Assert.That(getPublicIpAddressResponse, Is.Not.Null);

            Assert.That(getPublicIpAddressResponse.Value.Data.PublicIPAddressVersion, Is.EqualTo(NetworkIPVersion.IPv6));
            Assert.That(getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes, Is.EqualTo(4));
            Assert.That(getPublicIpAddressResponse.Value.Data.ResourceGuid, Is.Not.Null);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddressResource> getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            List<PublicIPAddressResource> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddressResource in a subscription
            AsyncPageable<PublicIPAddressResource> getPublicIpAddressListSubscriptionResponseAP = subscription.GetPublicIPAddressesAsync();
            List<PublicIPAddressResource> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.That(getPublicIpAddressListSubscriptionResponse, Is.Not.Empty);

            // Delete PublicIPAddress
            var deleteOperation = await getPublicIpAddressResponse.Value.DeleteAsync(WaitUntil.Completed);
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressCollection.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.That(getPublicIpAddressListResponse, Is.Empty);

            // Also check IPv4 PublicIP
            // Create the parameter for PUT PublicIPAddress
            string ipv4PublicIpName = Recording.GenerateAssetName("csmipv4publicip");

            var ipv4PublicIp = new PublicIPAddressData()
            {
                Location = TestEnvironment.Location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = NetworkIPVersion.IPv4,
            };

            // Put PublicIPAddress
            var putIpv4PublicIpAddressResponseOperation = await publicIPAddressCollection.CreateOrUpdateAsync(WaitUntil.Completed, ipv4PublicIpName, ipv4PublicIp);
            Response<PublicIPAddressResource> putIpv4PublicIpAddressResponse = await putIpv4PublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.That(putIpv4PublicIpAddressResponse.Value.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));

            // Get PublicIPAddress
            Response<PublicIPAddressResource> getIpv4PublicIpAddressResponse = await publicIPAddressCollection.GetAsync(ipv4PublicIpName);
            Assert.That(getIpv4PublicIpAddressResponse, Is.Not.Null);

            Assert.That(getIpv4PublicIpAddressResponse.Value.Data.PublicIPAddressVersion, Is.EqualTo(NetworkIPVersion.IPv4));
            Assert.That(getIpv4PublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes, Is.EqualTo(4));
            Assert.That(getIpv4PublicIpAddressResponse.Value.Data.ResourceGuid, Is.Not.Null);

            // Delete PublicIPAddress
            await getIpv4PublicIpAddressResponse.Value.DeleteAsync(WaitUntil.Completed);
        }

        private static void ArePublicIpAddressesEqual(PublicIPAddressData publicIpAddress1, PublicIPAddressData publicIpAddress2)
        {
            Assert.That(publicIpAddress2.Name, Is.EqualTo(publicIpAddress1.Name));
            Assert.That(publicIpAddress2.Location, Is.EqualTo(publicIpAddress1.Location));
            // TODO
            //Assert.AreEqual(publicIpAddress1.Id, publicIpAddress2.Id);
            Assert.That(publicIpAddress2.DnsSettings.DomainNameLabel, Is.EqualTo(publicIpAddress1.DnsSettings.DomainNameLabel));
            Assert.That(publicIpAddress2.DnsSettings.Fqdn, Is.EqualTo(publicIpAddress1.DnsSettings.Fqdn));
            Assert.That(publicIpAddress2.IdleTimeoutInMinutes, Is.EqualTo(publicIpAddress1.IdleTimeoutInMinutes));
            Assert.That(publicIpAddress2.Tags.Count, Is.EqualTo(publicIpAddress1.Tags.Count));
            Assert.That(publicIpAddress2.PublicIPAddressVersion, Is.EqualTo(publicIpAddress1.PublicIPAddressVersion));
        }
    }
}
