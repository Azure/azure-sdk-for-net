// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Security.Attestation.Models;
using Azure.Identity;
using Azure.Security.Attestation.Tests.Samples;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Azure.Security.Attestation.Tests
{
    public class PolicyGetSetTests : RecordedTestBase<AttestationClientTestEnvironment>
    {
        public PolicyGetSetTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetPolicyShared()
        {
            var adminclient = GetSharedAdministrationClient();

            StoredAttestationPolicy policyResult = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.AttestationPolicy;

            var policyRaw = Base64Url.Decode(result);
            var policy = System.Text.Encoding.UTF8.GetString(policyRaw);
            Assert.IsTrue(policy.StartsWith("version"));
        }

        [RecordedTest]
        public async Task GetPolicyAad()
        {
            var adminclient = GetAadAdministrationClient();

            StoredAttestationPolicy policyResult = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.AttestationPolicy;

            var policyRaw = Base64Url.Decode(result);
            var policy = System.Text.Encoding.UTF8.GetString(policyRaw);
            Assert.IsTrue(policy.StartsWith("version"));
        }

        [RecordedTest]
        public async Task GetPolicyIsolated()
        {
            var adminclient = GetIsolatedAdministrationClient();

            StoredAttestationPolicy policyResult = await adminclient.GetPolicyAsync(AttestationType.SgxEnclave);
            var result = policyResult.AttestationPolicy;

            var policyRaw = Base64Url.Decode(result);
            var policy = System.Text.Encoding.UTF8.GetString(policyRaw);

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
            AttestationToken policyResetToken;

            if (isSecuredToken)
            {
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

                policyResetToken = new SecuredAttestationToken(rsaKey, x509Certificate);
            }
            else
            {
                policyResetToken = new UnsecuredAttestationToken();
            }

            var policySetResult = await adminClient.ResetPolicyAsync(AttestationType.OpenEnclave, policyResetToken);
            Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
            Assert.AreEqual(PolicyModification.Removed, policySetResult.Value.PolicyResolution);
        }

        [RecordedTest]
        public async Task SetPolicyUnsecuredAad()
        {
            var adminclient = GetAadAdministrationClient();

            // Reset the current attestation policy to a known state. Necessary if there were previous runs that failed.
            await ResetAttestationPolicy(adminclient, AttestationType.OpenEnclave, false, false);

            string originalPolicy;
            {
                var policyResult = await adminclient.GetPolicyAsync(AttestationType.OpenEnclave);
                var result = policyResult.Value.AttestationPolicy;

                var policyRaw = Base64Url.Decode(result);
                originalPolicy = System.Text.Encoding.UTF8.GetString(policyRaw);
            }

            byte[] disallowDebuggingHash;
            {
                var policySetToken = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = Base64Url.EncodeString(disallowDebugging) });

                var policySetResult = await adminclient.SetPolicyAsync(AttestationType.OpenEnclave, policySetToken);

                var shaHasher = SHA256Managed.Create();
                disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));

                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Updated, policySetResult.Value.PolicyResolution);
                CollectionAssert.AreEqual(disallowDebuggingHash, policySetResult.Value.PolicyTokenHash);
            }

            {
                var policyResult = await adminclient.GetPolicyAsync(AttestationType.OpenEnclave);
                var result = policyResult.Value.AttestationPolicy;

                var policyRaw = Base64Url.Decode(result);
                var policy = System.Text.Encoding.UTF8.GetString(policyRaw);

                Assert.AreEqual(disallowDebugging, policy);
            }
            {
                var policyResetToken = new UnsecuredAttestationToken();

                var policySetResult = await adminclient.ResetPolicyAsync(AttestationType.OpenEnclave, policyResetToken);
                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Removed, policySetResult.Value.PolicyResolution);
            }

            {
                var policyResult = await adminclient.GetPolicyAsync(AttestationType.OpenEnclave);
                var result = policyResult.Value.AttestationPolicy;

                var policyRaw = Base64Url.Decode(result);
                var policy = System.Text.Encoding.UTF8.GetString(policyRaw);

                // And when we're done, policy should be reset to the original value.
                Assert.AreEqual(originalPolicy, policy);
            }
        }

        [RecordedTest]
        public async Task SetPolicyUnsecuredIsolated()
        {
            var adminclient = GetIsolatedAdministrationClient();

            byte[] disallowDebuggingHash;
            {
                var policySetToken = new UnsecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = Base64Url.EncodeString(disallowDebugging) });

                var shaHasher = SHA256Managed.Create();
                disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));

                var error = Assert.ThrowsAsync<Azure.RequestFailedException>(async () => await adminclient.SetPolicyAsync(AttestationType.OpenEnclave, policySetToken));
                Assert.AreEqual(400, error.Status);
                await Task.Yield();
            }
        }

        public async Task SetPolicySecured(AttestationAdministrationClient adminClient, bool isIsolated)
        {
            // Reset the current attestation policy to a known state. Necessary if there were previous runs that failed.
            await ResetAttestationPolicy(adminClient, AttestationType.OpenEnclave, true, isIsolated);

            string originalPolicy;
            {
                var policyResult = await adminClient.GetPolicyAsync(AttestationType.OpenEnclave);
                var result = policyResult.Value.AttestationPolicy;

                var policyRaw = Base64Url.Decode(result);
                originalPolicy = System.Text.Encoding.UTF8.GetString(policyRaw);
            }

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
                var policySetToken = new SecuredAttestationToken(new StoredAttestationPolicy { AttestationPolicy = Base64Url.EncodeString(disallowDebugging) }, rsaKey, x509Certificate);

                var policySetResult = await adminClient.SetPolicyAsync(AttestationType.OpenEnclave, policySetToken);

                var shaHasher = SHA256Managed.Create();
                disallowDebuggingHash = shaHasher.ComputeHash(Encoding.UTF8.GetBytes(policySetToken.ToString()));

                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Updated, policySetResult.Value.PolicyResolution);
                CollectionAssert.AreEqual(disallowDebuggingHash, policySetResult.Value.PolicyTokenHash);
                Assert.AreEqual(x509Certificate, policySetResult.Value.PolicySigner.SigningCertificates[0]);
            }

            {
                var policyResult = await adminClient.GetPolicyAsync(AttestationType.OpenEnclave);
                var result = policyResult.Value.AttestationPolicy;

                var policyRaw = Base64Url.Decode(result);
                var policy = System.Text.Encoding.UTF8.GetString(policyRaw);

                Assert.AreEqual(disallowDebugging, policy);
            }
            {
                var policyResetToken = new SecuredAttestationToken(rsaKey, x509Certificate);

                var policySetResult = await adminClient.ResetPolicyAsync(AttestationType.OpenEnclave, policyResetToken);
                Assert.AreEqual(200, policySetResult.GetRawResponse().Status);
                Assert.AreEqual(PolicyModification.Removed, policySetResult.Value.PolicyResolution);
            }

            {
                var policyResult = await adminClient.GetPolicyAsync(AttestationType.OpenEnclave);
                var result = policyResult.Value.AttestationPolicy;

                var policyRaw = Base64Url.Decode(result);
                var policy = System.Text.Encoding.UTF8.GetString(policyRaw);

                // And when we're done, policy should be reset to the original value.
                Assert.AreEqual(originalPolicy, policy);
            }
        }

        [RecordedTest]
        public async Task SetPolicySecuredAad()
        {
            var adminclient = GetAadAdministrationClient();

            await SetPolicySecured(adminclient, false);
        }

        [RecordedTest]
        public async Task SetPolicySecuredIsolated()
        {
            var adminclient = GetIsolatedAdministrationClient();

            await SetPolicySecured(adminclient, true);
        }

        [RecordedTest]
        public async Task GetPolicyManagementCertificatesIsolated()
        {
            var adminclient = GetIsolatedAdministrationClient();
            {
                var certificateResult = await adminclient.GetPolicyManagementCertificatesAsync();
                Assert.AreNotEqual(0, certificateResult.Value.GetPolicyCertificates().Count);

                bool foundInitialRoot = false;
                foreach (var cert in certificateResult.Value.GetPolicyCertificates())
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
            var adminclient = GetSharedAdministrationClient();
            {
                var certificateResult = await adminclient.GetPolicyManagementCertificatesAsync();
                Assert.AreEqual(0, certificateResult.Value.GetPolicyCertificates().Count);
            }
        }

        [RecordedTest]
        public async Task AddRemovePolicyManagementCertificate()
        {
            var adminClient = GetIsolatedAdministrationClient();

            var x509Certificate = TestEnvironment.PolicyManagementCertificate;
            var rsaKey = TestEnvironment.PolicyManagementKey;
            {
                PolicyCertificateModification modification = new Models.PolicyCertificateModification(TestEnvironment.PolicyCertificate2);
                var policySetToken = new SecuredAttestationToken(modification, rsaKey, x509Certificate);

                var modificationResult = await adminClient.AddPolicyManagementCertificateAsync(policySetToken);
                Assert.AreEqual(CertificateModification.IsPresent, modificationResult.Value.CertificateResolution);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.Value.CertificateThumbprint);

                // Verify that the certificate we got back was in fact added.
                var certificateResult = await adminClient.GetPolicyManagementCertificatesAsync();
                bool foundAddedCertificate = false;
                foreach (var cert in certificateResult.Value.GetPolicyCertificates())
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
                PolicyCertificateModification modification = new Models.PolicyCertificateModification(TestEnvironment.PolicyCertificate2);
                var policySetToken = new SecuredAttestationToken(modification, rsaKey, x509Certificate);

                var modificationResult = await adminClient.AddPolicyManagementCertificateAsync(policySetToken);
                Assert.AreEqual(CertificateModification.IsPresent, modificationResult.Value.CertificateResolution);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.Value.CertificateThumbprint);

                // Verify that the certificate we got back was in fact added.
                var certificateResult = await adminClient.GetPolicyManagementCertificatesAsync();
                bool foundAddedCertificate = false;
                foreach (var cert in certificateResult.Value.GetPolicyCertificates())
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
                PolicyCertificateModification modification = new Models.PolicyCertificateModification(TestEnvironment.PolicyCertificate2);
                var policySetToken = new SecuredAttestationToken(modification, rsaKey, x509Certificate);

                var modificationResult = await adminClient.RemovePolicyManagementCertificateAsync(policySetToken);
                Assert.AreEqual(CertificateModification.IsAbsent, modificationResult.Value.CertificateResolution);
                Assert.AreEqual(TestEnvironment.PolicyCertificate2.Thumbprint, modificationResult.Value.CertificateThumbprint);

                // Verify that the certificate we got back was in fact added.
                var certificateResult = await adminClient.GetPolicyManagementCertificatesAsync();
                bool foundAddedCertificate = false;
                foreach (var cert in certificateResult.Value.GetPolicyCertificates())
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

        private AttestationAdministrationClient GetSharedAdministrationClient()
        {
            string endpoint = TestEnvironment.SharedUkSouth;
            var options = InstrumentClientOptions(new AttestationClientOptions());
            return InstrumentClient(new AttestationAdministrationClient(new Uri(endpoint), TestEnvironment.GetClientSecretCredential(), options));
        }

        private AttestationAdministrationClient GetAadAdministrationClient()
        {
            string endpoint = TestEnvironment.AadAttestationUrl;

            var options = InstrumentClientOptions(new AttestationClientOptions());
            return InstrumentClient(new AttestationAdministrationClient(new Uri(endpoint), TestEnvironment.GetClientSecretCredential(), options));
        }

        private AttestationAdministrationClient GetIsolatedAdministrationClient()
        {
            string endpoint = TestEnvironment.IsolatedAttestationUrl;

            var options = InstrumentClientOptions(new AttestationClientOptions());
            return InstrumentClient(new AttestationAdministrationClient(new Uri(endpoint), TestEnvironment.GetClientSecretCredential(), options));
        }
    }
}
