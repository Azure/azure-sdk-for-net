// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Azure.Test;
using Azure.Core.TestFramework;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class PublicIpAddressTests : NetworkTestsManagementClientBase
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

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task PublicIpAddressApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create the parameter for PUT PublicIPAddress
            string publicIpName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");

            PublicIPAddress publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, publicIpName);
            Assert.AreEqual(4, getPublicIpAddressResponse.Value.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIpAddressResponse.Value.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = NetworkManagementClient.PublicIPAddresses.ListAsync(resourceGroupName);
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.First());

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = NetworkManagementClient.PublicIPAddresses.ListAllAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            PublicIPAddressesDeleteOperation deleteOperation = await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, publicIpName);
            await WaitForCompletionAsync(deleteOperation);

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = NetworkManagementClient.PublicIPAddresses.ListAsync(resourceGroupName);
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);
        }

        [Test]
        public async Task PublicIpAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await ResourcesManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create the parameter for PUT PublicIPAddress
            string publicIpName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");
            string reverseFqdn;

            PublicIPAddress publicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel, },
                IdleTimeoutInMinutes = 16,
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, publicIpName);

            // Add Reverse FQDN
            reverseFqdn = getPublicIpAddressResponse.Value.DnsSettings.Fqdn;
            getPublicIpAddressResponse.Value.DnsSettings.ReverseFqdn = reverseFqdn;

            putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, publicIpName, getPublicIpAddressResponse);
            putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            // Get PublicIPAddress
            getPublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, publicIpName);
            Assert.AreEqual(16, getPublicIpAddressResponse.Value.IdleTimeoutInMinutes);
            Assert.AreEqual(reverseFqdn, getPublicIpAddressResponse.Value.DnsSettings.ReverseFqdn);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = NetworkManagementClient.PublicIPAddresses.ListAsync(resourceGroupName);
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.First());

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = NetworkManagementClient.PublicIPAddresses.ListAllAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            PublicIPAddressesDeleteOperation deleteOperation = await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, publicIpName);
            await WaitForCompletionAsync(deleteOperation);

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = NetworkManagementClient.PublicIPAddresses.ListAsync(resourceGroupName);
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);
        }

        [Test]
        public async Task PublicIpAddressApiTestIPv6()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await ResourcesManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            // Create the parameter for PUT PublicIPAddress
            string ipv6PublicIpName = Recording.GenerateAssetName("csmipv6publicip");
            string domainNameLabel = Recording.GenerateAssetName("csmdnslabelpublicip");

            PublicIPAddress ipv6PublicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = IPVersion.IPv6
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, ipv6PublicIpName, ipv6PublicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await WaitForCompletionAsync(putPublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, ipv6PublicIpName);
            Assert.NotNull(getPublicIpAddressResponse);

            Assert.AreEqual(IPVersion.IPv6, getPublicIpAddressResponse.Value.PublicIPAddressVersion);
            Assert.AreEqual(4, getPublicIpAddressResponse.Value.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIpAddressResponse.Value.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = NetworkManagementClient.PublicIPAddresses.ListAsync(resourceGroupName);
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.First());

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = NetworkManagementClient.PublicIPAddresses.ListAllAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            PublicIPAddressesDeleteOperation deleteOperation = await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, ipv6PublicIpName);
            await WaitForCompletionAsync(deleteOperation);

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = NetworkManagementClient.PublicIPAddresses.ListAsync(resourceGroupName);
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);

            // Also check IPv4 PublicIP
            // Create the parameter for PUT PublicIPAddress
            string ipv4PublicIpName = Recording.GenerateAssetName("csmipv4publicip");

            PublicIPAddress ipv4PublicIp = new PublicIPAddress()
            {
                Location = location,
                Tags = new Dictionary<string, string>() { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = IPVersion.IPv4,
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putIpv4PublicIpAddressResponseOperation = await NetworkManagementClient.PublicIPAddresses.StartCreateOrUpdateAsync(resourceGroupName, ipv4PublicIpName, ipv4PublicIp);
            Response<PublicIPAddress> putIpv4PublicIpAddressResponse = await WaitForCompletionAsync(putIpv4PublicIpAddressResponseOperation);
            Assert.AreEqual("Succeeded", putIpv4PublicIpAddressResponse.Value.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getIpv4PublicIpAddressResponse = await NetworkManagementClient.PublicIPAddresses.GetAsync(resourceGroupName, ipv4PublicIpName);
            Assert.NotNull(getIpv4PublicIpAddressResponse);

            Assert.AreEqual(IPVersion.IPv4, getIpv4PublicIpAddressResponse.Value.PublicIPAddressVersion);
            Assert.AreEqual(4, getIpv4PublicIpAddressResponse.Value.IdleTimeoutInMinutes);
            Assert.NotNull(getIpv4PublicIpAddressResponse.Value.ResourceGuid);

            // Delete PublicIPAddress
            await NetworkManagementClient.PublicIPAddresses.StartDeleteAsync(resourceGroupName, ipv4PublicIpName);
        }

        private static void ArePublicIpAddressesEqual(PublicIPAddress publicIpAddress1, PublicIPAddress publicIpAddress2)
        {
            Assert.AreEqual(publicIpAddress1.Name, publicIpAddress2.Name);
            Assert.AreEqual(publicIpAddress1.Location, publicIpAddress2.Location);
            Assert.AreEqual(publicIpAddress1.Id, publicIpAddress2.Id);
            Assert.AreEqual(publicIpAddress1.DnsSettings.DomainNameLabel, publicIpAddress2.DnsSettings.DomainNameLabel);
            Assert.AreEqual(publicIpAddress1.DnsSettings.Fqdn, publicIpAddress2.DnsSettings.Fqdn);
            Assert.AreEqual(publicIpAddress1.IdleTimeoutInMinutes, publicIpAddress2.IdleTimeoutInMinutes);
            Assert.AreEqual(publicIpAddress1.Tags.Count, publicIpAddress2.Tags.Count);
            Assert.AreEqual(publicIpAddress1.PublicIPAddressVersion, publicIpAddress2.PublicIPAddressVersion);
        }
    }
}
