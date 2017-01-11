// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Runtime.CompilerServices;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal minimalistic app gateway test.
    /// </summary>
    public class PrivateMinimal : TestTemplate<IApplicationGateway, IApplicationGateways>
    {
        private INetworks networks;
        private ApplicationGatewayHelper applicationGatewayHelper;
        public PrivateMinimal(INetworks networks,
            [CallerMemberName] string methodName = "testframework_failed")
            : base(methodName)
        {
            applicationGatewayHelper = new ApplicationGatewayHelper(TestUtilities.GenerateName("", methodName));
            this.networks = networks;
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {

            // Create an app gateway
            resources.Define(applicationGatewayHelper.APP_GATEWAY_NAME)
                .WithRegion(applicationGatewayHelper.REGION)
                .WithNewResourceGroup(applicationGatewayHelper.GROUP_NAME)

                // Request routing rule
                .DefineRequestRoutingRule("rule1")
                    .FromPrivateFrontend()
                    .FromFrontendHttpPort(80)
                    .ToBackendHttpPort(8080)
                    .ToBackendIpAddress("11.1.1.1")
                    .ToBackendIpAddress("11.1.1.2")
                    .Attach()
                .Create();

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            var appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.Equal(ApplicationGatewayTier.Standard, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.StandardSmall, appGateway.Size);
            Assert.Equal(appGateway.InstanceCount, 1);

            // Verify frontend ports
            Assert.Equal(appGateway.FrontendPorts.Count, 1);
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(80));

            // Verify frontends
            Assert.True(appGateway.IsPrivate);
            Assert.True(!appGateway.IsPublic);
            Assert.Equal(appGateway.Frontends.Count, 1);

            // Verify listeners
            Assert.Equal(appGateway.Listeners.Count, 1);
            Assert.NotNull(appGateway.ListenerByPortNumber(80));

            // Verify backends
            Assert.Equal(appGateway.Backends.Count, 1);

            // Verify backend HTTP configs
            Assert.Equal(appGateway.BackendHttpConfigurations.Count, 1);

            // Verify rules
            Assert.Equal(appGateway.RequestRoutingRules.Count, 1);
            var rule = appGateway.RequestRoutingRules["rule1"];
            Assert.NotNull(rule);
            Assert.Equal(rule.FrontendPort, 80);
            Assert.Equal(ApplicationGatewayProtocol.Http, rule.FrontendProtocol);
            Assert.NotNull(rule.Listener);
            Assert.NotNull(rule.Listener.Frontend);
            Assert.True(!rule.Listener.Frontend.IsPublic);
            Assert.True(rule.Listener.Frontend.IsPrivate);
            Assert.NotNull(rule.Listener.SubnetName);
            Assert.NotNull(rule.Listener.NetworkId);
            Assert.Equal(rule.BackendAddresses.Count, 2);
            Assert.NotNull(rule.Backend);
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.2"));
            Assert.Equal(rule.BackendPort, 8080);

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            resource.Update()
                .WithInstanceCount(2)
                .WithSize(ApplicationGatewaySkuName.StandardMedium)
                .WithFrontendPort(81, "port81")         // Add a new port
                .WithoutBackendIpAddress("11.1.1.1")    // Remove from all existing backends
                .DefineListener("listener2")
                    .WithPrivateFrontend()
                    .WithFrontendPort(81)
                    .WithHttps()
                    .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets", "myTest._pfx")))
                    .WithSslCertificatePassword("Abc123")
                    .Attach()
                .DefineBackend("backend2")
                    .WithIpAddress("11.1.1.3")
                    .Attach()
                .DefineBackendHttpConfiguration("config2")
                    .WithCookieBasedAffinity()
                    .WithPort(8081)
                    .WithRequestTimeout(33)
                    .Attach()
                .DefineRequestRoutingRule("rule2")
                    .FromListener("listener2")
                    .ToBackendHttpConfiguration("config2")
                    .ToBackend("backend2")
                    .Attach()
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.True(resource.Tags.ContainsKey("tag2"));
            Assert.Equal(ApplicationGatewaySkuName.StandardMedium, resource.Size);
            Assert.Equal(resource.InstanceCount, 2);

            // Verify frontend ports
            Assert.Equal(resource.FrontendPorts.Count, 2);
            Assert.True(resource.FrontendPorts.ContainsKey("port81"));
            Assert.Equal("port81", resource.FrontendPortNameFromNumber(81));

            // Verify listeners
            Assert.Equal(resource.Listeners.Count, 2);
            IApplicationGatewayListener listener = resource.Listeners["listener2"];
            Assert.NotNull(listener);
            Assert.True(listener.Frontend.IsPrivate);
            Assert.True(!listener.Frontend.IsPublic);
            Assert.Equal("port81", listener.FrontendPortName);
            Assert.Equal(ApplicationGatewayProtocol.Https, listener.Protocol);
            Assert.NotNull(listener.SslCertificate);

            // Verify backends
            Assert.Equal(resource.Backends.Count, 2);
            IApplicationGatewayBackend backend = resource.Backends["backend2"];
            Assert.NotNull(backend);
            Assert.Equal(backend.Addresses.Count, 1);
            Assert.True(backend.ContainsIpAddress("11.1.1.3"));

            // Verify HTTP configs
            Assert.Equal(resource.BackendHttpConfigurations.Count, 2);
            IApplicationGatewayBackendHttpConfiguration config = resource.BackendHttpConfigurations["config2"];
            Assert.NotNull(config);
            Assert.True(config.CookieBasedAffinity);
            Assert.Equal(config.Port, 8081);
            Assert.Equal(config.RequestTimeout, 33);

            // Verify request routing rules
            Assert.Equal(resource.RequestRoutingRules.Count, 2);
            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule2"];
            Assert.NotNull(rule);
            Assert.NotNull(rule.Listener);
            Assert.Equal("listener2", rule.Listener.Name);
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal("config2", rule.BackendHttpConfiguration.Name);
            Assert.NotNull(rule.Backend);
            Assert.Equal("backend2", rule.Backend.Name);

            return resource;
        }
    }
}
