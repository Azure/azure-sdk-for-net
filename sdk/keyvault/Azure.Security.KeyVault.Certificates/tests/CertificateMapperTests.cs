// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    // Direct unit coverage of CertificateMapper - the adapter Phase 2 introduced
    // between the hand-written customer-facing models (which implement the
    // private IJsonSerializable / IJsonDeserializable interfaces) and the
    // protocol-method surface of the generated KeyVaultCertificatesClient.
    //
    // The mapper has no I/O, so these tests are pure data-flow: build a model,
    // run it through the mapper, parse the resulting bytes back, assert
    // byte-shape parity with the legacy hand-written serializer. The wire-shape
    // contract these tests pin is the same one previously-shipped 4.x
    // recordings depend on, so the test set doubles as a regression net for
    // anyone tempted to refactor the JSON writer.
    public class CertificateMapperTests
    {
        // ----- ToRequestContent -----

        [Test]
        public void ToRequestContent_Null_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => CertificateMapper.ToRequestContent(null));
        }

        [Test]
        public void ToRequestContent_CertificatePolicy_RoundTripsThroughLegacySerializer()
        {
            CertificatePolicy policy = CertificatePolicy.Default;

            AssertRoundTripsLegacySerializer(policy);
        }

        [Test]
        public void ToRequestContent_CertificatePolicy_FullyPopulated_RoundTripsThroughLegacySerializer()
        {
            var policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=Azure SDK")
            {
                CertificateTransparency = true,
                CertificateType         = "Standard",
                ContentType             = CertificateContentType.Pkcs12,
                Enabled                 = true,
                Exportable              = true,
                KeyCurveName            = CertificateKeyCurveName.P256,
                KeySize                 = 2048,
                KeyType                 = CertificateKeyType.Rsa,
                ReuseKey                = false,
                ValidityInMonths        = 12,
            };
            policy.EnhancedKeyUsage.Add("1.3.6.1.5.5.7.3.1");
            policy.KeyUsage.Add(CertificateKeyUsage.DigitalSignature);
            policy.LifetimeActions.Add(new LifetimeAction(CertificatePolicyAction.AutoRenew) { LifetimePercentage = 80 });

            AssertRoundTripsLegacySerializer(policy);
        }

        [Test]
        public void ToRequestContent_CertificatePolicy_WithSubjectAlternativeNames_RoundTripsThroughLegacySerializer()
        {
            var sans = new SubjectAlternativeNames { DnsNames = { "contoso.com", "www.contoso.com" } };
            var policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=Azure SDK", sans)
            {
                ContentType = CertificateContentType.Pkcs12,
                ValidityInMonths = 6,
            };

            AssertRoundTripsLegacySerializer(policy);
        }

        [Test]
        public void ToRequestContent_CertificateIssuer_RoundTripsThroughLegacySerializer()
        {
            var issuer = new CertificateIssuer("test-issuer", "Self")
            {
                AccountId = "account",
                Password  = "secret",
                OrganizationId = "org-1",
            };
            issuer.AdministratorContacts.Add(new AdministratorContact
            {
                FirstName = "Heath", LastName = "Stewart", Email = "heath@contoso.com", Phone = "+15555550100",
            });

            AssertRoundTripsLegacySerializer(issuer);
        }

        [Test]
        public void ToRequestContent_ContactList_RoundTripsThroughLegacySerializer()
        {
            var list = new ContactList(new[]
            {
                new CertificateContact { Name = "n1", Email = "e1@contoso.com", Phone = "1" },
                new CertificateContact { Name = "n2", Email = "e2@contoso.com" },
            });

            AssertRoundTripsLegacySerializer(list);
        }

        [Test]
        public void ToRequestContent_ImportCertificateOptions_RoundTripsThroughLegacySerializer()
        {
            var options = new ImportCertificateOptions("imported", new byte[] { 1, 2, 3, 4, 5 })
            {
                Password = "pwd",
                Enabled  = true,
                PreserveCertificateOrder = false,
            };
            options.Tags["env"] = "prod";

            AssertRoundTripsLegacySerializer(options);
        }

        [Test]
        public void ToRequestContent_MergeCertificateOptions_RoundTripsThroughLegacySerializer()
        {
            var options = new MergeCertificateOptions("merged", new[]
            {
                new byte[] { 0x11, 0x22, 0x33 },
                new byte[] { 0x44, 0x55, 0x66 },
            })
            {
                Enabled = true,
            };
            options.Tags["team"] = "kv";

            AssertRoundTripsLegacySerializer(options);
        }

        [Test]
        public void ToRequestContent_CertificateCreateParameters_RoundTripsThroughLegacySerializer()
        {
            var policy = CertificatePolicy.Default;
            var parameters = new CertificateCreateParameters(
                policy,
                enabled: true,
                tags: new Dictionary<string, string> { ["env"] = "prod" },
                preserveCertificateOrder: true);

            AssertRoundTripsLegacySerializer(parameters);
        }

        // ----- WriteUpdateBody -----

        [Test]
        public void WriteUpdateBody_Null_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => CertificateMapper.WriteUpdateBody(null));
        }

        [Test]
        public void WriteUpdateBody_UntouchedAttributesUntouchedTags_EmitsEmptyObject()
        {
            var props = new CertificateProperties("name");
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.AreEqual(JsonValueKind.Object, doc.RootElement.ValueKind);
            Assert.IsFalse(doc.RootElement.TryGetProperty("attributes", out _),
                "An untouched .Enabled must NOT emit an attributes object.");
            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _),
                "An untouched .Tags must NOT emit a tags object (server would interpret an empty object as 'wipe').");

            // Sanity-check the no-property-emitted invariant by enumerating.
            int count = 0;
            foreach (var _ in doc.RootElement.EnumerateObject()) { count++; }
            Assert.AreEqual(0, count, "Body should be exactly {}.");
        }

        [Test]
        public void WriteUpdateBody_EnabledOnly_EmitsAttributesOnly()
        {
            var props = new CertificateProperties("name") { Enabled = true };
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.IsTrue(doc.RootElement.TryGetProperty("attributes", out JsonElement attrs));
            Assert.IsTrue(attrs.GetProperty("enabled").GetBoolean());
            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _));
        }

        [Test]
        public void WriteUpdateBody_EnabledFalse_EmitsAttributesEnabledFalse()
        {
            var props = new CertificateProperties("name") { Enabled = false };
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.IsTrue(doc.RootElement.TryGetProperty("attributes", out JsonElement attrs));
            Assert.IsFalse(attrs.GetProperty("enabled").GetBoolean());
        }

        [Test]
        public void WriteUpdateBody_TagsRead_ButEmpty_DoesNotEmitTags()
        {
            // Customer touched .Tags (allocating the backing dictionary) but
            // never added a key. The Count: > 0 guard in WriteUpdateBody must
            // skip the "tags" object - else server tags would be wiped.
            var props = new CertificateProperties("name");
            _ = props.Tags;
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _));
            Assert.IsFalse(doc.RootElement.TryGetProperty("attributes", out _));
        }

        [Test]
        public void WriteUpdateBody_TagsClearedToZero_DoesNotEmitTags()
        {
            var props = new CertificateProperties("name");
            props.Tags["env"] = "prod";
            props.Tags.Clear();
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _));
        }

        [Test]
        public void WriteUpdateBody_TagsPopulated_EmitsTags()
        {
            var props = new CertificateProperties("name");
            props.Tags["env"] = "prod";
            props.Tags["owner"] = "rohit";
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.IsTrue(doc.RootElement.TryGetProperty("tags", out JsonElement tags));
            Assert.AreEqual("prod",  tags.GetProperty("env").GetString());
            Assert.AreEqual("rohit", tags.GetProperty("owner").GetString());
            Assert.IsFalse(doc.RootElement.TryGetProperty("attributes", out _));
        }

        [Test]
        public void WriteUpdateBody_EnabledAndTags_EmitsBoth()
        {
            var props = new CertificateProperties("name") { Enabled = true };
            props.Tags["env"] = "prod";
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteUpdateBody(props));

            Assert.IsTrue(doc.RootElement.TryGetProperty("attributes", out JsonElement attrs));
            Assert.IsTrue(attrs.GetProperty("enabled").GetBoolean());
            Assert.IsTrue(doc.RootElement.TryGetProperty("tags", out JsonElement tags));
            Assert.AreEqual("prod", tags.GetProperty("env").GetString());
        }

        // ----- WriteCancelOperationBody -----

        [Test]
        public void WriteCancelOperationBody_EmitsCancellationRequestedTrue()
        {
            using JsonDocument doc = ParseRequestContent(CertificateMapper.WriteCancelOperationBody());

            Assert.AreEqual(JsonValueKind.Object, doc.RootElement.ValueKind);
            Assert.IsTrue(doc.RootElement.GetProperty("cancellation_requested").GetBoolean());

            int count = 0;
            foreach (var _ in doc.RootElement.EnumerateObject()) { count++; }
            Assert.AreEqual(1, count, "Body must contain exactly one property: cancellation_requested.");
        }

        // ----- Deserialize<T>(Response, factory) -----

        [Test]
        public void Deserialize_NullResponse_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => CertificateMapper.Deserialize<CertificateBackup>(null, () => new CertificateBackup()));
        }

        [Test]
        public void Deserialize_NullFactory_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => CertificateMapper.Deserialize<CertificateBackup>(new MockResponse(200), null));
        }

        [Test]
        public void Deserialize_CertificateBackup_RoundTripsValueField()
        {
            byte[] expected = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF, 0x00, 0x11, 0x22, 0x33 };
            // CertificateBackup uses Base64Url encoding (no padding, URL-safe).
            string encoded = Base64UrlEncode(expected);
            var raw = new MockResponse(200);
            raw.SetContent($"{{\"value\":\"{encoded}\"}}");

            CertificateBackup backup = CertificateMapper.Deserialize(raw, () => new CertificateBackup());

            CollectionAssert.AreEqual(expected, backup.Value);
        }

        [Test]
        public void Deserialize_ContactList_RoundTripsContacts()
        {
            var raw = new MockResponse(200);
            raw.SetContent(@"{ ""contacts"": [
                { ""name"": ""Alice"", ""email"": ""alice@contoso.com"", ""phone"": ""1"" },
                { ""name"": ""Bob"",   ""email"": ""bob@contoso.com""                  }
            ] }");

            ContactList list = CertificateMapper.Deserialize(raw, () => new ContactList());
            IList<CertificateContact> contacts = list.ToList();

            Assert.AreEqual(2, contacts.Count);
            Assert.AreEqual("Alice", contacts[0].Name);
            Assert.AreEqual("alice@contoso.com", contacts[0].Email);
            Assert.AreEqual("1", contacts[0].Phone);
            Assert.AreEqual("Bob", contacts[1].Name);
            Assert.IsNull(contacts[1].Phone);
        }

        [Test]
        public void Deserialize_FromContentStream_Works()
        {
            // Ensure the mapper reads from response.ContentStream when present,
            // not just response.Content - mirrors the path the protocol method
            // takes when the body is streamed back from the wire.
            var raw = new MockResponse(200);
            raw.ContentStream = new MemoryStream(Encoding.UTF8.GetBytes(@"{""value"":""AQID""}"));

            CertificateBackup backup = CertificateMapper.Deserialize(raw, () => new CertificateBackup());
            CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, backup.Value);
        }

        // ----- DeserializeItem<T>(BinaryData, factory) -----

        [Test]
        public void DeserializeItem_NullData_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => CertificateMapper.DeserializeItem<CertificateProperties>(null, () => new CertificateProperties()));
        }

        [Test]
        public void DeserializeItem_NullFactory_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () => CertificateMapper.DeserializeItem<CertificateProperties>(BinaryData.FromString("{}"), null));
        }

        [Test]
        public void DeserializeItem_CertificateProperties_ParsesId()
        {
            BinaryData data = BinaryData.FromString(
                @"{""id"":""https://test.vault.azure.net/certificates/widget/abc123""}");

            CertificateProperties props = CertificateMapper.DeserializeItem(data, () => new CertificateProperties());

            Assert.AreEqual("widget",  props.Name);
            Assert.AreEqual("abc123",  props.Version);
            Assert.AreEqual("https://test.vault.azure.net/certificates/widget/abc123", props.Id.ToString());
        }

        // ----- ToBackupResponse -----

        [Test]
        public void ToBackupResponse_RoundTripsBytes()
        {
            byte[] expected = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            string encoded = Base64UrlEncode(expected);
            var raw = new MockResponse(200);
            raw.SetContent($"{{\"value\":\"{encoded}\"}}");

            Response<byte[]> response = CertificateMapper.ToBackupResponse(raw);

            CollectionAssert.AreEqual(expected, response.Value);
            Assert.AreSame(raw, response.GetRawResponse());
        }

        // ----- ToContactsResponse -----

        [Test]
        public void ToContactsResponse_ProjectsContacts()
        {
            var raw = new MockResponse(200);
            raw.SetContent(@"{ ""contacts"": [
                { ""name"": ""Alice"", ""email"": ""alice@contoso.com"" }
            ] }");

            Response<IList<CertificateContact>> response = CertificateMapper.ToContactsResponse(raw);

            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("Alice", response.Value[0].Name);
            Assert.AreSame(raw, response.GetRawResponse());
        }

        [Test]
        public void ToContactsResponse_EmptyObject_ProjectsEmptyList()
        {
            var raw = new MockResponse(200);
            raw.SetContent("{}");

            Response<IList<CertificateContact>> response = CertificateMapper.ToContactsResponse(raw);

            Assert.IsNotNull(response.Value);
            Assert.AreEqual(0, response.Value.Count);
        }

        // ----- helpers -----

        // Asserts that the bytes produced by CertificateMapper.ToRequestContent
        // match the bytes produced by the model's hand-written
        // IJsonSerializable.Serialize() output (which already brackets in
        // StartObject/EndObject) - structurally, byte-for-byte equivalent.
        private static void AssertRoundTripsLegacySerializer(IJsonSerializable model)
        {
            ReadOnlyMemory<byte> expected = model.Serialize();
            RequestContent content = CertificateMapper.ToRequestContent(model);

            using var actualStream = new MemoryStream();
            content.WriteTo(actualStream, default);
            byte[] actualBytes = actualStream.ToArray();

            // Bytes are not necessarily identical (different whitespace pinning).
            // Compare structurally as JSON.
            using JsonDocument expectedDoc = JsonDocument.Parse(expected);
            using JsonDocument actualDoc   = JsonDocument.Parse(actualBytes);
            Assert.AreEqual(
                expectedDoc.RootElement.GetRawText(),
                actualDoc.RootElement.GetRawText(),
                "CertificateMapper.ToRequestContent must produce the same JSON as the legacy IJsonSerializable.Serialize().");
        }

        private static JsonDocument ParseRequestContent(RequestContent content)
        {
            using var stream = new MemoryStream();
            content.WriteTo(stream, default);
            return JsonDocument.Parse(stream.ToArray());
        }

        private static string Base64UrlEncode(byte[] bytes)
        {
            string s = Convert.ToBase64String(bytes);
            return s.TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }
    }
}
