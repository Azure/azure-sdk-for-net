﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

namespace Azure.ResourceManager.Network.Tests.Tests
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

        //[TearDown]
        //public async Task CleanupResourceGroup()
        //{
        //    await CleanupResourceGroupsAsync();
        //}

        [Test]
        public async Task PublicIpAddressApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await NetworkManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));

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
            var publicIPAddressContainer = GetPublicIPAddressContainer(resourceGroupName);
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressContainer.GetAsync(publicIpName);
            Assert.AreEqual(4, getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIpAddressResponse.Value.Data.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = publicIPAddressContainer.GetAllAsync();
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = ArmClient.DefaultSubscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            PublicIPAddressesDeleteOperation deleteOperation = await getPublicIpAddressResponse.Value.StartDeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressContainer.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);
        }

        [Test]
        public async Task PublicIpAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await ResourcesManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));

            // Create the parameter for PUT PublicIPAddress
            string publicIpName = Recording.GenerateAssetName("ipname");
            string domainNameLabel = Recording.GenerateAssetName("domain");
            string reverseFqdn;

            var publicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings() { DomainNameLabel = domainNameLabel, },
                IdleTimeoutInMinutes = 16,
            };

            // Put PublicIPAddress
            var publicIPAddressContainer = GetPublicIPAddressContainer(resourceGroupName);
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(publicIpName, publicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressContainer.GetAsync(publicIpName);

            // Add Reverse FQDN
            reverseFqdn = getPublicIpAddressResponse.Value.Data.DnsSettings.Fqdn;
            getPublicIpAddressResponse.Value.Data.DnsSettings.ReverseFqdn = reverseFqdn;

            putPublicIpAddressResponseOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(publicIpName, getPublicIpAddressResponse.Value.Data);
            putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            getPublicIpAddressResponse = await publicIPAddressContainer.GetAsync(publicIpName);
            Assert.AreEqual(16, getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.AreEqual(reverseFqdn, getPublicIpAddressResponse.Value.Data.DnsSettings.ReverseFqdn);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = publicIPAddressContainer.GetAllAsync();
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = ArmClient.DefaultSubscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            PublicIPAddressesDeleteOperation deleteOperation = await getPublicIpAddressResponse.Value.StartDeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressContainer.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);
        }

        [Test]
        public async Task PublicIpAddressApiTestIPv6()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = await ResourcesManagementTestUtilities.GetResourceLocation(ResourceManagementClient, "Microsoft.Network/publicIPAddresses");
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new Resources.Models.ResourceGroup(location));

            // Create the parameter for PUT PublicIPAddress
            string ipv6PublicIpName = Recording.GenerateAssetName("csmipv6publicip");
            string domainNameLabel = Recording.GenerateAssetName("csmdnslabelpublicip");

            var ipv6PublicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = IPVersion.IPv6
            };

            // Put PublicIPAddress
            var publicIPAddressContainer = GetPublicIPAddressContainer(resourceGroupName);
            PublicIPAddressesCreateOrUpdateOperation putPublicIpAddressResponseOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(ipv6PublicIpName, ipv6PublicIp);
            Response<PublicIPAddress> putPublicIpAddressResponse = await putPublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putPublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getPublicIpAddressResponse = await publicIPAddressContainer.GetAsync(ipv6PublicIpName);
            Assert.NotNull(getPublicIpAddressResponse);

            Assert.AreEqual(IPVersion.IPv6, getPublicIpAddressResponse.Value.Data.PublicIPAddressVersion);
            Assert.AreEqual(4, getPublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getPublicIpAddressResponse.Value.Data.ResourceGuid);

            // Get List of PublicIPAddress
            AsyncPageable<PublicIPAddress> getPublicIpAddressListResponseAP = publicIPAddressContainer.GetAllAsync();
            List<PublicIPAddress> getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Has.One.EqualTo(getPublicIpAddressListResponse);
            ArePublicIpAddressesEqual(getPublicIpAddressResponse.Value.Data, getPublicIpAddressListResponse.First().Data);

            // Get List of PublicIPAddress in a subscription
            AsyncPageable<PublicIPAddress> getPublicIpAddressListSubscriptionResponseAP = ArmClient.DefaultSubscription.GetPublicIPAddressesAsync();
            List<PublicIPAddress> getPublicIpAddressListSubscriptionResponse = await getPublicIpAddressListSubscriptionResponseAP.ToEnumerableAsync();
            Assert.IsNotEmpty(getPublicIpAddressListSubscriptionResponse);

            // Delete PublicIPAddress
            PublicIPAddressesDeleteOperation deleteOperation = await getPublicIpAddressResponse.Value.StartDeleteAsync();
            await deleteOperation.WaitForCompletionResponseAsync();;

            // Get PublicIPAddress
            getPublicIpAddressListResponseAP = publicIPAddressContainer.GetAllAsync();
            getPublicIpAddressListResponse = await getPublicIpAddressListResponseAP.ToEnumerableAsync();
            Assert.IsEmpty(getPublicIpAddressListResponse);

            // Also check IPv4 PublicIP
            // Create the parameter for PUT PublicIPAddress
            string ipv4PublicIpName = Recording.GenerateAssetName("csmipv4publicip");

            var ipv4PublicIp = new PublicIPAddressData()
            {
                Location = location,
                Tags = { { "key", "value" } },
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                PublicIPAddressVersion = IPVersion.IPv4,
            };

            // Put PublicIPAddress
            PublicIPAddressesCreateOrUpdateOperation putIpv4PublicIpAddressResponseOperation = await publicIPAddressContainer.StartCreateOrUpdateAsync(ipv4PublicIpName, ipv4PublicIp);
            Response<PublicIPAddress> putIpv4PublicIpAddressResponse = await putIpv4PublicIpAddressResponseOperation.WaitForCompletionAsync();;
            Assert.AreEqual("Succeeded", putIpv4PublicIpAddressResponse.Value.Data.ProvisioningState.ToString());

            // Get PublicIPAddress
            Response<PublicIPAddress> getIpv4PublicIpAddressResponse = await publicIPAddressContainer.GetAsync(ipv4PublicIpName);
            Assert.NotNull(getIpv4PublicIpAddressResponse);

            Assert.AreEqual(IPVersion.IPv4, getIpv4PublicIpAddressResponse.Value.Data.PublicIPAddressVersion);
            Assert.AreEqual(4, getIpv4PublicIpAddressResponse.Value.Data.IdleTimeoutInMinutes);
            Assert.NotNull(getIpv4PublicIpAddressResponse.Value.Data.ResourceGuid);

            // Delete PublicIPAddress
            await getIpv4PublicIpAddressResponse.Value.StartDeleteAsync();
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
