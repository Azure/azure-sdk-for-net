// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    // Argument-validation parity for CertificateClient's public surface. The
    // existing CertificateClientTests.cs (which we do NOT modify) already
    // pins the most common name/argument cases; this file only covers the
    // gaps - so the union of both files is a complete validation matrix for
    // the post-Phase 2 rewire.
    public class CertificateClientArgumentValidationTests
    {
        private static readonly Uri TestVault = new Uri("https://example.vault.azure.net");

        private static CertificateClient NewClient()
            => new CertificateClient(TestVault, new MockCredential(), new CertificateClientOptions
            {
                Transport = new MockTransport(),
            });

        // ----- StartCreateCertificate -----

        [Test]
        public void StartCreateCertificate_NullName_Throws()
        {
            var client = NewClient();
            var policy = CertificatePolicy.Default;
            Assert.Throws<ArgumentNullException>(
                () => client.StartCreateCertificate(null, policy));
            Assert.ThrowsAsync<ArgumentNullException>(
                () => client.StartCreateCertificateAsync(null, policy));
        }

        [Test]
        public void StartCreateCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            var policy = CertificatePolicy.Default;
            Assert.Throws<ArgumentException>(
                () => client.StartCreateCertificate(string.Empty, policy));
            Assert.ThrowsAsync<ArgumentException>(
                () => client.StartCreateCertificateAsync(string.Empty, policy));
        }

        [Test]
        public void StartCreateCertificate_NullPolicy_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(
                () => client.StartCreateCertificate("name", null));
            Assert.ThrowsAsync<ArgumentNullException>(
                () => client.StartCreateCertificateAsync("name", null));
        }

        // ----- GetCertificate / GetCertificateVersion -----

        [Test]
        public void GetCertificate_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.GetCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCertificateAsync(null));
        }

        [Test]
        public void GetCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.GetCertificate(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCertificateAsync(string.Empty));
        }

        [Test]
        public void GetCertificateVersion_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.GetCertificateVersion(null, "v"));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCertificateVersionAsync(null, "v"));
        }

        [Test]
        public void GetCertificateVersion_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.GetCertificateVersion(string.Empty, "v"));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCertificateVersionAsync(string.Empty, "v"));
        }

        // ----- UpdateCertificateProperties -----

        [Test]
        public void UpdateCertificateProperties_NullProperties_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.UpdateCertificateProperties(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.UpdateCertificatePropertiesAsync(null));
        }

        // ----- StartDeleteCertificate / GetDeletedCertificate / StartRecoverDeletedCertificate -----

        [Test]
        public void StartDeleteCertificate_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.StartDeleteCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartDeleteCertificateAsync(null));
        }

        [Test]
        public void StartDeleteCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.StartDeleteCertificate(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.StartDeleteCertificateAsync(string.Empty));
        }

        [Test]
        public void GetDeletedCertificate_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.GetDeletedCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetDeletedCertificateAsync(null));
        }

        [Test]
        public void GetDeletedCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.GetDeletedCertificate(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetDeletedCertificateAsync(string.Empty));
        }

        [Test]
        public void StartRecoverDeletedCertificate_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.StartRecoverDeletedCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.StartRecoverDeletedCertificateAsync(null));
        }

        [Test]
        public void StartRecoverDeletedCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.StartRecoverDeletedCertificate(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.StartRecoverDeletedCertificateAsync(string.Empty));
        }

        // ----- PurgeDeletedCertificate -----

        [Test]
        public void PurgeDeletedCertificate_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.PurgeDeletedCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.PurgeDeletedCertificateAsync(null));
        }

        [Test]
        public void PurgeDeletedCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.PurgeDeletedCertificate(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.PurgeDeletedCertificateAsync(string.Empty));
        }

        // ----- BackupCertificate / RestoreCertificateBackup -----

        [Test]
        public void BackupCertificate_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.BackupCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.BackupCertificateAsync(null));
        }

        [Test]
        public void BackupCertificate_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.BackupCertificate(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.BackupCertificateAsync(string.Empty));
        }

        [Test]
        public void RestoreCertificateBackup_NullBackup_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.RestoreCertificateBackup(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.RestoreCertificateBackupAsync(null));
        }

        // ----- ImportCertificate -----

        [Test]
        public void ImportCertificate_NullOptions_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.ImportCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.ImportCertificateAsync(null));
        }

        // ----- MergeCertificate -----

        [Test]
        public void MergeCertificate_NullOptions_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.MergeCertificate(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.MergeCertificateAsync(null));
        }

        // ----- GetPropertiesOfCertificateVersions -----

        [Test]
        public void GetPropertiesOfCertificateVersions_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.GetPropertiesOfCertificateVersions(null));
            Assert.Throws<ArgumentNullException>(() => client.GetPropertiesOfCertificateVersionsAsync(null));
        }

        [Test]
        public void GetPropertiesOfCertificateVersions_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.GetPropertiesOfCertificateVersions(string.Empty));
            Assert.Throws<ArgumentException>(() => client.GetPropertiesOfCertificateVersionsAsync(string.Empty));
        }

        // ----- GetCertificateOperation -----

        [Test]
        public void GetCertificateOperation_NullName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentNullException>(() => client.GetCertificateOperation(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => client.GetCertificateOperationAsync(null));
        }

        [Test]
        public void GetCertificateOperation_EmptyName_Throws()
        {
            var client = NewClient();
            Assert.Throws<ArgumentException>(() => client.GetCertificateOperation(string.Empty));
            Assert.ThrowsAsync<ArgumentException>(() => client.GetCertificateOperationAsync(string.Empty));
        }
    }
}
