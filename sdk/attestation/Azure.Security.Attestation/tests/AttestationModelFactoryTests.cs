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
                Assert.AreEqual(PolicyModification.Updated, modificationResult.PolicyResolution);
                CollectionAssert.AreEqual(new byte[] { 0xd7, 0x6d, 0xf8, 0xe3, 0x9e, 0xbb }, modificationResult.PolicyTokenHash.ToArray());
                Assert.IsNull(modificationResult.PolicySigner);
            }

            {
                AttestationSigner signer = new AttestationSigner(new List<X509Certificate2> { TestEnvironment.PolicyCertificate0, TestEnvironment.PolicyCertificate1, TestEnvironment.PolicyCertificate2 }, "KeyId4");
                var modificationResult = AttestationModelFactory.PolicyModificationResult(PolicyModification.Updated, "12345678", signer);
                Assert.AreEqual(PolicyModification.Updated, modificationResult.PolicyResolution);
                CollectionAssert.AreEqual(new byte[] { 0xd7, 0x6d, 0xf8, 0xe7, 0xae, 0xfc }, modificationResult.PolicyTokenHash.ToArray());
                Assert.AreEqual("KeyId4", modificationResult.PolicySigner.CertificateKeyId);
                Assert.IsNotNull(modificationResult.PolicySigner);
                Assert.AreEqual(3, modificationResult.PolicySigner.SigningCertificates.Count);
                Assert.AreEqual(TestEnvironment.PolicyCertificate0.Thumbprint, modificationResult.PolicySigner.SigningCertificates[0].Thumbprint);
                Assert.AreEqual(TestEnvironment.PolicyCertificate1.Thumbprint, modificationResult.PolicySigner.SigningCertificates[1].Thumbprint);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.PolicySigner.SigningCertificates[2].Thumbprint);
            }
        }

        [RecordedTest]
        public async Task TestGetPolicyCertificatesModificationResult()
        {
            await Task.Yield();
            {
                var modificationResult = AttestationModelFactory.PolicyCertificatesModificationResult(PolicyCertificateResolution.IsAbsent, "12344567");
                Assert.AreEqual(PolicyCertificateResolution.IsAbsent, modificationResult.CertificateResolution);
                Assert.AreEqual("12344567", modificationResult.CertificateThumbprint);
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
                Assert.AreEqual(modificationResult.CertificateResolution, result.CertificateResolution);
                Assert.AreEqual(modificationResult.CertificateThumbprint, result.CertificateThumbprint);
            }
        }

        [RecordedTest]
        public async Task TestGetAttestationResult()
        {
            {
                var attestationResult = AttestationModelFactory.AttestationResult();
                Assert.IsNotNull(attestationResult);
            }
            {
                AttestationSigner signer1 = new AttestationSigner(new List<X509Certificate2> { TestEnvironment.PolicyCertificate0, TestEnvironment.PolicyCertificate1, TestEnvironment.PolicyCertificate2 }, "KeyId4");
                AttestationSigner signer2 = new AttestationSigner(new List<X509Certificate2> { TestEnvironment.PolicyCertificate0, TestEnvironment.PolicyCertificate1, TestEnvironment.PolicyCertificate2 }, "KeyId75");

                var attestationResult = AttestationModelFactory.AttestationResult(policySigner: signer1, deprecatedPolicySigner: signer2, jti: "12345");
                Assert.IsNotNull(attestationResult);
                Assert.AreEqual("KeyId4", attestationResult.PolicySigner.CertificateKeyId);
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.AreEqual("KeyId75", attestationResult.DeprecatedPolicySigner.CertificateKeyId);
#pragma warning restore CS0618 // Type or member is obsolete
                Assert.IsNotNull(attestationResult.PolicySigner);
                Assert.AreEqual(3, attestationResult.PolicySigner.SigningCertificates.Count);
                Assert.AreEqual(TestEnvironment.PolicyCertificate0.Thumbprint, attestationResult.PolicySigner.SigningCertificates[0].Thumbprint);
                Assert.AreEqual(TestEnvironment.PolicyCertificate1.Thumbprint, attestationResult.PolicySigner.SigningCertificates[1].Thumbprint);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, attestationResult.PolicySigner.SigningCertificates[2].Thumbprint);

#pragma warning disable CS0618 // Type or member is obsolete
                Assert.AreEqual(3, attestationResult.DeprecatedPolicySigner.SigningCertificates.Count);
                Assert.AreEqual(TestEnvironment.PolicyCertificate0.Thumbprint, attestationResult.DeprecatedPolicySigner.SigningCertificates[0].Thumbprint);
                Assert.AreEqual(TestEnvironment.PolicyCertificate1.Thumbprint, attestationResult.DeprecatedPolicySigner.SigningCertificates[1].Thumbprint);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, attestationResult.DeprecatedPolicySigner.SigningCertificates[2].Thumbprint);
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
                Assert.IsNotNull(attestationResult);
                Assert.AreEqual("jti", attestationResult.UniqueIdentifier);
                Assert.AreEqual(new Uri("http://issuer"), attestationResult.Issuer);
                Assert.AreEqual(issuedAtTime.ToUnixTimeSeconds(), attestationResult.IssuedAt.ToUnixTimeSeconds());
                Assert.AreEqual(expTime.ToUnixTimeSeconds(), attestationResult.Expiration.ToUnixTimeSeconds());
                Assert.AreEqual(nbfTime.ToUnixTimeSeconds(), attestationResult.NotBefore.ToUnixTimeSeconds());
                Assert.AreEqual("cnf", attestationResult.Confirmation);
                Assert.AreEqual("nonce", attestationResult.Nonce);
                Assert.AreEqual("version", attestationResult.Version);
                Assert.AreEqual("runtimeClaims", attestationResult.RuntimeClaims);
                Assert.AreEqual("inittimeClaims", attestationResult.InittimeClaims);
                Assert.AreEqual("policyClaims", attestationResult.PolicyClaims);
                Assert.AreEqual("verifiertype", attestationResult.VerifierType);
                CollectionAssert.AreEqual(new byte[] { 1, 2, 3 }, attestationResult.PolicyHash.ToArray());
                Assert.AreEqual(true, attestationResult.IsDebuggable);
                Assert.AreEqual(4, attestationResult.ProductId);
                Assert.AreEqual("mrenclave", attestationResult.MrEnclave);
                Assert.AreEqual("mrsigner", attestationResult.MrSigner);
                Assert.AreEqual(5, attestationResult.Svn);
                CollectionAssert.AreEqual(new byte[] { 4, 5, 6 }, attestationResult.EnclaveHeldData.ToArray());
                Assert.AreEqual("sgxCollateral", attestationResult.SgxCollateral);
#pragma warning disable CS0618 // Type or member is obsolete
                Assert.AreEqual("deprecatedVersion", attestationResult.DeprecatedVersion);
                CollectionAssert.AreEqual(new byte[]{ 7, 8, 9 }, attestationResult.DeprecatedEnclaveHeldData.ToArray());
                CollectionAssert.AreEqual(new byte[] { 10, 11, 12 }, attestationResult.DeprecatedEnclaveHeldData2.ToArray());
                Assert.AreEqual(6, attestationResult.DeprecatedProductId);
                Assert.AreEqual("deprecatedMrEnclave", attestationResult.DeprecatedMrEnclave);
                Assert.AreEqual("deprecatedMrSigner", attestationResult.DeprecatedMrSigner);
                Assert.AreEqual(7, attestationResult.DeprecatedSvn);
                Assert.AreEqual("deprecatedTee", attestationResult.DeprecatedTee);
                CollectionAssert.AreEqual(new byte[] { 13, 14, 15, 16 }, attestationResult.DeprecatedPolicyHash.ToArray());
                Assert.AreEqual("deprecatedRpData", attestationResult.DeprecatedRpData);
#pragma warning restore CS0618 // Type or member is obsolete
            }
            await Task.Yield();
        }
    }
}
