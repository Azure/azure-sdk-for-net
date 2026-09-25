// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class MLDsaOptionsTests
    {
        private static readonly byte[] s_message = { 1, 2, 3, 4 };
        private static readonly byte[] s_signature = { 5, 6, 7, 8 };
        private static readonly byte[] s_externalMu = { 9, 10, 11, 12 };
        private static readonly byte[] s_context = { 13, 14, 15, 16 };

        [Test]
        public void SignOptionsNullMessageThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new MLDsaSignOptions(null));
            Assert.AreEqual("message", ex.ParamName);
        }

        [Test]
        public void SignOptionsStoresMessage()
        {
            MLDsaSignOptions options = new MLDsaSignOptions(s_message);

            Assert.AreSame(s_message, options.Message);
            Assert.IsNull(options.ExternalMu);
            Assert.IsNull(options.Context);
        }

        [Test]
        public void VerifyOptionsNullMessageThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new MLDsaVerifyOptions(null, s_signature));
            Assert.AreEqual("message", ex.ParamName);
        }

        [Test]
        public void VerifyOptionsNullSignatureThrows()
        {
            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => new MLDsaVerifyOptions(s_message, null));
            Assert.AreEqual("signature", ex.ParamName);
        }

        [Test]
        public void VerifyOptionsStoresMessageAndSignature()
        {
            MLDsaVerifyOptions options = new MLDsaVerifyOptions(s_message, s_signature);

            Assert.AreSame(s_message, options.Message);
            Assert.AreSame(s_signature, options.Signature);
            Assert.IsNull(options.ExternalMu);
            Assert.IsNull(options.Context);
        }

        [Test]
        public void SignParametersSerializeMessageAndContext()
        {
            KeySignParameters parameters = new KeySignParameters
            {
                Digest = s_message,
                Context = s_context,
            };

            using JsonDocument json = JsonDocument.Parse(((IJsonSerializable)parameters).Serialize());
            JsonElement root = json.RootElement;

            Assert.AreEqual(ToBase64Url(s_message), root.GetProperty("value").GetString());
            Assert.AreEqual(ToBase64Url(s_context), root.GetProperty("context").GetString());
            Assert.IsFalse(root.TryGetProperty("external_mu", out _));
        }

        [Test]
        public void SignParametersSerializeExternalMu()
        {
            KeySignParameters parameters = new KeySignParameters
            {
                ExternalMu = s_externalMu,
            };

            using JsonDocument json = JsonDocument.Parse(((IJsonSerializable)parameters).Serialize());
            JsonElement root = json.RootElement;

            Assert.AreEqual(ToBase64Url(s_externalMu), root.GetProperty("external_mu").GetString());
            Assert.IsFalse(root.TryGetProperty("value", out _));
        }

        [Test]
        public void VerifyParametersSerializeExternalMuAndSignature()
        {
            KeyVerifyParameters parameters = new KeyVerifyParameters
            {
                Signature = s_signature,
                ExternalMu = s_externalMu,
            };

            using JsonDocument json = JsonDocument.Parse(((IJsonSerializable)parameters).Serialize());
            JsonElement root = json.RootElement;

            Assert.AreEqual(ToBase64Url(s_signature), root.GetProperty("value").GetString());
            Assert.AreEqual(ToBase64Url(s_externalMu), root.GetProperty("external_mu").GetString());
        }

        private static string ToBase64Url(byte[] value) =>
            Convert.ToBase64String(value).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }
}
