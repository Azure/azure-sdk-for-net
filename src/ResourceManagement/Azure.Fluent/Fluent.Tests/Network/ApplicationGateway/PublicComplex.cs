// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests.Common;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Azure.Tests.Network.ApplicationGateway
{
    /// <summary>
    /// Internal complex app gateway test.
    /// </summary>
    public class PublicComplex : TestTemplate<IApplicationGateway, IApplicationGateways, INetworkManager>
    {
        private List<IPublicIPAddress> testPips;
        private ApplicationGatewayHelper applicationGatewayHelper;

        public PublicComplex([CallerMemberName] string methodName = "testframework_failed")
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

            // Create an application gateway
            try
            {
                resources.Define(applicationGatewayHelper.AppGatewayName)
                    .WithRegion(applicationGatewayHelper.Region)
                    .WithExistingResourceGroup(applicationGatewayHelper.GroupName)

                    // Request routing rules
                    .DefineRequestRoutingRule("rule80")
                        .FromPublicFrontend()
                        .FromFrontendHttpPort(80)
                        .ToBackendHttpPort(8080)
                        .ToBackendFqdn("www.microsoft.com")
                        .ToBackendFqdn("www.example.com")
                        .ToBackendIPAddress("11.1.1.1")
                        .ToBackendIPAddress("11.1.1.2")
                        .WithCookieBasedAffinity()
                        .Attach()
                    .DefineRequestRoutingRule("rule443")
                        .FromPublicFrontend()
                        .FromFrontendHttpsPort(443)
                        .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets", "myTest._pfx")))
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
                        .WithIPAddress("11.1.1.1")
                        .WithIPAddress("11.1.1.2")
                        .Attach()

                    // Additional/explicit frontend listeners
                    .DefineListener("listener1")
                        .WithPublicFrontend()
                        .WithFrontendPort(9000)
                        .WithHttps()
                        .WithSslCertificateFromPfxFile(new FileInfo(Path.Combine("Assets","myTest2._pfx")))
                        .WithSslCertificatePassword("Abc123")
                        .WithServerNameIndication()
                        .WithHostName("www.fabricam.com")
                        .Attach()

                    .WithExistingPublicIPAddress(testPips[0])
                    .WithSize(ApplicationGatewaySkuName.StandardMedium)
                    .WithInstanceCount(2)
                    .Create();
            }
            catch
            {
            }

            // Get the resource as created so far
            string resourceId = applicationGatewayHelper.CreateResourceId(resources.Manager.SubscriptionId);
            IApplicationGateway appGateway = resources.GetById(resourceId);
            Assert.NotNull(appGateway);
            Assert.True(appGateway.IsPublic);
            Assert.True(!appGateway.IsPrivate);
            Assert.Equal(ApplicationGatewayTier.Standard, appGateway.Tier);
            Assert.Equal(ApplicationGatewaySkuName.StandardMedium, appGateway.Size);
            Assert.Equal(appGateway.InstanceCount, 2);
            Assert.Equal(appGateway.IPConfigurations.Count, 1);

            // Verify frontend ports
            Assert.Equal(appGateway.FrontendPorts.Count, 3);
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(80));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(443));
            Assert.NotNull(appGateway.FrontendPortNameFromNumber(9000));

            // Verify frontends
            Assert.Equal(appGateway.Frontends.Count, 1);
            Assert.Equal(appGateway.PublicFrontends.Count, 1);
            Assert.Equal(appGateway.PrivateFrontends.Count, 0);
            IApplicationGatewayFrontend frontend = appGateway.PublicFrontends.Values.First();
            Assert.True(frontend.IsPublic);
            Assert.True(!frontend.IsPrivate);

            // Verify listeners
            Assert.Equal(appGateway.Listeners.Count, 3);
            IApplicationGatewayListener listener = appGateway.Listeners["listener1"];
            Assert.NotNull(listener);
            Assert.Equal(listener.FrontendPortNumber, 9000);
            Assert.Equal("www.fabricam.com", listener.HostName);
            Assert.True(listener.RequiresServerNameIndication);
            Assert.NotNull(listener.Frontend);
            Assert.True(!listener.Frontend.IsPrivate);
            Assert.True(listener.Frontend.IsPublic);
            Assert.Equal(ApplicationGatewayProtocol.Https, listener.Protocol);
            Assert.NotNull(appGateway.ListenerByPortNumber(80));
            Assert.NotNull(appGateway.ListenerByPortNumber(443));

            // Verify certificates
            Assert.Equal(appGateway.SslCertificates.Count, 2);

            // Verify backend HTTP settings configs
            Assert.Equal(appGateway.BackendHttpConfigurations.Count, 2);
            IApplicationGatewayBackendHttpConfiguration config = appGateway.BackendHttpConfigurations["config1"];
            Assert.NotNull(config);
            Assert.Equal(config.Port, 8081);
            Assert.Equal(config.RequestTimeout, 45);

            // Verify backends
            Assert.Equal(appGateway.Backends.Count, 2);
            IApplicationGatewayBackend backend = appGateway.Backends["backend1"];
            Assert.NotNull(backend);
            Assert.Equal(backend.Addresses.Count, 2);

            // Verify request routing rules
            Assert.Equal(appGateway.RequestRoutingRules.Count, 3);
            IApplicationGatewayRequestRoutingRule rule;

            rule = appGateway.RequestRoutingRules["rule80"];
            Assert.NotNull(rule);
            Assert.Equal(testPips[0].Id, rule.PublicIPAddressId);
            Assert.Equal(rule.FrontendPort, 80);
            Assert.Equal(rule.BackendPort, 8080);
            Assert.True(rule.CookieBasedAffinity);
            Assert.Equal(rule.BackendAddresses.Count, 4);
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.2"));
            Assert.True(rule.Backend.ContainsIPAddress("11.1.1.1"));
            Assert.True(rule.Backend.ContainsFqdn("www.microsoft.com"));
            Assert.True(rule.Backend.ContainsFqdn("www.example.com"));

            rule = appGateway.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.Equal(testPips[0].Id, rule.PublicIPAddressId);
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
            Assert.NotNull(rule.BackendHttpConfiguration);
            Assert.Equal(rule.BackendHttpConfiguration.Name, "config1");
            Assert.NotNull(rule.Backend);
            Assert.Equal(rule.Backend.Name, "backend1");

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
            Assert.Equal(resource.Size, ApplicationGatewaySkuName.StandardSmall);
            Assert.Equal(resource.InstanceCount, 1);

            // Verify listeners
            IApplicationGatewayListener listener = resource.Listeners["listener1"];
            Assert.Equal("www.contoso.com", listener.HostName);

            // Verify request routing rules
            Assert.Equal(resource.RequestRoutingRules.Count, rulesCount - 1);
            Assert.True(!resource.RequestRoutingRules.ContainsKey("rule9000"));
            IApplicationGatewayRequestRoutingRule rule = resource.RequestRoutingRules["rule443"];
            Assert.NotNull(rule);
            Assert.Equal("listener1", rule.Listener.Name);
            return resource;
        }
    }
}
