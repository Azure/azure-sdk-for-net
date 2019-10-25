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
    /// Sample demonstrates how to list keys and versions of a given key,
    /// and list deleted keys in a soft-delete enabled Key Vault
    /// using the synchronous methods of the KeyClient.
    /// </summary>
    [LiveOnly]
    public partial class GetCertificates
    {
        [Test]
        public void GetCertificatesSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            // Instantiate a certificate client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create two self-signed certificates using the default policy
            string certName1 = $"defaultCert-{Guid.NewGuid()}";

            CertificateOperation certOp1 = client.StartCreateCertificate(certName1);

            string certName2 = $"defaultCert-{Guid.NewGuid()}";

            CertificateOperation certOp2 = client.StartCreateCertificate(certName1);

            // Next let's wait on the certificate operation to complete. Note that certificate creation can last an indeterministic
            // amount of time, so applications should only wait on the operation to complete in the case the issuance time is well
            // known and within the scope of the application lifetime. In this case we are creating a self-signed certificate which
            // should be issued in a relatively short amount of time.
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

            // Let's list the certificates which exist in the vault along with their thumbprints
            foreach (CertificateProperties cert in client.GetCertificates())
            {
                Debug.WriteLine($"Certificate is returned with name {cert.Name} and thumbprint {BitConverter.ToString(cert.X509Thumbprint)}");
            }

            // We need to create a new version of a certificate. Creating a certificate with the same name will create another version of the certificate
            CertificateOperation newCertOp = client.StartCreateCertificate(certName1);

            while (!newCertOp.HasCompleted)
            {
                newCertOp.UpdateStatus();

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            // Let's print all the versions of this certificate
            foreach (CertificateProperties cert in client.GetCertificateVersions(certName1))
            {
                Debug.WriteLine($"Certificate {cert.Name} with name {cert.Version}");
            }

            // The certificates are no longer needed.
            // You need to delete them from the Key Vault.
            client.DeleteCertificate(certName1);
            client.DeleteCertificate(certName2);

            // To ensure certificates are deleted on server side.
            Assert.IsTrue(WaitForDeletedCertificate(client, certName1));
            Assert.IsTrue(WaitForDeletedCertificate(client, certName2));

            // You can list all the deleted and non-purged certificates, assuming Key Vault is soft-delete enabled.
            foreach (DeletedCertificate deletedCert in client.GetDeletedCertificates())
            {
                Debug.WriteLine($"Deleted certificate's recovery Id {deletedCert.RecoveryId}");
            }

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
