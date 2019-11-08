// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    /// <summary>
    /// Sample demonstrates how to list certificates and versions of a given certificates,
    /// and list deleted certificates in a soft delete-enabled key vault
    /// using the synchronous methods of the CertificateClient.
    /// </summary>
    [LiveOnly]
    public partial class GetCertificates
    {
        [Test]
        public void GetCertificatesSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");
            GetCertificatesSync(keyVaultUrl);
        }

        private void GetCertificatesSync(string keyVaultUrl)
        {
            #region Snippet:CertificatesSample2CertificateClient
            var client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:CertificatesSample2CreateCertificate
            string certName1 = $"defaultCert-{Guid.NewGuid()}";
            CertificateOperation certOp1 = client.StartCreateCertificate(certName1, CertificatePolicy.Default);

            string certName2 = $"defaultCert-{Guid.NewGuid()}";
            CertificateOperation certOp2 = client.StartCreateCertificate(certName1, CertificatePolicy.Default);

            while (!certOp1.HasCompleted)
            {
                certOp1.UpdateStatus();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            while (!certOp2.HasCompleted)
            {
                certOp2.UpdateStatus();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            #endregion

            #region Snippet:CertificatesSample2ListCertificates
            foreach (CertificateProperties cert in client.GetPropertiesOfCertificates())
            {
                Debug.WriteLine($"Certificate is returned with name {cert.Name} and thumbprint {BitConverter.ToString(cert.X509Thumbprint)}");
            }
            #endregion

            #region Snippet:CertificatesSample2CreateCertificateWithNewVersion
            CertificateOperation newCertOp = client.StartCreateCertificate(certName1, CertificatePolicy.Default);

            while (!newCertOp.HasCompleted)
            {
                newCertOp.UpdateStatus();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            #endregion

            #region Snippet:CertificatesSample2ListCertificateVersions
            foreach (CertificateProperties cert in client.GetPropertiesOfCertificateVersions(certName1))
            {
                Debug.WriteLine($"Certificate {cert.Name} with name {cert.Version}");
            }
            #endregion

            #region Snippet:CertificatesSample2DeleteCertificates
            client.DeleteCertificate(certName1);
            client.DeleteCertificate(certName2);
            #endregion

            Assert.IsTrue(WaitForDeletedCertificate(client, certName1));
            Assert.IsTrue(WaitForDeletedCertificate(client, certName2));

            #region Snippet:CertificatesSample2ListDeletedCertificates
            foreach (DeletedCertificate deletedCert in client.GetDeletedCertificates())
            {
                Debug.WriteLine($"Deleted certificate's recovery Id {deletedCert.RecoveryId}");
            }
            #endregion

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            client.PurgeDeletedCertificate(certName1);
            client.PurgeDeletedCertificate(certName2);
        }

        private bool WaitForDeletedCertificate(CertificateClient client, string certName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    client.GetDeletedCertificate(certName);
                    return true;
                }
                catch
                {
                    Thread.Sleep(2000);
                }
            }
            return false;
        }
    }
}
