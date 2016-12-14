// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System;
using System.IO;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internet-facing minimalistic app gateway test.
    /// </summary>
    public class PublicMinimal : TestTemplate<IApplicationGateway, IApplicationGateways>
    {
        private INetworks networks;
        private INetwork network;
        private static string APP_GATEWAY_NAME = "ag" + ApplicationGatewayHelper.TEST_ID;

        public PublicMinimal(INetworks networks)
        {
            this.networks = networks;
        }

        static string CreateResourceId(String subscriptionId)
        {
            return ApplicationGatewayHelper.ID_TEMPLATE
                    .Replace("${subId}", subscriptionId)
                    .Replace("${rgName}", ApplicationGatewayHelper.GROUP_NAME)
                    .Replace("${resourceName}", APP_GATEWAY_NAME);
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {
            /*
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Console.WriteLine("Hello, world");
            }).Start();
        */

            try
            {
                resources.Define(ApplicationGatewayHelper.APP_GATEWAY_NAME)
                    .WithRegion(ApplicationGatewayHelper.REGION)
                    .WithNewResourceGroup(ApplicationGatewayHelper.GROUP_NAME)

                    // Request routing rules
                    .DefineRequestRoutingRule("rule1")
                        .FromPublicFrontend()
                        .FromFrontendHttpsPort(443)
                        .WithSslCertificateFromPfxFile(new FileInfo("c:\\automation\\myTest.pfx"))
                        .WithSslCertificatePassword("Abc123")
                        .ToBackendHttpPort(8080)
                        .ToBackendIpAddress("11.1.1.1")
                        .ToBackendIpAddress("11.1.1.2")
                        .Attach()
                    .Create();
            }
            catch (IOException e)
            {
            }

            // Get the resource as created so far
            string resourceId = CreateResourceId(resources.Manager.SubscriptionId);
            var appGateway = resources.GetById(resourceId);
            Assert.True(appGateway != null);
            Assert.True(ApplicationGatewayTier.Standard == appGateway.Tier);
            Assert.True(ApplicationGatewaySkuName.StandardSmall == appGateway.Size);
            Assert.True(appGateway.InstanceCount == 1);

            // Verify frontend ports
            Assert.True(appGateway.FrontendPorts.Count == 1);
            Assert.True(appGateway.FrontendPortNameFromNumber(443) != null);

            // Verify frontends
            Assert.True(!appGateway.IsPrivate);
            Assert.True(appGateway.IsPublic);
            Assert.True(appGateway.Frontends.Count == 1);

            // Verify listeners
            Assert.True(appGateway.Listeners.Count == 1);
            Assert.True(appGateway.ListenerByPortNumber(443) != null);

            // Verify backends
            Assert.True(appGateway.Backends.Count == 1);

            // Verify backend HTTP configs
            Assert.True(appGateway.BackendHttpConfigurations.Count == 1);

            // Verify rules
            Assert.True(appGateway.RequestRoutingRules.Count == 1);
            var rule = appGateway.RequestRoutingRules["rule1"];
            Assert.True(rule != null);
            Assert.True(rule.FrontendPort == 443);
            Assert.True(ApplicationGatewayProtocol.Https == rule.FrontendProtocol);
            Assert.True(rule.Listener != null);
            Assert.True(rule.Listener.Frontend != null);
            Assert.True(rule.Listener.Frontend.IsPublic);
            Assert.True(!rule.Listener.Frontend.IsPrivate);
            Assert.True(rule.Listener.SubnetName == null);
            Assert.True(rule.Listener.NetworkId == null);
            Assert.True(rule.BackendPort == 8080);
            Assert.True(rule.BackendAddresses.Count == 2);
            Assert.True(rule.Backend != null);
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.2"));

            // Verify certificates
            Assert.True(appGateway.SslCertificates.Count == 1);

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            resource.Update()
                .WithInstanceCount(2)
                .WithSize(ApplicationGatewaySkuName.StandardMedium)
                .WithoutBackendIpAddress("11.1.1.1")
                .DefineListener("listener2")
                    .WithPublicFrontend()
                    .WithFrontendPort(80)
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
            Assert.True(null != resource.FrontendPortNameFromNumber(80));

            // Verify listeners
            Assert.True(resource.Listeners.Count == 2);
            IApplicationGatewayListener listener = resource.Listeners["listener2"];
            Assert.True(listener != null);
            Assert.True(!listener.Frontend.IsPrivate);
            Assert.True(listener.Frontend.IsPublic);
            Assert.True(listener.FrontendPortNumber == 80);
            Assert.True(ApplicationGatewayProtocol.Http == listener.Protocol);
            Assert.True(listener.SslCertificate == null);

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
