// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientDisposalTests : ClientDisposalTestsBase<CertificateClient, CertificateClientOptions>
    {
        protected override CertificateClient CreateClient(TokenCredential credential, CertificateClientOptions options = null) =>
            options == null ? new CertificateClient(VaultUri, credential) : new CertificateClient(VaultUri, credential, options);

        protected override CertificateClientOptions CreateOptions() => new();

        protected override HttpPipeline GetPipeline(CertificateClient client) =>
            ReadField<KeyVaultCertificatesClient>(client, "_generated").Pipeline;

        [Test]
        public async Task DisposeReleasesGeneratedAndDownloadPipelineOnlyOnce([Values] bool isAsync)
        {
            ResponsePolicy policy = new(request => request.Uri.Path.StartsWith("/certificates/")
                ? new MockResponse(200).WithJson("""{"id":"https://disposal.vault.azure.net/certificates/certificate/version","sid":"https://disposal.vault.azure.net/secrets/certificate/version"}""")
                : new MockResponse(403));
            CertificateClientOptions options = new();
            options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            using CertificateClient client = CreateClient(new MockCredential(), options);
            HttpPipeline pipeline = GetPipeline(client);
            Assert.That(GetKeyVaultPipeline(client), Is.SameAs(pipeline));
            DefaultTransportLifetime lifetime = new(pipeline);

            if (isAsync)
            {
                Assert.That((await client.GetCertificateAsync("certificate")).Value.Name, Is.EqualTo("certificate"));
                Assert.That(Assert.ThrowsAsync<RequestFailedException>(async () => await client.DownloadCertificateAsync("certificate")).Status, Is.EqualTo(403));
            }
            else
            {
                Assert.That(client.GetCertificate("certificate").Value.Name, Is.EqualTo("certificate"));
                Assert.That(Assert.Throws<RequestFailedException>(() => client.DownloadCertificate("certificate")).Status, Is.EqualTo(403));
            }

            Assert.That(policy.RequestCount, Is.EqualTo(3));
            lifetime.AssertAlive();
            DisposeRepeatedly(client, concurrent: true);
            lifetime.AssertDisposedOnce();
        }
    }
}
