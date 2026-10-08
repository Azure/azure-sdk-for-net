// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
#if NET6_0_OR_GREATER
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
#endif

namespace Azure.Security.Attestation.Tests
{
    /// <summary>
    /// Guards the request each public operation sends, and how it reads the response, against the 1.0.0 wire format.
    /// </summary>
    /// <remarks>
    /// The recorded tests for these operations are <c>LiveOnly</c>, so without these tests nothing checks them in playback.
    /// </remarks>
    public class ClientOperationWireTests
    {
        private const string Endpoint = "https://contoso.attest.azure.net";
        private const string ApiVersion = "api-version=2025-06-01";
        private const string Policy = "version=1.0; authorizationrules{=> permit();};";
        private static readonly byte[] s_evidence = { 0xFB, 0xFF, 0xBF, 0x01 };
        private static readonly byte[] s_runtimeData = { 0xFA, 0xFE, 0x02 };

        [Test]
        public void AttestSgxEnclave()
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{\"x-ms-sgx-svn\":7,\"svn\":8}")));

            AttestationResult result = client.AttestSgxEnclave(new AttestationRequest
            {
                Evidence = BinaryData.FromBytes(s_evidence),
                RuntimeData = new AttestationData(BinaryData.FromBytes(s_runtimeData), false),
                InittimeData = new AttestationData(BinaryData.FromString("{\"a\":1}"), true),
                DraftPolicyForAttestation = Policy,
            }).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/attest/SgxEnclave?{ApiVersion}", request.Uri);
            Assert.AreEqual("application/json", request.ContentType);
            AssertJsonEqual(
                $@"{{""quote"":""{Base64Url.Encode(s_evidence)}"",
                    ""runtimeData"":{{""data"":""{Base64Url.Encode(s_runtimeData)}"",""dataType"":""Binary""}},
                    ""initTimeData"":{{""data"":""{Base64Url.EncodeString("{\"a\":1}")}"",""dataType"":""JSON""}},
                    ""draftPolicyForAttestation"":""{Policy}""}}",
                request.Body);
            Assert.AreEqual(7f, result.Svn);
#pragma warning disable CS0618 // The deprecated claim is exercised deliberately.
            Assert.AreEqual(8f, result.DeprecatedSvn);
#pragma warning restore CS0618
        }

        [Test]
        public void AttestOpenEnclave()
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{\"x-ms-sgx-mrsigner\":\"mrs\"}")));

            AttestationResult result = client.AttestOpenEnclave(new AttestationRequest { Evidence = BinaryData.FromBytes(s_evidence) }).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/attest/OpenEnclave?{ApiVersion}", request.Uri);
            Assert.AreEqual("application/json", request.ContentType);
            AssertJsonEqual($@"{{""report"":""{Base64Url.Encode(s_evidence)}""}}", request.Body);
            Assert.AreEqual("mrs", result.MrSigner);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async System.Threading.Tasks.Task AttestTdxVm(bool async)
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{\"nonce\":\"n1\",\"x-ms-attestation-type\":\"tdxvm\",\"tdx_mrtd\":\"abc\"}")));
            var attestationRequest = new AttestationRequest
            {
                Evidence = BinaryData.FromBytes(s_evidence),
                RuntimeData = new AttestationData(BinaryData.FromBytes(s_runtimeData), false),
                InittimeData = new AttestationData(BinaryData.FromString("{\"a\":1}"), true),
                Nonce = "n1",
            };

            AttestationResult result = async
                ? (await client.AttestTdxVmAsync(attestationRequest)).Value
                : client.AttestTdxVm(attestationRequest).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/attest/TdxVm?{ApiVersion}", request.Uri);
            Assert.AreEqual("application/json", request.ContentType);
            AssertJsonEqual(
                $@"{{""quote"":""{Base64Url.Encode(s_evidence)}"",
                    ""runtimeData"":{{""data"":""{Base64Url.Encode(s_runtimeData)}"",""dataType"":""Binary""}},
                    ""initTimeData"":{{""data"":""{Base64Url.EncodeString("{\"a\":1}")}"",""dataType"":""JSON""}},
                    ""nonce"":""n1""}}",
                request.Body);
            Assert.AreEqual("n1", result.Nonce);
            Assert.AreEqual("tdxvm", result.VerifierType);
            Assert.AreEqual("abc", result.AdditionalClaims["tdx_mrtd"].ToObjectFromJson<string>());
        }

        [TestCase(false)]
        [TestCase(true)]
        public async System.Threading.Tasks.Task AttestSevSnpVm(bool async)
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{\"nonce\":\"n2\",\"x-ms-attestation-type\":\"sevsnpvm\",\"x-ms-sevsnpvm-guestsvn\":7}")));
            const string Evidence = "{\"SnpReport\":\"AQID\",\"VcekCertChain\":\"BAUG\"}";
            var attestationRequest = new AttestationRequest
            {
                Evidence = BinaryData.FromString(Evidence),
                RuntimeData = new AttestationData(BinaryData.FromString("{\"b\":2}"), true),
                DraftPolicyForAttestation = Policy,
                Nonce = "n2",
            };

            AttestationResult result = async
                ? (await client.AttestSevSnpVmAsync(attestationRequest)).Value
                : client.AttestSevSnpVm(attestationRequest).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/attest/SevSnpVm?{ApiVersion}", request.Uri);
            Assert.AreEqual("application/json", request.ContentType);
            AssertJsonEqual(
                $@"{{""report"":""{Base64Url.EncodeString(Evidence)}"",
                    ""runtimeData"":{{""data"":""{Base64Url.EncodeString("{\"b\":2}")}"",""dataType"":""JSON""}},
                    ""draftPolicyForAttestation"":""{Policy}"",
                    ""nonce"":""n2""}}",
                request.Body);
            Assert.AreEqual("n2", result.Nonce);
            Assert.AreEqual("sevsnpvm", result.VerifierType);
            Assert.AreEqual(7, result.AdditionalClaims["x-ms-sevsnpvm-guestsvn"].ToObjectFromJson<int>());
        }

        [Test]
        public void AttestTdxVmRejectsDraftPolicy()
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{}")));
            var request = new AttestationRequest { Evidence = BinaryData.FromBytes(s_evidence), DraftPolicyForAttestation = Policy };

            Assert.Throws<ArgumentException>(() => client.AttestTdxVm(request));
            Assert.ThrowsAsync<ArgumentException>(() => client.AttestTdxVmAsync(request));
            Assert.IsEmpty(captured);
        }

        [Test]
        public void AttestTdxVmRequiresServiceVersion20250601()
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{}"), AttestationClientOptions.ServiceVersion.V2020_10_01));
            var request = new AttestationRequest { Evidence = BinaryData.FromBytes(s_evidence) };

            Assert.Throws<NotSupportedException>(() => client.AttestTdxVm(request));
            Assert.ThrowsAsync<NotSupportedException>(() => client.AttestTdxVmAsync(request));
            Assert.IsEmpty(captured);
        }

        [Test]
        public void AttestSevSnpVmIsAvailableOnServiceVersion20201001()
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{}"), AttestationClientOptions.ServiceVersion.V2020_10_01));

            client.AttestSevSnpVm(new AttestationRequest { Evidence = BinaryData.FromString("{}") });

            Assert.AreEqual($"{Endpoint}/attest/SevSnpVm?api-version=2020-10-01", captured.Single().Uri);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AttestConfidentialVmRejectsNullArguments(bool tdx)
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{}")));
            Action<AttestationRequest> attest = tdx ? r => client.AttestTdxVm(r) : r => client.AttestSevSnpVm(r);

            Assert.AreEqual("request", Assert.Throws<ArgumentNullException>(() => attest(null)).ParamName);
            Assert.AreEqual("Evidence", Assert.Throws<ArgumentNullException>(() => attest(new AttestationRequest())).ParamName);
            Assert.IsEmpty(captured);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void AttestEnclaveSendsNonce(bool sgx)
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{}")));
            var request = new AttestationRequest { Evidence = BinaryData.FromBytes(s_evidence), Nonce = "n3" };

            _ = sgx ? client.AttestSgxEnclave(request) : client.AttestOpenEnclave(request);

            using JsonDocument body = JsonDocument.Parse(captured.Single().Body);
            Assert.AreEqual("n3", body.RootElement.GetProperty("nonce").GetString());
        }

        // The service never signs the token for a draft-policy attestation; 1.0.0 returned it, and so must 1.1.0.
        [Test]
        public async System.Threading.Tasks.Task DraftPolicyAttestationReturnsUnsignedToken([Values("SgxEnclave", "OpenEnclave", "SevSnpVm")] string type, [Values] bool async)
        {
            AttestationClient client = ValidatingClient("{\"nonce\":\"d1\"}");
            var request = new AttestationRequest { Evidence = BinaryData.FromString("{}"), DraftPolicyForAttestation = Policy };

            AttestationResponse<AttestationResult> response = await Attest(client, type, request, async);

            Assert.AreEqual("none", response.Token.Algorithm);
            Assert.AreEqual("d1", response.Value.Nonce);
        }

        [Test]
        public void AttestationWithoutDraftPolicyRejectsUnsignedToken([Values("SgxEnclave", "OpenEnclave", "SevSnpVm", "TdxVm")] string type, [Values] bool async)
        {
            AttestationClient client = ValidatingClient("{\"nonce\":\"d1\"}");
            var request = new AttestationRequest { Evidence = BinaryData.FromString("{}") };

            Assert.ThrowsAsync<AttestationTokenValidationFailedException>(() => Attest(client, type, request, async));
        }

        [Test]
        public void DraftPolicyAttestationStillChecksExpiration([Values] bool async)
        {
            long expired = DateTimeOffset.UtcNow.AddHours(-1).ToUnixTimeSeconds();
            AttestationClient client = ValidatingClient($"{{\"exp\":{expired}}}");
            var request = new AttestationRequest { Evidence = BinaryData.FromString("{}"), DraftPolicyForAttestation = Policy };

            Exception ex = Assert.CatchAsync(() => Attest(client, "SevSnpVm", request, async));
            Assert.AreEqual("Attestation token expired.", ex.Message);
        }

        [Test]
        public void DraftPolicyAttestationStillRaisesTokenValidated([Values] bool async)
        {
            var tokenOptions = new AttestationTokenValidationOptions();
            tokenOptions.TokenValidated += args =>
            {
                args.IsValid = false;
                return System.Threading.Tasks.Task.CompletedTask;
            };
            AttestationClient client = ValidatingClient("{}", tokenOptions);
            var request = new AttestationRequest { Evidence = BinaryData.FromString("{}"), DraftPolicyForAttestation = Policy };

            Assert.ThrowsAsync<AttestationTokenValidationFailedException>(() => Attest(client, "SgxEnclave", request, async));
        }

        [Test]
        public void AttestTpm()
        {
            var captured = new List<CapturedRequest>();
            string responseData = Base64Url.Encode(s_runtimeData);
            var client = new AttestationClient(new Uri(Endpoint), new MockCredential(), Options(captured, $"{{\"data\":\"{responseData}\"}}"));

            TpmAttestationResponse response = client.AttestTpm(new TpmAttestationRequest { Data = BinaryData.FromBytes(s_evidence) }).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/attest/Tpm?{ApiVersion}", request.Uri);
            Assert.AreEqual("application/json", request.ContentType);
            AssertJsonEqual($@"{{""data"":""{Base64Url.Encode(s_evidence)}""}}", request.Body);
            CollectionAssert.AreEqual(s_runtimeData, response.Data.ToArray());
        }

        [Test]
        public void GetPolicy()
        {
            var captured = new List<CapturedRequest>();
            string storedPolicy = Jwt($"{{\"AttestationPolicy\":\"{Base64Url.EncodeString(Policy)}\"}}");
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse($"{{\"x-ms-policy\":\"{storedPolicy}\"}}")));

            string policy = client.GetPolicy(AttestationType.SgxEnclave).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"{Endpoint}/policies/SgxEnclave?{ApiVersion}", request.Uri);
            Assert.AreEqual(Policy, policy);
        }

        [Test]
        public void GetPolicyWithEmptyPolicyTokenIsNull()
        {
            // The service reports an unconfigured policy as a policy token with an empty body.
            string emptyPolicy = $"{Base64Url.EncodeString("{\"alg\":\"none\"}")}..";
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(new List<CapturedRequest>(), TokenResponse($"{{\"x-ms-policy\":\"{emptyPolicy}\"}}")));

            Assert.IsNull(client.GetPolicy(AttestationType.SgxEnclave).Value);
        }

        [Test]
        public void SetPolicy()
        {
            var captured = new List<CapturedRequest>();
            byte[] hash = { 0xFB, 0xFF, 0x03 };
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(captured,
                TokenResponse($"{{\"x-ms-policy-result\":\"Updated\",\"x-ms-policy-token-hash\":\"{Base64Url.Encode(hash)}\"}}")));

            PolicyModificationResult result = client.SetPolicy(AttestationType.SgxEnclave, Policy).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Put, request.Method);
            Assert.AreEqual($"{Endpoint}/policies/SgxEnclave?{ApiVersion}", request.Uri);
            Assert.AreEqual("text/plain", request.ContentType);
            AssertJsonEqual($"{{\"AttestationPolicy\":\"{Base64Url.EncodeString(Policy)}\"}}", JwtBody(request.Body));
            Assert.AreEqual(PolicyModification.Updated, result.PolicyResolution);
            CollectionAssert.AreEqual(hash, result.PolicyTokenHash.ToArray());
        }

        [Test]
        public void ResetPolicy()
        {
            var captured = new List<CapturedRequest>();
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{\"x-ms-policy-result\":\"Removed\"}")));

            PolicyModificationResult result = client.ResetPolicy(AttestationType.SgxEnclave).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/policies/SgxEnclave:reset?{ApiVersion}", request.Uri);
            Assert.AreEqual("text/plain", request.ContentType);
            Assert.AreEqual(3, request.Body.Split('.').Length, "The body must be the raw JWS, not JSON");
            Assert.AreEqual(PolicyModification.Removed, result.PolicyResolution);
        }

#if NET6_0_OR_GREATER
        // CertificateRequest and RSA.Create(int) are unavailable on .NET Framework 4.6.2.
        [TestCase(true)]
        [TestCase(false)]
        public void ModifyPolicyManagementCertificate(bool add)
        {
            var captured = new List<CapturedRequest>();
            using RSA rsa = RSA.Create(2048);
            using X509Certificate2 certificate = CreateSelfSignedCertificate(rsa);
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(captured,
                TokenResponse("{\"x-ms-certificate-thumbprint\":\"ABCDEF\",\"x-ms-policycertificates-result\":\"IsPresent\"}")));
            var signingKey = new AttestationTokenSigningKey(rsa, certificate);

            PolicyCertificatesModificationResult result = add
                ? client.AddPolicyManagementCertificate(certificate, signingKey).Value
                : client.RemovePolicyManagementCertificate(certificate, signingKey).Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Post, request.Method);
            Assert.AreEqual($"{Endpoint}/certificates:{(add ? "add" : "remove")}?{ApiVersion}", request.Uri);
            Assert.AreEqual("application/json", request.ContentType);
            string jws = JsonSerializer.Deserialize<string>(request.Body);
            using JsonDocument body = JsonDocument.Parse(JwtBody(jws));
            string x5c = body.RootElement.GetProperty("policyCertificate").GetProperty("x5c")[0].GetString();
            Assert.AreEqual(Convert.ToBase64String(certificate.Export(X509ContentType.Cert)), x5c);
            Assert.AreEqual(PolicyCertificateResolution.IsPresent, result.CertificateResolution);
            Assert.AreEqual("ABCDEF", result.CertificateThumbprint);
        }

        [TestCase(true, false)]
        [TestCase(true, true)]
        [TestCase(false, false)]
        [TestCase(false, true)]
        public void ModifyPolicyManagementCertificateRejectsNullArguments(bool add, bool async)
        {
            var captured = new List<CapturedRequest>();
            using RSA rsa = RSA.Create(2048);
            using X509Certificate2 certificate = CreateSelfSignedCertificate(rsa);
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(captured, TokenResponse("{}")));
            var signingKey = new AttestationTokenSigningKey(rsa, certificate);

            Assert.AreEqual("existingSigningKey", ModifyPolicyManagementCertificate(client, add, async, certificate, null).ParamName);
            Assert.AreEqual(add ? "newSigningCertificate" : "certificateToRemove", ModifyPolicyManagementCertificate(client, add, async, null, signingKey).ParamName);
            Assert.IsEmpty(captured);
        }

        private static ArgumentNullException ModifyPolicyManagementCertificate(AttestationAdministrationClient client, bool add, bool async, X509Certificate2 certificate, AttestationTokenSigningKey signingKey)
            => (add, async) switch
            {
                (true, false) => Assert.Throws<ArgumentNullException>(() => client.AddPolicyManagementCertificate(certificate, signingKey)),
                (true, true) => Assert.ThrowsAsync<ArgumentNullException>(() => client.AddPolicyManagementCertificateAsync(certificate, signingKey)),
                (false, false) => Assert.Throws<ArgumentNullException>(() => client.RemovePolicyManagementCertificate(certificate, signingKey)),
                _ => Assert.ThrowsAsync<ArgumentNullException>(() => client.RemovePolicyManagementCertificateAsync(certificate, signingKey)),
            };

        [Test]
        public void GetPolicyManagementCertificates()
        {
            var captured = new List<CapturedRequest>();
            using RSA rsa = RSA.Create(2048);
            using X509Certificate2 certificate = CreateSelfSignedCertificate(rsa);
            string x5c = Convert.ToBase64String(certificate.Export(X509ContentType.Cert));
            var client = new AttestationAdministrationClient(new Uri(Endpoint), new MockCredential(), Options(captured,
                TokenResponse($"{{\"x-ms-policy-certificates\":{{\"keys\":[{{\"kty\":\"RSA\",\"x5c\":[\"{x5c}\"]}}]}}}}")));

            IReadOnlyList<X509Certificate2> certificates = client.GetPolicyManagementCertificates().Value;

            CapturedRequest request = captured.Single();
            Assert.AreEqual(RequestMethod.Get, request.Method);
            Assert.AreEqual($"{Endpoint}/certificates?{ApiVersion}", request.Uri);
            Assert.AreEqual(certificate.Thumbprint, certificates.Single().Thumbprint);
        }

        private static X509Certificate2 CreateSelfSignedCertificate(RSA rsa)
            => new CertificateRequest("CN=ClientOperationWireTests", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                .CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));
#endif

        // Default token validation; /certs returns no keys, and every attestation returns an unsigned token.
        private static AttestationClient ValidatingClient(string tokenBody, AttestationTokenValidationOptions tokenOptions = null)
            => new AttestationClient(new Uri(Endpoint), new MockCredential(), new AttestationClientOptions(tokenOptions: tokenOptions)
            {
                Transport = new MockTransport(request => new MockResponse(200).SetContent(
                    request.Uri.Path == "/certs" ? "{\"keys\":[]}" : TokenResponse(tokenBody))),
            });

        private static async System.Threading.Tasks.Task<AttestationResponse<AttestationResult>> Attest(AttestationClient client, string type, AttestationRequest request, bool async)
            => type switch
            {
                "SgxEnclave" => async ? await client.AttestSgxEnclaveAsync(request) : client.AttestSgxEnclave(request),
                "OpenEnclave" => async ? await client.AttestOpenEnclaveAsync(request) : client.AttestOpenEnclave(request),
                "SevSnpVm" => async ? await client.AttestSevSnpVmAsync(request) : client.AttestSevSnpVm(request),
                _ => async ? await client.AttestTdxVmAsync(request) : client.AttestTdxVm(request),
            };

        private static AttestationClientOptions Options(List<CapturedRequest> captured, string responseBody, AttestationClientOptions.ServiceVersion version = AttestationClientOptions.ServiceVersion.V2025_06_01)
            => new AttestationClientOptions(version, new AttestationTokenValidationOptions { ValidateToken = false })
            {
                Transport = new MockTransport(request =>
                {
                    captured.Add(new CapturedRequest(request));
                    return new MockResponse(200).SetContent(responseBody);
                }),
            };

        private static string Jwt(string body)
            => $"{Base64Url.EncodeString("{\"alg\":\"none\"}")}.{Base64Url.EncodeString(body)}.";

        private static string TokenResponse(string tokenBody) => $"{{\"token\":\"{Jwt(tokenBody)}\"}}";

        private static string JwtBody(string jws)
        {
            string[] parts = jws.Split('.');
            Assert.AreEqual(3, parts.Length, $"Expected a JWS but got: {jws}");
            return Base64Url.DecodeString(parts[1]);
        }

        private static void AssertJsonEqual(string expected, string actual)
        {
            using JsonDocument expectedDocument = JsonDocument.Parse(expected);
            using JsonDocument actualDocument = JsonDocument.Parse(actual);
            Assert.AreEqual(Canonical(expectedDocument.RootElement), Canonical(actualDocument.RootElement), actual);
        }

        private static string Canonical(JsonElement element) => element.ValueKind switch
        {
            JsonValueKind.Object => "{" + string.Join(",", element.EnumerateObject()
                .OrderBy(p => p.Name, StringComparer.Ordinal)
                .Select(p => JsonSerializer.Serialize(p.Name) + ":" + Canonical(p.Value))) + "}",
            JsonValueKind.Array => "[" + string.Join(",", element.EnumerateArray().Select(Canonical)) + "]",
            _ => element.GetRawText(),
        };

        private sealed class CapturedRequest
        {
            public CapturedRequest(MockRequest request)
            {
                Method = request.Method;
                Uri = request.Uri.ToString();
                ContentType = request.Headers.TryGetValue("Content-Type", out string contentType) ? contentType : null;
                if (request.Content != null)
                {
                    using var stream = new MemoryStream();
                    request.Content.WriteTo(stream, default);
                    Body = Encoding.UTF8.GetString(stream.ToArray());
                }
            }

            public RequestMethod Method { get; }
            public string Uri { get; }
            public string ContentType { get; }
            public string Body { get; }
        }
    }
}
