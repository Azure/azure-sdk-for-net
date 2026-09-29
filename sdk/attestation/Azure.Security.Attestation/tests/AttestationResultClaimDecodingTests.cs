// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    /// <summary>
    /// Guards the wire name and encoding of every <see cref="AttestationResult"/> claim against the 1.0.0 behavior.
    /// </summary>
    public class AttestationResultClaimDecodingTests
    {
        // 0xFB 0xFF 0xBF encodes to "-_-_" (Base64Url) but "+/+/" (Base64), so a decoder of the wrong alphabet fails.
        private static readonly byte[] s_bytes = { 0xFB, 0xFF, 0xBF, 0xFB, 0xFF, 0x01 };
        private static readonly string s_base64Url = Base64Url.Encode(s_bytes);

        [TestCase("x-ms-sgx-ehd")]
        [TestCase("x-ms-policy-hash")]
        [TestCase("aas-ehd")]
        [TestCase("maa-ehd")]
        [TestCase("policy_hash")]
        public void DecodesBase64UrlByteClaims(string claim)
        {
            Assert.That(s_base64Url, Does.Contain("-").And.Contain("_").And.Not.EndWith("="));

            AttestationResult result = Parse($"{{\"{claim}\":\"{s_base64Url}\"}}");

            CollectionAssert.AreEqual(s_bytes, GetBytes(result, claim).ToArray());
        }

        [TestCase("x-ms-sgx-ehd")]
        [TestCase("x-ms-policy-hash")]
        [TestCase("aas-ehd")]
        [TestCase("maa-ehd")]
        [TestCase("policy_hash")]
        public void WritesBase64UrlByteClaims(string claim)
        {
            AttestationResult result = Parse($"{{\"{claim}\":\"{s_base64Url}\"}}");

            using JsonDocument written = JsonDocument.Parse(ModelReaderWriter.Write(result));

            Assert.AreEqual(s_base64Url, written.RootElement.GetProperty(claim).GetString());
        }

        [Test]
        public void MapsRenamedStringClaims()
        {
            AttestationResult result = Parse("{\"jti\":\"id-1\",\"iss\":\"https://contoso.attest.azure.net\"}");

            Assert.AreEqual("id-1", result.UniqueIdentifier);
            Assert.AreEqual(new Uri("https://contoso.attest.azure.net"), result.Issuer);
        }

        // Every claim has a distinct value, so a property bound to the wrong claim name fails.
        private const string AllClaims = @"{
            ""jti"":""jti-1"", ""iss"":""https://contoso.attest.azure.net"", ""iat"":1600000001, ""exp"":1600000002, ""nbf"":1600000003,
            ""nonce"":""nonce-1"", ""x-ms-ver"":""ver-1"", ""x-ms-attestation-type"":""sgx"",
            ""x-ms-runtime"":{""r"":1}, ""x-ms-inittime"":{""i"":1}, ""x-ms-policy"":{""p"":1},
            ""x-ms-sgx-collateral"":{""c"":1}, ""maa-attestationcollateral"":{""dc"":1},
            ""x-ms-sgx-is-debuggable"":true, ""is-debuggable"":false,
            ""x-ms-sgx-product-id"":11, ""product-id"":12,
            ""x-ms-sgx-svn"":21, ""svn"":22,
            ""x-ms-sgx-mrenclave"":""mre"", ""sgx-mrenclave"":""dmre"",
            ""x-ms-sgx-mrsigner"":""mrs"", ""sgx-mrsigner"":""dmrs"",
            ""ver"":""dver"", ""tee"":""dtee"", ""rp_data"":""drp""
        }";

        [Test]
        public void MapsEveryClaimFromItsWireName()
        {
            AttestationResult result = Parse(AllClaims);

            Assert.AreEqual("jti-1", result.UniqueIdentifier);
            Assert.AreEqual(new Uri("https://contoso.attest.azure.net"), result.Issuer);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1600000001), result.IssuedAt);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1600000002), result.Expiration);
            Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1600000003), result.NotBefore);
            Assert.AreEqual("nonce-1", result.Nonce);
            Assert.AreEqual("ver-1", result.Version);
            Assert.AreEqual("sgx", result.VerifierType);
            AssertObjectClaim(result.RuntimeClaims, "r");
            AssertObjectClaim(result.InittimeClaims, "i");
            AssertObjectClaim(result.PolicyClaims, "p");
            AssertObjectClaim(result.SgxCollateral, "c");
            Assert.AreEqual(true, result.IsDebuggable);
            Assert.AreEqual(11f, result.ProductId);
            Assert.AreEqual(21f, result.Svn);
            Assert.AreEqual("mre", result.MrEnclave);
            Assert.AreEqual("mrs", result.MrSigner);
#pragma warning disable CS0618 // The deprecated claims are exercised deliberately.
            AssertObjectClaim(result.DeprecatedSgxCollateral, "dc");
            Assert.AreEqual(false, result.DeprecatedIsDebuggable);
            Assert.AreEqual(12f, result.DeprecatedProductId);
            Assert.AreEqual(22f, result.DeprecatedSvn);
            Assert.AreEqual("dmre", result.DeprecatedMrEnclave);
            Assert.AreEqual("dmrs", result.DeprecatedMrSigner);
            Assert.AreEqual("dver", result.DeprecatedVersion);
            Assert.AreEqual("dtee", result.DeprecatedTee);
            Assert.AreEqual("drp", result.DeprecatedRpData);
#pragma warning restore CS0618
        }

        [Test]
        public void WritesEveryClaimUnderItsWireName()
        {
            using JsonDocument expected = JsonDocument.Parse(AllClaims);
            using JsonDocument written = JsonDocument.Parse(ModelReaderWriter.Write(Parse(AllClaims)));

            foreach (JsonProperty claim in expected.RootElement.EnumerateObject())
            {
                Assert.IsTrue(written.RootElement.TryGetProperty(claim.Name, out JsonElement value), $"'{claim.Name}' was not written");
                Assert.AreEqual(claim.Value.GetRawText().Replace(" ", ""), value.GetRawText(), claim.Name);
            }
            Assert.AreEqual(expected.RootElement.EnumerateObject().Count(), written.RootElement.EnumerateObject().Count());
        }

        [Test]
        public void AbsentByteClaimsAreNull()
        {
            AttestationResult result = Parse("{}");

            Assert.IsNull(result.EnclaveHeldData);
            Assert.IsNull(result.PolicyHash);
        }

        [TestCase("x-ms-sgx-ehd")]
        [TestCase("x-ms-policy-hash")]
        [TestCase("aas-ehd")]
        [TestCase("maa-ehd")]
        [TestCase("policy_hash")]
        public void NullByteClaimsAreNull(string claim)
        {
            AttestationResult result = Parse($"{{\"{claim}\":null}}");

            Assert.IsNull(GetBytes(result, claim));
        }

        [Test]
        public void ModelFactoryResultWithoutCnfSerializes()
        {
            AttestationResult result = AttestationModelFactory.AttestationResult(jti: "id-1");

            using JsonDocument written = JsonDocument.Parse(ModelReaderWriter.Write(result));

            Assert.AreEqual("id-1", written.RootElement.GetProperty("jti").GetString());
            Assert.IsFalse(written.RootElement.TryGetProperty("cnf", out _));
        }

        private static AttestationResult Parse(string json)
            => new AttestationToken(BinaryData.FromString(json)).GetBody<AttestationResult>();

        private static void AssertObjectClaim(object claim, string expectedKey)
            => Assert.That(claim, Is.InstanceOf<IDictionary<string, object>>().And.ContainKey(expectedKey));

#pragma warning disable CS0618 // The deprecated claims are exercised deliberately.
        private static BinaryData GetBytes(AttestationResult result, string claim) => claim switch
        {
            "x-ms-sgx-ehd" => result.EnclaveHeldData,
            "x-ms-policy-hash" => result.PolicyHash,
            "aas-ehd" => result.DeprecatedEnclaveHeldData,
            "maa-ehd" => result.DeprecatedEnclaveHeldData2,
            "policy_hash" => result.DeprecatedPolicyHash,
            _ => throw new ArgumentOutOfRangeException(nameof(claim)),
        };
#pragma warning restore CS0618
    }
}
