// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    public class AttestationModelFactoryTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public AttestationModelFactoryTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task TestGetPolicyModificationResult()
        {
            await Task.Yield();
            {
                var modificationResult = AttestationModelFactory.PolicyModificationResult(PolicyModification.Updated, "12344567", null);
                Assert.That(modificationResult.PolicyResolution, Is.EqualTo(PolicyModification.Updated));
                Assert.That(modificationResult.PolicyTokenHash.ToArray(), Is.EqualTo(new byte[] { 0xd7, 0x6d, 0xf8, 0xe3, 0x9e, 0xbb }));
                Assert.That(modificationResult.PolicySigner, Is.Null);
            }

            {
                AttestationSigner signer = new AttestationSigner(new List<X509Certificate2> { TestEnvironment.PolicyCertificate0, TestEnvironment.PolicyCertificate1, TestEnvironment.PolicyCertificate2 }, "KeyId4");
                var modificationResult = AttestationModelFactory.PolicyModificationResult(PolicyModification.Updated, "12345678", signer);
                Assert.That(modificationResult.PolicyResolution, Is.EqualTo(PolicyModification.Updated));
                Assert.That(modificationResult.PolicyTokenHash.ToArray(), Is.EqualTo(new byte[] { 0xd7, 0x6d, 0xf8, 0xe7, 0xae, 0xfc }));
                Assert.That(modificationResult.PolicySigner.CertificateKeyId, Is.EqualTo("KeyId4"));
                Assert.That(modificationResult.PolicySigner, Is.Not.Null);
                Assert.That(modificationResult.PolicySigner.SigningCertificates.Count, Is.EqualTo(3));
                Assert.That(modificationResult.PolicySigner.SigningCertificates[0].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate0.Thumbprint));
                Assert.That(modificationResult.PolicySigner.SigningCertificates[1].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate1.Thumbprint));
                Assert.That(modificationResult.PolicySigner.SigningCertificates[2].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate2.Thumbprint));
            }
        }

        [RecordedTest]
        public async Task TestGetPolicyCertificatesModificationResult()
        {
            await Task.Yield();
            {
                var modificationResult = AttestationModelFactory.PolicyCertificatesModificationResult(PolicyCertificateResolution.IsAbsent, "12344567");
                Assert.That(modificationResult.CertificateResolution, Is.EqualTo(PolicyCertificateResolution.IsAbsent));
                Assert.That(modificationResult.CertificateThumbprint, Is.EqualTo("12344567"));
            }
        }

        [RecordedTest]
        public async Task TestGetAttestationResponse()
        {
            await Task.Yield();
            {
                var modificationResult = AttestationModelFactory.PolicyCertificatesModificationResult(PolicyCertificateResolution.IsAbsent, "12344567");
                var response = Response.FromValue(modificationResult, null);
                var attestationResponse = AttestationModelFactory.AttestationResponse<PolicyCertificatesModificationResult>(response.GetRawResponse(), new AttestationToken(BinaryData.FromObjectAsJson(modificationResult)));
                PolicyCertificatesModificationResult result = attestationResponse.Value;
                Assert.That(result.CertificateResolution, Is.EqualTo(modificationResult.CertificateResolution));
                Assert.That(result.CertificateThumbprint, Is.EqualTo(modificationResult.CertificateThumbprint));
            }
        }

        [RecordedTest]
        public async Task TestGetAttestationResult()
        {
            {
                var attestationResult = AttestationModelFactory.AttestationResult();
                Assert.That(attestationResult, Is.Not.Null);
            }
            {
                AttestationSigner signer1 = new AttestationSigner(new List<X509Certificate2> { TestEnvironment.PolicyCertificate0, TestEnvironment.PolicyCertificate1, TestEnvironment.PolicyCertificate2 }, "KeyId4");
                AttestationSigner signer2 = new AttestationSigner(new List<X509Certificate2> { TestEnvironment.PolicyCertificate0, TestEnvironment.PolicyCertificate1, TestEnvironment.PolicyCertificate2 }, "KeyId75");

                var attestationResult = AttestationModelFactory.AttestationResult(policySigner: signer1, deprecatedPolicySigner: signer2, jti: "12345");
                Assert.That(attestationResult, Is.Not.Null);
                Assert.That(attestationResult.PolicySigner.CertificateKeyId, Is.EqualTo("KeyId4"));
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.That(attestationResult.DeprecatedPolicySigner.CertificateKeyId, Is.EqualTo("KeyId75"));
#pragma warning restore CS0618 // Type or member is obsolete
                Assert.That(attestationResult.PolicySigner, Is.Not.Null);
                Assert.That(attestationResult.PolicySigner.SigningCertificates.Count, Is.EqualTo(3));
                Assert.That(attestationResult.PolicySigner.SigningCertificates[0].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate0.Thumbprint));
                Assert.That(attestationResult.PolicySigner.SigningCertificates[1].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate1.Thumbprint));
                Assert.That(attestationResult.PolicySigner.SigningCertificates[2].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate2.Thumbprint));

#pragma warning disable CS0618 // Type or member is obsolete
                Assert.That(attestationResult.DeprecatedPolicySigner.SigningCertificates.Count, Is.EqualTo(3));
                Assert.That(attestationResult.DeprecatedPolicySigner.SigningCertificates[0].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate0.Thumbprint));
                Assert.That(attestationResult.DeprecatedPolicySigner.SigningCertificates[1].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate1.Thumbprint));
                Assert.That(attestationResult.DeprecatedPolicySigner.SigningCertificates[2].Thumbprint, Is.EqualTo(TestEnvironment.PolicyCertificate2.Thumbprint));
#pragma warning restore CS0618 // Type or member is obsolete
            }

            {
                var issuedAtTime = DateTimeOffset.Now;
                var expTime = DateTimeOffset.UtcNow;
                var nbfTime = DateTimeOffset.MaxValue;
                var attestationResult = AttestationModelFactory.AttestationResult(
                    jti: "jti",
                    issuer: "http://issuer",
                    issuedAt: issuedAtTime,
                    expiration: expTime,
                    notBefore: nbfTime,
                    cnf: "cnf",
                    nonce: "nonce",
                    version: "version",
                    runtimeClaims: "runtimeClaims",
                    inittimeClaims: "inittimeClaims",
                    policyClaims: "policyClaims",
                    verifierType: "verifiertype",
                    policyHash: BinaryData.FromBytes(new byte[] { 1, 2, 3 }),
                    isDebuggable: true,
                    productId: 4,
                    mrEnclave: "mrenclave",
                    mrSigner: "mrsigner",
                    svn: 5,
                    enclaveHeldData: BinaryData.FromBytes(new byte[] { 4, 5, 6 }),
                    sgxCollateral: "sgxCollateral",
                    deprecatedVersion: "deprecatedVersion",
                    deprecatedIsDebuggable: false,
                    deprecatedSgxCollateral: "deprecatedSgxCollateral",
                    deprecatedEnclaveHeldData: BinaryData.FromBytes(new byte[] { 7, 8, 9 }),
                    deprecatedEnclaveHeldData2: BinaryData.FromBytes(new byte[] { 10, 11, 12 }),
                    deprecatedProductId: 6,
                    deprecatedMrEnclave: "deprecatedMrEnclave",
                    deprecatedMrSigner: "deprecatedMrSigner",
                    deprecatedSvn: 7,
                    deprecatedTee: "deprecatedTee",
                    deprecatedPolicyHash: BinaryData.FromBytes(new byte[] { 13, 14, 15, 16 }),
                    deprecatedRpData: "deprecatedRpData");
                Assert.That(attestationResult, Is.Not.Null);
                Assert.That(attestationResult.UniqueIdentifier, Is.EqualTo("jti"));
                Assert.That(attestationResult.Issuer, Is.EqualTo(new Uri("http://issuer")));
                Assert.That(attestationResult.IssuedAt.ToUnixTimeSeconds(), Is.EqualTo(issuedAtTime.ToUnixTimeSeconds()));
                Assert.That(attestationResult.Expiration.ToUnixTimeSeconds(), Is.EqualTo(expTime.ToUnixTimeSeconds()));
                Assert.That(attestationResult.NotBefore.ToUnixTimeSeconds(), Is.EqualTo(nbfTime.ToUnixTimeSeconds()));
                Assert.That(attestationResult.Confirmation, Is.EqualTo("cnf"));
                Assert.That(attestationResult.Nonce, Is.EqualTo("nonce"));
                Assert.That(attestationResult.Version, Is.EqualTo("version"));
                Assert.That(attestationResult.RuntimeClaims, Is.EqualTo("runtimeClaims"));
                Assert.That(attestationResult.InittimeClaims, Is.EqualTo("inittimeClaims"));
                Assert.That(attestationResult.PolicyClaims, Is.EqualTo("policyClaims"));
                Assert.That(attestationResult.VerifierType, Is.EqualTo("verifiertype"));
                Assert.That(attestationResult.PolicyHash.ToArray(), Is.EqualTo(new byte[] { 1, 2, 3 }));
                Assert.That(attestationResult.IsDebuggable, Is.EqualTo(true));
                Assert.That(attestationResult.ProductId, Is.EqualTo(4));
                Assert.That(attestationResult.MrEnclave, Is.EqualTo("mrenclave"));
                Assert.That(attestationResult.MrSigner, Is.EqualTo("mrsigner"));
                Assert.That(attestationResult.Svn, Is.EqualTo(5));
                Assert.That(attestationResult.EnclaveHeldData.ToArray(), Is.EqualTo(new byte[] { 4, 5, 6 }));
                Assert.That(attestationResult.SgxCollateral, Is.EqualTo("sgxCollateral"));
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.That(attestationResult.DeprecatedVersion, Is.EqualTo("deprecatedVersion"));
                Assert.That(attestationResult.DeprecatedEnclaveHeldData.ToArray(), Is.EqualTo(new byte[]{ 7, 8, 9 }));
                Assert.That(attestationResult.DeprecatedEnclaveHeldData2.ToArray(), Is.EqualTo(new byte[] { 10, 11, 12 }));
                Assert.That(attestationResult.DeprecatedProductId, Is.EqualTo(6));
                Assert.That(attestationResult.DeprecatedMrEnclave, Is.EqualTo("deprecatedMrEnclave"));
                Assert.That(attestationResult.DeprecatedMrSigner, Is.EqualTo("deprecatedMrSigner"));
                Assert.That(attestationResult.DeprecatedSvn, Is.EqualTo(7));
                Assert.That(attestationResult.DeprecatedTee, Is.EqualTo("deprecatedTee"));
                Assert.That(attestationResult.DeprecatedPolicyHash.ToArray(), Is.EqualTo(new byte[] { 13, 14, 15, 16 }));
                Assert.That(attestationResult.DeprecatedRpData, Is.EqualTo("deprecatedRpData"));
#pragma warning restore CS0618 // Type or member is obsolete
            }
            await Task.Yield();
        }
    }
}