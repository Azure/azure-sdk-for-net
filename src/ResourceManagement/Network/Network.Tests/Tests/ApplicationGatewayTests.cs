using System.Collections.Generic;
using System.Net;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Networks.Tests
{
    using Microsoft.Azure.Test.HttpRecorder;
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

        public ApplicationGatewayTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
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

        private ApplicationGateway CreateApplicationGateway(string location, Subnet subnet, string resourceGroupName, string appGwName, string subscriptionId)
        {
            var gatewayIPConfigName = TestUtilities.GenerateName();
            var frontendIPConfigName = TestUtilities.GenerateName();
            var frontendPort1Name = TestUtilities.GenerateName();
            var frontendPort2Name = TestUtilities.GenerateName();            
            var backendAddressPoolName = TestUtilities.GenerateName();
            var nicBackendAddressPoolName = TestUtilities.GenerateName();
            var backendHttpSettings1Name = TestUtilities.GenerateName();
            var backendHttpSettings2Name = TestUtilities.GenerateName();
            var requestRoutingRule1Name = TestUtilities.GenerateName();
            var requestRoutingRule2Name = TestUtilities.GenerateName();
            var httpListener1Name = TestUtilities.GenerateName();
            var httpListener2Name = TestUtilities.GenerateName();            
            var probeName = TestUtilities.GenerateName();
            var sslCertName = TestUtilities.GenerateName();
            var authCertName = TestUtilities.GenerateName();

            //var httpListenerMultiHostingName = TestUtilities.GenerateName();
            //var frontendPortMultiHostingName = TestUtilities.GenerateName();
            //var urlPathMapName = TestUtilities.GenerateName();
            //var imagePathRuleName = TestUtilities.GenerateName();
            //var videoPathRuleName = TestUtilities.GenerateName();
            //var requestRoutingRuleMultiHostingName = TestUtilities.GenerateName();

            string certPath = System.IO.Path.Combine("Tests", "Data", "ApplicationGatewayAuthCert.cer");
            Console.WriteLine("Certificate Path: {0}", certPath);
            var x509AuthCertificate = new X509Certificate2(certPath);

            var authCertList = new List<ApplicationGatewayAuthenticationCertificate>()
            {
                new ApplicationGatewayAuthenticationCertificate()
                {
                    Name = authCertName,
                    Data  = Convert.ToBase64String(x509AuthCertificate.Export(X509ContentType.Cert))
                }
            };

            var appGw = new ApplicationGateway()
            {
                Location = location,                
                SslPolicy = new ApplicationGatewaySslPolicy()
                    {
                        DisabledSslProtocols = new List<string>()
                        {
                            ApplicationGatewaySslProtocol.TLSv10,
                            ApplicationGatewaySslProtocol.TLSv11
                        }
                    },
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
                            Name = frontendPort1Name,
                            Port = 80
                        },
                        new ApplicationGatewayFrontendPort()
                        {
                            Name = frontendPort2Name,
                            Port = 88
                        },
                        //new ApplicationGatewayFrontendPort()
                        //{
                        //    Name = frontendPortMultiHostingName,
                        //    Port = 8080
                        //}
                    },
                Probes = new List<ApplicationGatewayProbe>
                    {
                        new ApplicationGatewayProbe()
                        {
                            Name = probeName,
                            Protocol = ApplicationGatewayProtocol.Http,
                            Host = "probe.com",
                            Path = "/path/path.htm",
                            Interval = 17,
                            Timeout = 17,
                            UnhealthyThreshold = 5
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
                        },
                        new ApplicationGatewayBackendAddressPool()
                        {
                            Name = nicBackendAddressPoolName,
                        }
                    },
                BackendHttpSettingsCollection = new List<ApplicationGatewayBackendHttpSettings> 
                    {
                        new ApplicationGatewayBackendHttpSettings()
                        {
                            Name = backendHttpSettings1Name,
                            Port = 80,
                            Protocol = ApplicationGatewayProtocol.Http,
                            CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled,
                            RequestTimeout = 69,
                            Probe = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "probes", probeName)
                            }
                        },
                        new ApplicationGatewayBackendHttpSettings()
                        {
                            Name = backendHttpSettings2Name,
                            Port = 443,
                            Protocol = ApplicationGatewayProtocol.Https,
                            CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Enabled,                            
                            AuthenticationCertificates =  new List<SubResource>()
                            {
                                new SubResource()
                                {
                                    Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "authenticationCertificates", authCertName)
                                }
                            }
                        }
                    },
                HttpListeners = new List<ApplicationGatewayHttpListener>
                    {
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListener1Name,
                            FrontendPort = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPort1Name)
                            },
                            FrontendIPConfiguration = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                            },
                            SslCertificate = null,
                            Protocol = ApplicationGatewayProtocol.Http
                        },
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListener2Name,
                            FrontendPort = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPort2Name)
                            },
                            FrontendIPConfiguration = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                            },
                            SslCertificate = null,
                            Protocol = ApplicationGatewayProtocol.Http
                        },                        
                        //new ApplicationGatewayHttpListener()
                        //{
                        //    Name = httpListenerMultiHostingName,
                        //    FrontendPort = new SubResource()
                        //    {
                        //        Id = GetChildAppGwResourceId(subscriptionId,
                        //            resourceGroupName, appGwName, "frontendPorts", frontendPortMultiHostingName)
                        //    },
                        //    FrontendIPConfiguration = new SubResource()
                        //    {
                        //        Id = GetChildAppGwResourceId(subscriptionId,
                        //            resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                        //    },
                        //    SslCertificate = null,
                        //    Protocol = ApplicationGatewayProtocol.Http
                        //}
                    },
                //UrlPathMaps = new List<ApplicationGatewayUrlPathMap>()
                //    {
                //        new ApplicationGatewayUrlPathMap()
                //        {
                //            Name = urlPathMapName,
                //            DefaultBackendAddressPool = new SubResource()
                //            {
                //                Id = GetChildAppGwResourceId(subscriptionId,
                //                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                //            },
                //            DefaultBackendHttpSettings = new SubResource()
                //            {
                //                Id = GetChildAppGwResourceId(subscriptionId,
                //                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                //            },
                //            PathRules = new List<ApplicationGatewayPathRule>()
                //            {
                //                new ApplicationGatewayPathRule()
                //                {
                //                    Name = imagePathRuleName,
                //                    Paths = new List<string>() { "/images*" },
                //                    BackendAddressPool = new SubResource()
                //                    {
                //                        Id = GetChildAppGwResourceId(subscriptionId,
                //                        resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                //                    },
                //                    BackendHttpSettings = new SubResource()
                //                    {
                //                        Id = GetChildAppGwResourceId(subscriptionId,
                //                        resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                //                    }
                //                },
                //                new ApplicationGatewayPathRule()
                //                {
                //                    Name = videoPathRuleName,
                //                    Paths = new List<string>() { "/videos*" },
                //                    BackendAddressPool = new SubResource()
                //                    {
                //                        Id = GetChildAppGwResourceId(subscriptionId,
                //                        resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                //                    },
                //                    BackendHttpSettings = new SubResource()
                //                    {
                //                        Id = GetChildAppGwResourceId(subscriptionId,
                //                        resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettingsName)
                //                    }
                //                }
                //            }
                //        }
                //    },                
                RequestRoutingRules = new List<ApplicationGatewayRequestRoutingRule>()
                    {
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRule1Name,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListener1Name)
                            },
                            BackendAddressPool = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings1Name)
                            }
                        },
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRule2Name,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListener2Name)
                            },
                            BackendAddressPool = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                            },
                            BackendHttpSettings = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings2Name)
                            }
                        },
                        //new ApplicationGatewayRequestRoutingRule()
                        //{
                        //    Name = requestRoutingRuleMultiHostingName,
                        //    RuleType = ApplicationGatewayRequestRoutingRuleType.PathBasedRouting,
                        //    HttpListener = new SubResource()
                        //    {
                        //        Id = GetChildAppGwResourceId(subscriptionId,
                        //            resourceGroupName, appGwName, "httpListeners", httpListenerMultiHostingName)
                        //    },
                        //    UrlPathMap = new SubResource()
                        //    {
                        //        Id = GetChildAppGwResourceId(subscriptionId,
                        //            resourceGroupName, appGwName, "urlPathMaps", urlPathMapName)
                        //    }
                        //}
                    },
                AuthenticationCertificates = authCertList
            };
            return appGw;
        }

        private void CompareApplicationGateway(ApplicationGateway gw1, ApplicationGateway gw2)
        {
            Assert.Equal(gw1.Sku.Name, gw2.Sku.Name);
            Assert.Equal(gw1.Sku.Tier, gw2.Sku.Tier);
            Assert.Equal(gw1.Sku.Capacity, gw2.Sku.Capacity);
            Assert.Equal(gw1.GatewayIPConfigurations.Count, gw2.GatewayIPConfigurations.Count);
            Assert.Equal(gw1.FrontendIPConfigurations.Count, gw2.FrontendIPConfigurations.Count);
            Assert.Equal(gw1.FrontendPorts.Count, gw2.FrontendPorts.Count);
            Assert.Equal(gw1.Probes.Count, gw2.Probes.Count);
            Assert.Equal(gw1.BackendAddressPools.Count, gw2.BackendAddressPools.Count);
            Assert.Equal(gw1.BackendHttpSettingsCollection.Count, gw2.BackendHttpSettingsCollection.Count);
            Assert.Equal(gw1.HttpListeners.Count, gw2.HttpListeners.Count);
            Assert.Equal(gw1.RequestRoutingRules.Count, gw2.RequestRoutingRules.Count);            
            Assert.Equal(gw1.SslPolicy.DisabledSslProtocols.Count, gw2.SslPolicy.DisabledSslProtocols.Count);
            Assert.Equal(gw1.AuthenticationCertificates.Count, gw2.AuthenticationCertificates.Count);
        }

        [Fact]
        public void ApplicationGatewayApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                var gwSubnetName = TestUtilities.GenerateName();
                var subnet2Name = TestUtilities.GenerateName();
                var appGwName = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                    {
                        "10.0.0.0/16",
                    }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                    {
                        "10.1.1.1",
                        "10.1.2.4"
                    }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = gwSubnetName,
                            AddressPrefix = "10.0.0.0/24",
                        },
                        new Subnet()
                        {
                            Name = subnet2Name,
                            AddressPrefix = "10.0.1.0/24",
                        }
                    }
                };

                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                var getVnetResponse = networkManagementClient.VirtualNetworks.Get(resourceGroupName, vnetName);
                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, gwSubnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);
                var gwSubnet = getSubnetResponse;

                var appGw = CreateApplicationGateway(location, gwSubnet, resourceGroupName, appGwName, networkManagementClient.SubscriptionId);     

                // Put AppGw                
                var putAppGwResponse = networkManagementClient.ApplicationGateways.CreateOrUpdate(resourceGroupName, appGwName, appGw);                
                Assert.Equal("Succeeded", putAppGwResponse.ProvisioningState);
                
                // Get AppGw
                var getGateway = networkManagementClient.ApplicationGateways.Get(resourceGroupName, appGwName);
                Assert.Equal(appGwName, getGateway.Name);
                CompareApplicationGateway(appGw, getGateway);

                // Create Nics
                string nic1name = TestUtilities.GenerateName();
                string nic2name = TestUtilities.GenerateName();

                var nic1 = TestHelper.CreateNetworkInterface(
                    nic1name,
                    resourceGroupName,
                    null,
                    getVnetResponse.Subnets[1].Id,
                    location,
                    "ipconfig",
                    networkManagementClient);

                var nic2 = TestHelper.CreateNetworkInterface(
                    nic2name,
                    resourceGroupName,
                    null,
                    getVnetResponse.Subnets[1].Id,
                    location,
                    "ipconfig",
                    networkManagementClient);

                // Add NIC to application gateway backend address pool.
                nic1.IpConfigurations[0].ApplicationGatewayBackendAddressPools = new List<ApplicationGatewayBackendAddressPool>
                                                                                    {
                                                                                        getGateway.BackendAddressPools[1]
                                                                                    };
                nic2.IpConfigurations[0].ApplicationGatewayBackendAddressPools = new List<ApplicationGatewayBackendAddressPool>
                                                                                    {
                                                                                        getGateway.BackendAddressPools[1]
                                                                                    };
                // Put Nics
                networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic1name, nic1);
                networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic2name, nic2);

                //Start AppGw
                networkManagementClient.ApplicationGateways.Start(resourceGroupName, appGwName);
                
                // Get AppGw and make sure nics are added to backend
                getGateway = networkManagementClient.ApplicationGateways.Get(resourceGroupName, appGwName);
                Assert.Equal(2, getGateway.BackendAddressPools[1].BackendIPConfigurations.Count);

                //Stop AppGw
                networkManagementClient.ApplicationGateways.Stop(resourceGroupName, appGwName);
                
                // Delete AppGw
                networkManagementClient.ApplicationGateways.Delete(resourceGroupName, appGwName);
            }
        }        
    }
}