// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    // Unit-level guards for the five post-emit wire-shape patches applied by
    // eng/Internalize-Generated.ps1, plus the MapApiVersion enum mapping and
    // the CertificatePolicyAction null-throw contract. The recorded playback
    // suite catches the same regressions, but these tests run without
    // cassettes so they fail fast in CI on a fresh emit.
    public class CertificateClientWireShapeTests
    {
        private static readonly Uri TestVault = new Uri("https://example.vault.azure.net");

        private static (CertificateClient Client, MockTransport Transport) NewClient(MockResponse response)
        {
            var transport = new MockTransport(response);
            var client = new CertificateClient(TestVault, new MockCredential(),
                new CertificateClientOptions { Transport = transport });
            return (client, transport);
        }

        // Patch 2: GET /certificates/{name} (no trailing slash) when version is null.
        [Test]
        public async Task GetCertificate_NoVersion_PathHasNoTrailingSlash()
        {
            var (client, transport) = NewClient(new MockResponse(200).WithJson(
                @"{""id"":""https://example.vault.azure.net/certificates/x/1""}"));
            await client.GetCertificateAsync("x");
            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/certificates/x", path,
                "GetCertificate (latest version) must emit /certificates/{name} without trailing slash to match recorded shape.");
        }

        // Patch 3: contacts collection URL keeps trailing slash.
        [Test]
        public async Task GetContacts_PathEndsWithTrailingSlash()
        {
            var (client, transport) = NewClient(new MockResponse(200).WithJson(
                @"{""id"":""https://example.vault.azure.net/certificates/contacts/""}"));
            await client.GetContactsAsync();
            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/certificates/contacts/", path,
                "Contacts collection URL must include trailing slash to match recorded shape.");
        }

        // Patch 4: issuers LIST collection URL keeps trailing slash.
        [Test]
        public async Task GetPropertiesOfIssuers_PathEndsWithTrailingSlash()
        {
            var (client, transport) = NewClient(new MockResponse(200).WithJson(
                @"{""value"":[]}"));
            var pageable = client.GetPropertiesOfIssuersAsync();
            await foreach (var _ in pageable) { break; }
            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/certificates/issuers/", path,
                "Issuers LIST URL must include trailing slash to match recorded shape.");
        }

        // Patch 5: PurgeDeletedCertificate carries Accept: application/json.
        [Test]
        public async Task PurgeDeletedCertificate_RequestSetsAcceptJsonHeader()
        {
            var (client, transport) = NewClient(new MockResponse(204));
            await client.PurgeDeletedCertificateAsync("x");
            Assert.IsTrue(transport.SingleRequest.Headers.TryGetValue("Accept", out string accept),
                "PurgeDeletedCertificate must set Accept header (204 No Content path).");
            Assert.AreEqual("application/json", accept);
        }

        // Patch 1: UpdateCertificate builds PATCH /certificates/{name}/{version}
        // (correct positional arg order — the emitter bug swaps content into
        // the version slot which produces a malformed path).
        [Test]
        public async Task UpdateCertificate_PathHasNameThenVersion()
        {
            var (client, transport) = NewClient(new MockResponse(200).WithJson(
                @"{""id"":""https://example.vault.azure.net/certificates/x/v1""}"));
            await client.UpdateCertificatePropertiesAsync(new CertificateProperties("x") { Version = "v1" });
            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/certificates/x/v1", path,
                "UpdateCertificate must build /certificates/{name}/{version}; arg-order regression would produce a malformed path.");
        }

        // C2: every ServiceVersion enum value must round-trip through the public
        // CertificateClient ctor without throwing. Guards against future enum
        // additions that forget to add a MapApiVersion case.
        [TestCaseSource(nameof(AllServiceVersions))]
        public void AllServiceVersions_ConstructSuccessfully(CertificateClientOptions.ServiceVersion v)
        {
            var opts = new CertificateClientOptions(v);
            Assert.DoesNotThrow(() => new CertificateClient(TestVault, new MockCredential(), opts));
        }

        public static System.Collections.Generic.IEnumerable<CertificateClientOptions.ServiceVersion> AllServiceVersions()
            => (CertificateClientOptions.ServiceVersion[])Enum.GetValues(typeof(CertificateClientOptions.ServiceVersion));

        // C3: CertificatePolicyAction(null) and the implicit operator(null)
        // must both throw ArgumentNullException — the legacy contract that
        // Patch 6 restores by removing the generated nullable operator.
        [Test]
        public void CertificatePolicyAction_NullStringCtor_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => { _ = new CertificatePolicyAction(null); });
        }

        [Test]
        public void CertificatePolicyAction_NullStringImplicit_Throws()
        {
            string s = null;
            Assert.Throws<ArgumentNullException>(() => { CertificatePolicyAction a = s; });
        }
    }
}
