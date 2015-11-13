﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Security.Cryptography.X509Certificates;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

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
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);
            return getSubnetResponse;
        }

        private ApplicationGatewaySslCertificate CreateSslCertificate(string sslCertName, string password)
        {
            throw new NotImplementedException("Certificate is not support for cross platform testing");
            //X509Certificate2 cert = new X509Certificate2("ApplicationGatewayCertificate\\GW5000.pfx", password, X509KeyStorageFlags.Exportable);
            //ApplicationGatewaySslCertificate sslCert = new ApplicationGatewaySslCertificate()
            //{
            //    Name = sslCertName,
            //    Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password)),
            //    Password = password
            //};

            //return sslCert;
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
                Sku = new ApplicationGatewaySku()
                    {
                        Name = ApplicationGatewaySkuName.StandardMedium,
                        Tier = ApplicationGatewayTier.Standard,
                        Capacity = 2
                    },
                GatewayIPConfigurations = new List<ApplicationGatewayIPConfiguration>()
                    {
                        new ApplicationGatewayIPConfiguration()
                        {
                            Name = gatewayIpConfigName,
                            Subnet = new Subnet()
                            {
                                Id = subnet.Id
                            }
                        }
                    },
                FrontendIPConfigurations = new List<ApplicationGatewayFrontendIPConfiguration>() 
                    { 
                        new ApplicationGatewayFrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
                            Subnet = new Subnet()
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
                            FrontendPort = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
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
                            HttpListener = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
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
                            Name = gatewayIpConfigName,
                            Subnet = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            Name = frontendIpConfigName,
                            PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
                            Subnet = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            FrontendPort = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPortName)
                            },
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIpConfigName)
                            },
                            SslCertificate = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
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
                            HttpListener = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListenerName)
                            },
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = GetChildAppGwResourceId(networkResourceProviderClient.SubscriptionId,
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
            Assert.Equal(gw1.GatewayIPConfigurations.Count, gw2.GatewayIPConfigurations.Count);
            Assert.Equal(gw1.FrontendIPConfigurations.Count, gw2.FrontendIPConfigurations.Count);
            Assert.Equal(gw1.FrontendPorts.Count, gw2.FrontendPorts.Count);
            Assert.Equal(gw1.SslCertificates.Count, gw2.SslCertificates.Count);
            Assert.Equal(gw1.BackendAddressPools.Count, gw2.BackendAddressPools.Count);
            Assert.Equal(gw1.BackendHttpSettingsCollection.Count, gw2.BackendHttpSettingsCollection.Count);
            Assert.Equal(gw1.HttpListeners.Count, gw2.HttpListeners.Count);
            Assert.Equal(gw1.RequestRoutingRules.Count, gw2.RequestRoutingRules.Count);
        }

        [Fact(Skip="TODO: Autorest")]
        public void ApplicationGatewayApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };            

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);
                
                location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/applicationgateways");

                resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                Init();
                
                var appGw = CreateApplicationGatewayWithSsl();
                var appGwName = TestUtilities.GenerateName("azsmnet");

                // Put AppGw
                var putAppGwResponse = networkResourceProviderClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGwName, appGw);                
                Assert.Equal("Succeeded", putAppGwResponse.ProvisioningState);
                
                // Get AppGw
                var getResp = networkResourceProviderClient.ApplicationGateways.Get(resourceGroupName, appGwName);
                CompareApplicationGateway(appGw, getResp);

                // List AppGw
                var listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                Assert.Equal(1, listAppGw.Count());

                // List all AppGw
                var listAllAppGw = networkResourceProviderClient.ApplicationGateways.ListAll();
                Assert.Equal(1, listAllAppGw.Count());

                //Add one more gateway
                // Put AppGw
                var appGw2 = CreateApplicationGateway();
                var appGw2Name = TestUtilities.GenerateName("azsmnet");

                putAppGwResponse = networkResourceProviderClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGw2Name, appGw2);
                Assert.Equal("Succeeded", putAppGwResponse.ProvisioningState);

                // Get AppGw
                getResp = networkResourceProviderClient.ApplicationGateways.Get(resourceGroupName, appGw2Name);
                CompareApplicationGateway(appGw2, getResp);

                // List AppGw
                listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                Assert.Equal(2, listAppGw.Count());

                // List all AppGw
                listAllAppGw = networkResourceProviderClient.ApplicationGateways.ListAll();
                Assert.Equal(2, listAllAppGw.Count());

                //Start AppGw
                networkResourceProviderClient.ApplicationGateways.Start(resourceGroupName, appGwName);

                networkResourceProviderClient.ApplicationGateways.Start(resourceGroupName, appGw2Name);
                
                //Stop AppGw
                networkResourceProviderClient.ApplicationGateways.Stop(resourceGroupName, appGwName);

                networkResourceProviderClient.ApplicationGateways.Stop(resourceGroupName, appGw2Name);
                
                // Delete AppGw
                networkResourceProviderClient.ApplicationGateways.Delete(resourceGroupName, appGwName);

                networkResourceProviderClient.ApplicationGateways.Delete(resourceGroupName, appGw2Name);

                // Verify Delete
                listAppGw = networkResourceProviderClient.ApplicationGateways.List(resourceGroupName);
                Assert.Null(listAppGw);
            }
        }        
    }
}