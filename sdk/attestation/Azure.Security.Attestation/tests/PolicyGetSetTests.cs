// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Security.Attestation;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Security.Attestation.Tests
{
    [LiveOnly(Reason = "JWT cannot be stored in recordings.")]
    public class PolicyGetSetTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public PolicyGetSetTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetPolicyShared()
        {
            var adminclient = TestEnvironment.GetSharedAdministrationClient(this);

            string policy = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);

            Assert.IsTrue(policy.StartsWith("version"));
        }

        [RecordedTest]
        public async Task GetPolicyAad()
        {
            var adminclient = TestEnvironment.GetAadAdministrationClient(this);

            string policy = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);

            Assert.IsTrue(policy.StartsWith("version"));
        }

        [RecordedTest]
        public async Task GetPolicyIsolated()
        {
            var adminclient = TestEnvironment.GetIsolatedAdministrationClient(this);

            string policy = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);

            Assert.IsTrue(policy.StartsWith("version"));
        }

        public const string disallowDebugging = "version=1.0;" +
"authorizationrules {" +
"c:[type==\"$is-debuggable\"] && [value==true] => deny();" +
"=> permit();" +
"};"+
"issuancerules {" +
"    c:[type==\"$is-debuggable\"] => issue(type=\"NotDebuggable\", value=c.value);"+
"    c:[type==\"$is-debuggable\"] => issue(type=\"is-debuggable\", value=c.value);"+
"    c:[type==\"$sgx-mrsigner\"] => issue(type=\"sgx-mrsigner\", value=c.value);"+
"    c:[type==\"$sgx-mrenclave\"] => issue(type=\"sgx-mrenclave\", value=c.value);"+
"    c:[type==\"$product-id\"] => issue(type=\"product-id\", value=c.value);"+
"    c:[type==\"$svn\"] => issue(type=\"svn\", value=c.value);"+
"    c:[type==\"$tee\"] => issue(type=\"tee\", value=c.value);"+
"};";

        private async Task ResetAttestationPolicy(AttestationAdministrationClient adminClient, AttestationType attestationType, bool isSecuredToken, bool isIsolated)
        {
            X509Certificate2 x509Certificate = null;
            RSA rsaKey = null;
            if (isSecuredToken)
            {
                if (isIsolated)
                {
                    x509Certificate = TestEnvironment.PolicyManagementCertificate;

                    rsaKey = TestEnvironment.PolicyManagementKey;
                }
                else
                {
                    x509Certificate = TestEnvironment.PolicyCertificate0;

                    rsaKey = TestEnvironment.PolicySigningKey0;
                }
            }
            else
            {
            }

            var policySetResult = await adminClient.ResetPolicyAsync(AttestationType.OpenEnclave, (rsaKey != null ? new AttestationTokenSigningKey(rsaKey, x509Certificate) : null));
            Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
            Assert.AreEqual(PolicyModification.Removed, policySetResult.Value.PolicyResolution);
        }

        [RecordedTest]
        public async Task SetPolicyUnsecuredAad()
        {
            var adminclient = TestEnvironment.GetAadAdministrationClient(this);

            // Reset the current attestation policy to a known state. Necessary if there were previous runs that failed.
            await ResetAttestationPolicy(adminclient, AttestationType.OpenEnclave, false, false);

            string originalPolicy;
            {
                originalPolicy = await adminclient.GetPolicyAsync(AttestationType.OpenEnclave);
            }

            byte[] disallowDebuggingHash;
            {
                var policySetResult = await adminclient.SetPolicyAsync(AttestationType.OpenEnclave, disallowDebugging);

                // The SetPolicyAsync API will create an UnsecuredAttestationToken to transmit the policy.
                var shaHasher = SHA256.Create();
                var policySetToken = new AttestationToken(BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = disallowDebugging }));

                disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));

                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Updated, policySetResult.Value.PolicyResolution);
                CollectionAssert.AreEqual(disallowDebuggingHash, policySetResult.Value.PolicyTokenHash.ToArray());
            }

            {
                string policyResult = await adminclient.GetPolicyAsync(AttestationType.OpenEnclave);

                Assert.AreEqual(disallowDebugging, policyResult);
            }
            {
                var policySetResult = await adminclient.ResetPolicyAsync(AttestationType.OpenEnclave);
                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Removed, policySetResult.Value.PolicyResolution);
            }

            {
                var policyResult = await adminclient.GetPolicyAsync(AttestationType.OpenEnclave);

                // And when we're done, policy should be reset to the original value.
                Assert.AreEqual(originalPolicy, policyResult.Value);
            }
        }

        [RecordedTest]
        public async Task SetPolicyUnsecuredIsolated()
        {
            var adminclient = TestEnvironment.GetIsolatedAdministrationClient(this);

            var error = Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await adminclient.SetPolicyAsync(AttestationType.OpenEnclave, disallowDebugging));
            Assert.AreEqual(400, error.Status);
            await Task.Yield();
        }

        public async Task SetPolicySecured(AttestationAdministrationClient adminClient, bool isIsolated)
        {
            // Reset the current attestation policy to a known state. Necessary if there were previous runs that failed.
            await ResetAttestationPolicy(adminClient, AttestationType.OpenEnclave, true, isIsolated);

            string originalPolicy = await adminClient.GetPolicyAsync(AttestationType.OpenEnclave);

            X509Certificate2 x509Certificate;
            RSA rsaKey;

            if (isIsolated)
            {
                x509Certificate = TestEnvironment.PolicyManagementCertificate;

                rsaKey = TestEnvironment.PolicyManagementKey;
            }
            else
            {
                x509Certificate = TestEnvironment.PolicyCertificate0;

                rsaKey = TestEnvironment.PolicySigningKey0;
            }

            byte[] disallowDebuggingHash;
            {
                var policySetResult = await adminClient.SetPolicyAsync(AttestationType.OpenEnclave, disallowDebugging, new AttestationTokenSigningKey(rsaKey, x509Certificate));

                var shaHasher = SHA256.Create();

                var policySetToken = new AttestationToken(
                    BinaryData.FromObjectAsJson(new StoredAttestationPolicy { AttestationPolicy = disallowDebugging }), new AttestationTokenSigningKey(rsaKey, x509Certificate));
                disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.Serialize()));

                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Updated, policySetResult.Value.PolicyResolution);
                CollectionAssert.AreEqual(disallowDebuggingHash, policySetResult.Value.PolicyTokenHash.ToArray());
                Assert.AreEqual(x509Certificate, policySetResult.Value.PolicySigner.SigningCertificates[0]);
            }

            {
                var policyResult = await adminClient.GetPolicyAsync(AttestationType.OpenEnclave);

                Assert.AreEqual(disallowDebugging, policyResult.Value);
            }
            {
                var policySetResult = await adminClient.ResetPolicyAsync(AttestationType.OpenEnclave, new AttestationTokenSigningKey(rsaKey, x509Certificate));
                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Removed, policySetResult.Value.PolicyResolution);
            }

            {
                var policyResult = await adminClient.GetPolicyAsync(AttestationType.OpenEnclave);

                // And when we're done, policy should be reset to the original value.
                Assert.AreEqual(originalPolicy, policyResult.Value);
            }
        }

        [RecordedTest]
        public async Task SetPolicySecuredAad()
        {
            var adminclient = TestEnvironment.GetAadAdministrationClient(this);

            await SetPolicySecured(adminclient, false);
        }

        [RecordedTest]
        public async Task SetPolicySecuredIsolated()
        {
            var adminclient = TestEnvironment.GetIsolatedAdministrationClient(this);

            await SetPolicySecured(adminclient, true);
        }

        [RecordedTest]
        public async Task GetPolicyManagementCertificatesIsolated()
        {
            var adminclient = TestEnvironment.GetIsolatedAdministrationClient(this);
            {
                var certificateResult = await adminclient.GetPolicyManagementCertificatesAsync();
                Assert.AreNotEqual(0, certificateResult.Value.Count);

                bool foundInitialRoot = false;
                foreach (var cert in certificateResult.Value)
                {
                    if (cert.Thumbprint == TestEnvironment.PolicyManagementCertificate.Thumbprint)
                    {
                        foundInitialRoot = true;
                        break;
                    }
                }
                Assert.IsTrue(foundInitialRoot);
            }
        }

        [RecordedTest]
        public async Task GetPolicyManagementCertificatesShared()
        {
            var adminclient = TestEnvironment.GetSharedAdministrationClient(this);
            {
                var certificateResult = await adminclient.GetPolicyManagementCertificatesAsync();
                Assert.AreEqual(0, certificateResult.Value.Count);
            }
        }

        [RecordedTest]
        public async Task AddRemovePolicyManagementCertificate()
        {
            var adminClient = TestEnvironment.GetIsolatedAdministrationClient(this);

            var x509Certificate = TestEnvironment.PolicyManagementCertificate;
            var rsaKey = TestEnvironment.PolicyManagementKey;
            {
                var modificationResult = await adminClient.AddPolicyManagementCertificateAsync(
                    TestEnvironment.PolicyCertificate2,
                    new AttestationTokenSigningKey(rsaKey, x509Certificate));
                Assert.AreEqual(PolicyCertificateResolution.IsPresent, modificationResult.Value.CertificateResolution);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.Value.CertificateThumbprint);

                // Verify that the certificate we got back was in fact added.
                var certificateResult = await adminClient.GetPolicyManagementCertificatesAsync();
                bool foundAddedCertificate = false;
                foreach (var cert in certificateResult.Value)
                {
                    if (cert.Thumbprint == TestEnvironment.PolicyCertificate2.Thumbprint)
                    {
                        foundAddedCertificate = true;
                        break;
                    }
                }
                Assert.IsTrue(foundAddedCertificate);
            }

            // Add the same certificate a second time, that should generate the same result.
            {
                var modificationResult = await adminClient.AddPolicyManagementCertificateAsync(
                    TestEnvironment.PolicyCertificate2,
                    new AttestationTokenSigningKey(rsaKey, x509Certificate));
                Assert.AreEqual(PolicyCertificateResolution.IsPresent, modificationResult.Value.CertificateResolution);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.Value.CertificateThumbprint);

                // Verify that the certificate we got back was in fact added.
                var certificateResult = await adminClient.GetPolicyManagementCertificatesAsync();
                bool foundAddedCertificate = false;
                foreach (var cert in certificateResult.Value)
                {
                    if (cert.Thumbprint == TestEnvironment.PolicyCertificate2.Thumbprint)
                    {
                        foundAddedCertificate = true;
                        break;
                    }
                }
                Assert.IsTrue(foundAddedCertificate);
            }

            {
                var modificationResult = await adminClient.RemovePolicyManagementCertificateAsync(
                    TestEnvironment.PolicyCertificate2,
                    new AttestationTokenSigningKey(rsaKey, x509Certificate));
                Assert.AreEqual(PolicyCertificateResolution.IsAbsent, modificationResult.Value.CertificateResolution);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.Value.CertificateThumbprint);

                // Verify that the certificate we got back was in fact added.
                var certificateResult = await adminClient.GetPolicyManagementCertificatesAsync();
                bool foundAddedCertificate = false;
                foreach (var cert in certificateResult.Value)
                {
                    if (cert.Thumbprint == TestEnvironment.PolicyCertificate2.Thumbprint)
                    {
                        foundAddedCertificate = true;
                        break;
                    }
                }
                Assert.IsFalse(foundAddedCertificate);
            }
        }
    }
}
