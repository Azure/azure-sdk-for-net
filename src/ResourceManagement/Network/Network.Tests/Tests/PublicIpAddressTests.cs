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
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class PublicIpAddressTests
    {
        [Fact]
        public void PublicIpAddressApiTest()
        {
            var handler1 = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                
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
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);
                
                // Get PublicIPAddress
                var getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(4, getPublicIpAddressResponse.IdleTimeoutInMinutes);
                Assert.NotNull(getPublicIpAddressResponse.ResourceGuid);

                // Get List of PublicIPAddress 
                var getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(1, getPublicIpAddressListResponse.Count());
                ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.First());

                // Get List of PublicIPAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkManagementClient.PublicIPAddresses.ListAll();
                Assert.NotEqual(0, getPublicIpAddressListSubscriptionResponse.Count());
                
                // Delete PublicIPAddress
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, publicIpName);
                
                // Get PublicIPAddress
                getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(0, getPublicIpAddressListResponse.Count());
            }
        }

        [Fact]
        public void PublicIpAddressApiTestWithIdletTimeoutAndReverseFqdn()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

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
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);

                // Get PublicIPAddress
                var getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);
                
                // Add Reverse FQDN
                reverseFqdn = getPublicIpAddressResponse.DnsSettings.Fqdn;
                getPublicIpAddressResponse.DnsSettings.ReverseFqdn = reverseFqdn;

                putPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, publicIpName, getPublicIpAddressResponse);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);

                // Get PublicIPAddress
                getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);
                Assert.Equal(16, getPublicIpAddressResponse.IdleTimeoutInMinutes);
                Assert.Equal(reverseFqdn, getPublicIpAddressResponse.DnsSettings.ReverseFqdn);

                // Get List of PublicIPAddress 
                var getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(1, getPublicIpAddressListResponse.Count());
                ArePublicIpAddressesEqual(getPublicIpAddressResponse, getPublicIpAddressListResponse.First());

                // Get List of PublicIPAddress in a subscription
                var getPublicIpAddressListSubscriptionResponse = networkManagementClient.PublicIPAddresses.ListAll();
                Assert.NotEqual(0, getPublicIpAddressListSubscriptionResponse.Count());
                
                // Delete PublicIPAddress
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, publicIpName);
                
                // Get PublicIPAddress
                getPublicIpAddressListResponse = networkManagementClient.PublicIPAddresses.List(resourceGroupName);
                Assert.Equal(0, getPublicIpAddressListResponse.Count());

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