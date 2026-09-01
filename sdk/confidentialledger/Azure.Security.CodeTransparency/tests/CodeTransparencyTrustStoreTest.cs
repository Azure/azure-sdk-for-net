// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET462
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyTrustStoreTest
    {
        private static CodeTransparencyVerificationKey CreateKey(string keyId, ECCurve? curve = null)
        {
            using ECDsa ecdsa = ECDsa.Create(curve ?? ECCurve.NamedCurves.nistP256);
            return new CodeTransparencyVerificationKey(keyId, ecdsa);
        }

        private static CodeTransparencyVerificationKeySet CreateKeySet(params string[] keyIds)
        {
            var keys = new List<CodeTransparencyVerificationKey>();
            foreach (string id in keyIds)
            {
                keys.Add(CreateKey(id));
            }
            return new CodeTransparencyVerificationKeySet(keys);
        }

        [Test]
        public void Constructor_InitializesEmptyStore()
        {
            var store = new CodeTransparencyTrustStore();

            Assert.IsNotNull(store.KeysByIssuer);
            Assert.AreEqual(0, store.KeysByIssuer.Count);
        }

        [Test]
        public void SetKeys_AddsAndUpdatesEntries()
        {
            var store = new CodeTransparencyTrustStore();
            var first = CreateKeySet("a");
            var second = CreateKeySet("b");

            store.SetKeys("ledger1", first);
            Assert.AreEqual(1, store.KeysByIssuer.Count);
            Assert.IsTrue(store.TryGetKeys("ledger1", out CodeTransparencyVerificationKeySet found));
            Assert.AreSame(first, found);

            store.SetKeys("ledger1", second);
            Assert.AreEqual(1, store.KeysByIssuer.Count);
            store.TryGetKeys("ledger1", out found);
            Assert.AreSame(second, found);
        }

        [Test]
        public void SetKeys_IsCaseInsensitiveOnIssuer()
        {
            var store = new CodeTransparencyTrustStore();
            var keys = CreateKeySet("a");

            store.SetKeys("Ledger.Domain", keys);

            Assert.IsTrue(store.TryGetKeys("ledger.domain", out CodeTransparencyVerificationKeySet found));
            Assert.AreSame(keys, found);
        }

        [Test]
        public void SetKeys_ThrowsOnInvalidArguments()
        {
            var store = new CodeTransparencyTrustStore();

            Assert.Throws<ArgumentException>(() => store.SetKeys(null, CreateKeySet("a")));
            Assert.Throws<ArgumentException>(() => store.SetKeys(string.Empty, CreateKeySet("a")));
            Assert.Throws<ArgumentNullException>(() => store.SetKeys("ledger1", null));
        }

        [Test]
        public void RemoveKeys_RemovesEntry()
        {
            var store = new CodeTransparencyTrustStore();
            store.SetKeys("ledger1", CreateKeySet("a"));

            Assert.IsTrue(store.RemoveKeys("LEDGER1"));
            Assert.AreEqual(0, store.KeysByIssuer.Count);
            Assert.IsFalse(store.RemoveKeys("ledger1"));
        }

        [Test]
        public void KeysByIssuer_IsReadOnly()
        {
            var store = new CodeTransparencyTrustStore();
            store.SetKeys("ledger1", CreateKeySet("a"));

            var dictionary = (IDictionary<string, CodeTransparencyVerificationKeySet>)store.KeysByIssuer;
            Assert.Throws<NotSupportedException>(() => dictionary["ledger2"] = CreateKeySet("b"));
        }

        [Test]
        public void ToBinaryData_RoundTripsAndPersistsOnlyPublicMaterial()
        {
            using ECDsa full = ECDsa.Create(ECCurve.NamedCurves.nistP384);
            ECParameters privateParams = full.ExportParameters(true);
            var key = new CodeTransparencyVerificationKey("key-1", full);

            var store = new CodeTransparencyTrustStore();
            store.SetKeys("ledger.contoso.com", new CodeTransparencyVerificationKeySet(new[] { key }));

            BinaryData serialized = store.ToBinaryData();
            string json = serialized.ToString();

            // Only public parameters are persisted.
            StringAssert.Contains("\"version\"", json);
            StringAssert.Contains("\"ledger.contoso.com\"", json);
            StringAssert.DoesNotContain("\"d\"", json);
            string privateBase64 = Convert.ToBase64String(privateParams.D);
            StringAssert.DoesNotContain(privateBase64, json);

            CodeTransparencyTrustStore restored = CodeTransparencyTrustStore.FromBinaryData(serialized);
            Assert.IsTrue(restored.TryGetKeys("ledger.contoso.com", out CodeTransparencyVerificationKeySet restoredKeys));
            Assert.AreEqual(1, restoredKeys.Keys.Count);
            Assert.AreEqual("key-1", restoredKeys.Keys[0].KeyId);

            // The restored public key still verifies a signature made by the original private key.
            byte[] data = Encoding.UTF8.GetBytes("payload");
            byte[] signature = full.SignData(data, HashAlgorithmName.SHA384);
            using ECDsa verifier = restoredKeys.Keys[0].ToECDsa();
            Assert.IsTrue(verifier.VerifyData(data, signature, HashAlgorithmName.SHA384));
        }

        [Test]
        public void FromBinaryData_ThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => CodeTransparencyTrustStore.FromBinaryData(null));
        }

        [Test]
        public void FromBinaryData_ThrowsOnUnsupportedVersion()
        {
            var data = BinaryData.FromString("{\"version\":999,\"issuers\":{}}");
            Assert.Throws<NotSupportedException>(() => CodeTransparencyTrustStore.FromBinaryData(data));
        }

        [Test]
        public void VerificationKeySet_RejectsMissingAndDuplicateIds()
        {
            Assert.Throws<ArgumentNullException>(() => new CodeTransparencyVerificationKeySet(null));
            Assert.Throws<ArgumentException>(() => new CodeTransparencyVerificationKeySet(new CodeTransparencyVerificationKey[] { null }));
            Assert.Throws<ArgumentException>(() => CreateKeySet("dup", "dup"));
        }

        [Test]
        public void VerificationKeySet_TryGetKeyIsCaseSensitive()
        {
            CodeTransparencyVerificationKeySet set = CreateKeySet("Key-1");

            Assert.IsTrue(set.TryGetKey("Key-1", out CodeTransparencyVerificationKey found));
            Assert.AreEqual("Key-1", found.KeyId);
            Assert.IsFalse(set.TryGetKey("key-1", out _));
            Assert.IsFalse(set.TryGetKey(null, out _));
        }

        [Test]
        public void VerificationKey_ConstructorValidatesArguments()
        {
            using ECDsa ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);

            Assert.Throws<ArgumentException>(() => new CodeTransparencyVerificationKey(null, ecdsa));
            Assert.Throws<ArgumentException>(() => new CodeTransparencyVerificationKey(string.Empty, ecdsa));
            Assert.Throws<ArgumentNullException>(() => new CodeTransparencyVerificationKey("k", null));
        }

        [Test]
        public void ToECDsa_ReturnsIndependentInstances()
        {
            CodeTransparencyVerificationKey key = CreateKey("k");
            ECDsa first = key.ToECDsa();
            ECDsa second = key.ToECDsa();

            Assert.AreNotSame(first, second);

            // Disposing one instance must not affect the other.
            first.Dispose();
            Assert.DoesNotThrow(() => second.ExportParameters(false));
            second.Dispose();
        }
    }
}
#endif
