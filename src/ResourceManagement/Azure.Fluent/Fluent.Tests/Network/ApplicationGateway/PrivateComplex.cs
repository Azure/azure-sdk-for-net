// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal complex app gateway test.
    /// </summary>
    public class PrivateComplex : TestTemplate<IApplicationGateway, IApplicationGateways>
    {
        private INetworks networks;
        private List<IPublicIpAddress> testPips;

        public PrivateComplex(INetworks networks, IPublicIpAddresses pips)
        {
            this.networks = networks;
            testPips = new List<IPublicIpAddress>(ApplicationGatewayHelper.EnsurePIPs(pips));
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {
            INetwork vnet = networks.Define("net" + ApplicationGatewayHelper.TEST_ID)
                .WithRegion(ApplicationGatewayHelper.REGION)
                .WithNewResourceGroup(ApplicationGatewayHelper.GROUP_NAME)
                .WithAddressSpace("10.0.0.0/28")
                .WithSubnet("subnet1", "10.0.0.0/29")
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            Thread creationThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                // Create an application gateway
                try {
                    resources.Define(ApplicationGatewayHelper.APP_GATEWAY_NAME)
                        .WithRegion(ApplicationGatewayHelper.REGION)
                        .WithExistingResourceGroup(ApplicationGatewayHelper.GROUP_NAME)

                        // Request routing rules
                        .DefineRequestRoutingRule("rule80")
                            .FromPrivateFrontend()
                            .FromFrontendHttpPort(80)
                            .ToBackendHttpPort(8080)
                            .ToBackendIpAddress("11.1.1.1")
                            .ToBackendIpAddress("11.1.1.2")
                            .WithCookieBasedAffinity()
                            .Attach()
                        .DefineRequestRoutingRule("rule443")
                            .FromPrivateFrontend()
                            .FromFrontendHttpsPort(443)
                            .WithSslCertificateFromPfxFile(new FileInfo("c:\\automation\\myTest.pfx"))
                            .WithSslCertificatePassword("Abc123")
                            .ToBackendHttpConfiguration("config1")
                            .ToBackend("backend1")
                        .Attach()
                        .DefineRequestRoutingRule("rule9000")
                            .FromListener("listener1")
                            .ToBackendHttpConfiguration("config1")
                            .ToBackend("backend1")
                            .Attach()

                        // Additional/explicit backend HTTP setting configs
                        .DefineBackendHttpConfiguration("config1")
                            .WithPort(8081)
                            .WithRequestTimeout(45)
                            .Attach()
                        .DefineBackendHttpConfiguration("config2")
                            .Attach()

                        // Additional/explicit backends
                        .DefineBackend("backend1")
                            .WithIpAddress("11.1.1.3")
                            .WithIpAddress("11.1.1.4")
                            .Attach()
                        .DefineBackend("backend2")
                            .Attach()

                        // Additional/explicit frontend listeners
                        .DefineListener("listener1")
                            .WithPrivateFrontend()
                            .WithFrontendPort(9000)
                            .WithHttp()
                            .Attach()

                        // Additional/explicit certificates
                        .DefineSslCertificate("cert1")
                            .WithPfxFromFile(new FileInfo("c:\\automation\\myTest2.pfx"))
                            .WithPfxPassword("Abc123")
                            .Attach()

                        .WithExistingSubnet(vnet, "subnet1")
                        .WithSize(ApplicationGatewaySkuName.StandardMedium)
                        .WithInstanceCount(2)
                        .Create();
                } catch {
                }

            });

            // Start creating in a separate thread...
            creationThread.Start();

            // ...But don't wait till the end - not needed for the test, 30 sec should be enough
            Thread.Sleep(30 * 1000);

            // Get the resource as created so far
            string resourceId = ApplicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.True(appGateway != null);
            Assert.True(ApplicationGatewayTier.Standard == appGateway.Tier);
            Assert.True(ApplicationGatewaySkuName.StandardMedium == appGateway.Size);
            Assert.True(appGateway.InstanceCount == 2);
            Assert.True(!appGateway.IsPublic);
            Assert.True(appGateway.IsPrivate);
            Assert.True(appGateway.IpConfigurations.Count == 1);

            // Verify frontend ports
            Assert.True(appGateway.FrontendPorts.Count == 3);
            Assert.True(appGateway.FrontendPortNameFromNumber(80) != null);
            Assert.True(appGateway.FrontendPortNameFromNumber(443) != null);
            Assert.True(appGateway.FrontendPortNameFromNumber(9000) != null);

            // Verify frontends
            Assert.True(appGateway.Frontends.Count == 1);
            Assert.True(appGateway.PublicFrontends.Count == 0);
            Assert.True(appGateway.PrivateFrontends.Count == 1);
            IApplicationGatewayFrontend frontend = appGateway.PrivateFrontends.Values.First();
            Assert.True(!frontend.IsPublic);
            Assert.True(frontend.IsPrivate);

            // Verify listeners
            Assert.True(appGateway.Listeners.Count == 3);
            IApplicationGatewayListener listener = appGateway.Listeners["listener1"];
            Assert.True(listener != null);
            Assert.True(listener.FrontendPortNumber == 9000);
            Assert.True(ApplicationGatewayProtocol.Http == listener.Protocol);
            Assert.True(listener.Frontend != null);
            Assert.True(listener.Frontend.IsPrivate);
            Assert.True(!listener.Frontend.IsPublic);
            Assert.True(appGateway.ListenerByPortNumber(80) != null);
            Assert.True(appGateway.ListenerByPortNumber(443) != null);

            // Verify certificates
            Assert.True(appGateway.SslCertificates.Count == 2);
            Assert.True(appGateway.SslCertificates.ContainsKey("cert1"));

            // Verify backend HTTP settings configs
            Assert.True(appGateway.BackendHttpConfigurations.Count == 3);
            IApplicationGatewayBackendHttpConfiguration config = appGateway.BackendHttpConfigurations["config1"];
            Assert.True(config != null);
            Assert.True(config.Port == 8081);
            Assert.True(config.RequestTimeout == 45);
            Assert.True(appGateway.BackendHttpConfigurations.ContainsKey("config2"));

            // Verify backends
            Assert.True(appGateway.Backends.Count == 3);
            IApplicationGatewayBackend backend = appGateway.Backends["backend1"];
            Assert.True(backend != null);
            Assert.True(backend.Addresses.Count == 2);
            Assert.True(backend.ContainsIpAddress("11.1.1.3"));
            Assert.True(backend.ContainsIpAddress("11.1.1.4"));
            Assert.True(appGateway.Backends.ContainsKey("backend2"));

            // Verify request routing rules
            Assert.True(appGateway.RequestRoutingRules.Count == 3);
            IApplicationGatewayRequestRoutingRule rule;

            rule = appGateway.RequestRoutingRules["rule80"];
            Assert.True(rule != null);
            Assert.True(vnet.Id == rule.Listener.Frontend.NetworkId);
            Assert.True(rule.FrontendPort == 80);
            Assert.True(rule.BackendPort == 8080);
            Assert.True(rule.CookieBasedAffinity);
            Assert.True(rule.BackendAddresses.Count == 2);
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.2"));

            rule = appGateway.RequestRoutingRules["rule443"];
            Assert.True(rule != null);
            Assert.True(vnet.Id == rule.Listener.Frontend.NetworkId);
            Assert.True(rule.FrontendPort == 443);
            Assert.True(ApplicationGatewayProtocol.Https == rule.FrontendProtocol);
            Assert.True(rule.SslCertificate != null);
            Assert.True(rule.BackendHttpConfiguration != null);
            Assert.True(rule.BackendHttpConfiguration.Name == "config1");
            Assert.True(rule.Backend != null);
            Assert.True(rule.Backend.Name == "backend1");

            rule = appGateway.RequestRoutingRules["rule9000"];
            Assert.True(rule != null);
            Assert.True(rule.Listener != null);
            Assert.True(rule.Listener.Name == "listener1");
            Assert.True(rule.Listener.SubnetName != null);
            Assert.True(rule.Listener.NetworkId != null);
            Assert.True(rule.BackendHttpConfiguration != null);
            Assert.True(rule.BackendHttpConfiguration.Name == "config1");
            Assert.True(rule.Backend != null);
            Assert.True(rule.Backend.Name == "backend1");

            creationThread.Join();

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            int portCount = resource.FrontendPorts.Count;
            int frontendCount = resource.Frontends.Count;
            int listenerCount = resource.Listeners.Count;
            int ruleCount = resource.RequestRoutingRules.Count;
            int backendCount = resource.Backends.Count;
            int configCount = resource.BackendHttpConfigurations.Count;
            int certCount = resource.SslCertificates.Count;

            resource.Update()
                .WithSize(ApplicationGatewaySkuName.StandardSmall)
                .WithInstanceCount(1)
                .WithoutFrontendPort(9000)
                .WithoutListener("listener1")
                .WithoutBackendIpAddress("11.1.1.4")
                .WithoutBackendHttpConfiguration("config2")
                .WithoutBackend("backend2")
                .WithoutRequestRoutingRule("rule9000")
                .WithoutCertificate("cert1")
                .UpdateListener(resource.RequestRoutingRules["rule443"].Listener.Name)
                    .WithHostName("foobar")
                    .Parent()
                .UpdateBackendHttpConfiguration("config1")
                    .WithPort(8082)
                    .WithCookieBasedAffinity()
                    .WithRequestTimeout(20)
                    .Parent()
                .UpdateBackend("backend1")
                    .WithoutIpAddress("11.1.1.3")
                    .WithIpAddress("11.1.1.5")
                    .Parent()
                .UpdateRequestRoutingRule("rule80")
                    .ToBackend("backend1")
                    .ToBackendHttpConfiguration("config1")
                    .Parent()
                .WithExistingPublicIpAddress(testPips[0]) // Associate with a public IP as well
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            // Get the resource created so far
            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.True(resource.Tags.ContainsKey("tag2"));
            Assert.True(ApplicationGatewaySkuName.StandardSmall == resource.Size);
            Assert.True(resource.InstanceCount == 1);

            // Verify frontend ports
            Assert.True(resource.FrontendPorts.Count == portCount - 1);
            Assert.True(resource.FrontendPortNameFromNumber(9000) == null);

            // Verify frontends
            Assert.True(resource.Frontends.Count == frontendCount + 1);
            Assert.True(resource.PublicFrontends.Count == 1);
            Assert.True(resource.PrivateFrontends.Count == 1);
            IApplicationGatewayFrontend frontend = resource.PrivateFrontends.Values.First();
            Assert.True(!frontend.IsPublic);
            Assert.True(frontend.IsPrivate);

            // Verify listeners
            Assert.True(resource.Listeners.Count == listenerCount - 1);
            Assert.True(!resource.Listeners.ContainsKey("listener1"));

            // Verify backends
            Assert.True(resource.Backends.Count == backendCount - 1);
            Assert.True(!resource.Backends.ContainsKey("backend2"));
            IApplicationGatewayBackend backend = resource.Backends["backend1"];
            Assert.True(backend != null);
            Assert.True(backend.Addresses.Count == 1);
            Assert.True(backend.ContainsIpAddress("11.1.1.5"));
            Assert.True(!backend.ContainsIpAddress("11.1.1.3"));
            Assert.True(!backend.ContainsIpAddress("11.1.1.4"));

            // Verify HTTP configs
            Assert.True(resource.BackendHttpConfigurations.Count == configCount - 1);
            Assert.True(!resource.BackendHttpConfigurations.ContainsKey("config2"));
            IApplicationGatewayBackendHttpConfiguration config = resource.BackendHttpConfigurations["config1"];
            Assert.True(config.Port == 8082);
            Assert.True(config.RequestTimeout == 20);
            Assert.True(config.CookieBasedAffinity);

            // Verify rules
            Assert.True(resource.RequestRoutingRules.Count == ruleCount - 1);
            Assert.True(!resource.RequestRoutingRules.ContainsKey("rule9000"));

            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule80"];
            Assert.True(rule != null);
            Assert.True(rule.Backend != null);
            Assert.True("backend1" == rule.Backend.Name);
            Assert.True(rule.BackendHttpConfiguration != null);
            Assert.True("config1" == rule.BackendHttpConfiguration.Name);

            rule = resource.RequestRoutingRules["rule443"];
            Assert.True(rule != null);
            Assert.True(rule.Listener != null);
            Assert.True("foobar" == rule.Listener.HostName);

            // Verify certificates
            Assert.True(resource.SslCertificates.Count == certCount - 1);
            Assert.True(!resource.SslCertificates.ContainsKey("cert1"));

            return resource;
        }
    }
}
