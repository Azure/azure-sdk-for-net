using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Networks.Tests
{
    public class PublicIpAddressTests
    {
        [Fact]
        public void PublicIpAddressApiTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                
                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/publicIPAddresses");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });


                // Create the parameter for PUT PublicIpAddress
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var publicIp = new PublicIpAddress()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                    PublicIPAllocationMethod = IpAllocationMethod.Dynamic,
                    DnsSettings = new PublicIpAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel
                    }
                };

                // Put PublicIpAddress
                var putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);
                
                // Get PublicIpAddress
                var getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(4, getPublicIpAddressResponse.IdleTimeoutInMinutes);

                // Get List of PublicIpAddress 
                var getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(1, getPublicIpAddressListResponse.Value.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.Value[0]);

                // Get List of PublicIpAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkResourceProviderClient.PublicIpAddresses.ListAll();
                Assert.Equal(1, getPublicIpAddressListSubscriptionResponse.Value.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListSubscriptionResponse.Value[0]);

                // Delete PublicIpAddress
                networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, publicIpName);

                // Get PublicIpAddress
                getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(0, getPublicIpAddressListResponse.Value.Count);
            }
        }

        [Fact]
        public void PublicIpAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/publicIPAddresses");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create the parameter for PUT PublicIpAddress
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();
                string reverseFqdn;

                var publicIp = new PublicIpAddress()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                    PublicIPAllocationMethod = IpAllocationMethod.Dynamic,
                    DnsSettings = new PublicIpAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel,
                    },
                    IdleTimeoutInMinutes = 16,
                };

                // Put PublicIpAddress
                var putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);

                // Get PublicIpAddress
                var getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);

                // Add Reverse FQDN
                reverseFqdn = getPublicIpAddressResponse.DnsSettings.Fqdn;
                getPublicIpAddressResponse.DnsSettings.ReverseFqdn = reverseFqdn;

                putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, getPublicIpAddressResponse);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);

                // Get PublicIpAddress
                getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(16, getPublicIpAddressResponse.IdleTimeoutInMinutes);
                Assert.Equal(reverseFqdn, getPublicIpAddressResponse.DnsSettings.ReverseFqdn);

                // Get List of PublicIpAddress 
                var getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(1, getPublicIpAddressListResponse.Value.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.Value[0]);

                // Get List of PublicIpAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkResourceProviderClient.PublicIpAddresses.ListAll();
                Assert.Equal(1, getPublicIpAddressListSubscriptionResponse.Value.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListSubscriptionResponse.Value[0]);

                // Delete PublicIpAddress
                networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, publicIpName);

                // Get PublicIpAddress
                getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(0, getPublicIpAddressListResponse.Value.Count);

            }
        }

        private static void ArePublicIpAddressesEqual(PublicIpAddress publicIpAddress1, PublicIpAddress publicIpAddress2)
        {
            Assert.Equal(publicIpAddress1.Name, publicIpAddress2.Name);
            Assert.Equal(publicIpAddress1.Location, publicIpAddress2.Location);
            Assert.Equal(publicIpAddress1.Id, publicIpAddress2.Id);
            Assert.Equal(publicIpAddress1.DnsSettings.DomainNameLabel, publicIpAddress2.DnsSettings.DomainNameLabel);
            Assert.Equal(publicIpAddress1.DnsSettings.Fqdn, publicIpAddress2.DnsSettings.Fqdn);
            Assert.Equal(publicIpAddress1.IdleTimeoutInMinutes, publicIpAddress2.IdleTimeoutInMinutes);
            Assert.Equal(publicIpAddress1.Tags.Count, publicIpAddress2.Tags.Count);
        }
    }
}