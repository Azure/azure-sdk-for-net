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

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler);
                
                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/publicIPAddresses");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });


                // Create the parameter for PUT PublicIPAddress
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var publicIp = new PublicIPAddress()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                    DnsSettings = new PublicIPAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel
                    }
                };

                // Put PublicIPAddress
                var putPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);
                
                // Get PublicIPAddress
                var getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressResponse.StatusCode);
                Assert.Equal(4, getPublicIpAddressResponse.PublicIPAddress.IdleTimeoutInMinutes);
                Assert.NotNull(getPublicIpAddressResponse.PublicIPAddress.ResourceGuid);

                // Get List of PublicIPAddress 
                var getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListResponse.PublicIPAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIPAddress, getPublicIpAddressListResponse.PublicIPAddresses[0]);

                // Get List of PublicIPAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkManagementClient.PublicIPAddresses.ListAll();
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListSubscriptionResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListSubscriptionResponse.PublicIPAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIPAddress, getPublicIpAddressListSubscriptionResponse.PublicIPAddresses[0]);

                // Delete PublicIPAddress
                var deletePublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddressResponse.StatusCode);

                // Get PublicIPAddress
                getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(0, getPublicIpAddressListResponse.PublicIPAddresses.Count);
            }
        }

        [Fact]
        public void PublicIpAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/publicIPAddresses");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create the parameter for PUT PublicIPAddress
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();
                string reverseFqdn;

                var publicIp = new PublicIPAddress()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                    DnsSettings = new PublicIPAddressDnsSettings()
                    {
                        DomainNameLabel = domainNameLabel,
                    },
                    IdleTimeoutInMinutes = 16,
                };

                // Put PublicIPAddress
                var putPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);

                // Get PublicIPAddress
                var getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressResponse.StatusCode);

                // Add Reverse FQDN
                reverseFqdn = getPublicIpAddressResponse.PublicIPAddress.DnsSettings.Fqdn;
                getPublicIpAddressResponse.PublicIPAddress.DnsSettings.ReverseFqdn = reverseFqdn;

                putPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, publicIpName, getPublicIpAddressResponse.PublicIPAddress);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);

                // Get PublicIPAddress
                getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressResponse.StatusCode);
                Assert.Equal(16, getPublicIpAddressResponse.PublicIPAddress.IdleTimeoutInMinutes);
                Assert.Equal(reverseFqdn, getPublicIpAddressResponse.PublicIPAddress.DnsSettings.ReverseFqdn);

                // Get List of PublicIPAddress 
                var getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListResponse.PublicIPAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIPAddress, getPublicIpAddressListResponse.PublicIPAddresses[0]);

                // Get List of PublicIPAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkManagementClient.PublicIPAddresses.ListAll();
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListSubscriptionResponse.StatusCode);
                Assert.Equal(1, getPublicIpAddressListSubscriptionResponse.PublicIPAddresses.Count);
                ArePublicIpAddressesEqual(getPublicIpAddressResponse.PublicIPAddress, getPublicIpAddressListSubscriptionResponse.PublicIPAddresses[0]);

                // Delete PublicIPAddress
                var deletePublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddressResponse.StatusCode);

                // Get PublicIPAddress
                getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getPublicIpAddressListResponse.StatusCode);
                Assert.Equal(0, getPublicIpAddressListResponse.PublicIPAddresses.Count);

            }
        }

        private static void ArePublicIpAddressesEqual(PublicIPAddress publicIpAddress1, PublicIPAddress publicIpAddress2)
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