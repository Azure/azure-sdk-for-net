// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Identity;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class Sample5_EkmHelloWorld : EkmTestBase
    {
        public Sample5_EkmHelloWorld(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"server_ca_certificates\"\\s*:\\s*)\\[[^\\]]*\\]")
            {
                Value = "[\"AA==\"]"
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..host") { Value = "ekm.contoso.com" });
        }

        [Test]
        public void CreateClientSample()
        {
            var managedHsmUrl = TestEnvironment.ManagedHsmUrl;

            #region Snippet:HelloCreateKeyVaultEkmClient
            KeyVaultEkmClient client = new KeyVaultEkmClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
            #endregion
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task EkmHelloWorldAsync()
        {
            string ekmHost = TestEnvironment.EkmHost
                ?? throw new IgnoreException("AZURE_KEYVAULT_EKM_HOST is not defined.");

            #region Snippet:EkmCreateConnectionAsync
#if SNIPPET
            // Read the EKM proxy's CA certificate bytes.
            byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");

            // Build the EKM connection. Host is the FQDN of the EKM proxy.
            KeyVaultEkmConnection connection = new KeyVaultEkmConnection("ekm.contoso.com", new[] { serverCaCertificate })
            {
                PathPrefix = "v1",
                ServerSubjectCommonName = "ekm.contoso.com",
            };
#else
            byte[] serverCaCertificate = ReadCaCertificate();
            KeyVaultEkmConnection connection = new KeyVaultEkmConnection(ekmHost, new[] { serverCaCertificate })
            {
                PathPrefix = TestEnvironment.EkmPathPrefix,
                ServerSubjectCommonName = TestEnvironment.EkmServerSubjectCommonName,
            };
#endif

            // Create the EKM connection on the Managed HSM.
            Response<KeyVaultEkmConnection> created = await Client.CreateEkmConnectionAsync(connection);
            #endregion

            Assert.That(created.Value.Host, Is.EqualTo(connection.Host));

            #region Snippet:EkmGetConnectionAsync
            // Retrieve the current EKM connection.
            Response<KeyVaultEkmConnection> current = await Client.GetEkmConnectionAsync();

            Console.WriteLine($"EKM host: {current.Value.Host}");
            Console.WriteLine($"Path prefix: {current.Value.PathPrefix}");
            #endregion

            #region Snippet:EkmCheckConnectionAsync
            // Verify connectivity and authentication with the EKM proxy.
            Response<EkmProxyInfo> info = await Client.CheckEkmConnectionAsync();

            Console.WriteLine($"EKM vendor: {info.Value.EkmVendor}, product: {info.Value.EkmProduct}");
            #endregion

            #region Snippet:EkmGetCertificateAsync
            // Retrieve the client certificate the Managed HSM uses to authenticate with the EKM proxy.
            Response<EkmProxyClientCertificateInfo> certificateInfo = await Client.GetEkmCertificateAsync();

            string subject = certificateInfo.Value.SubjectCommonName;
            #endregion

            #region Snippet:EkmUpdateConnectionAsync
            // Update an existing EKM connection (for example, to rotate the server CA certificate
            // by replacing the value in ServerCaCertificates).
            Response<KeyVaultEkmConnection> updated = await Client.UpdateEkmConnectionAsync(current.Value);
            #endregion

            #region Snippet:EkmDeleteConnectionAsync
            // Remove the EKM connection.
            await Client.DeleteEkmConnectionAsync();
            #endregion

            Assert.That(updated.Value, Is.Not.Null);
            Assert.That(subject, Is.Not.Null);
            Assert.That(info.Value, Is.Not.Null);
        }

        [RecordedTest]
        [SyncOnly]
        public void EkmHelloWorldSync()
        {
            string ekmHost = TestEnvironment.EkmHost
                ?? throw new IgnoreException("AZURE_KEYVAULT_EKM_HOST is not defined.");

            #region Snippet:EkmCreateConnectionSync
#if SNIPPET
            // Read the EKM proxy's CA certificate bytes (DER- or PEM-encoded).
            byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");

            // Build the EKM connection. Host is the FQDN of the EKM proxy.
            KeyVaultEkmConnection connection = new KeyVaultEkmConnection("ekm.contoso.com", new[] { serverCaCertificate })
            {
                PathPrefix = "v1",
                ServerSubjectCommonName = "ekm.contoso.com",
            };
#else
            byte[] serverCaCertificate = ReadCaCertificate();
            KeyVaultEkmConnection connection = new KeyVaultEkmConnection(ekmHost, new[] { serverCaCertificate })
            {
                PathPrefix = TestEnvironment.EkmPathPrefix,
                ServerSubjectCommonName = TestEnvironment.EkmServerSubjectCommonName,
            };
#endif

            // Create the EKM connection on the Managed HSM. Requires the "ekm/write" permission.
            Response<KeyVaultEkmConnection> created = Client.CreateEkmConnection(connection);
            #endregion

            Assert.That(created.Value.Host, Is.EqualTo(connection.Host));

            #region Snippet:EkmGetConnectionSync
            // Retrieve the current EKM connection. Requires the "ekm/read" permission.
            Response<KeyVaultEkmConnection> current = Client.GetEkmConnection();

            Console.WriteLine($"EKM host: {current.Value.Host}");
            Console.WriteLine($"Path prefix: {current.Value.PathPrefix}");
            #endregion

            #region Snippet:EkmCheckConnectionSync
            // Verify connectivity and authentication with the EKM proxy.
            Response<EkmProxyInfo> info = Client.CheckEkmConnection();

            Console.WriteLine($"EKM vendor: {info.Value.EkmVendor}, product: {info.Value.EkmProduct}");
            #endregion

            #region Snippet:EkmDeleteConnectionSync
            // Remove the EKM connection.
            Client.DeleteEkmConnection();
            #endregion

            Assert.That(info.Value, Is.Not.Null);
        }

        [TearDown]
        public async Task EnsureConnectionDeleted()
        {
            if (Mode == RecordedTestMode.Playback || Client is null || Recording is null)
            {
                return;
            }

            try
            {
                using (Recording.DisableRecording())
                {
                    await Client.DeleteEkmConnectionAsync();
                }
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                // Already deleted.
            }
            catch
            {
                // Best-effort cleanup; never fail teardown.
            }
        }

        private byte[] ReadCaCertificate()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return new byte[] { 0x00 };
            }

            string base64 = TestEnvironment.EkmServerCaCertBase64
                ?? throw new IgnoreException("AZURE_KEYVAULT_EKM_SERVER_CA_CERT is not defined.");

            return Convert.FromBase64String(base64);
        }
    }
}
