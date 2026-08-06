// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SCME0002

#if NET8_0_OR_GREATER
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class BlobClientHostExtensionsTests
    {
        private static Dictionary<string, string> GetBaseConfig() => new()
        {
            ["Storage:Url"] = "https://myaccount.blob.core.windows.net/mycontainer/myblob",
            ["Storage:Credential:CredentialSource"] = "TokenCredential",
        };

        [Test]
        public void AddBlobClient_WithSectionName_RegistersClient()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(GetBaseConfig());
            builder.Services.AddCredentialResolver<FakeCredentialResolver>();

            builder.AddBlobClient("Storage");

            IHost host = builder.Build();
            BlobClient client = host.Services.GetRequiredService<BlobClient>();
            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void AddBlobClient_WithConfigureSettings_RegistersClient()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(GetBaseConfig());
            builder.Services.AddCredentialResolver<FakeCredentialResolver>();

            builder.AddBlobClient("Storage", settings =>
            {
                settings.Url = new Uri("https://myaccount.blob.core.windows.net/other/blob");
            });

            IHost host = builder.Build();
            BlobClient client = host.Services.GetRequiredService<BlobClient>();
            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void AddKeyedBlobClient_WithSectionName_RegistersKeyedClient()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(GetBaseConfig());
            builder.Services.AddCredentialResolver<FakeCredentialResolver>();

            builder.AddKeyedBlobClient("myKey", "Storage");

            IHost host = builder.Build();
            BlobClient client = host.Services.GetRequiredKeyedService<BlobClient>("myKey");
            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void AddKeyedBlobClient_WithConfigureSettings_RegistersKeyedClient()
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder();
            builder.Configuration.AddInMemoryCollection(GetBaseConfig());
            builder.Services.AddCredentialResolver<FakeCredentialResolver>();

            builder.AddKeyedBlobClient("myKey", "Storage", settings =>
            {
                settings.Url = new Uri("https://myaccount.blob.core.windows.net/other/blob");
            });

            IHost host = builder.Build();
            BlobClient client = host.Services.GetRequiredKeyedService<BlobClient>("myKey");
            Assert.That(client, Is.Not.Null);
        }

        private class FakeCredentialResolver : System.ClientModel.Primitives.CredentialResolver
        {
            public override bool TryResolve(
                IConfigurationSection credentialSection,
                out AuthenticationTokenProvider provider)
            {
                provider = new FakeTokenCredential();
                return true;
            }
        }

        private class FakeTokenCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("fake-token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(new AccessToken("fake-token", DateTimeOffset.MaxValue));
        }
    }
}
#endif
