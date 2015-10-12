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
                    PublicIpAllocationMethod = IpAllocationMethod.Dynamic,
                    DnsSettings = new PublicIpAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel
                    }
                };

                // Put PublicIpAddress
                var putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);
                
                // Get PublicIpAddress
                var getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressResponse.StatusCode);
                Assert.Equal(4, getPublicIpAddressResponse.PublicIpAddress.IdleTimeoutInMinutes);
                Assert.NotNull(getPublicIpAddressResponse.PublicIpAddress.ResourceGuid);

                // Get List of PublicIpAddress 
                var getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListResponse.PublicIpAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIpAddress, getPublicIpAddressListResponse.PublicIpAddresses[0]);

                // Get List of PublicIpAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkResourceProviderClient.PublicIpAddresses.ListAll();
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListSubscriptionResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListSubscriptionResponse.PublicIpAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIpAddress, getPublicIpAddressListSubscriptionResponse.PublicIpAddresses[0]);

                // Delete PublicIpAddress
                var deletePublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddressResponse.StatusCode);

                // Get PublicIpAddress
                getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(0, getPublicIpAddressListResponse.PublicIpAddresses.Count);
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
                    PublicIpAllocationMethod = IpAllocationMethod.Dynamic,
                    DnsSettings = new PublicIpAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel,
                    },
                    IdleTimeoutInMinutes = 16,
                };

                // Put PublicIpAddress
                var putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);

                // Get PublicIpAddress
                var getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressResponse.StatusCode);

                // Add Reverse FQDN
                reverseFqdn = getPublicIpAddressResponse.PublicIpAddress.DnsSettings.Fqdn;
                getPublicIpAddressResponse.PublicIpAddress.DnsSettings.ReverseFqdn = reverseFqdn;

                putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, getPublicIpAddressResponse.PublicIpAddress);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);

                // Get PublicIpAddress
                getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressResponse.StatusCode);
                Assert.Equal(16, getPublicIpAddressResponse.PublicIpAddress.IdleTimeoutInMinutes);
                Assert.Equal(reverseFqdn, getPublicIpAddressResponse.PublicIpAddress.DnsSettings.ReverseFqdn);

                // Get List of PublicIpAddress 
                var getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListResponse.PublicIpAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIpAddress, getPublicIpAddressListResponse.PublicIpAddresses[0]);

                // Get List of PublicIpAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkResourceProviderClient.PublicIpAddresses.ListAll();
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListSubscriptionResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListSubscriptionResponse.PublicIpAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIpAddress, getPublicIpAddressListSubscriptionResponse.PublicIpAddresses[0]);

                // Delete PublicIpAddress
                var deletePublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddressResponse.StatusCode);

                // Get PublicIpAddress
                getPublicIpAddressListResponse = networkResourceProviderClient.PublicIpAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(0, getPublicIpAddressListResponse.PublicIpAddresses.Count);

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