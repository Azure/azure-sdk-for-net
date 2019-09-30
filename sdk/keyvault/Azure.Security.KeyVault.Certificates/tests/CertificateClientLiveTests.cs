// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificateClientLiveTests : CertificatesTestBase
    {
        public CertificateClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task VerifyCertificateCreateDefaultPolicy()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            CertificateWithPolicy certificate = await WaitForCompletion(operation);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);
        }


        [Test]
        public async Task VerifyGetCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = Client.CreateDefaultPolicy();

            certificatePolicy.IssuerName = "UNKNOWN";

            await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            CertificateOperation getOperation = await Client.GetCertificateOperationAsync(certName);

            Assert.IsNotNull(getOperation);
        }

        [Test]
        public async Task VerifyCancelCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = Client.CreateDefaultPolicy();

            certificatePolicy.IssuerName = "UNKNOWN";

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            await Client.CancelCertificateOperationAsync(certName);

            Assert.ThrowsAsync<OperationCanceledException>(() => WaitForCompletion(operation));
        }

        [Test]
        public async Task VerifyDeleteCertificateOperation()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = Client.CreateDefaultPolicy();

            certificatePolicy.IssuerName = "UNKNOWN";

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            await Client.DeleteCertificateOperationAsync(certName);

            Assert.ThrowsAsync<RequestFailedException>(() => WaitForCompletion(operation));
        }

        [Test]
        public async Task VerifyCertificateGetWithPolicyInProgress()
        {
            string certName = Recording.GenerateId();

            CertificatePolicy certificatePolicy = Client.CreateDefaultPolicy();

            certificatePolicy.IssuerName = "UNKNOWN";

            await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            CertificateWithPolicy certificateWithPolicy = await Client.GetCertificateWithPolicyAsync(certName);

            Assert.NotNull(certificateWithPolicy);

            Assert.AreEqual(certificateWithPolicy.Name, certName);

            Assert.NotNull(certificateWithPolicy.Version);

            Certificate certificate = await Client.GetCertificateAsync(certName, certificateWithPolicy.Version);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);
        }

        [Test]
        public async Task VerifyGetCertificateCompleted()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            await WaitForCompletion(operation);

            CertificateWithPolicy certificateWithPolicy = await Client.GetCertificateWithPolicyAsync(certName);

            Assert.NotNull(certificateWithPolicy);

            Assert.AreEqual(certificateWithPolicy.Name, certName);

            Assert.NotNull(certificateWithPolicy.Version);

            Certificate certificate = await Client.GetCertificateAsync(certName, certificateWithPolicy.Version);

            Assert.NotNull(certificate);

            Assert.AreEqual(certificate.Name, certName);

        }

        [Test]
        public async Task VerifyUpdateCertificate()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName);

            RegisterForCleanup(certName);

            CertificateWithPolicy original = await WaitForCompletion(operation);

            IDictionary<string, string> expTags = new Dictionary<string, string>() { { "key1", "value1" } };

            Certificate updated = await Client.UpdateCertificateAsync(certName, original.Version, tags: expTags);

            Assert.IsEmpty(original.Properties.Tags);

            CollectionAssert.AreEqual(expTags, updated.Properties.Tags);

            updated = await Client.UpdateCertificateAsync(certName, original.Version, enabled: false);

            Assert.IsFalse(updated.Properties.Enabled);
        }

        [Test]
        public async Task VerifyDeleteRecoverPurge()
        {
            string certName = Recording.GenerateId();

            CertificateOperation operation = await Client.StartCreateCertificateAsync(certName);

            CertificateWithPolicy original = await WaitForCompletion(operation);

            Assert.NotNull(original);

            DeletedCertificate deletedCert = await Client.DeleteCertificateAsync(certName);

            Assert.IsNotNull(deletedCert);

            Assert.IsNotNull(deletedCert.RecoveryId);

            await WaitForDeletedCertificate(certName);

            _ = await Client.RecoverDeletedCertificateAsync(certName);

            Assert.NotNull(original);

            await PollForCertificate(certName);

            deletedCert = await Client.DeleteCertificateAsync(certName);

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
    }
}
