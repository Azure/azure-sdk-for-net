// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Security.CodeTransparency;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyOfflineKeysTest
    {
        private sealed class DummyJwksDocument : JwksDocument
        {
            private readonly string _id;

            public DummyJwksDocument(string id)
            {
                _id = id;
            }

            public string Id => _id;
        }

        [Test]
        public void Constructor_InitializesEmptyDictionary()
        {
            var keys = new CodeTransparencyOfflineKeys();

            Assert.That(keys.ByIssuer, Is.Not.Null);
            Assert.That(keys.ByIssuer.Count, Is.EqualTo(0));
        }

        [Test]
        public void Add_AddsNewEntry()
        {
            var keys = new CodeTransparencyOfflineKeys();
            var doc = new DummyJwksDocument("doc1");

            keys.Add("ledger1", doc);

            Assert.That(keys.ByIssuer, Has.Count.EqualTo(1));
            Assert.That(keys.ByIssuer["ledger1"], Is.SameAs(doc));
        }

        [Test]
        public void Add_UpdatesExistingEntry()
        {
            var keys = new CodeTransparencyOfflineKeys();
            var doc1 = new DummyJwksDocument("doc1");
            var doc2 = new DummyJwksDocument("doc2");

            keys.Add("ledger1", doc1);
            keys.Add("ledger1", doc2);

            Assert.That(keys.ByIssuer, Has.Count.EqualTo(1));
            Assert.That(keys.ByIssuer["ledger1"], Is.SameAs(doc2));
        }

        [Test]
        public void Add_IsCaseInsensitiveOnDomain()
        {
            var keys = new CodeTransparencyOfflineKeys();
            var doc1 = new DummyJwksDocument("doc1");
            var doc2 = new DummyJwksDocument("doc2");

            keys.Add("Ledger.Domain", doc1);
            keys.Add("ledger.domain", doc2);

            Assert.That(keys.ByIssuer, Has.Count.EqualTo(1));
            Assert.That(keys.ByIssuer["LEDGER.DOMAIN"], Is.SameAs(doc2));
        }

        [Test]
        public void Add_ThrowsOnNullLedgerDomain()
        {
            var keys = new CodeTransparencyOfflineKeys();
            var doc = new DummyJwksDocument("doc");

            Assert.Throws<ArgumentNullException>(() => keys.Add(null, doc));
        }

        [Test]
        public void Add_ThrowsOnEmptyLedgerDomain()
        {
            var keys = new CodeTransparencyOfflineKeys();
            var doc = new DummyJwksDocument("doc");

            Assert.Throws<ArgumentException>(() => keys.Add(string.Empty, doc));
        }

        [Test]
        public void Add_ThrowsOnNullJwksDocument()
        {
            var keys = new CodeTransparencyOfflineKeys();

            Assert.Throws<ArgumentNullException>(() => keys.Add("ledger1", null));
        }

        [Test]
        public void ByIssuer_ReturnsReadOnlyDictionary()
        {
            var keys = new CodeTransparencyOfflineKeys();
            var doc = new DummyJwksDocument("doc1");
            keys.Add("ledger1", doc);

            var byIssuer = keys.ByIssuer;

            // IReadOnlyDictionary is read-only by design
            Assert.Throws<NotSupportedException>(() =>
            {
                var cast = (IDictionary<string, JwksDocument>)byIssuer;
                cast["ledger2"] = doc;
            });
        }

        [Test]
        public void FromBinaryData_ParsesMultipleEntries()
        {
            var json = @"
            {
                ""ledger1.contoso.com"": {},
                ""ledger2.contoso.com"": {}
            }";

            // We only care that JwksDocument.DeserializeJwksDocument is called for each entry.
            // Since we cannot easily assert the internal JwksDocument instances without
            // relying on its implementation, we focus on the key count.
            var binary = new BinaryData(json);

            var keys = CodeTransparencyOfflineKeys.FromBinaryData(binary);

            Assert.That(keys.ByIssuer, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(keys.ByIssuer.ContainsKey("ledger1.contoso.com"), Is.True);
                Assert.That(keys.ByIssuer.ContainsKey("ledger2.contoso.com"), Is.True);
            });
        }

        [Test]
        public void DeserializeKeys_UsesPropertyNamesAsLedgerDomains()
        {
            var json = @"
            {
                ""ledger1.example.com"": {},
                ""ledger2.example.com"": {}
            }";

            using var doc = JsonDocument.Parse(json);
            var keys = CodeTransparencyOfflineKeys.DeserializeKeys(doc.RootElement);

            Assert.That(keys.ByIssuer, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(keys.ByIssuer.ContainsKey("ledger1.example.com"), Is.True);
                Assert.That(keys.ByIssuer.ContainsKey("ledger2.example.com"), Is.True);
            });
        }
    }
}