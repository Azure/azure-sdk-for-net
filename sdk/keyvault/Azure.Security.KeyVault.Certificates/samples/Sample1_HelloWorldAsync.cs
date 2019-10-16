// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    /// <summary>
    /// Sample demonstrates how to set, get, update and delete a key using the asynchronous methods of the KeyClient.
    /// </summary>
    [LiveOnly]
    public partial class HelloWorld
    {
        [Test]
        public async Task HelloWorldAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            // Instantiate a certificate client that will be used to call the service. Notice that the client is using
            // default Azure credentials. To make default credentials work, ensure that environment variables 'AZURE_CLIENT_ID',
            // 'AZURE_CLIENT_KEY' and 'AZURE_TENANT_ID' are set with the service principal credentials.
            var client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            // Let's create a self signed certifiate using the default policy. If the certificiate
            // already exists in the Key Vault, then a new version of the key is created.
            string certName = $"defaultCert-{Guid.NewGuid()}";

            CertificateOperation certOp = await client.StartCreateCertificateAsync(certName);

            // Next let's wait on the certificate operation to complete. Note that certificate creation can last an indeterministic
            // amount of time, so applications should only wait on the operation to complete in the case the issuance time is well
            // known and within the scope of the application lifetime. In this case we are creating a self-signed certificate which
            // should be issued in a relatively short amount of time.
            CertificateWithPolicy certificate = await certOp.WaitForCompletionAsync();

            // At some time later we could get the created certificate along with it's policy from the Key Vault.
            certificate = await client.GetCertificateAsync(certName);

            Debug.WriteLine($"Certificate was returned with name {certificate.Name} which expires {certificate.Properties.Expires}");

            // We find that the certificate has been compromised and we want to disable it so applications will no longer be able
            // to access the compromised version of the certificate.
            CertificateProperties certificateProperties = certificate.Properties;
            certificateProperties.Enabled = false;

            Certificate updatedCert = await client.UpdateCertificatePropertiesAsync(certificateProperties);

            Debug.WriteLine($"Certificate enabled set to '{updatedCert.Properties.Enabled}'");

            // We need to create a new version of the certificate that applications can use to replace the compromised certificate.
            // Creating a certificate with the same name and policy as the compromised certificate will create another version of the
            // certificate with similar properties to the original certificate
            CertificateOperation newCertOp = await client.StartCreateCertificateAsync(certificate.Name, certificate.Policy);

            CertificateWithPolicy newCert = await newCertOp.WaitForCompletionAsync();

            // The certificate is no longer needed, need to delete it from the Key Vault.
            await client.DeleteCertificateAsync(certName);

            // To ensure key is deleted on server side.
            Assert.IsTrue(await WaitForDeletedKeyAsync(client, certName));

            // If the keyvault is soft-delete enabled, then for permanent deletion, deleted key needs to be purged.
            await client.PurgeDeletedCertificateAsync(certName);
        }

        private async Task<bool> WaitForDeletedKeyAsync(CertificateClient client, string certName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    await client.GetDeletedCertificateAsync(certName);
                    return true;
                }
                catch
                {
                    await Task.Delay(5000);
                }
            }
            return false;
        }
    }
}
