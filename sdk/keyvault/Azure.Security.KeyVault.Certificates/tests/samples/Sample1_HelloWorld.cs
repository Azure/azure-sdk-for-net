// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    /// <summary>
    /// This sample demonstrates how to create, get, update, and delete a certificate using the synchronous methods of the <see cref="CertificateClient">.
    /// </summary>
    public partial class HelloWorld
    {
        [Test]
        public void HelloWorldSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:CertificatesSample1CertificateClient
            var client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:CertificatesSample1CreateCertificate
            string certName = $"defaultCert-{Guid.NewGuid()}";
            CertificateOperation certOp = client.StartCreateCertificate(certName, CertificatePolicy.Default);

            while (!certOp.HasCompleted)
            {
                certOp.UpdateStatus();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            #endregion

            #region Snippet:CertificatesSample1GetCertificateWithPolicy
            KeyVaultCertificateWithPolicy certificate = client.GetCertificate(certName);

            Debug.WriteLine($"Certificate was returned with name {certificate.Name} which expires {certificate.Properties.ExpiresOn}");
            #endregion

            #region Snippet:CertificatesSample1UpdateCertificate
            CertificateProperties certificateProperties = certificate.Properties;
            certificateProperties.Enabled = false;

            KeyVaultCertificate updatedCert = client.UpdateCertificateProperties(certificateProperties);
            Debug.WriteLine($"Certificate enabled set to '{updatedCert.Properties.Enabled}'");
            #endregion

            #region Snippet:CertificatesSample1CreateCertificateWithNewVersion
            CertificateOperation newCertOp = client.StartCreateCertificate(certificate.Name, certificate.Policy);

            while (!newCertOp.HasCompleted)
            {
                newCertOp.UpdateStatus();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            #endregion

            #region Snippet:CertificatesSample1DeleteCertificate
            DeleteCertificateOperation operation = client.StartDeleteCertificate(certName);

            // You only need to wait for completion if you want to purge or recover the certificate.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }
            #endregion

            // If the keyvault is soft-delete enabled, then for permanent deletion, the deleted certificate needs to be purged.
            client.PurgeDeletedCertificate(certName);
        }
    }
}
