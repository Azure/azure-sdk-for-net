// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    /// <summary>
    /// Sample demonstrates how to list certificates, versions of a given certificates,
    /// and list deleted certificates in a soft delete-enabled key vault
    /// using the synchronous methods of the CertificateClient.
    /// </summary>
    public partial class GetCertificates
    {
        [Test]
        public async Task GetCertificatesAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            // Instantiate a certificate client that will be used to call the service. Notice that the client is using default Azure
            // credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create two self-signed certificates using the default policy
            string certName1 = $"defaultCert-{Guid.NewGuid()}";

            CertificateOperation certOp1 = await client.StartCreateCertificateAsync(certName1, CertificatePolicy.Default);

            string certName2 = $"defaultCert-{Guid.NewGuid()}";

            CertificateOperation certOp2 = await client.StartCreateCertificateAsync(certName2, CertificatePolicy.Default);

            // Next, let's wait on the certificate operation to complete. Note that certificate creation can last an indeterministic
            // amount of time, so applications should only wait on the operation to complete in the case the issuance time is well
            // known and within the scope of the application lifetime. In this case we are creating a self-signed certificate which
            // should be issued in a relatively short amount of time.
            await certOp1.WaitForCompletionAsync();
            await certOp2.WaitForCompletionAsync();

            // Let's list the certificates which exist in the vault along with their thumbprints
            await foreach (CertificateProperties cert in client.GetPropertiesOfCertificatesAsync())
            {
                Debug.WriteLine($"Certificate is returned with name {cert.Name} and thumbprint {cert.X509ThumbprintString}");
            }

            // We need to create a new version of a certificate. Creating a certificate with the same name will create another version of the certificate
            CertificateOperation newCertOp = await client.StartCreateCertificateAsync(certName1, CertificatePolicy.Default);

            await newCertOp.WaitForCompletionAsync();

            // Let's print all the versions of this certificate
            await foreach (CertificateProperties cert in client.GetPropertiesOfCertificateVersionsAsync(certName1))
            {
                Debug.WriteLine($"Certificate {cert.Name} with name {cert.Version}");
            }

            // The certificates are no longer needed.
            // You need to delete them from the Key Vault.
            DeleteCertificateOperation operation1 = await client.StartDeleteCertificateAsync(certName1);
            DeleteCertificateOperation operation2 = await client.StartDeleteCertificateAsync(certName2);

            // You only need to wait for completion if you want to purge or recover the certificate.
            await Task.WhenAll(
                operation1.WaitForCompletionAsync().AsTask(),
                operation2.WaitForCompletionAsync().AsTask());

            // You can list all the deleted and non-purged certificates, assuming Key Vault is soft-delete enabled.
            await foreach (DeletedCertificate deletedCert in client.GetDeletedCertificatesAsync())
            {
                Debug.WriteLine($"Deleted certificate's recovery Id {deletedCert.RecoveryId}");
            }

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted keys needs to be purged.
            await Task.WhenAll(
                client.PurgeDeletedCertificateAsync(certName1),
                client.PurgeDeletedCertificateAsync(certName2));
        }
    }
}
