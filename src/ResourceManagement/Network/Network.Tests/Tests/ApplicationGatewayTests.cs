using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using System;
using Microsoft.Azure.Management.Network;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.Network.Models;

namespace Networks.Tests
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using SubResource = Microsoft.Azure.Management.Network.Models.SubResource;

    public class ApplicationGatewayTests
    {
        private static string GetChildAppGwResourceId(string subscriptionId,
                                                        string resourceGroupName,
                                                        string appGwname,
                                                        string childResourceType,
                                                        string childResourceName)
        {
            return string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/applicationGateways/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    appGwname,
                    childResourceType,
                    childResourceName);
        }

        private ApplicationGatewaySslCertificate CreateSslCertificate(string sslCertName, string password)
        {
            X509Certificate2 cert = new X509Certificate2("ApplicationGatewayCertificate\\GW5000.pfx", password, X509KeyStorageFlags.Exportable);
            ApplicationGatewaySslCertificate sslCert = new ApplicationGatewaySslCertificate()
            {
                Name = sslCertName,
                Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password)),                
                Password = password
            };

            return sslCert;
        }

        private ApplicationGateway CreateApplicationGateway(string location, Subnet subnet, string resourceGroupName, string subscriptionId)
        {
            var appGwName = TestUtilities.GenerateName();
            var gatewayIPConfigName = TestUtilities.GenerateName();
            var frontendIPConfigName = TestUtilities.GenerateName();
            var frontendPortName = TestUtilities.GenerateName();
            var backendAddressPoolName = TestUtilities.GenerateName();
            var backendHttpSettingsName = TestUtilities.GenerateName();
            var requestRoutingRuleName = TestUtilities.GenerateName();
            var httpListenerName = TestUtilities.GenerateName();
            
            var appGw = new ApplicationGateway()
            {
                Location = location,
                Sku = new ApplicationGatewaySku()
                    {
                        Name = ApplicationGatewaySkuName.StandardSmall,
                        Tier = ApplicationGatewayTier.Standard,
                        Capacity = 2
                    },
                GatewayIPConfigurations = new List<ApplicationGatewayIPConfiguration>()
                    {
                        new ApplicationGatewayIPConfiguration()
                        {
                            Name = gatewayIPConfigName,
                            Subnet = new SubResource()
                            {
                                Id = subnet.Id
                            }
                        }
                    },            
                FrontendIPConfigurations = new List<ApplicationGatewayFrontendIPConfiguration>() 
                    { 
                        new ApplicationGatewayFrontendIPConfiguration()
                        {
                            Name = frontendIPConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                            Subnet = new SubResource()
                            {
                                Id = subnet.Id
                            }                          
                        }                    
                    },
                FrontendPorts = new List<ApplicationGatewayFrontendPort>
                    {
                        new ApplicationGatewayFrontendPort()
                        {
                            Name = frontendPortName,
                            Port = 80
                        }
                    },
                BackendAddressPools = new List<ApplicationGatewayBackendAddressPool>
                    {
                        new ApplicationGatewayBackendAddressPool()
                        {
                            Name = backendAddressPoolName,
                            BackendAddresses = new List<ApplicationGatewayBackendAddress>()
                            {
                                new ApplicationGatewayBackendAddress()
                                {
                                    IpAddress = "104.42.6.202"
                                },
                                new ApplicationGatewayBackendAddress()
                                {
                                    IpAddress = "23.99.1.115"
                                }
                            }
                        }
                    },
                BackendHttpSettingsCollection = new List<ApplicationGatewayBackendHttpSettings> 
                    {
                        new ApplicationGatewayBackendHttpSettings()
                        {
                            Name = backendHttpSettingsName,
                            Port = 80,
                            Protocol = ApplicationGatewayProtocol.Http,
                            CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled
                        }
                    },
                HttpListeners = new List<ApplicationGatewayHttpListener>
                    {
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListenerName,
                            FrontendPort = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIPConfiguration = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                            },
                            SslCertificate = null,
                            Protocol = ApplicationGatewayProtocol.Http
                        }
                    },
                RequestRoutingRules = new List<ApplicationGatewayRequestRoutingRule>()
                    {
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRuleName,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                            }
                        }
                    }
            };
            return appGw;
        }

        private ApplicationGateway CreateApplicationGatewayWithSsl(string location, Subnet subnet, string resourceGroupName, string subscriptionId)
        {
            var appGwName = TestUtilities.GenerateName();
            var gatewayIPConfigName = TestUtilities.GenerateName();
            var frontendIPConfigName = TestUtilities.GenerateName();
            var frontendPortName = TestUtilities.GenerateName();
            var backendAddressPoolName = TestUtilities.GenerateName();
            var backendHttpSettingsName = TestUtilities.GenerateName();
            var requestRoutingRuleName = TestUtilities.GenerateName();
            var sslCertName = TestUtilities.GenerateName();            
            var httpListenerName = TestUtilities.GenerateName();
            var password = "1234";                        
            ApplicationGatewaySslCertificate sslCert = CreateSslCertificate(sslCertName, password);

            var appGw = new ApplicationGateway()
            {
                Location = location,
                Sku = new ApplicationGatewaySku()
                {
                    Name = ApplicationGatewaySkuName.StandardLarge,
                    Tier = ApplicationGatewayTier.Standard,
                    Capacity = 2
                },
                GatewayIPConfigurations = new List<ApplicationGatewayIPConfiguration>()
                    {
                        new ApplicationGatewayIPConfiguration()
                        {
                            Name = gatewayIPConfigName,
                            Subnet = new SubResource()
                            {
                                Id = subnet.Id
                            }
                        }
                    },
                SslCertificates = new List<ApplicationGatewaySslCertificate>()
                    {
                        sslCert
                    },
                FrontendIPConfigurations = new List<ApplicationGatewayFrontendIPConfiguration>() 
                    { 
                        new ApplicationGatewayFrontendIPConfiguration()
                        {
                            Name = frontendIPConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                            Subnet = new SubResource()
                            {
                                Id = subnet.Id
                            } 
                        }                    
                    },
                FrontendPorts = new List<ApplicationGatewayFrontendPort>
                    {
                        new ApplicationGatewayFrontendPort()
                        {
                            Name = frontendPortName,
                            Port = 443
                        }
                    },
                BackendAddressPools = new List<ApplicationGatewayBackendAddressPool>
                    {
                        new ApplicationGatewayBackendAddressPool()
                        {
                            Name = backendAddressPoolName,
                            BackendAddresses = new List<ApplicationGatewayBackendAddress>()
                            {
                                new ApplicationGatewayBackendAddress()
                                {
                                    IpAddress = "10.2.0.1"
                                },
                                new ApplicationGatewayBackendAddress()
                                {
                                    IpAddress = "10.2.0.2"
                                }
                            }
                        }
                    },
                BackendHttpSettingsCollection = new List<ApplicationGatewayBackendHttpSettings> 
                    {
                        new ApplicationGatewayBackendHttpSettings()
                        {
                            Name = backendHttpSettingsName,
                            Port = 80,
                            Protocol = ApplicationGatewayProtocol.Http,
                            CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Enabled
                        }
                    },
                HttpListeners = new List<ApplicationGatewayHttpListener>
                    {
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListenerName,
                            FrontendPort = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIPConfiguration = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                            },
                            SslCertificate = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "sslCertificates", sslCertName)
                            },
                            Protocol = ApplicationGatewayProtocol.Https
                        }
                    },
                RequestRoutingRules = new List<ApplicationGatewayRequestRoutingRule>()
                    {
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRuleName,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                            }
                        }
                    }
            };
            return appGw;
        }

        private void CompareApplicationGateway(ApplicationGateway gw1, ApplicationGateway gw2)
        {

            Assert.Equal(gw1.Name, gw2.Name);
            Assert.Equal(gw1.Sku.Name, gw2.Sku.Name);
            Assert.Equal(gw1.Sku.Tier, gw2.Sku.Tier);
            Assert.Equal(gw1.Sku.Capacity, gw2.Sku.Capacity);
            //Assert.Equal(gw1.GatewayIPConfigurations.Count, gw2.GatewayIPConfigurations.Count);
            //Assert.Equal(gw1.FrontendIPConfigurations.Count, gw2.FrontendIPConfigurations.Count);
            Assert.Equal(gw1.FrontendPorts.Count, gw2.FrontendPorts.Count);
            Assert.Equal(gw1.SslCertificates.Count, gw2.SslCertificates.Count);
            Assert.Equal(gw1.BackendAddressPools.Count, gw2.BackendAddressPools.Count);
            Assert.Equal(gw1.BackendHttpSettingsCollection.Count, gw2.BackendHttpSettingsCollection.Count);
            Assert.Equal(gw1.HttpListeners.Count, gw2.HttpListeners.Count);
            Assert.Equal(gw1.RequestRoutingRules.Count, gw2.RequestRoutingRules.Count);
            //Assert.Equal(gw1.ResourceGuid, gw2.ResourceGuid);
        }

        [Fact(Skip = "TODO: Autorest")]
        public void ApplicationGatewayApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/applicationgateways");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                var vnetName = TestUtilities.GenerateName();
                var subnetName = TestUtilities.GenerateName();                

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);
                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);
                var subnet = getSubnetResponse;

                var appGw = CreateApplicationGateway(location, subnet, resourceGroupName, networkManagementClient.SubscriptionId);     

                // Put AppGw                
                var putAppGwResponse = networkManagementClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGw.Name, appGw);                
                Assert.Equal("Succeeded", putAppGwResponse.ProvisioningState);
                
                // Get AppGw
                var getResp = networkManagementClient.ApplicationGateways.Get(resourceGroupName, appGw.Name);
                CompareApplicationGateway(appGw, getResp);

                //Start AppGw
                networkManagementClient.ApplicationGateways.Start(resourceGroupName, appGw.Name);
                
                //Stop AppGw
                networkManagementClient.ApplicationGateways.Stop(resourceGroupName, appGw.Name);
                
                // Delete AppGw
                networkManagementClient.ApplicationGateways.Delete(resourceGroupName, appGw.Name);
            }
        }        
    }
}