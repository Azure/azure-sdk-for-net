// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal complex app gateway test.
    /// </summary>
    public class PrivateComplex : TestTemplate<IApplicationGateway, IApplicationGateways, INetworkManager>
    {
        private INetworks networks;
        private List<IPublicIPAddress> testPips;
        private ApplicationGatewayHelper applicationGatewayHelper;

        public PrivateComplex([CallerMemberName] string methodName = "testframework_failed")
            : base(methodName)
        {
            applicationGatewayHelper = new ApplicationGatewayHelper(TestUtilities.GenerateName("", methodName));
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {
            testPips = new List<IPublicIPAddress>(applicationGatewayHelper.EnsurePIPs(resources.Manager.PublicIPAddresses));
            networks = resources.Manager.Networks;

            INetwork vnet = networks.Define("net" + applicationGatewayHelper.TestId)
                .WithRegion(applicationGatewayHelper.Region)
                .WithNewResourceGroup(applicationGatewayHelper.GroupName)
                .WithAddressSpace("10.0.0.0/28")
                .WithSubnet("subnet1", "10.0.0.0/29")
                .WithSubnet("subnet2", "10.0.0.8/29")
                .Create();

            Thread creationThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                // Create an application gateway
                resources.Define(applicationGatewayHelper.AppGatewayName)
                    .WithRegion(applicationGatewayHelper.Region)
                    .WithExistingResourceGroup(applicationGatewayHelper.GroupName)

                    // Request routing rules
                    .DefineRequestRoutingRule("rule80")
                        .FromPrivateFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendIPAddress("11.1.1.1")
                        .ToBackendIPAddress("11.1.1.2")
                        .WithCookieBasedAffinity()
                        .Attach()
                    .DefineRequestRoutingRule("rule443")
                        .FromPrivateFrontend()
                        .FromFrontendHttpsPort(443)
                        .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets","myTest._pfx")))
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
                        .WithIPAddress("11.1.1.3")
                        .WithIPAddress("11.1.1.4")
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
                        .WithPfxFromFile(new FileInfo(Path.Combine("Assets","myTest2._pfx")))
                        .WithPfxPassword("Abc123")
                        .Attach()

                    .WithExistingSubnet(vnet, "subnet1")
                    .WithSize(ApplicationGatewaySkuName.StandardMedium)
                    .WithInstanceCount(2)
                    .Create();
            });

            // Start creating in a separate thread...
            creationThread.Start();

            // ...But don't wait till the end - not needed for the test, 30 sec should be enough
            TestHelper.Delay(30 * 1000);

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.Equal(ApplicationGatewayTier.Standard, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.StandardMedium, appGateway.Size);
            Assert.Equal(appGateway.InstanceCount, 2);
            Assert.False(appGateway.IsPublic);
            Assert.True(appGateway.IsPrivate);
            Assert.Equal(appGateway.IPConfigurations.Count, 1);

            // Verify frontend ports
            Assert.Equal(appGateway.FrontendPorts.Count, 3);
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(80));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(443));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(9000));

            // Verify frontends
            Assert.Equal(appGateway.Frontends.Count, 1);
            Assert.Equal(appGateway.PublicFrontends.Count, 0);
            Assert.Equal(appGateway.PrivateFrontends.Count, 1);
            IApplicationGatewayFrontend frontend = appGateway.PrivateFrontends.Values.First();
            Assert.False(frontend.IsPublic);
            Assert.True(frontend.IsPrivate);

            // Verify listeners
            Assert.Equal(appGateway.Listeners.Count, 3);
            IApplicationGatewayListener listener = appGateway.Listeners["listener1"];
            Assert.NotNull(listener);
            Assert.Equal(listener.FrontendPortNumber, 9000);
            Assert.Equal(ApplicationGatewayProtocol.Http, listener.Protocol);
            Assert.NotNull(listener.Frontend);
            Assert.True(listener.Frontend.IsPrivate);
            Assert.False(listener.Frontend.IsPublic);
            Assert.NotNull(appGateway.ListenerByPortNumber(80));
            Assert.NotNull(appGateway.ListenerByPortNumber(443));

            // Verify certificates
            Assert.Equal(appGateway.SslCertificates.Count, 2);
            Assert.True(appGateway.SslCertificates.ContainsKey("cert1"));

            // Verify backend HTTP settings configs
            Assert.Equal(appGateway.BackendHttpConfigurations.Count, 3);
            IApplicationGatewayBackendHttpConfiguration config = appGateway.BackendHttpConfigurations["config1"];
            Assert.NotNull(config);
            Assert.Equal(config.Port, 8081);
            Assert.Equal(config.RequestTimeout, 45);
            Assert.True(appGateway.BackendHttpConfigurations.ContainsKey("config2"));

            // Verify backends
            Assert.Equal(appGateway.Backends.Count, 3);
            IApplicationGatewayBackend backend = appGateway.Backends["backend1"];
            Assert.NotNull(backend);
            Assert.Equal(backend.Addresses.Count, 2);
            Assert.True(backend.ContainsIPAddress("11.1.1.3"));
            Assert.True(backend.ContainsIPAddress("11.1.1.4"));
            Assert.True(appGateway.Backends.ContainsKey("backend2"));

            // Verify request routing rules
            Assert.Equal(appGateway.RequestRoutingRules.Count, 3);
            IApplicationGatewayRequestRoutingRule rule;

            rule = appGateway.RequestRoutingRules["rule80"];
            Assert.NotNull(rule);
            Assert.Equal(vnet.Id, rule.Listener.Frontend.NetworkId);
            Assert.Equal(rule.FrontendPort, 80);
            Assert.Equal(rule.BackendPort, 8080);
            Assert.True(rule.CookieBasedAffinity);
            Assert.Equal(rule.BackendAddresses.Count, 2);
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.2"));

            rule = appGateway.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.Equal(vnet.Id, rule.Listener.Frontend.NetworkId);
            Assert.Equal(rule.FrontendPort, 443);
            Assert.Equal(ApplicationGatewayProtocol.Https, rule.FrontendProtocol);
            Assert.NotNull(rule.SslCertificate);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal(rule.BackendHttpConfiguration.Name, "config1");
            Assert.NotNull(rule.Backend);
            Assert.Equal(rule.Backend.Name, "backend1");

            rule = appGateway.RequestRoutingRules["rule9000"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Listener);
            Assert.Equal(rule.Listener.Name, "listener1");
            Assert.NotNull(rule.Listener.SubnetName);
            Assert.NotNull(rule.Listener.NetworkId);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal(rule.BackendHttpConfiguration.Name, "config1");
            Assert.NotNull(rule.Backend);
            Assert.Equal(rule.Backend.Name, "backend1");

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
                .WithoutBackendIPAddress("11.1.1.4")
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
                    .WithoutIPAddress("11.1.1.3")
                    .WithIPAddress("11.1.1.5")
                    .Parent()
                .UpdateRequestRoutingRule("rule80")
                    .ToBackend("backend1")
                    .ToBackendHttpConfiguration("config1")
                    .Parent()
                .WithExistingPublicIPAddress(testPips[0]) // Associate with a public IP as well
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            // Get the resource created so far
            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.True(resource.Tags.ContainsKey("tag2"));
            Assert.Equal(ApplicationGatewaySkuName.StandardSmall, resource.Size);
            Assert.Equal(resource.InstanceCount, 1);

            // Verify frontend ports
            Assert.Equal(resource.FrontendPorts.Count, portCount - 1);
            Assert.Null(resource.FrontendPortNameFromNumber(9000));

            // Verify frontends
            Assert.Equal(resource.Frontends.Count, frontendCount + 1);
            Assert.Equal(resource.PublicFrontends.Count, 1);
            Assert.Equal(resource.PrivateFrontends.Count, 1);
            IApplicationGatewayFrontend frontend = resource.PrivateFrontends.Values.First();
            Assert.True(!frontend.IsPublic);
            Assert.True(frontend.IsPrivate);

            // Verify listeners
            Assert.Equal(resource.Listeners.Count, listenerCount - 1);
            Assert.True(!resource.Listeners.ContainsKey("listener1"));

            // Verify backends
            Assert.Equal(resource.Backends.Count, backendCount - 1);
            Assert.True(!resource.Backends.ContainsKey("backend2"));
            IApplicationGatewayBackend backend = resource.Backends["backend1"];
            Assert.NotNull(backend);
            Assert.Equal(backend.Addresses.Count, 1);
            Assert.True(backend.ContainsIPAddress("11.1.1.5"));
            Assert.True(!backend.ContainsIPAddress("11.1.1.3"));
            Assert.True(!backend.ContainsIPAddress("11.1.1.4"));

            // Verify HTTP configs
            Assert.Equal(resource.BackendHttpConfigurations.Count, configCount - 1);
            Assert.True(!resource.BackendHttpConfigurations.ContainsKey("config2"));
            IApplicationGatewayBackendHttpConfiguration config = resource.BackendHttpConfigurations["config1"];
            Assert.Equal(config.Port, 8082);
            Assert.Equal(config.RequestTimeout, 20);
            Assert.True(config.CookieBasedAffinity);

            // Verify rules
            Assert.Equal(resource.RequestRoutingRules.Count, ruleCount - 1);
            Assert.True(!resource.RequestRoutingRules.ContainsKey("rule9000"));

            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule80"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend1", rule.Backend.Name);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config1", rule.BackendHttpConfiguration.Name);

            rule = resource.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Listener);
            Assert.Equal("foobar", rule.Listener.HostName);

            // Verify certificates
            Assert.Equal(resource.SslCertificates.Count, certCount - 1);
            Assert.True(!resource.SslCertificates.ContainsKey("cert1"));

            return resource;
        }
    }
}
