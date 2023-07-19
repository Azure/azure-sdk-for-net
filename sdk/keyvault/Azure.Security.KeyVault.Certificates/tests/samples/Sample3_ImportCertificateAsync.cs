// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Samples
{
    public partial class ImportCertificate
    {
        [Test]
        public async Task ImportPfxCertificateAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            string name = $"cert-{Guid.NewGuid()}";
#if SNIPPET
            byte[] pfx = File.ReadAllBytes("certificate.pfx");
#else
            byte[] pfx = Convert.FromBase64String(s_pfxBase64);
#endif
            ImportCertificateOptions importOptions = new ImportCertificateOptions(name, pfx)
            {
                Policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=contoso.com")
                {
                    // Required when setting a policy; if no policy required, Pfx is assumed.
                    ContentType = CertificateContentType.Pkcs12,

                    // Optionally mark the private key exportable.
                    Exportable = true
                }
            };

            await client.ImportCertificateAsync(importOptions);

            DeleteCertificateOperation operation = await client.StartDeleteCertificateAsync(name);

            // To ensure certificates are deleted on server side.
            // You only need to wait for completion if you want to purge or recover the certificate.
            await operation.WaitForCompletionAsync();

            client.PurgeDeletedCertificate(name);
        }

        [Test]
        public async Task ImportPemCertificateAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            CertificateClient client = new CertificateClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            string name = $"cert-{Guid.NewGuid()}";
#if SNIPPET
            byte[] pem = File.ReadAllBytes("certificate.cer");
#else
            byte[] pem = Encoding.ASCII.GetBytes(s_pem);
#endif
            ImportCertificateOptions importOptions = new ImportCertificateOptions(name, pem)
            {
                Policy = new CertificatePolicy(WellKnownIssuerNames.Self, "CN=contoso.com")
                {
                    // Required when the certificate bytes are a PEM-formatted certificate.
                    ContentType = CertificateContentType.Pem,

                    // Optionally mark the private key exportable.
                    Exportable = true
                }
            };

            await client.ImportCertificateAsync(importOptions);

            DeleteCertificateOperation operation = await client.StartDeleteCertificateAsync(name);

            // To ensure certificates are deleted on server side.
            // You only need to wait for completion if you want to purge or recover the certificate.
            await operation.WaitForCompletionAsync();

            client.PurgeDeletedCertificate(name);
        }
    }
}
