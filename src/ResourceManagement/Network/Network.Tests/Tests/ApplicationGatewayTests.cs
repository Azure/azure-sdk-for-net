using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure;
using System;
using Microsoft.Azure.Management.Network;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.Network.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Networks.Tests
{
    public class ApplicationGatewayTests
    {
        private NetworkResourceProviderClient networkResourceProviderClient = null;
        private string vnetName = null;
        private string subnetName = null;
        private string resourceGroupName = null;
        private string location = null;
        private Subnet subnet = null;
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

        private void Init()
        {
            vnetName = "azsmnet_vnetName";
            subnetName = "azsmnet_subnetName";     
            subnet = CreateSubnet();
        }

        private Subnet CreateSubnet()
        {
            var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);
            var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);            
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Subnet.Id);
            return getSubnetResponse.Subnet;
        }

        private ApplicationGatewaySslCertificate CreateSslCertificate(string sslCertName, string password)
        {
            X509Certificate2 cert = new X509Certificate2("D:\\AppGWe2eTest\\GW5000.pfx", password, X509KeyStorageFlags.Exportable);
            ApplicationGatewaySslCertificate sslCert = new ApplicationGatewaySslCertificate()
            {
                Name = sslCertName,
                Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password)),
                Password = password
            };

            return sslCert;
        }

        private ApplicationGateway CreateApplicationGateway()
        {
            var appGwName = "azsmnet_appGw";
            var gatewayIpConfigName = "azsmnet_gatewayIpConfigName";
            var frontendIpConfigName = "azsmnet_frontendIpConfigName";
            var frontendPortName = "azsmnet_frontendPortName";
            var backendAddressPoolName = "azsmnet_backendAddressPoolName";
            var backendHttpSettingsName = "azsmnet_backendHttpSettingsName";
            var requestRoutingRuleName = "azsmnet_requestRoutingRuleName";
            var httpListenerName = "azsmnet_httpListenerName";
            
            var appGw = new ApplicationGateway()
            {
                Location = location,
                Name = appGwName,
                Sku = new ApplicationGatewaySku()
                    {
                        Name = ApplicationGatewaySkuName.StandardMedium,
                        Tier = ApplicationGatewayTier.Standard,
                        Capacity = 2
                    },
                GatewayIpConfigurations = new List<ApplicationGatewayIpConfiguration>()
                    {
                        new ApplicationGatewayIpConfiguration()
                        {
                            Name = gatewayIpConfigName,
                            Subnet = new ResourceId()
                            {
                                Id = subnet.Id
                            }
                        }
                    },            
                FrontendIpConfigurations = new List<ApplicationGatewayFrontendIpConfiguration>() 
                    { 
                        new ApplicationGatewayFrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                            Subnet = new ResourceId()
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
                            FrontendPort = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIpConfiguration = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIpConfigName)
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
                            HttpListener = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                            }
                        }
                    }
            };
            return appGw;
        }

        private ApplicationGateway CreateApplicationGatewayWithSsl()
        {
            var appGwName = "azsmnet_appGwSsl";
            var gatewayIpConfigName = "azsmnet_gatewayIpConfigNameSsl";
            var frontendIpConfigName = "azsmnet_frontendIpConfigNameSsl";
            var frontendPortName = "azsmnet_frontendPortNameSsl";
            var backendAddressPoolName = "azsmnet_backendAddressPoolNameSsl";
            var backendHttpSettingsName = "azsmnet_backendHttpSettingsNameSsl";
            var requestRoutingRuleName = "azsmnet_requestRoutingRuleNameSsl";
            var sslCertName = "azsmnet_sslCertNameSsl";            
            var httpListenerName = "azsmnet_httpListenerNameSsl";
            var password = "1234";                        
            ApplicationGatewaySslCertificate sslCert = CreateSslCertificate(sslCertName, password);

            var appGw = new ApplicationGateway()
            {
                Location = location,
                Name = appGwName,
                Sku = new ApplicationGatewaySku()
                {
                    Name = ApplicationGatewaySkuName.StandardLarge,
                    Tier = ApplicationGatewayTier.Standard,
                    Capacity = 2
                },
                GatewayIpConfigurations = new List<ApplicationGatewayIpConfiguration>()
                    {
                        new ApplicationGatewayIpConfiguration()
                        {
                            Name = gatewayIpConfigName,
                            Subnet = new ResourceId()
                            {
                                Id = subnet.Id
                            }
                        }
                    },
                SslCertificates = new List<ApplicationGatewaySslCertificate>()
                    {
                        sslCert
                    },
                FrontendIpConfigurations = new List<ApplicationGatewayFrontendIpConfiguration>() 
                    { 
                        new ApplicationGatewayFrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                            Subnet = new ResourceId()
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
                            FrontendPort = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIpConfiguration = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIpConfigName)
                            },
                            SslCertificate = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "sslCertificates", sslCertName)
                            },
                            Protocol = ApplicationGatewayProtocol.Http
                        }
                    },
                RequestRoutingRules = new List<ApplicationGatewayRequestRoutingRule>()
                    {
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRuleName,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new ResourceId()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
            Assert.Equal(gw1.GatewayIpConfigurations.Count, gw2.GatewayIpConfigurations.Count);
            Assert.Equal(gw1.FrontendIpConfigurations.Count, gw2.FrontendIpConfigurations.Count);
            Assert.Equal(gw1.FrontendPorts.Count, gw2.FrontendPorts.Count);
            Assert.Equal(gw1.SslCertificates.Count, gw2.SslCertificates.Count);
            Assert.Equal(gw1.BackendAddressPools.Count, gw2.BackendAddressPools.Count);
            Assert.Equal(gw1.BackendHttpSettingsCollection.Count, gw2.BackendHttpSettingsCollection.Count);
            Assert.Equal(gw1.HttpListeners.Count, gw2.HttpListeners.Count);
            Assert.Equal(gw1.RequestRoutingRules.Count, gw2.RequestRoutingRules.Count);
        }

        [Fact]
        public void ApplicationGatewayApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };            

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                
                location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/applicationgateways");

                resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                Init();
                
                var appGw = CreateApplicationGatewayWithSsl();

                // Put AppGw
                var putAppGwResponse = networkResourceProviderClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGw.Name, appGw);                
                Assert.Equal(HttpStatusCode.OK, putAppGwResponse.StatusCode);
                Assert.Equal("Succeeded", putAppGwResponse.Status);
                
                // Get AppGw
                var getResp = networkResourceProviderClient.ApplicationGateways.Get(resourceGroupName, appGw.Name);
                CompareApplicationGateway(appGw, getResp.ApplicationGateway);

                // List AppGw
                var listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                Assert.Equal(1, listAppGw.ApplicationGateways.Count);

                // List all AppGw
                var listAllAppGw = networkResourceProviderClient.ApplicationGateways.ListAll();
                Assert.Equal(1, listAllAppGw.ApplicationGateways.Count);

                //Add one more gateway
                // Put AppGw
                var appGw2 = CreateApplicationGateway();
                putAppGwResponse = networkResourceProviderClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGw2.Name, appGw2);
                Assert.Equal(HttpStatusCode.OK, putAppGwResponse.StatusCode);
                Assert.Equal("Succeeded", putAppGwResponse.Status);

                // Get AppGw
                getResp = networkResourceProviderClient.ApplicationGateways.Get(resourceGroupName, appGw2.Name);
                CompareApplicationGateway(appGw2, getResp.ApplicationGateway);

                // List AppGw
                listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                Assert.Equal(2, listAppGw.ApplicationGateways.Count);

                // List all AppGw
                listAllAppGw = networkResourceProviderClient.ApplicationGateways.ListAll();
                Assert.Equal(2, listAllAppGw.ApplicationGateways.Count);

                //Start AppGw
                var startResult = networkResourceProviderClient.ApplicationGateways.Start(resourceGroupName, appGw.Name);
                Assert.Equal(HttpStatusCode.OK, startResult.StatusCode);
                Assert.Equal("Succeeded", startResult.Status);

                startResult = networkResourceProviderClient.ApplicationGateways.Start(resourceGroupName, appGw2.Name);
                Assert.Equal(HttpStatusCode.OK, startResult.StatusCode);
                Assert.Equal("Succeeded", startResult.Status);
                
                //Stop AppGw
                var stopResult = networkResourceProviderClient.ApplicationGateways.Stop(resourceGroupName, appGw.Name);
                Assert.Equal(HttpStatusCode.OK, stopResult.StatusCode);
                Assert.Equal("Succeeded", stopResult.Status);

                stopResult = networkResourceProviderClient.ApplicationGateways.Stop(resourceGroupName, appGw2.Name);
                Assert.Equal(HttpStatusCode.OK, stopResult.StatusCode);
                Assert.Equal("Succeeded", stopResult.Status);
                
                // Delete AppGw
                var deleteResult = networkResourceProviderClient.ApplicationGateways.Delete(resourceGroupName, appGw.Name);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);

                deleteResult = networkResourceProviderClient.ApplicationGateways.Delete(resourceGroupName, appGw2.Name);
                Assert.Equal(HttpStatusCode.OK, deleteResult.StatusCode);

                // Verify Delete
                listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                Assert.Equal(0, listAppGw.ApplicationGateways.Count);
            }
        }        
    }
}