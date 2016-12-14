// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System.IO;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal minimalistic app gateway test.
    /// </summary>
    public class PrivateMinimal : TestTemplate<IApplicationGateway, IApplicationGateways>
    {
        private INetworks networks;
        private INetwork network;

        public PrivateMinimal(INetworks networks)
        {
            this.networks = networks;
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {

            // Create an app gateway
            resources.Define(ApplicationGatewayHelper.APP_GATEWAY_NAME)
                .WithRegion(ApplicationGatewayHelper.REGION)
                .WithNewResourceGroup(ApplicationGatewayHelper.GROUP_NAME)

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
            string resourceId = ApplicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            var appGateway = resources.GetById(resourceId);
            Assert.True(appGateway != null);
            Assert.True(ApplicationGatewayTier.Standard == appGateway.Tier);
            Assert.True(ApplicationGatewaySkuName.StandardSmall == appGateway.Size);
            Assert.True(appGateway.InstanceCount == 1);

            // Verify frontend ports
            Assert.True(appGateway.FrontendPorts.Count == 1);
            Assert.True(appGateway.FrontendPortNameFromNumber(80) != null);

            // Verify frontends
            Assert.True(appGateway.IsPrivate);
            Assert.True(!appGateway.IsPublic);
            Assert.True(appGateway.Frontends.Count == 1);

            // Verify listeners
            Assert.True(appGateway.Listeners.Count == 1);
            Assert.True(appGateway.ListenerByPortNumber(80) != null);

            // Verify backends
            Assert.True(appGateway.Backends.Count == 1);

            // Verify backend HTTP configs
            Assert.True(appGateway.BackendHttpConfigurations.Count == 1);

            // Verify rules
            Assert.True(appGateway.RequestRoutingRules.Count == 1);
            var rule = appGateway.RequestRoutingRules["rule1"];
            Assert.True(rule != null);
            Assert.True(rule.FrontendPort == 80);
            Assert.True(ApplicationGatewayProtocol.Http == rule.FrontendProtocol);
            Assert.True(rule.Listener != null);
            Assert.True(rule.Listener.Frontend != null);
            Assert.True(!rule.Listener.Frontend.IsPublic);
            Assert.True(rule.Listener.Frontend.IsPrivate);
            Assert.True(rule.Listener.SubnetName != null);
            Assert.True(rule.Listener.NetworkId != null);
            Assert.True(rule.BackendAddresses.Count == 2);
            Assert.True(rule.Backend != null);
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.2"));
            Assert.True(rule.BackendPort == 8080);

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
                    .WithSslCertificateFromPfxFile(new FileInfo("c:\\automation\\myTest.pfx"))
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
            Assert.True(ApplicationGatewaySkuName.StandardMedium == resource.Size);
            Assert.True(resource.InstanceCount == 2);

            // Verify frontend ports
            Assert.True(resource.FrontendPorts.Count == 2);
            Assert.True(resource.FrontendPorts.ContainsKey("port81"));
            Assert.True("port81" == resource.FrontendPortNameFromNumber(81));

            // Verify listeners
            Assert.True(resource.Listeners.Count == 2);
            IApplicationGatewayListener listener = resource.Listeners["listener2"];
            Assert.True(listener != null);
            Assert.True(listener.Frontend.IsPrivate);
            Assert.True(!listener.Frontend.IsPublic);
            Assert.True("port81" == listener.FrontendPortName);
            Assert.True(ApplicationGatewayProtocol.Https == listener.Protocol);
            Assert.True(listener.SslCertificate != null);

            // Verify backends
            Assert.True(resource.Backends.Count == 2);
            IApplicationGatewayBackend backend = resource.Backends["backend2"];
            Assert.True(backend != null);
            Assert.True(backend.Addresses.Count == 1);
            Assert.True(backend.ContainsIpAddress("11.1.1.3"));

            // Verify HTTP configs
            Assert.True(resource.BackendHttpConfigurations.Count == 2);
            IApplicationGatewayBackendHttpConfiguration config = resource.BackendHttpConfigurations["config2"];
            Assert.True(config != null);
            Assert.True(config.CookieBasedAffinity);
            Assert.True(config.Port == 8081);
            Assert.True(config.RequestTimeout == 33);

            // Verify request routing rules
            Assert.True(resource.RequestRoutingRules.Count == 2);
            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule2"];
            Assert.True(rule != null);
            Assert.True(rule.Listener != null);
            Assert.True("listener2" == rule.Listener.Name);
            Assert.True(rule.BackendHttpConfiguration != null);
            Assert.True("config2" == rule.BackendHttpConfiguration.Name);
            Assert.True(rule.Backend != null);
            Assert.True("backend2" == rule.Backend.Name);

            return resource;
        }
    }
}
