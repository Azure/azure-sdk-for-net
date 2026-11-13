// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Linq;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity.CredentialResolvers
{
    public class AzureCredentialResolverDITests
    {
        [Test]
        public void AddAzureCredentialResolver_RegistersOneResolver()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddAzureCredentialResolver();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
            Assert.That(resolvers[0], Is.InstanceOf<AzureCredentialResolver>());
        }

        [Test]
        public void AddAzureCredentialResolver_CalledTwice_IsIdempotent()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddAzureCredentialResolver();
            services.AddAzureCredentialResolver();
            services.AddAzureCredentialResolver();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
            Assert.That(resolvers[0], Is.InstanceOf<AzureCredentialResolver>());
        }

        [Test]
        public void AddAzureCredentialResolver_AndGenericRegistration_AreIdempotent()
        {
            // Mixing AddAzureCredentialResolver with the generic AddCredentialResolver<T> registration
            // for the same implementation type must still produce exactly one registration.
            ServiceCollection services = new ServiceCollection();
            services.AddAzureCredentialResolver();
            services.AddCredentialResolver<AzureCredentialResolver>();

            using ServiceProvider sp = services.BuildServiceProvider();
            CredentialResolver[] resolvers = sp.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
        }

        [Test]
        public void AddAzureCredentialResolver_OnHostBuilder_RegistersResolver()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.AddAzureCredentialResolver();
            builder.AddAzureCredentialResolver();

            using IHost host = builder.Build();
            CredentialResolver[] resolvers = host.Services.GetServices<CredentialResolver>().ToArray();

            Assert.That(resolvers.Length, Is.EqualTo(1));
            Assert.That(resolvers[0], Is.InstanceOf<AzureCredentialResolver>());
        }
    }
}
