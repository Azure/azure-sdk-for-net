// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Networks.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test;
    using Networks.Tests.Helpers;
    using ResourceGroups.Tests;
    using Xunit;

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

        private List<ApplicationGatewaySslCertificate> CreateSslCertificate(string sslCertName, string password)
        {
            string certPath = System.IO.Path.Combine("Tests", "Data", "rsa2048.pfx");
            var cert = new X509Certificate2(certPath, password, X509KeyStorageFlags.Exportable);

            var sslCertList = new List<ApplicationGatewaySslCertificate>{
                new ApplicationGatewaySslCertificate()
                {
                    Name = sslCertName,
                    Data = Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password)),
                    Password = password
                }
            };
            return sslCertList;
        }

        private List<ApplicationGatewayAuthenticationCertificate> CreateAuthCertificate(string authCertName)
        {
            string certPath = System.IO.Path.Combine("Tests", "Data", "ApplicationGatewayAuthCert.cer");
            var cert = new X509Certificate2(certPath);

            var authCertList = new List<ApplicationGatewayAuthenticationCertificate>()
            {
                new ApplicationGatewayAuthenticationCertificate()
                {
                    Name = authCertName,
                    Data  = Convert.ToBase64String(cert.Export(X509ContentType.Cert))
                }
            };
            return authCertList;
        }

        private ApplicationGateway CreateApplicationGateway(string location, Subnet subnet, string resourceGroupName, string appGwName, string subscriptionId)
        {
            var gatewayIPConfigName = TestUtilities.GenerateName();
            var frontendIPConfigName = TestUtilities.GenerateName();
            var frontendPort1Name = TestUtilities.GenerateName();
            var frontendPort2Name = TestUtilities.GenerateName();
            var frontendPort3Name = TestUtilities.GenerateName();
            var frontendPort4Name = TestUtilities.GenerateName();
            var backendAddressPoolName = TestUtilities.GenerateName();
            var nicBackendAddressPoolName = TestUtilities.GenerateName();
            var backendHttpSettings1Name = TestUtilities.GenerateName();
            var backendHttpSettings2Name = TestUtilities.GenerateName();
            var requestRoutingRule1Name = TestUtilities.GenerateName();
            var requestRoutingRule2Name = TestUtilities.GenerateName();
            var requestRoutingRule3Name = TestUtilities.GenerateName();
            var requestRoutingRule4Name = TestUtilities.GenerateName();
            var httpListener1Name = TestUtilities.GenerateName();
            var httpListener2Name = TestUtilities.GenerateName();
            var httpListener3Name = TestUtilities.GenerateName();
            var httpListener4Name = TestUtilities.GenerateName();
            var probeName = TestUtilities.GenerateName();
            var sslCertName = TestUtilities.GenerateName();
            var authCertName = TestUtilities.GenerateName();
            var redirectConfiguration1Name = TestUtilities.GenerateName();
            var redirectConfiguration2Name = TestUtilities.GenerateName();
            var urlPathMapName = TestUtilities.GenerateName();
            var pathRuleName = TestUtilities.GenerateName();

            var appGw = new ApplicationGateway()
            {
                Location = location,
                Sku = new ApplicationGatewaySku()
                {
                    Name = ApplicationGatewaySkuName.WAFMedium,
                    Tier = ApplicationGatewayTier.WAF,
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
                            Port = 443
                        },
                        new ApplicationGatewayFrontendPort()
                        {
                            Name = frontendPort3Name,
                            Port = 8080
                        },
                        new ApplicationGatewayFrontendPort()
                        {
                            Name = frontendPort4Name,
                            Port = 8081
                        }
                    },
                Probes = new List<ApplicationGatewayProbe>
                    {
                        new ApplicationGatewayProbe()
                        {
                            Name = probeName,
                            Protocol = ApplicationGatewayProtocol.Http,
                            Path = "/path/path.htm",
                            Interval = 17,
                            Timeout = 17,
                            UnhealthyThreshold = 5,
                            PickHostNameFromBackendHttpSettings = true,
                            Match = new ApplicationGatewayProbeHealthResponseMatch
                            {
                                Body = "helloworld",
                                StatusCodes = new List<string> {"200-300","403"}
                            }
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
                                    IpAddress = "hello1.azurewebsites.net"
                                },
                                new ApplicationGatewayBackendAddress()
                                {
                                    IpAddress = "hello2.azurewebsites.net"
                                }
                            }
                        },
                        new ApplicationGatewayBackendAddressPool()
                        {
                            Name = nicBackendAddressPoolName
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
                            },
                            ConnectionDraining = new ApplicationGatewayConnectionDraining()
                            {
                                Enabled = true,
                                DrainTimeoutInSec = 42
                            },
                            ProbeEnabled = true,
                            PickHostNameFromBackendAddress = true
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
                            SslCertificate = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "sslCertificates", sslCertName)
                            },
                            Protocol = ApplicationGatewayProtocol.Https
                        },
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListener3Name,
                            FrontendPort = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPort3Name)
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
                        },
                        new ApplicationGatewayHttpListener()
                        {
                            Name = httpListener4Name,
                            FrontendPort = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "frontendPorts", frontendPort4Name)
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
                UrlPathMaps = new List<ApplicationGatewayUrlPathMap>()
                    {
                        new ApplicationGatewayUrlPathMap{
                            Name = urlPathMapName,
                            DefaultRedirectConfiguration = new SubResource
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "redirectConfigurations", redirectConfiguration2Name)
                            },
                            PathRules = new List<ApplicationGatewayPathRule>
                            {
                                new ApplicationGatewayPathRule{
                                    Name = pathRuleName,
                                    Paths = new List<string>{"/paa"},
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
                                }
                            }

                        }
                    },
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
                            RedirectConfiguration = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "redirectConfigurations", redirectConfiguration1Name)
                            }
                        },
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRule3Name,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.PathBasedRouting,
                            HttpListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListener3Name)
                            },
                            UrlPathMap = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "urlPathMaps", urlPathMapName)
                            }
                        },
                        new ApplicationGatewayRequestRoutingRule()
                        {
                            Name = requestRoutingRule4Name,
                            RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                            HttpListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListener4Name)
                            },
                            BackendAddressPool = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendAddressPools", nicBackendAddressPoolName)
                            },
                            BackendHttpSettings = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings2Name)
                            }
                        },
                    },
                AuthenticationCertificates = CreateAuthCertificate(authCertName),
                WebApplicationFirewallConfiguration = new ApplicationGatewayWebApplicationFirewallConfiguration()
                {
                    Enabled = true,
                    FirewallMode = ApplicationGatewayFirewallMode.Prevention,
                    RuleSetType = "OWASP",
                    RuleSetVersion = "2.2.9",
                    DisabledRuleGroups = new List<ApplicationGatewayFirewallDisabledRuleGroup>()
                        {
                            new ApplicationGatewayFirewallDisabledRuleGroup(
                                "crs_41_sql_injection_attacks",
                                new List<int>() { 981318, 981320 }),
                            new ApplicationGatewayFirewallDisabledRuleGroup("crs_35_bad_robots")
                        }
                },
                SslPolicy = new ApplicationGatewaySslPolicy()
                {
                    PolicyType = "Predefined",
                    PolicyName = "AppGwSslPolicy20170401"
                },
                RedirectConfigurations = new List<ApplicationGatewayRedirectConfiguration>
                    {
                        new ApplicationGatewayRedirectConfiguration
                        {
                            Name = redirectConfiguration1Name,
                            RedirectType = ApplicationGatewayRedirectType.Permanent,
                            TargetListener = new SubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                    resourceGroupName, appGwName, "httpListeners", httpListener1Name)
                            },
                        },
                        new ApplicationGatewayRedirectConfiguration
                        {
                            Name = redirectConfiguration2Name,
                            RedirectType = ApplicationGatewayRedirectType.Permanent,
                            TargetUrl = "http://www.bing.com"
                        }
                    },
                //SslCertificates = CreateSslCertificate(sslCertName, "abc")
            };
            return appGw;
        }

        private void CompareApplicationGateway(ApplicationGateway gw1, ApplicationGateway gw2)
        {
            // compare count of child resources
            Assert.Equal(gw1.GatewayIPConfigurations.Count, gw2.GatewayIPConfigurations.Count);
            Assert.Equal(gw1.FrontendIPConfigurations.Count, gw2.FrontendIPConfigurations.Count);
            Assert.Equal(gw1.FrontendPorts.Count, gw2.FrontendPorts.Count);
            Assert.Equal(gw1.Probes.Count, gw2.Probes.Count);
            Assert.Equal(gw1.BackendAddressPools.Count, gw2.BackendAddressPools.Count);
            Assert.Equal(gw1.BackendHttpSettingsCollection.Count, gw2.BackendHttpSettingsCollection.Count);
            Assert.Equal(gw1.HttpListeners.Count, gw2.HttpListeners.Count);
            Assert.Equal(gw1.RequestRoutingRules.Count, gw2.RequestRoutingRules.Count);
            Assert.Equal(gw1.RedirectConfigurations.Count, gw2.RedirectConfigurations.Count);
            Assert.Equal(gw1.AuthenticationCertificates.Count, gw2.AuthenticationCertificates.Count);

            // compare sku
            Assert.Equal(gw1.Sku.Name, gw2.Sku.Name);
            Assert.Equal(gw1.Sku.Tier, gw2.Sku.Tier);
            Assert.Equal(gw1.Sku.Capacity, gw2.Sku.Capacity);

            // compare connectionDraining
            for (int i = 0; i < gw1.BackendHttpSettingsCollection.Count; i++)
            {
                if (gw1.BackendHttpSettingsCollection[i].ConnectionDraining != null)
                {
                    Assert.NotNull(gw2.BackendHttpSettingsCollection[i].ConnectionDraining);
                    Assert.Equal(gw1.BackendHttpSettingsCollection[i].ConnectionDraining.Enabled, gw2.BackendHttpSettingsCollection[i].ConnectionDraining.Enabled);
                    Assert.Equal(gw1.BackendHttpSettingsCollection[i].ConnectionDraining.DrainTimeoutInSec, gw2.BackendHttpSettingsCollection[i].ConnectionDraining.DrainTimeoutInSec);
                }
                else
                {
                    Assert.Null(gw2.BackendHttpSettingsCollection[i].ConnectionDraining);
                }
            }

            //compare WAF
            Assert.Equal(gw1.WebApplicationFirewallConfiguration.Enabled, gw2.WebApplicationFirewallConfiguration.Enabled);
            Assert.Equal(gw1.WebApplicationFirewallConfiguration.FirewallMode, gw2.WebApplicationFirewallConfiguration.FirewallMode);
            Assert.Equal(gw1.WebApplicationFirewallConfiguration.RuleSetType, gw2.WebApplicationFirewallConfiguration.RuleSetType);
            Assert.Equal(gw1.WebApplicationFirewallConfiguration.RuleSetVersion, gw2.WebApplicationFirewallConfiguration.RuleSetVersion);
            if (gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups != null)
            {
                Assert.NotNull(gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups);
                Assert.Equal(gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count, gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count);
                for (int i = 0; i < gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count; i++)
                {
                    Assert.Equal(gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].RuleGroupName, gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].RuleGroupName);
                    Assert.Equal(gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].Rules, gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].Rules);
                }
            }
            else
            {
                Assert.Empty(gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups);
            }

            // ssl policy
            Assert.Equal(gw1.SslPolicy.PolicyType, gw2.SslPolicy.PolicyType);
            Assert.Equal(gw1.SslPolicy.PolicyName, gw2.SslPolicy.PolicyName);
            Assert.Equal(gw1.SslPolicy.MinProtocolVersion, gw2.SslPolicy.MinProtocolVersion);
        }

        [Fact(Skip="Disable tests")]
        public void ApplicationGatewayApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = "West US";

                var a = HttpMockServer.Mode;


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

                // Get available WAF rule sets (validate first result set/group)
                var availableWAFRuleSets = networkManagementClient.ApplicationGateways.ListAvailableWafRuleSets();
                Assert.NotNull(availableWAFRuleSets);
                Assert.NotEmpty(availableWAFRuleSets.Value);
                Assert.NotNull(availableWAFRuleSets.Value[0].Name);
                Assert.NotNull(availableWAFRuleSets.Value[0].RuleSetType);
                Assert.NotNull(availableWAFRuleSets.Value[0].RuleSetVersion);
                Assert.NotEmpty(availableWAFRuleSets.Value[0].RuleGroups);
                Assert.NotNull(availableWAFRuleSets.Value[0].RuleGroups[0].RuleGroupName);
                Assert.NotEmpty(availableWAFRuleSets.Value[0].RuleGroups[0].Rules);
                // Assert.NotNull(availableWAFRuleSets.Value[0].RuleGroups[0].Rules[0].RuleId);

                // Get availalbe SSL options
                var sslOptions = networkManagementClient.ApplicationGateways.ListAvailableSslOptions();
                Assert.NotNull(sslOptions.DefaultPolicy);
                Assert.NotNull(sslOptions.AvailableCipherSuites);
                Assert.NotNull(sslOptions.AvailableCipherSuites[20]);

                var policies = networkManagementClient.ApplicationGateways.ListAvailableSslPredefinedPolicies();
                var enumerator = policies.GetEnumerator();
                Assert.True(enumerator.MoveNext());
                Assert.NotNull(enumerator.Current.Name);

                var policy = networkManagementClient.ApplicationGateways.GetSslPredefinedPolicy(ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501);
                Assert.NotNull(policy.MinProtocolVersion);
                Assert.NotNull(policy.CipherSuites);
                Assert.NotNull(policy.CipherSuites[20]);

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

                // Get AppGw backend health
                var backendHealth = networkManagementClient.ApplicationGateways.BackendHealth(resourceGroupName, appGwName, "true");
                Assert.Equal(2, backendHealth.BackendAddressPools.Count);
                Assert.Equal(1, backendHealth.BackendAddressPools[0].BackendHttpSettingsCollection.Count);
                Assert.Equal(1, backendHealth.BackendAddressPools[1].BackendHttpSettingsCollection.Count);
                Assert.True(backendHealth.BackendAddressPools[1].BackendAddressPool.BackendIPConfigurations.IsAny());


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

