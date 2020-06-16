﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Compute;
using Azure.Management.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using SubResource = Azure.ResourceManager.Network.Models.SubResource;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class ApplicationGatewayTests : NetworkTestsManagementClientBase
    {
        public ApplicationGatewayTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

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

        private List<ApplicationGatewaySslCertificate> CreateSslCertificate(string sslCertName, string password)
        {
            string certPath = System.IO.Path.Combine("Tests", "Data", "rsa2048.pfx");
            X509Certificate2 cert = new X509Certificate2(certPath, password, X509KeyStorageFlags.Exportable);

            List<ApplicationGatewaySslCertificate> sslCertList = new List<ApplicationGatewaySslCertificate>{
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
            X509Certificate2 cert = new X509Certificate2(certPath);

            List<ApplicationGatewayAuthenticationCertificate> authCertList = new List<ApplicationGatewayAuthenticationCertificate>()
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

            ApplicationGateway appGw = new ApplicationGateway()
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
                WebApplicationFirewallConfiguration = new ApplicationGatewayWebApplicationFirewallConfiguration(true, ApplicationGatewayFirewallMode.Prevention, "OWASP", "2.2.9")
                {
                    DisabledRuleGroups = new List<ApplicationGatewayFirewallDisabledRuleGroup>()
                    {
                        new ApplicationGatewayFirewallDisabledRuleGroup("crs_41_sql_injection_attacks")
                        {
                            Rules=new List<int>() { 981318, 981320 }
                        },
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
                    Assert.AreEqual(gw1.BackendHttpSettingsCollection[i].ConnectionDraining.DrainTimeoutInSec, gw2.BackendHttpSettingsCollection[i].ConnectionDraining.DrainTimeoutInSec);
                }
                else
                {
                    Assert.Null(gw2.BackendHttpSettingsCollection[i].ConnectionDraining);
                }
            }

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

        [Test]
        [Ignore("Track2: SSL is missing, and there is no explicit SSL creation in the test.")]
        public async Task ApplicationGatewayApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("csmrg");

            string location = "West US";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));
            string vnetName = Recording.GenerateAssetName("azsmnet");
            string gwSubnetName = Recording.GenerateAssetName("azsmnet");
            string subnet2Name = Recording.GenerateAssetName("azsmnet");
            string appGwName = Recording.GenerateAssetName("azsmnet");

            VirtualNetwork vnet = new VirtualNetwork()
            {
                Location = location,
                AddressSpace = new AddressSpace() { AddressPrefixes = new List<string>() { "10.0.0.0/16", } },
                DhcpOptions = new DhcpOptions() { DnsServers = new List<string>() { "10.1.1.1", "10.1.2.4" } },
                Subnets = new List<Subnet>()
                    {
                        new Subnet() { Name = gwSubnetName, AddressPrefix = "10.0.0.0/24" },
                        new Subnet() { Name = subnet2Name, AddressPrefix = "10.0.1.0/24" }
                    }
            };

            VirtualNetworksCreateOrUpdateOperation putVnetResponseOperation = await NetworkManagementClient.VirtualNetworks.StartCreateOrUpdateAsync(resourceGroupName, vnetName, vnet);
            await WaitForCompletionAsync(putVnetResponseOperation);
            Response<VirtualNetwork> getVnetResponse = await NetworkManagementClient.VirtualNetworks.GetAsync(resourceGroupName, vnetName);
            Response<Subnet> getSubnetResponse = await NetworkManagementClient.Subnets.GetAsync(resourceGroupName, vnetName, gwSubnetName);
            Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Value.Id);
            Response<Subnet> gwSubnet = getSubnetResponse;

            ApplicationGateway appGw = CreateApplicationGateway(location, gwSubnet, resourceGroupName, appGwName, TestEnvironment.SubscriptionId);

            // Put AppGw
            Operation<ApplicationGateway> putAppGw = await NetworkManagementClient.ApplicationGateways.StartCreateOrUpdateAsync(resourceGroupName, appGwName, appGw);
            Response<ApplicationGateway> putAppGwResponse = await WaitForCompletionAsync(putAppGw);
            Assert.AreEqual("Succeeded", putAppGwResponse.Value.ProvisioningState.ToString());

            // Get AppGw
            Response<ApplicationGateway> getGateway = await NetworkManagementClient.ApplicationGateways.GetAsync(resourceGroupName, appGwName);
            Assert.AreEqual(appGwName, getGateway.Value.Name);
            CompareApplicationGateway(appGw, getGateway);

            // Get available WAF rule sets (validate first result set/group)
            Response<ApplicationGatewayAvailableWafRuleSetsResult> availableWAFRuleSets = await NetworkManagementClient.ApplicationGateways.ListAvailableWafRuleSetsAsync();
            Assert.NotNull(availableWAFRuleSets);
            Assert.IsNotEmpty(availableWAFRuleSets.Value.Value);
            Assert.NotNull(availableWAFRuleSets.Value.Value[0].Name);
            Assert.NotNull(availableWAFRuleSets.Value.Value[0].RuleSetType);
            Assert.NotNull(availableWAFRuleSets.Value.Value[0].RuleSetVersion);
            Assert.IsNotEmpty(availableWAFRuleSets.Value.Value[0].RuleGroups);
            Assert.NotNull(availableWAFRuleSets.Value.Value[0].RuleGroups[0].RuleGroupName);
            Assert.IsNotEmpty(availableWAFRuleSets.Value.Value[0].RuleGroups[0].Rules);
            // Assert.NotNull(availableWAFRuleSets.Value[0].RuleGroups[0].Rules[0].RuleId);

            // Get availalbe SSL options
            Response<ApplicationGatewayAvailableSslOptions> sslOptions = await NetworkManagementClient.ApplicationGateways.ListAvailableSslOptionsAsync();
            Assert.NotNull(sslOptions.Value.DefaultPolicy);
            Assert.NotNull(sslOptions.Value.AvailableCipherSuites);
            Assert.NotNull(sslOptions.Value.AvailableCipherSuites[20]);

            AsyncPageable<ApplicationGatewaySslPredefinedPolicy> policies = NetworkManagementClient.ApplicationGateways.ListAvailableSslPredefinedPoliciesAsync();
            IAsyncEnumerator<ApplicationGatewaySslPredefinedPolicy> enumerator = policies.GetAsyncEnumerator();
            Assert.True(enumerator.MoveNextAsync().Result);
            Assert.NotNull(enumerator.Current.Name);

            Task<Response<ApplicationGatewaySslPredefinedPolicy>> policy = NetworkManagementClient.ApplicationGateways.GetSslPredefinedPolicyAsync(ApplicationGatewaySslPolicyName.AppGwSslPolicy20150501.ToString());
            Assert.NotNull(policy.Result.Value.MinProtocolVersion);
            Assert.NotNull(policy.Result.Value.CipherSuites);
            Assert.NotNull(policy.Result.Value.CipherSuites[20]);

            // Create Nics
            string nic1name = Recording.GenerateAssetName("azsmnet");
            string nic2name = Recording.GenerateAssetName("azsmnet");

            Task<NetworkInterface> nic1 = CreateNetworkInterface(
                nic1name,
                resourceGroupName,
                null,
                getVnetResponse.Value.Subnets[1].Id,
                location,
                "ipconfig",
                NetworkManagementClient);

            Task<NetworkInterface> nic2 = CreateNetworkInterface(
                nic2name,
                resourceGroupName,
                null,
                getVnetResponse.Value.Subnets[1].Id,
                location,
                "ipconfig",
                NetworkManagementClient);

            // Add NIC to application gateway backend address pool.
            nic1.Result.IpConfigurations[0].ApplicationGatewayBackendAddressPools = new List<ApplicationGatewayBackendAddressPool> { getGateway.Value.BackendAddressPools[1] };
            nic2.Result.IpConfigurations[0].ApplicationGatewayBackendAddressPools = new List<ApplicationGatewayBackendAddressPool> { getGateway.Value.BackendAddressPools[1] };
            // Put Nics
            NetworkInterfacesCreateOrUpdateOperation createOrUpdateOperation1 = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic1name, nic1.Result);
            await WaitForCompletionAsync(createOrUpdateOperation1);

            NetworkInterfacesCreateOrUpdateOperation createOrUpdateOperation2 = await NetworkManagementClient.NetworkInterfaces.StartCreateOrUpdateAsync(resourceGroupName, nic2name, nic2.Result);
            await WaitForCompletionAsync(createOrUpdateOperation2);

            // Get AppGw backend health
            Operation<ApplicationGatewayBackendHealth> backendHealthOperation = await NetworkManagementClient.ApplicationGateways.StartBackendHealthAsync(resourceGroupName, appGwName, "true");
            Response<ApplicationGatewayBackendHealth> backendHealth = await WaitForCompletionAsync(backendHealthOperation);

            Assert.AreEqual(2, backendHealth.Value.BackendAddressPools.Count);
            Assert.AreEqual(1, backendHealth.Value.BackendAddressPools[0].BackendHttpSettingsCollection.Count);
            Assert.AreEqual(1, backendHealth.Value.BackendAddressPools[1].BackendHttpSettingsCollection.Count);
            Assert.True(backendHealth.Value.BackendAddressPools[1].BackendAddressPool.BackendIPConfigurations.Any());

            //Start AppGw
            await NetworkManagementClient.ApplicationGateways.StartStartAsync(resourceGroupName, appGwName);

            // Get AppGw and make sure nics are added to backend
            getGateway = await NetworkManagementClient.ApplicationGateways.GetAsync(resourceGroupName, appGwName);
            Assert.AreEqual(2, getGateway.Value.BackendAddressPools[1].BackendIPConfigurations.Count);

            //Stop AppGw
            await NetworkManagementClient.ApplicationGateways.StartStopAsync(resourceGroupName, appGwName);

            // Delete AppGw
            await NetworkManagementClient.ApplicationGateways.StartDeleteAsync(resourceGroupName, appGwName);
        }
    }
}
