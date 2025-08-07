// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Azure.Core;

namespace Azure.ResourceManager.Network.Tests
{
    public class ApplicationGatewayTests : NetworkServiceClientTestBase
    {
        public ApplicationGatewayTests(bool isAsync) : base(isAsync)
        {
        }

        private SubscriptionResource _subscription;

        [SetUp]
        public async Task ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
            _subscription = await ArmClient.GetDefaultSubscriptionAsync();
        }

        private static ResourceIdentifier GetChildAppGwResourceId(string subscriptionId,
                                                string resourceGroupName,
                                                string appGwname,
                                                string childResourceType,
                                                string childResourceName)
        {
            return new ResourceIdentifier(string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/applicationGateways/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    appGwname,
                    childResourceType,
                    childResourceName));
        }

        private List<ApplicationGatewaySslCertificate> CreateSslCertificate(string sslCertName, string password)
        {
            string certPath = System.IO.Path.Combine("Tests", "Data", "rsa2048.pfx");
#if NET9_0_OR_GREATER
            X509Certificate2 cert = X509CertificateLoader.LoadPkcs12FromFile(certPath, password, X509KeyStorageFlags.Exportable);
#else
            X509Certificate2 cert = new X509Certificate2(certPath, password, X509KeyStorageFlags.Exportable);
#endif

            List<ApplicationGatewaySslCertificate> sslCertList = new List<ApplicationGatewaySslCertificate>{
                new ApplicationGatewaySslCertificate()
                {
                    Name = sslCertName,
                    Data = BinaryData.FromString(Convert.ToBase64String(cert.Export(X509ContentType.Pfx, password))),
                    Password = password
                }
            };
            return sslCertList;
        }

        private ApplicationGatewayAuthenticationCertificate CreateAuthCertificate(string authCertName)
        {
            string certPath = System.IO.Path.Combine("Tests", "Data", "ApplicationGatewayAuthCert.cer");
#if NET9_0_OR_GREATER
            X509Certificate2 cert = X509CertificateLoader.LoadCertificateFromFile(certPath);
#else
            X509Certificate2 cert = new X509Certificate2(certPath);
#endif

            return
                new ApplicationGatewayAuthenticationCertificate()
                {
                    Name = authCertName,
                    Data = BinaryData.FromString(Convert.ToBase64String(cert.Export(X509ContentType.Cert)))
                };
        }

        private ApplicationGatewayData CreateApplicationGateway(string location, SubnetResource subnet, string resourceGroupName, string appGwName, string subscriptionId)
        {
            string gatewayIPConfigName = Recording.GenerateAssetName("azsmnet");
            string frontendIPConfigName = Recording.GenerateAssetName("azsmnet");
            string frontendPort1Name = Recording.GenerateAssetName("azsmnet");
            string frontendPort2Name = Recording.GenerateAssetName("azsmnet");
            string frontendPort3Name = Recording.GenerateAssetName("azsmnet");
            string frontendPort4Name = Recording.GenerateAssetName("azsmnet");
            string backendAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string nicBackendAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string backendHttpSettings1Name = Recording.GenerateAssetName("azsmnet");
            string backendHttpSettings2Name = Recording.GenerateAssetName("azsmnet");
            string requestRoutingRule1Name = Recording.GenerateAssetName("azsmnet");
            string requestRoutingRule2Name = Recording.GenerateAssetName("azsmnet");
            string requestRoutingRule3Name = Recording.GenerateAssetName("azsmnet");
            string requestRoutingRule4Name = Recording.GenerateAssetName("azsmnet");
            string httpListener1Name = Recording.GenerateAssetName("azsmnet");
            string httpListener2Name = Recording.GenerateAssetName("azsmnet");
            string httpListener3Name = Recording.GenerateAssetName("azsmnet");
            string httpListener4Name = Recording.GenerateAssetName("azsmnet");
            string probeName = Recording.GenerateAssetName("azsmnet");
            string sslCertName = Recording.GenerateAssetName("azsmnet");
            string authCertName = Recording.GenerateAssetName("azsmnet");
            string redirectConfiguration1Name = Recording.GenerateAssetName("azsmnet");
            string redirectConfiguration2Name = Recording.GenerateAssetName("azsmnet");
            string urlPathMapName = Recording.GenerateAssetName("azsmnet");
            string pathRuleName = Recording.GenerateAssetName("azsmnet");

            var appGw = new ApplicationGatewayData()
            {
                Location = location,
                Sku = new ApplicationGatewaySku()
                {
                    Name = ApplicationGatewaySkuName.StandardV2,
                    Tier = ApplicationGatewayTier.StandardV2,
                    Capacity = 2
                },
                GatewayIPConfigurations = {
                    new ApplicationGatewayIPConfiguration()
                    {
                        Name = gatewayIPConfigName,
                        Subnet = new WritableSubResource()
                        {
                            Id = subnet.Id
                        }
                    }
                },
                FrontendIPConfigurations = {
                    new ApplicationGatewayFrontendIPConfiguration()
                    {
                        Name = frontendIPConfigName,
                        PrivateIPAllocationMethod = NetworkIPAllocationMethod.Dynamic,
                        Subnet = new WritableSubResource()
                        {
                            Id = subnet.Id
                        }
                    }
                },
                FrontendPorts = {
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
                Probes = {
                    new ApplicationGatewayProbe()
                    {
                        Name = probeName,
                        Protocol = ApplicationGatewayProtocol.Http,
                        Path = "/path/path.htm",
                        IntervalInSeconds = 17,
                        TimeoutInSeconds = 17,
                        UnhealthyThreshold = 5,
                        PickHostNameFromBackendHttpSettings = true,
                        Match = new ApplicationGatewayProbeHealthResponseMatch
                        {
                            Body = BinaryData.FromString("helloworld"),
                            StatusCodes = {"200-300","403"}
                        }
                    }
                },
                BackendAddressPools = {
                    new ApplicationGatewayBackendAddressPool()
                    {
                        Name = backendAddressPoolName,
                        BackendAddresses = {
                            new ApplicationGatewayBackendAddress()
                            {
                                IPAddress = "hello1.azurewebsites.net"
                            },
                            new ApplicationGatewayBackendAddress()
                            {
                                IPAddress = "hello2.azurewebsites.net"
                            }
                        }
                    },
                    new ApplicationGatewayBackendAddressPool()
                    {
                        Name = nicBackendAddressPoolName
                    }
                },
                BackendHttpSettingsCollection = {
                    new ApplicationGatewayBackendHttpSettings()
                    {
                        Name = backendHttpSettings1Name,
                        Port = 80,
                        Protocol = ApplicationGatewayProtocol.Http,
                        CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled,
                        RequestTimeoutInSeconds = 69,
                        Probe = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "probes", probeName)
                        },
                        ConnectionDraining = new ApplicationGatewayConnectionDraining(true,42),
                        ProbeEnabled = true,
                        PickHostNameFromBackendAddress = true
                    },
                    new ApplicationGatewayBackendHttpSettings()
                    {
                        Name = backendHttpSettings2Name,
                        Port = 443,
                        Protocol = ApplicationGatewayProtocol.Https,
                        CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Enabled,
                        AuthenticationCertificates =
                        {
                            new WritableSubResource()
                            {
                                Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "authenticationCertificates", authCertName)
                            }
                        }
                    }
                },
                HttpListeners = {
                    new ApplicationGatewayHttpListener()
                    {
                        Name = httpListener1Name,
                        FrontendPort = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendPorts", frontendPort1Name)
                        },
                        FrontendIPConfiguration = new WritableSubResource()
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
                        FrontendPort = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendPorts", frontendPort2Name)
                        },
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                        },
                        SslCertificate = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "sslCertificates", sslCertName)
                        },
                        Protocol = ApplicationGatewayProtocol.Https
                    },
                    new ApplicationGatewayHttpListener()
                    {
                        Name = httpListener3Name,
                        FrontendPort = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendPorts", frontendPort3Name)
                        },
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                        },
                        SslCertificate = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "sslCertificates", sslCertName)
                        },
                        Protocol = ApplicationGatewayProtocol.Https
                    },
                    new ApplicationGatewayHttpListener()
                    {
                        Name = httpListener4Name,
                        FrontendPort = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendPorts", frontendPort4Name)
                        },
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                        },
                        SslCertificate = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "sslCertificates", sslCertName)
                        },
                        Protocol = ApplicationGatewayProtocol.Https
                    }
                },
                UrlPathMaps = {
                    new ApplicationGatewayUrlPathMap{
                        Name = urlPathMapName,
                        DefaultRedirectConfiguration = new WritableSubResource
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                            resourceGroupName, appGwName, "redirectConfigurations", redirectConfiguration2Name)
                        },
                        PathRules = {
                            new ApplicationGatewayPathRule{
                                Name = pathRuleName,
                                Paths = {"/paa"},
                                BackendAddressPool = new WritableSubResource()
                                {
                                    Id = GetChildAppGwResourceId(subscriptionId,
                                        resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                                },
                                BackendHttpSettings = new WritableSubResource()
                                {
                                    Id = GetChildAppGwResourceId(subscriptionId,
                                        resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings1Name)
                                }
                            }
                        }
                    }
                },
                RequestRoutingRules = {
                    new ApplicationGatewayRequestRoutingRule()
                    {
                        Name = requestRoutingRule1Name,
                        RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                        Priority = 1,
                        HttpListener = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "httpListeners", httpListener1Name)
                        },
                        BackendAddressPool = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                        },
                        BackendHttpSettings = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings1Name)
                        }
                    },
                    new ApplicationGatewayRequestRoutingRule()
                    {
                        Name = requestRoutingRule2Name,
                        RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                        Priority = 1,
                        HttpListener = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "httpListeners", httpListener2Name)
                        },
                        RedirectConfiguration = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "redirectConfigurations", redirectConfiguration1Name)
                        }
                    },
                    new ApplicationGatewayRequestRoutingRule()
                    {
                        Name = requestRoutingRule3Name,
                        RuleType = ApplicationGatewayRequestRoutingRuleType.PathBasedRouting,
                        Priority = 1,
                        HttpListener = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "httpListeners", httpListener3Name)
                        },
                        UrlPathMap = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "urlPathMaps", urlPathMapName)
                        }
                    },
                    new ApplicationGatewayRequestRoutingRule()
                    {
                        Name = requestRoutingRule4Name,
                        RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                        Priority = 1,
                        HttpListener = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "httpListeners", httpListener4Name)
                        },
                        BackendAddressPool = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "backendAddressPools", nicBackendAddressPoolName)
                        },
                        BackendHttpSettings = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings2Name)
                        }
                    },
                },
                AuthenticationCertificates = {
                    CreateAuthCertificate(authCertName)
                },
                WebApplicationFirewallConfiguration = new ApplicationGatewayWebApplicationFirewallConfiguration(true, ApplicationGatewayFirewallMode.Prevention, "OWASP", "2.2.9")
                {
                    DisabledRuleGroups = {
                        new ApplicationGatewayFirewallDisabledRuleGroup("crs_41_sql_injection_attacks")
                        {
                            Rules = { 981318, 981320 }
                        },
                        new ApplicationGatewayFirewallDisabledRuleGroup("crs_35_bad_robots")
                    }
                },
                SslPolicy = new ApplicationGatewaySslPolicy()
                {
                    PolicyType = "Predefined",
                    PolicyName = "AppGwSslPolicy20170401"
                },
                RedirectConfigurations = {
                    new ApplicationGatewayRedirectConfiguration
                    {
                        Name = redirectConfiguration1Name,
                        RedirectType = ApplicationGatewayRedirectType.Permanent,
                        TargetListener = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "httpListeners", httpListener1Name)
                        },
                    },
                    new ApplicationGatewayRedirectConfiguration
                    {
                        Name = redirectConfiguration2Name,
                        RedirectType = ApplicationGatewayRedirectType.Permanent,
                        TargetUri = new Uri("http://www.bing.com")
                    }
                },
                //SslCertificates = CreateSslCertificate(sslCertName, "abc")
            };
            return appGw;
        }

        private ApplicationGatewayData CreateApplicationGatewayWithoutSsl(string location, PublicIPAddressResource publicIP, SubnetResource subnet, string resourceGroupName, string appGwName, string subscriptionId, string[] ipAddresses)
        {
            string gatewayIPConfigName = Recording.GenerateAssetName("azsmnet");
            string frontendIPConfigName = Recording.GenerateAssetName("azsmnet");
            string frontendPort1Name = Recording.GenerateAssetName("azsmnet");
            string backendAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string nicBackendAddressPoolName = Recording.GenerateAssetName("azsmnet");
            string backendHttpSettings1Name = Recording.GenerateAssetName("azsmnet");
            string requestRoutingRule1Name = Recording.GenerateAssetName("azsmnet");
            string httpListener1Name = Recording.GenerateAssetName("azsmnet");

            var appGw = new ApplicationGatewayData()
            {
                Location = location,
                Sku = new ApplicationGatewaySku()
                {
                    Name = ApplicationGatewaySkuName.StandardV2,
                    Tier = ApplicationGatewayTier.StandardV2,
                    Capacity = 2
                },
                GatewayIPConfigurations = {
                    new ApplicationGatewayIPConfiguration()
                    {
                        Name = gatewayIPConfigName,
                        Subnet = new WritableSubResource()
                        {
                            Id = subnet.Id
                        }
                    }
                },
                FrontendIPConfigurations = {
                    new ApplicationGatewayFrontendIPConfiguration()
                    {
                        Name = frontendIPConfigName,
                        PublicIPAddressId = publicIP.Id
                    }
                },
                FrontendPorts = {
                    new ApplicationGatewayFrontendPort()
                    {
                        Name = frontendPort1Name,
                        Port = 80
                    }
                },
                Probes = {
                },
                BackendAddressPools = {
                    new ApplicationGatewayBackendAddressPool()
                    {
                        Name = backendAddressPoolName,
                        BackendAddresses = {
                            new ApplicationGatewayBackendAddress()
                            {
                                IPAddress = ipAddresses[0]
                            },
                            new ApplicationGatewayBackendAddress()
                            {
                                IPAddress = ipAddresses[1]
                            }
                        }
                    },
                    new ApplicationGatewayBackendAddressPool()
                    {
                        Name = nicBackendAddressPoolName
                    }
                },
                BackendHttpSettingsCollection = {
                    new ApplicationGatewayBackendHttpSettings()
                    {
                        Name = backendHttpSettings1Name,
                        Port = 80,
                        Protocol = ApplicationGatewayProtocol.Http,
                        CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled,
                        RequestTimeoutInSeconds = 20,
                    }
                },
                HttpListeners = {
                    new ApplicationGatewayHttpListener()
                    {
                        Name = httpListener1Name,
                        FrontendPort = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendPorts", frontendPort1Name)
                        },
                        FrontendIPConfiguration = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "frontendIPConfigurations", frontendIPConfigName)
                        },
                        SslCertificate = null,
                        Protocol = ApplicationGatewayProtocol.Http
                    }
                },
                UrlPathMaps = {
                },
                RequestRoutingRules = {
                    new ApplicationGatewayRequestRoutingRule()
                    {
                        Name = requestRoutingRule1Name,
                        RuleType = ApplicationGatewayRequestRoutingRuleType.Basic,
                        Priority = 1,
                        HttpListener = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "httpListeners", httpListener1Name)
                        },
                        BackendAddressPool = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "backendAddressPools", backendAddressPoolName)
                        },
                        BackendHttpSettings = new WritableSubResource()
                        {
                            Id = GetChildAppGwResourceId(subscriptionId,
                                resourceGroupName, appGwName, "backendHttpSettingsCollection", backendHttpSettings1Name)
                        }
                    }
                },
                RedirectConfigurations = {
                },
            };
            return appGw;
        }

        private void CompareApplicationGateway(ApplicationGatewayData gw1, ApplicationGatewayData gw2)
        {
            //compare base data
            CompareApplicationGatewayBase(gw1,gw2);

            //compare WAF
            Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.Enabled, gw2.WebApplicationFirewallConfiguration.Enabled);
            Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.FirewallMode, gw2.WebApplicationFirewallConfiguration.FirewallMode);
            Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.RuleSetType, gw2.WebApplicationFirewallConfiguration.RuleSetType);
            Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.RuleSetVersion, gw2.WebApplicationFirewallConfiguration.RuleSetVersion);
            if (gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups != null)
            {
                Assert.NotNull(gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups);
                Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count, gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count);
                for (int i = 0; i < gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups.Count; i++)
                {
                    Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].RuleGroupName, gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].RuleGroupName);
                    Assert.AreEqual(gw1.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].Rules, gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups[i].Rules);
                }
            }
            else
            {
                Assert.IsEmpty(gw2.WebApplicationFirewallConfiguration.DisabledRuleGroups);
            }

            // ssl policy
            Assert.AreEqual(gw1.SslPolicy.PolicyType, gw2.SslPolicy.PolicyType);
            Assert.AreEqual(gw1.SslPolicy.PolicyName, gw2.SslPolicy.PolicyName);
            Assert.AreEqual(gw1.SslPolicy.MinProtocolVersion, gw2.SslPolicy.MinProtocolVersion);
        }

        private void CompareApplicationGatewayBase(ApplicationGatewayData gw1, ApplicationGatewayData gw2)
        {
            // compare count of child resources
            Assert.AreEqual(gw1.GatewayIPConfigurations.Count, gw2.GatewayIPConfigurations.Count);
            Assert.AreEqual(gw1.FrontendIPConfigurations.Count, gw2.FrontendIPConfigurations.Count);
            Assert.AreEqual(gw1.FrontendPorts.Count, gw2.FrontendPorts.Count);
            Assert.AreEqual(gw1.Probes.Count, gw2.Probes.Count);
            Assert.AreEqual(gw1.BackendAddressPools.Count, gw2.BackendAddressPools.Count);
            Assert.AreEqual(gw1.BackendHttpSettingsCollection.Count, gw2.BackendHttpSettingsCollection.Count);
            Assert.AreEqual(gw1.HttpListeners.Count, gw2.HttpListeners.Count);
            Assert.AreEqual(gw1.RequestRoutingRules.Count, gw2.RequestRoutingRules.Count);
            Assert.AreEqual(gw1.RedirectConfigurations.Count, gw2.RedirectConfigurations.Count);
            Assert.AreEqual(gw1.AuthenticationCertificates.Count, gw2.AuthenticationCertificates.Count);

            // compare sku
            Assert.AreEqual(gw1.Sku.Name, gw2.Sku.Name);
            Assert.AreEqual(gw1.Sku.Tier, gw2.Sku.Tier);
            Assert.AreEqual(gw1.Sku.Capacity, gw2.Sku.Capacity);

            // compare connectionDraining
            for (int i = 0; i < gw1.BackendHttpSettingsCollection.Count; i++)
            {
                if (gw1.BackendHttpSettingsCollection[i].ConnectionDraining != null)
                {
                    Assert.NotNull(gw2.BackendHttpSettingsCollection[i].ConnectionDraining);
                    Assert.AreEqual(gw1.BackendHttpSettingsCollection[i].ConnectionDraining.Enabled, gw2.BackendHttpSettingsCollection[i].ConnectionDraining.Enabled);
                    Assert.AreEqual(gw1.BackendHttpSettingsCollection[i].ConnectionDraining.DrainTimeoutInSeconds, gw2.BackendHttpSettingsCollection[i].ConnectionDraining.DrainTimeoutInSeconds);
                }
                else
                {
                    Assert.Null(gw2.BackendHttpSettingsCollection[i].ConnectionDraining);
                }
            }
        }

        [Test]
        [Ignore("Track2: SSL is missing, and there is no explicit SSL creation in the test.")]
        public async Task ApplicationGatewayApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "West US";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string gwSubnetName = Recording.GenerateAssetName("azsmnet");
            string subnet2Name = Recording.GenerateAssetName("azsmnet");
            string appGwName = Recording.GenerateAssetName("azsmnet");

            var vnet = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = { "10.1.1.1", "10.1.2.4" } },
                Subnets = {
                        new SubnetData() { Name = gwSubnetName, AddressPrefix = "10.0.0.0/24" },
                        new SubnetData() { Name = subnet2Name, AddressPrefix = "10.0.1.0/24" }
                    }
            };

            var virtualNetworkCollection = GetVirtualNetworkCollection(resourceGroup);
            var putVnetResponseOperation = await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, vnet);
            await putVnetResponseOperation.WaitForCompletionAsync();
            Response<VirtualNetworkResource> getVnetResponse = await virtualNetworkCollection.GetAsync(vnetName);
            Response<SubnetResource> getSubnetResponse = await getVnetResponse.Value.GetSubnets().GetAsync(gwSubnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Data.Id);
            Response<SubnetResource> gwSubnet = getSubnetResponse;

            ApplicationGatewayData appGw = CreateApplicationGateway(location, gwSubnet, resourceGroupName, appGwName, TestEnvironment.SubscriptionId);

            // Put AppGw
            var applicationGatewayCollection = GetApplicationGatewayCollection(resourceGroupName);
            Operation<ApplicationGatewayResource> putAppGw = await applicationGatewayCollection.CreateOrUpdateAsync(WaitUntil.Completed, appGwName, appGw);
            Response<ApplicationGatewayResource> putAppGwResponse = await putAppGw.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putAppGwResponse.Value.Data.ProvisioningState.ToString());

            // Get AppGw
            Response<ApplicationGatewayResource> getGateway = await applicationGatewayCollection.GetAsync(appGwName);
            Assert.AreEqual(appGwName, getGateway.Value.Data.Name);
            CompareApplicationGateway(appGw, getGateway.Value.Data);

            // Get available WAF rule sets (validate first result set/group)
            ApplicationGatewayFirewallRuleSet availableWAFRuleSet = null;
            await foreach (var namespaceId in _subscription.GetAppGatewayAvailableWafRuleSetsAsync())
            {
                availableWAFRuleSet = namespaceId;
                break;
            }

            Assert.NotNull(availableWAFRuleSet);
            Assert.NotNull(availableWAFRuleSet.Name);
            Assert.NotNull(availableWAFRuleSet.RuleSetType);
            Assert.NotNull(availableWAFRuleSet.RuleSetVersion);
            Assert.IsNotEmpty(availableWAFRuleSet.RuleGroups);
            Assert.NotNull(availableWAFRuleSet.RuleGroups[0].RuleGroupName);
            Assert.IsNotEmpty(availableWAFRuleSet.RuleGroups[0].Rules);
            // Assert.NotNull(availableWAFRuleSet.RuleGroups[0].Rules[0].RuleId);

            // Get availalbe SSL options
            //Response<ApplicationGatewayAvailableSslOptions> sslOptions = await _subscription.GetApplicationGatewayAvailableSslOptions().GetAsync();
            //Assert.NotNull(sslOptions.Value.Data.DefaultPolicy);
            //Assert.NotNull(sslOptions.Value.Data.AvailableCipherSuites);
            //Assert.NotNull(sslOptions.Value.Data.AvailableCipherSuites[20]);

            //AsyncPageable<ApplicationGatewaySslPredefinedPolicy> policies = _subscription.GetApplicationGatewayAvailableSslPredefinedPoliciesAsync();
            //IAsyncEnumerator<ApplicationGatewaySslPredefinedPolicy> enumerator = policies.GetAsyncEnumerator();
            //Assert.True(enumerator.MoveNextAsync().Result);
            //Assert.NotNull(enumerator.Current.Name);

            //Task<Response<ApplicationGatewaySslPredefinedPolicy>> policy = _subscription.GetApplicationGatewayAvailableSslPredefinedPolicyAsync(ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501.ToString());
            //Assert.NotNull(policy.Result.Value.MinProtocolVersion);
            //Assert.NotNull(policy.Result.Value.CipherSuites);
            //Assert.NotNull(policy.Result.Value.CipherSuites[20]);

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");

            Task<NetworkInterfaceResource> nic1 = CreateNetworkInterface(
                nic1name,
                resourceGroupName,
                null,
                getVnetResponse.Value.Data.Subnets[1].Id,
                location,
                "ipconfig");

            Task<NetworkInterfaceResource> nic2 = CreateNetworkInterface(
                nic2name,
                resourceGroupName,
                null,
                getVnetResponse.Value.Data.Subnets[1].Id,
                location,
                "ipconfig");

            // Add NIC to application gateway backend address pool.
            nic1.Result.Data.IPConfigurations[0].ApplicationGatewayBackendAddressPools.Add(getGateway.Value.Data.BackendAddressPools[1]);
            nic2.Result.Data.IPConfigurations[0].ApplicationGatewayBackendAddressPools.Add(getGateway.Value.Data.BackendAddressPools[1]);
            // Put Nics
            var networkInterfaceCollection = GetNetworkInterfaceCollection(resourceGroupName);
            var createOrUpdateOperation1 = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic1name, nic1.Result.Data);
            await createOrUpdateOperation1.WaitForCompletionAsync();

            var createOrUpdateOperation2 = await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, nic2name, nic2.Result.Data);
            await createOrUpdateOperation2.WaitForCompletionAsync();

            // Get AppGw backend health
            Operation<ApplicationGatewayBackendHealth> backendHealthOperation = await getGateway.Value.BackendHealthAsync(WaitUntil.Started, "true");
            Response<ApplicationGatewayBackendHealth> backendHealth = await backendHealthOperation.WaitForCompletionAsync();

            Assert.AreEqual(2, backendHealth.Value.BackendAddressPools.Count);
            Assert.AreEqual(1, backendHealth.Value.BackendAddressPools[0].BackendHttpSettingsCollection.Count);
            Assert.AreEqual(1, backendHealth.Value.BackendAddressPools[1].BackendHttpSettingsCollection.Count);
            Assert.True(backendHealth.Value.BackendAddressPools[1].BackendAddressPool.BackendIPConfigurations.Any());

            //Start AppGw
            await getGateway.Value.StartAsync(WaitUntil.Completed);

            // Get AppGw and make sure nics are added to backend
            getGateway = await applicationGatewayCollection.GetAsync(appGwName);
            Assert.AreEqual(2, getGateway.Value.Data.BackendAddressPools[1].BackendIPConfigurations.Count);

            //Stop AppGw
            await getGateway.Value.StopAsync(WaitUntil.Completed);

            // Delete AppGw
            await getGateway.Value.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task AppGatewayBackendHealthCheckTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");
            string location = "westus2";
            var resourceGroup = await CreateResourceGroup(resourceGroupName, location);

            //create vnet
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string AGSubnetName = Recording.GenerateAssetName("azsmnet");
            string BackendSubnetName = Recording.GenerateAssetName("azsmnet");

            var vnetdata = new VirtualNetworkData()
            {
                Location = location,
                AddressSpace = new VirtualNetworkAddressSpace() { AddressPrefixes = { "10.21.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = { "10.21.1.1", "10.21.2.4" } },
                Subnets = {
                        new SubnetData() { Name = BackendSubnetName, AddressPrefix = "10.21.1.0/24" },
                        new SubnetData() { Name = AGSubnetName, AddressPrefix = "10.21.0.0/24" }
                    }
            };
            var virtualNetworkCollection = GetVirtualNetworkCollection(resourceGroup);
            var putVnetResponseOperation = InstrumentOperation(await virtualNetworkCollection.CreateOrUpdateAsync(WaitUntil.Started, vnetName, vnetdata));
            var vnet = await putVnetResponseOperation.WaitForCompletionAsync();

            // Create PublicIpAddress
            string publicIpName = Recording.GenerateAssetName("azsmnet");
            string domainNameLabel = Recording.GenerateAssetName("azsmnet");

            PublicIPAddressResource nic1publicIp = await CreateStaticPublicIpAddress(publicIpName, domainNameLabel, location, resourceGroup.GetPublicIPAddresses());
            Assert.IsNotNull(nic1publicIp.Data);

            //create VMs
            string virtualMachineName1 = Recording.GenerateAssetName("azsmnet");
            string virtualMachineName2 = Recording.GenerateAssetName("azsmnet");
            string nicName1 = Recording.GenerateAssetName("azsmnet");
            string nicName2 = Recording.GenerateAssetName("azsmnet");

            //VMs and AppGateway use same vnet, different subnet
            var vm1 = await CreateLinuxVM(virtualMachineName1, nicName1, location, resourceGroup, vnet);
            var vm2 = await CreateLinuxVM(virtualMachineName2, nicName2, location, resourceGroup, vnet);

            //associate VMs's nic with application gateway
            var nicPrivateIpAdd1 = GetNetworkInterfaceCollection(resourceGroup).GetAsync(nicName1).Result.Value.Data.IPConfigurations.FirstOrDefault().PrivateIPAddress;
            var nicPrivateIpAdd2 = GetNetworkInterfaceCollection(resourceGroup).GetAsync(nicName2).Result.Value.Data.IPConfigurations.FirstOrDefault().PrivateIPAddress;
            string[] ipAddresses = new string[2] { nicPrivateIpAdd1, nicPrivateIpAdd2 };

            //create ApplicationGateway
            string appGwName = Recording.GenerateAssetName("azsmnet");
            Response<VirtualNetworkResource> getVnetResponse = await virtualNetworkCollection.GetAsync(vnetName);
            Response<SubnetResource> getSubnetResponse = await getVnetResponse.Value.GetSubnets().GetAsync(AGSubnetName);
            Response<SubnetResource> agSubnet = getSubnetResponse;

            ApplicationGatewayData appGw = CreateApplicationGatewayWithoutSsl(location, nic1publicIp, agSubnet, resourceGroupName, appGwName, TestEnvironment.SubscriptionId, ipAddresses);

            // Put AppGw
            var applicationGatewayCollection = resourceGroup.GetApplicationGateways();
            var putAppGw = await applicationGatewayCollection.CreateOrUpdateAsync(WaitUntil.Started, appGwName, appGw);
            var putAppGwResponse = await putAppGw.WaitForCompletionAsync();
            Assert.AreEqual("Succeeded", putAppGwResponse.Value.Data.ProvisioningState.ToString());

            // Get AppGw
            Response<ApplicationGatewayResource> getGateway = await applicationGatewayCollection.GetAsync(appGwName);
            Assert.AreEqual(appGwName, getGateway.Value.Data.Name);
            CompareApplicationGatewayBase(appGw, getGateway.Value.Data);

            // Add NIC to application gateway backend address pool.
            var nic1 = GetNetworkInterfaceCollection(resourceGroup).GetAsync(nicName1);
            var nic2 = GetNetworkInterfaceCollection(resourceGroup).GetAsync(nicName2);
            Assert.NotNull(nic1);
            Assert.NotNull(nic2);
            nic1.Result.Value.Data.IPConfigurations[0].ApplicationGatewayBackendAddressPools.Add(getGateway.Value.Data.BackendAddressPools[1]);
            nic2.Result.Value.Data.IPConfigurations[0].ApplicationGatewayBackendAddressPools.Add(getGateway.Value.Data.BackendAddressPools[1]);

            // Put Nics
            var networkInterfaceCollection = GetNetworkInterfaceCollection(resourceGroup);
            var createOrUpdateOperation1 = InstrumentOperation(await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Started, nicName1, nic1.Result.Value.Data));
            await createOrUpdateOperation1.WaitForCompletionAsync();

            var createOrUpdateOperation2 = InstrumentOperation(await networkInterfaceCollection.CreateOrUpdateAsync(WaitUntil.Started, nicName2, nic2.Result.Value.Data));
            await createOrUpdateOperation2.WaitForCompletionAsync();

            // Get AppGw backend health
            Operation<ApplicationGatewayBackendHealth> backendHealthOperation = InstrumentOperation(await getGateway.Value.BackendHealthAsync(WaitUntil.Started, "true"));
            Response<ApplicationGatewayBackendHealth> backendHealth = await backendHealthOperation.WaitForCompletionAsync();

            Assert.AreEqual(2, backendHealth.Value.BackendAddressPools[0].BackendHttpSettingsCollection[0].Servers.Count);
            Assert.AreEqual(nicPrivateIpAdd1, backendHealth.Value.BackendAddressPools[0].BackendHttpSettingsCollection[0].Servers[0].Address);
            Assert.AreEqual(nicPrivateIpAdd2, backendHealth.Value.BackendAddressPools[0].BackendHttpSettingsCollection[0].Servers[1].Address);

            //Start AppGw
            // TODO: ADO 6162, but consider to move this into another test
            //await getGateway.Value.StartAsync();

            // Get AppGw and make sure nics are added to backend
            getGateway = await applicationGatewayCollection.GetAsync(appGwName);
            Assert.AreEqual(2, getGateway.Value.Data.BackendAddressPools[1].BackendIPConfigurations.Count);

            //Stop AppGw
            // TODO: ADO 6162, but consider to move this into another test
            //await getGateway.Value.StopAsync();

            // Delete AppGw
            await getGateway.Value.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task ApplicationGatewayAvailableSslOptionsInfoTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();
            ApplicationGatewayAvailableSslOptionsInfo sslOptionsInfo = await subscription.GetApplicationGatewayAvailableSslOptionsAsync();
            Assert.NotNull(sslOptionsInfo);
            Assert.AreEqual(sslOptionsInfo.Name, "default");
            Assert.AreEqual(sslOptionsInfo.Id.ResourceType, sslOptionsInfo.ResourceType);
            Assert.AreEqual(sslOptionsInfo.DefaultPolicy, ApplicationGatewaySslPolicyName.AppGwSslPolicy20220101);
            Assert.AreEqual(sslOptionsInfo.PredefinedPolicies.Count, 5);
            foreach (var predefinedPolicy in sslOptionsInfo.PredefinedPolicies)
            {
                Assert.AreEqual(predefinedPolicy.Id.ResourceType, "Microsoft.Network/ApplicationGatewayAvailableSslOptions/ApplicationGatewaySslPredefinedPolicy");
            }
        }

        [Test]
        [RecordedTest]
        public async Task ApplicationGatewayAvailableSslPredefinedPoliciesTest()
        {
            SubscriptionResource subscription = await ArmClient.GetDefaultSubscriptionAsync();

            IList<ApplicationGatewaySslPredefinedPolicy> predefinedPolicies = await subscription.GetApplicationGatewayAvailableSslPredefinedPoliciesAsync().ToEnumerableAsync();

            int cnt = 0;
            foreach (var policy in predefinedPolicies)
            {
                ++cnt;
                Assert.NotNull(policy);
                Assert.AreEqual(policy.Id.ResourceType, policy.ResourceType);
            }
            Assert.AreEqual(cnt, 5);

            string predefinedPolicyName = predefinedPolicies[0].Name;
            ApplicationGatewaySslPredefinedPolicy predefinedPolicy = await subscription.GetApplicationGatewaySslPredefinedPolicyAsync(predefinedPolicyName);
            Assert.AreEqual(predefinedPolicy.Name, predefinedPolicyName);
            Assert.AreEqual(predefinedPolicy.Id.ResourceType, predefinedPolicy.ResourceType);
        }
    }
}
