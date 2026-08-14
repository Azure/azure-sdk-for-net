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
    // Unit-level guards for the client's wire shape (formerly enforced by the
    // eng/Internalize-Generated.ps1 post-emit patches, now removed since the
    // emitter produces the correct output natively), plus the MapApiVersion enum
    // mapping and the CertificatePolicyAction null-throw contract. The recorded
    // playback suite catches the same regressions, but these tests run without
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

        // Contacts collection URL uses the emitter-native shape (no trailing slash).
        [Test]
        public async Task GetContacts_PathHasNoTrailingSlash()
        {
            var (client, transport) = NewClient(new MockResponse(200).WithJson(
                @"{""id"":""https://example.vault.azure.net/certificates/contacts""}"));
            await client.GetContactsAsync();
            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/certificates/contacts", path,
                "Contacts collection URL must use the emitter-native shape without a trailing slash.");
        }

        // Issuers LIST collection URL uses the emitter-native shape (no trailing slash).
        [Test]
        public async Task GetPropertiesOfIssuers_PathHasNoTrailingSlash()
        {
            var (client, transport) = NewClient(new MockResponse(200).WithJson(
                @"{""value"":[]}"));
            var pageable = client.GetPropertiesOfIssuersAsync();
            await foreach (var _ in pageable) { break; }
            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/certificates/issuers", path,
                "Issuers LIST URL must use the emitter-native shape without a trailing slash.");
        }

        // PurgeDeletedCertificate (204 No Content) uses the emitter-native shape
        // and does not send an Accept header.
        [Test]
        public async Task PurgeDeletedCertificate_RequestDoesNotSetAcceptHeader()
        {
            var (client, transport) = NewClient(new MockResponse(204));
            await client.PurgeDeletedCertificateAsync("x");
            Assert.IsFalse(transport.SingleRequest.Headers.TryGetValue("Accept", out _),
                "PurgeDeletedCertificate must not send an Accept header (emitter-native 204 No Content path).");
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

        // C3: CertificatePolicyAction(null) must throw ArgumentNullException — the
        // legacy contract preserved by the handwritten ctor in src/CertificatePolicyAction.cs.
        // The emitter-generated nullable implicit operator (returning
        // CertificatePolicyAction?) returns null instead of throwing, which is
        // intentional .NET design (Azure/azure-sdk-for-net#60163), so this test
        // only covers the ctor and the non-nullable implicit conversion.
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

        // Regression guard for Azure/azure-sdk-for-net#60274:
        // Generated AsPages() loops used to expose the URI we used to fetch
        // the CURRENT page as that page's ContinuationToken, rather than
        // result.NextLink (the URI for the NEXT page). The emitter now yields
        // result.NextLink so customers persisting tokens and resuming with
        // AsPages(token) advance correctly.
        [Test]
        public async Task GetPropertiesOfCertificates_AsPages_ContinuationTokenIsNextLink()
        {
            const string nextLink = "https://example.vault.azure.net/certificates?api-version=7.5&$skiptoken=PG_TOKEN_2";
            var page1 = new MockResponse(200).WithJson(
                "{\"value\":[{\"id\":\"https://example.vault.azure.net/certificates/c1\"}],\"nextLink\":\"" + nextLink + "\"}");
            var page2 = new MockResponse(200).WithJson(
                "{\"value\":[{\"id\":\"https://example.vault.azure.net/certificates/c2\"}]}");
            var transport = new MockTransport(page1, page2);
            var client = new CertificateClient(TestVault, new MockCredential(),
                new CertificateClientOptions { Transport = transport });

            var pages = new System.Collections.Generic.List<Azure.Page<CertificateProperties>>();
            await foreach (Azure.Page<CertificateProperties> p in client.GetPropertiesOfCertificatesAsync().AsPages())
            {
                pages.Add(p);
            }

            Assert.AreEqual(2, pages.Count, "Two pages expected from two mocked responses.");
            Assert.AreEqual(nextLink, pages[0].ContinuationToken,
                "Page 1's ContinuationToken must equal the upstream nextLink (the URL to fetch page 2), not the URL used to fetch page 1.");
            Assert.IsNull(pages[1].ContinuationToken,
                "Final page's ContinuationToken must be null when the service didn't return a nextLink.");
        }

        // M4 (review gap): DeleteCertificateOperation.HasCompleted must be true
        // immediately when the service response carries no recoveryId (purge-only
        // vault, soft-delete disabled), so no polling round-trips happen.
        [Test]
        public async Task StartDeleteCertificate_NoRecoveryId_OperationCompletesImmediately()
        {
            var response = new MockResponse(200).WithJson(
                "{\"id\":\"https://example.vault.azure.net/certificates/x/1\"," +
                "\"deletedDate\":1700000000,\"scheduledPurgeDate\":1700000000}");
            var (client, _) = NewClient(response);

            DeleteCertificateOperation op = await client.StartDeleteCertificateAsync("x");

            Assert.IsTrue(op.HasCompleted,
                "When the DELETE response has no recoveryId, the LRO must complete immediately and not require any polling.");
            Assert.IsNotNull(op.Value, "Value must be populated when HasCompleted is true.");
        }

        // M3 (legacy-parity, "clearing all tags is a no-op"): pinned by
        // CertificateMapperTests.WriteUpdateBody_TagsClearedToZero_DoesNotEmitTags
        // and WriteUpdateBody_TagsRead_ButEmpty_DoesNotEmitTags. The behavior is
        // byte-identical to the legacy CertificateUpdateParameters serializer
        // (HasTags && Count > 0 guard); customers could never clear tags via
        // this PATCH and that's preserved on purpose.
    }
}
