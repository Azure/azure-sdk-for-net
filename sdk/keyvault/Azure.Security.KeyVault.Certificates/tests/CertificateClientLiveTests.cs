// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Diagnostics;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientLiveTests : CertificatesTestBase
    {
        public CertificateClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void StartCreateCertificateError()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = new CertificatePolicy("invalid", "Self")
            {
                KeyUsage =
                {
                    "invalid",
                },
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => Client.StartCreateCertificateAsync(certName, certificatePolicy));
            Assert.AreEqual(400, ex.Status);
        }

        [Test]
        public async Task VerifyGetCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            CertificateOperation getOperation = await Client.GetCertificateOperationAsync(certName);

            Assert.IsNotNull(getOperation);
        }

        [Test]
        public async Task VerifyCancelCertificateOperation()
        {
            // Log details why this fails often for live tests on net461.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);

            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            try
            {
                await operation.CancelAsync();
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                Assert.Inconclusive("The create operation completed before it could be canceled.");
            }

            OperationCanceledException ex = Assert.ThrowsAsync<OperationCanceledException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was canceled so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyUnexpectedCancelCertificateOperation()
        {
            // Log details why this fails often for live tests on net461.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);

            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            try
            {
                // Calling through the CertificateClient directly won't affect the CertificateOperation, so subsequent status updates should throw.
                await Client.CancelCertificateOperationAsync(certName);
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                Assert.Inconclusive("The create operation completed before it could be canceled.");
            }

            OperationCanceledException ex = Assert.ThrowsAsync<OperationCanceledException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was canceled so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyDeleteCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            await operation.DeleteAsync();

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was deleted so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(404, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyUnexpectedDeleteCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            try
            {
                // Calling through the CertificateClient directly won't affect the CertificateOperation, so subsequent status updates should throw.
                await Client.DeleteCertificateOperationAsync(certName);
            }
            catch (RequestFailedException e) when (e.Status == 403)
            {
                Assert.Inconclusive("The create operation completed before it could be canceled.");
            }

            InvalidOperationException ex = Assert.ThrowsAsync<InvalidOperationException>(() => WaitForCompletion(operation));
            Assert.AreEqual("The operation was deleted so no value is available.", ex.Message);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(404, operation.GetRawResponse().Status);
        }

        [Test]
        public async Task VerifyCertificateOperationError()
        {
            string issuerName = Recording.GenerateId();
            string certName = Recording.GenerateId();

            CertificateIssuer certIssuer = new CertificateIssuer(issuerName, "DigiCert")
            {
                AccountId = "test",
                Password = "test",
                OrganizationId = "test",
            };

            await Client.CreateIssuerAsync(certIssuer);

            CertificateOperation operation = null;
            try
            {
                CertificatePolicy certificatePolicy = DefaultPolicy;
                certificatePolicy.IssuerName = issuerName;

                operation = await Client.StartCreateCertificateAsync(certName, certificatePolicy);

                RegisterForCleanup(certName);

                using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
                TimeSpan pollingInterval = TimeSpan.FromSeconds((Mode == RecordedTestMode.Playback) ? 0 : 1);

                while (!operation.HasCompleted)
                {
                    await Task.Delay(pollingInterval, cts.Token);
                    await operation.UpdateStatusAsync(cts.Token);
                }

                InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => { KeyVaultCertificateWithPolicy cert = operation.Value; });
                StringAssert.StartsWith("The certificate operation failed: ", ex.Message);

                Assert.IsTrue(operation.HasCompleted);
                Assert.IsFalse(operation.HasValue);
                Assert.AreEqual(200, operation.GetRawResponse().Status);
                Assert.AreEqual("failed", operation.Properties.Status);
            }
            catch (TaskCanceledException) when (operation != null)
            {
                Assert.Inconclusive("Timed out while waiting for operation {0}", operation.Id);
            }
            finally
            {
                await Client.DeleteIssuerAsync(issuerName);
            }
        }

        [Test]
        public async Task VerifyCertificateGetWithPolicyInProgress()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = DefaultPolicy;
            certificatePolicy.IssuerName = WellKnownIssuerNames.Unknown;

            await Client.StartCreateCertificateAsync(certName, certificatePolicy);

            RegisterForCleanup(certName);

            KeyVaultCertificateWithPolicy certificateWithPolicy = await Client.GetCertificateAsync(certName);

            Assert.NotNull(certificateWithPolicy);

            Assert.AreEqual(certificateWithPolicy.Name, certName);

            Assert.NotNull(certificateWithPolicy.Properties.Version);

            KeyVaultCertificate certificate = await Client.GetCertificateVersionAsync(certName, certificateWithPolicy.Properties.Version);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);
        }

        [Test]
        public async Task VerifyGetCertificateCompleted()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            RegisterForCleanup(certName);

            await WaitForCompletion(operation);

            KeyVaultCertificateWithPolicy certificateWithPolicy = await Client.GetCertificateAsync(certName);

            Assert.NotNull(certificateWithPolicy);

            Assert.AreEqual(certificateWithPolicy.Name, certName);

            Assert.NotNull(certificateWithPolicy.Properties.Version);

            KeyVaultCertificate certificate = await Client.GetCertificateVersionAsync(certName, certificateWithPolicy.Properties.Version);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);

        }

        [Test]
        public async Task VerifyGetCertificateCompletedSubsequently()
        {
            string certName = Recording.GenerateId();

            await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            RegisterForCleanup(certName);

            // Pretend a separate process was started subsequently and we need to get the operation again.
            CertificateOperation operation = new CertificateOperation(Client, certName);

            // Need to call the real async wait method or the sync version of this test fails because it's using the instrumented Client directly.
            using CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));
            TimeSpan pollingInterval = TimeSpan.FromSeconds((Mode == RecordedTestMode.Playback) ? 0 : 1);

            await operation.WaitForCompletionAsync(pollingInterval, cts.Token);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            KeyVaultCertificateWithPolicy certificateWithPolicy = operation.Value;

            Assert.NotNull(certificateWithPolicy);
            Assert.AreEqual(certName, certificateWithPolicy.Name);
            Assert.NotNull(certificateWithPolicy.Properties.Version);
        }

        [Test]
        public async Task VerifyUpdateCertificate()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            RegisterForCleanup(certName);

            KeyVaultCertificateWithPolicy original = await WaitForCompletion(operation);
            CertificateProperties originalProperties = original.Properties;
            Assert.IsTrue(originalProperties.Enabled);
            Assert.IsEmpty(originalProperties.Tags);

            IDictionary<string, string> expTags = new Dictionary<string, string>() { { "key1", "value1" } };
            originalProperties.Tags.Add("key1", "value1");

            KeyVaultCertificate updated = await Client.UpdateCertificatePropertiesAsync(originalProperties);
            Assert.IsTrue(updated.Properties.Enabled);
            CollectionAssert.AreEqual(expTags, updated.Properties.Tags);

            originalProperties.Enabled = false;
            originalProperties.Tags.Clear();
            updated = await Client.UpdateCertificatePropertiesAsync(originalProperties);
            Assert.IsFalse(updated.Properties.Enabled);
            CollectionAssert.AreEqual(expTags, updated.Properties.Tags);
        }

        [Test]
        public async Task VerifyDeleteRecoverPurge()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName, DefaultPolicy);

            KeyVaultCertificateWithPolicy original = await WaitForCompletion(operation);

            Assert.NotNull(original);

            DeleteCertificateOperation deleteOperation = await Client.StartDeleteCertificateAsync(certName);
            DeletedCertificate deletedCert = deleteOperation.Value;

            Assert.IsNotNull(deletedCert);

            Assert.IsNotNull(deletedCert.RecoveryId);

            await WaitForDeletedCertificate(certName);

            _ = await Client.StartRecoverDeletedCertificateAsync(certName);

            Assert.NotNull(original);

            await PollForCertificate(certName);

            deleteOperation = await Client.StartDeleteCertificateAsync(certName);
            deletedCert = deleteOperation.Value;

            Assert.IsNotNull(deletedCert);

            Assert.IsNotNull(deletedCert.RecoveryId);

            await WaitForDeletedCertificate(certName);

            await Client.PurgeDeletedCertificateAsync(certName);

            await WaitForPurgedCertificate(certName);
        }

        // ImportPem
        // ImportPfx
        // Backup Restore
        // GetCertificates
        // GetCertificatsIncludePending
        // GetCertificateVersions
        // GetDeletedCertificates
        // GetUpdatePolicy
        // IssuerCrud
        // ContactsCrud

        private static CertificatePolicy DefaultPolicy => new CertificatePolicy
        {
            IssuerName = WellKnownIssuerNames.Self,
            Subject = "CN=default",
            KeyType = CertificateKeyType.Rsa,
            Exportable = true,
            ReuseKey = false,
            KeyUsage =
            {
                CertificateKeyUsage.CrlSign,
                CertificateKeyUsage.DataEncipherment,
                CertificateKeyUsage.DigitalSignature,
                CertificateKeyUsage.KeyEncipherment,
                CertificateKeyUsage.KeyAgreement,
                CertificateKeyUsage.KeyCertSign,
            },
            CertificateTransparency = false,
            ContentType = CertificateContentType.Pkcs12
        };
    }
}
