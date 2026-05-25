// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class KeyVaultEkmClientLiveTests : EkmTestBase
    {
        public KeyVaultEkmClientLiveTests(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record to re-record */)
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"server_ca_certificates\"\\s*:\\s*)\\[[^\\]]*\\]")
            {
                Value = "[\"AA==\"]"
            });
        }

        [RecordedTest]
        public async Task EkmConnectionLifecycle()
        {
            KeyVaultEkmConnection input = BuildConnection();

            // --- Create ---
            Response<KeyVaultEkmConnection> created = await Client.CreateEkmConnectionAsync(input);
            Assert.That(created.GetRawResponse().Status, Is.EqualTo(200).Or.EqualTo(201));
            Assert.That(created.Value.Host, Is.EqualTo(input.Host));

            // --- Get ---
            Response<KeyVaultEkmConnection> got = await Client.GetEkmConnectionAsync();
            Assert.That(got.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(got.Value.Host, Is.EqualTo(input.Host));
            Assert.That(got.Value.ServerCaCertificates, Is.Not.Null.And.Not.Empty);

            // --- Check ---
            Response<EkmProxyInfo> check = await Client.CheckEkmConnectionAsync();
            Assert.That(check.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(check.Value, Is.Not.Null);

            // --- Get certificate ---
            Response<EkmProxyClientCertificateInfo> cert = await Client.GetEkmCertificateAsync();
            Assert.That(cert.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(cert.Value, Is.Not.Null);

            // --- Update ---
            Response<KeyVaultEkmConnection> updated = await Client.UpdateEkmConnectionAsync(input);
            Assert.That(updated.GetRawResponse().Status, Is.EqualTo(200));

            // --- Delete ---
            Response<KeyVaultEkmConnection> deleted = await Client.DeleteEkmConnectionAsync();
            Assert.That(deleted.GetRawResponse().Status, Is.EqualTo(200).Or.EqualTo(204));
        }

        [TearDown]
        public async Task EnsureConnectionDeleted()
        {
            if (Mode == RecordedTestMode.Playback || Client is null)
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
                // Already Deleted
            }
        }

        private KeyVaultEkmConnection BuildConnection()
        {
            string host = TestEnvironment.EkmHost
                ?? throw new IgnoreException("AZURE_KEYVAULT_EKM_HOST is not defined.");

            byte[] ca = ReadCaCertificate();

            return new KeyVaultEkmConnection(host, new[] { ca })
            {
                PathPrefix = TestEnvironment.EkmPathPrefix,
                ServerSubjectCommonName = TestEnvironment.EkmServerSubjectCommonName,
            };
        }

        private byte[] ReadCaCertificate()
        {
            // In Playback we don't hit the wire, so a placeholder byte is enough to satisfy the constructor.
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