// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal complex app gateway test.
    /// </summary>
    public class PublicComplex : TestTemplate<IApplicationGateway, IApplicationGateways>
    {
        private List<IPublicIpAddress> testPips;

        public PublicComplex(IPublicIpAddresses pips)
        {
            testPips = new List<IPublicIpAddress>(ApplicationGatewayHelper.EnsurePIPs(pips));
        }

        public override void Print(IApplicationGateway resource)
        {
            ApplicationGatewayHelper.PrintAppGateway(resource);
        }

        public override IApplicationGateway CreateResource(IApplicationGateways resources)
        {
            // Create an application gateway
            try
            {
                resources.Define(ApplicationGatewayHelper.AppGatewayName)
                    .WithRegion(ApplicationGatewayHelper.Region)
                    .WithExistingResourceGroup(ApplicationGatewayHelper.GroupName)

                    // Request routing rules
                    .DefineRequestRoutingRule("rule80")
                        .FromPublicFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendFqdn("www.microsoft.com")
                        .ToBackendFqdn("www.example.com")
                        .ToBackendIpAddress("11.1.1.1")
                        .ToBackendIpAddress("11.1.1.2")
                        .WithCookieBasedAffinity()
                        .Attach()
                    .DefineRequestRoutingRule("rule443")
                        .FromPublicFrontend()
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

                    // Additional/explicit backends
                    .DefineBackend("backend1")
                        .WithIpAddress("11.1.1.1")
                        .WithIpAddress("11.1.1.2")
                        .Attach()

                    // Additional/explicit frontend listeners
                    .DefineListener("listener1")
                        .WithPublicFrontend()
                        .WithFrontendPort(9000)
                        .WithHttps()
                        .WithSslCertificateFromPfxFile(new FileInfo("c:\\automation\\myTest2.pfx"))
                        .WithSslCertificatePassword("Abc123")
                        .WithServerNameIndication()
                        .WithHostName("www.fabricam.com")
                        .Attach()

                    .WithExistingPublicIpAddress(testPips[0])
                    .WithSize(ApplicationGatewaySkuName.StandardMedium)
                    .WithInstanceCount(2)
                    .Create();
            }
            catch
            {
            }

            // Get the resource as created so far
            string resourceId = ApplicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.True(appGateway != null);
            Assert.True(appGateway.IsPublic);
            Assert.True(!appGateway.IsPrivate);
            Assert.True(ApplicationGatewayTier.Standard == appGateway.Tier);
            Assert.True(ApplicationGatewaySkuName.StandardMedium == appGateway.Size);
            Assert.True(appGateway.InstanceCount == 2);
            Assert.True(appGateway.IpConfigurations.Count == 1);

            // Verify frontend ports
            Assert.True(appGateway.FrontendPorts.Count == 3);
            Assert.True(appGateway.FrontendPortNameFromNumber(80) != null);
            Assert.True(appGateway.FrontendPortNameFromNumber(443) != null);
            Assert.True(appGateway.FrontendPortNameFromNumber(9000) != null);

            // Verify frontends
            Assert.True(appGateway.Frontends.Count == 1);
            Assert.True(appGateway.PublicFrontends.Count == 1);
            Assert.True(appGateway.PrivateFrontends.Count == 0);
            IApplicationGatewayFrontend frontend = appGateway.PublicFrontends.Values.First();
            Assert.True(frontend.IsPublic);
            Assert.True(!frontend.IsPrivate);

            // Verify listeners
            Assert.True(appGateway.Listeners.Count == 3);
            IApplicationGatewayListener listener = appGateway.Listeners["listener1"];
            Assert.True(listener != null);
            Assert.True(listener.FrontendPortNumber == 9000);
            Assert.True("www.fabricam.com" == listener.HostName);
            Assert.True(listener.RequiresServerNameIndication);
            Assert.True(listener.Frontend != null);
            Assert.True(!listener.Frontend.IsPrivate);
            Assert.True(listener.Frontend.IsPublic);
            Assert.True(ApplicationGatewayProtocol.Https == listener.Protocol);
            Assert.True(appGateway.ListenerByPortNumber(80) != null);
            Assert.True(appGateway.ListenerByPortNumber(443) != null);

            // Verify certificates
            Assert.True(appGateway.SslCertificates.Count == 2);

            // Verify backend HTTP settings configs
            Assert.True(appGateway.BackendHttpConfigurations.Count == 2);
            IApplicationGatewayBackendHttpConfiguration config = appGateway.BackendHttpConfigurations["config1"];
            Assert.True(config != null);
            Assert.True(config.Port == 8081);
            Assert.True(config.RequestTimeout == 45);

            // Verify backends
            Assert.True(appGateway.Backends.Count == 2);
            IApplicationGatewayBackend backend = appGateway.Backends["backend1"];
            Assert.True(backend != null);
            Assert.True(backend.Addresses.Count == 2);

            // Verify request routing rules
            Assert.True(appGateway.RequestRoutingRules.Count == 3);
            IApplicationGatewayRequestRoutingRule rule;

            rule = appGateway.RequestRoutingRules["rule80"];
            Assert.True(rule != null);
            Assert.True(testPips[0].Id == rule.PublicIpAddressId);
            Assert.True(rule.FrontendPort == 80);
            Assert.True(rule.BackendPort == 8080);
            Assert.True(rule.CookieBasedAffinity);
            Assert.True(rule.BackendAddresses.Count == 4);
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.2"));
            Assert.True(rule.Backend.ContainsIpAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsFqdn("www.microsoft.com"));
            Assert.True(rule.Backend.ContainsFqdn("www.example.com"));

            rule = appGateway.RequestRoutingRules["rule443"];
            Assert.True(rule != null);
            Assert.True(testPips[0].Id == rule.PublicIpAddressId);
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
            Assert.True(rule.BackendHttpConfiguration != null);
            Assert.True(rule.BackendHttpConfiguration.Name == "config1");
            Assert.True(rule.Backend != null);
            Assert.True(rule.Backend.Name == "backend1");

            return appGateway;
        }

        public override IApplicationGateway UpdateResource(IApplicationGateway resource)
        {
            int rulesCount = resource.RequestRoutingRules.Count;

            resource.Update()
                .WithSize(ApplicationGatewaySkuName.StandardSmall)
                .WithInstanceCount(1)
                .UpdateListener("listener1")
                    .WithHostName("www.contoso.com")
                    .Parent()
                .UpdateRequestRoutingRule("rule443")
                    .FromListener("listener1")
                    .Parent()
                .WithoutRequestRoutingRule("rule9000")
                .WithTag("tag1", "value1")
                .WithTag("tag2", "value2")
                .Apply();

            resource.Refresh();

            // Get the resource created so far
            Assert.True(resource.Tags.ContainsKey("tag1"));
            Assert.True(resource.Size == ApplicationGatewaySkuName.StandardSmall);
            Assert.True(resource.InstanceCount == 1);

            // Verify listeners
            IApplicationGatewayListener listener = resource.Listeners["listener1"];
            Assert.True("www.contoso.com" == listener.HostName);

            // Verify request routing rules
            Assert.True(resource.RequestRoutingRules.Count == rulesCount - 1);
            Assert.True(!resource.RequestRoutingRules.ContainsKey("rule9000"));
            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule443"];
            Assert.True(rule != null);
            Assert.True("listener1" == rule.Listener.Name);
            return resource;
        }
    }
}
