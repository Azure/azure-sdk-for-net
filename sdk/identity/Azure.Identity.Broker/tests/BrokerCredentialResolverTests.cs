// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class BrokerCredentialResolverTests
    {
        private static IConfigurationSection BuildSection(IDictionary<string, string> values)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(values)
                .Build();
            return config.GetSection("MyClient:Credential");
        }

        [Test]
        public void TryResolve_NullSection_ReturnsFalse()
        {
            var resolver = new BrokerCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(null, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_NonExistentSection_ReturnsFalse()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            var resolver = new BrokerCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(config.GetSection("Missing"), out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_NoCredentialSource_ReturnsFalse()
        {
            // Section exists but lacks a CredentialSource value — defer to next resolver.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:TenantId"] = "some-tenant",
            });

            var resolver = new BrokerCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [Test]
        public void TryResolve_UnknownCredentialSource_ReturnsFalse()
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "NotAKnownCredential",
            });

            var resolver = new BrokerCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [TestCase("AzureCli")]
        [TestCase("ManagedIdentityCredential")]
        [TestCase("EnvironmentCredential")]
        [TestCase("ChainedTokenCredential")]
        [TestCase("ApiKeyCredential")]
        public void TryResolve_NonBrokerCredentialSource_ReturnsFalse(string source)
        {
            // Broker resolver defers every source other than BrokerCredential /
            // VisualStudioCodeCredential so the next resolver in the chain
            // (typically AzureCredentialResolver) can claim it.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = source,
                ["MyClient:Credential:Key"] = "secret-api-key-value",
            });

            var resolver = new BrokerCredentialResolver();
            Assert.IsFalse(resolver.TryResolve(section, out var provider));
            Assert.IsNull(provider);
        }

        [TestCase("BrokerCredential")]
        [TestCase("brokercredential")]
        public void TryResolve_BrokerCredentialSource_ReturnsBrokerCredential(string source)
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = source,
                ["MyClient:Credential:TenantId"] = "00000000-0000-0000-0000-000000000000",
            });

            var resolver = new BrokerCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));
            Assert.IsNotNull(provider);
            // The internal BrokerCredential type derives from InteractiveBrowserCredential
            // (which derives from TokenCredential / AuthenticationTokenProvider). We can't
            // reference the internal type by name from this assembly, so just assert it is
            // a TokenCredential-shaped provider.
            Assert.IsInstanceOf<Azure.Core.TokenCredential>(provider);
        }

        [TestCase("VisualStudioCodeCredential")]
        [TestCase("visualstudiocodecredential")]
        public void TryResolve_VisualStudioCodeCredentialSource_ReturnsVisualStudioCodeCredential(string source)
        {
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = source,
                ["MyClient:Credential:TenantId"] = "00000000-0000-0000-0000-000000000000",
            });

            var resolver = new BrokerCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));
            Assert.IsNotNull(provider);
            Assert.IsInstanceOf<VisualStudioCodeCredential>(provider);
        }

        [Test]
        public void TryResolve_PropagatesBrokerSpecificOptions()
        {
            // Smoke test: building broker options with explicit broker-specific properties
            // should not throw — option binding flows through DefaultAzureCredentialFactory.
            var section = BuildSection(new Dictionary<string, string>
            {
                ["MyClient:Credential:CredentialSource"] = "BrokerCredential",
                ["MyClient:Credential:TenantId"] = "11111111-1111-1111-1111-111111111111",
                ["MyClient:Credential:UseDefaultBrokerAccount"] = "true",
                ["MyClient:Credential:IsLegacyMsaPassthroughEnabled"] = "true",
            });

            var resolver = new BrokerCredentialResolver();
            Assert.IsTrue(resolver.TryResolve(section, out var provider));
            Assert.IsNotNull(provider);
        }

        [Test]
        public void AddBrokerCredentialResolver_RegistersOneResolver()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddBrokerCredentialResolver();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
            Assert.That(resolvers[0], Is.InstanceOf<BrokerCredentialResolver>());
        }

        [Test]
        public void AddBrokerCredentialResolver_CalledTwice_IsIdempotent()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddBrokerCredentialResolver();
            services.AddBrokerCredentialResolver();
            services.AddBrokerCredentialResolver();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
            Assert.That(resolvers[0], Is.InstanceOf<BrokerCredentialResolver>());
        }

        [Test]
        public void AddBrokerCredentialResolver_AndGenericRegistration_AreIdempotent()
        {
            // Mixing AddBrokerCredentialResolver with the generic AddCredentialResolver<T>
            // for the same implementation type must still produce exactly one registration.
            ServiceCollection services = new ServiceCollection();
            services.AddBrokerCredentialResolver();
            services.AddCredentialResolver<BrokerCredentialResolver>();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
        }

        [Test]
        public void AddBrokerCredentialResolver_OnHostBuilder_RegistersResolver()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.AddBrokerCredentialResolver();
            builder.AddBrokerCredentialResolver();

            using IHost host = builder.Build();
            CredentialResolver[] resolvers = host.Services.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
            Assert.That(resolvers[0], Is.InstanceOf<BrokerCredentialResolver>());
        }

        [Test]
        public void AddBrokerCredentialResolver_NullServices_Throws()
        {
            IServiceCollection services = null;
            Assert.Throws<ArgumentNullException>(() => services.AddBrokerCredentialResolver());
        }

        [Test]
        public void AddBrokerCredentialResolver_NullHostBuilder_Throws()
        {
            IHostApplicationBuilder builder = null;
            Assert.Throws<ArgumentNullException>(() => builder.AddBrokerCredentialResolver());
        }

        [Test]
        public void AddBrokerCredentialResolver_BeforeAddAzureCredentialResolver_BrokerWinsForBrokerCredential()
        {
            // Documents the expected DI composition: register broker first so it claims
            // BrokerCredential sections, then Azure handles everything else.
            ServiceCollection services = new ServiceCollection();
            services.AddBrokerCredentialResolver();
            services.AddAzureCredentialResolver();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(2));
            Assert.That(resolvers[0], Is.InstanceOf<BrokerCredentialResolver>());
            Assert.That(resolvers[1], Is.InstanceOf<AzureCredentialResolver>());
        }
    }
}
