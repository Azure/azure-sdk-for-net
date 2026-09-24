// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    // The EKM proxy pool allows at most two private endpoints; concurrent fixture instances would race for that quota.
    [NonParallelizable]
    public class KeyVaultEkmClientLiveTests : EkmTestBase
    {
        private string _privateEndpointName;

        public KeyVaultEkmClientLiveTests(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record to re-record */)
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"server_ca_certificates\"\\s*:\\s*)\\[[^\\]]*\\]")
            {
                Value = "[\"AA==\"]"
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..host") { Value = "ekm.contoso.com" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..privateLinkServiceId") { Value = "fake-private-link-service-id" });
        }

        [RecordedTest]
        public async Task EkmConnectionLifecycle()
        {
            KeyVaultEkmConnection input = BuildConnection();

            // --- Create ---
            Response<KeyVaultEkmConnection> created = await Client.CreateEkmConnectionAsync(input);
            Assert.That(created.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(created.Value.HostName, Is.EqualTo(input.HostName));

            // --- Get ---
            Response<KeyVaultEkmConnection> got = await Client.GetEkmConnectionAsync();
            Assert.That(got.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(got.Value.HostName, Is.EqualTo(input.HostName));
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
            Assert.That(deleted.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        [ServiceVersion(Min = KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview)]
        public async Task EkmPrivateEndpointLifecycle()
        {
            string privateLinkServiceAlias = TestEnvironment.EkmPrivateLinkServiceId
                ?? throw new IgnoreException("EKM_PRIVATE_LINK_SERVICE_ID is not defined.");

            _privateEndpointName = Recording.GenerateId("ekm-pe-", 24);

            // --- Create ---
            Operation<KeyVaultEkmPrivateEndpointOperation> createOperation = await Client.CreateEkmPrivateEndpointAsync(
                WaitUntil.Completed, _privateEndpointName, privateLinkServiceAlias, requestMessage: "Please approve this connection");
            Assert.That(createOperation.HasValue, Is.True);
            Assert.That(createOperation.Value.PrivateEndpointName, Is.EqualTo(_privateEndpointName));
            Assert.That(createOperation.Value.OperationType, Is.EqualTo(KeyVaultEkmPrivateEndpointOperationType.Create));
            Assert.That(createOperation.Value.Status, Is.EqualTo(KeyVaultEkmPrivateEndpointOperationStatus.Succeeded));

            // --- Get ---
            Response<KeyVaultEkmPrivateEndpoint> got = await Client.GetEkmPrivateEndpointAsync(_privateEndpointName);
            Assert.That(got.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(got.Value.Name, Is.EqualTo(_privateEndpointName));
            Assert.That(got.Value.ProvisioningState, Is.Not.Null);
            Assert.That(got.Value.Properties?.PrivateLinkServiceAlias, Is.EqualTo(privateLinkServiceAlias));
            Assert.That(got.Value.PrivateLinkServiceConnectionState?.Status, Is.Not.Null);

            // --- List ---
            Response<IReadOnlyList<KeyVaultEkmPrivateEndpoint>> list = await Client.GetEkmPrivateEndpointsAsync();
            Assert.That(list.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(list.Value.Any(pe => pe.Name == _privateEndpointName), Is.True);

            // --- Delete ---
            Operation<KeyVaultEkmPrivateEndpointOperation> deleteOperation = await Client.DeleteEkmPrivateEndpointAsync(WaitUntil.Completed, _privateEndpointName);
            Assert.That(deleteOperation.HasValue, Is.True);
            Assert.That(deleteOperation.Value.PrivateEndpointName, Is.EqualTo(_privateEndpointName));
            Assert.That(deleteOperation.Value.OperationType, Is.EqualTo(KeyVaultEkmPrivateEndpointOperationType.Delete));
            Assert.That(deleteOperation.Value.Status, Is.EqualTo(KeyVaultEkmPrivateEndpointOperationStatus.Succeeded));

            // --- Get operation status by job ID ---
            Assert.That(deleteOperation.Value.JobId, Is.Not.Null.And.Not.Empty);

            Response<KeyVaultEkmPrivateEndpointOperation> status = await Client.GetEkmPrivateEndpointOperationStatusAsync(deleteOperation.Value.JobId);
            Assert.That(status.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(status.Value.JobId, Is.EqualTo(deleteOperation.Value.JobId));
            Assert.That(status.Value.Status, Is.EqualTo(KeyVaultEkmPrivateEndpointOperationStatus.Succeeded));

            _privateEndpointName = null;
        }

        [TearDown]
        public async Task EnsureCleanedUp()
        {
            if (Mode == RecordedTestMode.Playback || Client is null)
            {
                return;
            }

            using (Recording.DisableRecording())
            {
                // The connection must go first; the service rejects deleting a private endpoint still referenced by it.
                await TryAsync(() => Client.DeleteEkmConnectionAsync());

                if (_privateEndpointName is not null)
                {
                    await TryAsync(() => Client.DeleteEkmPrivateEndpointAsync(WaitUntil.Completed, _privateEndpointName));
                }
            }

            _privateEndpointName = null;

            // Best-effort cleanup; never fail teardown.
            static async Task TryAsync(Func<Task> action)
            {
                try { await action(); } catch { }
            }
        }

        private KeyVaultEkmConnection BuildConnection()
        {
            string host = TestEnvironment.EkmHost
                ?? throw new IgnoreException("EKM_PROXY_HOST  is not defined.");

            byte[] ca = ReadCaCertificate();

            return new KeyVaultEkmConnection(host, new[] { ca })
            {
                PathPrefix = TestEnvironment.EkmPathPrefix
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
                ?? throw new IgnoreException("EKM_SERVER_CA_CERTIFICATE is not defined.");

            return Convert.FromBase64String(base64);
        }
    }
}