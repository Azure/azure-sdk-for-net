// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    // The EKM proxy pool allows at most two private endpoints; concurrent fixture instances would race for that quota.
    [NonParallelizable]
    public class Sample6_EkmPrivateEndpoint : EkmTestBase
    {
        private string _privateEndpointName;

        public Sample6_EkmPrivateEndpoint(bool isAsync, KeyVaultAdministrationClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer("(?<=\"server_ca_certificates\"\\s*:\\s*)\\[[^\\]]*\\]")
            {
                Value = "[\"AA==\"]"
            });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..host") { Value = "ekm-proxy-pe" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..privateLinkServiceId") { Value = "fake-private-link-service-id" });
            BodyKeySanitizers.Add(new BodyKeySanitizer("$..server_subject_common_name") { Value = "ekm.contoso.com" });
        }

        [RecordedTest]
        [AsyncOnly]
        [ServiceVersion(Min = KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview)]
        public async Task EkmPrivateEndpointAsync()
        {
            string privateLinkServiceAlias = TestEnvironment.EkmPrivateLinkServiceId
                ?? throw new IgnoreException("EKM_PRIVATE_LINK_SERVICE_ID is not defined.");

#if SNIPPET
            privateLinkServiceAlias = "<private_link_service_alias>";
#endif

            _privateEndpointName = Recording.GenerateId("ekm-pe-", 24);

            #region Snippet:CreateEkmPrivateEndpointAsync
            // Create an EKM proxy private endpoint. A pool may have up to two private endpoints. This is a
            // long-running operation, so we wait for it to complete.
            Operation<KeyVaultEkmPrivateEndpointOperation> createOperation = await Client.CreateEkmPrivateEndpointAsync(
                WaitUntil.Completed,
                _privateEndpointName,
                privateLinkServiceAlias,
                requestMessage: "Please approve this connection from my Managed HSM");

            Console.WriteLine($"EKM private endpoint creation finished with status: {createOperation.Value.Status}");
            #endregion

            Assert.That(createOperation.Value.PrivateEndpointName, Is.EqualTo(_privateEndpointName));

            #region Snippet:GetEkmPrivateEndpointAsync
            // The Private Link Service owner has to approve the connection before the private endpoint can be
            // used by an EKM connection.
            Response<KeyVaultEkmPrivateEndpoint> privateEndpoint = await Client.GetEkmPrivateEndpointAsync(_privateEndpointName);

            Console.WriteLine($"Provisioning state: {privateEndpoint.Value.ProvisioningState}");
            Console.WriteLine($"Connection status: {privateEndpoint.Value.PrivateLinkServiceConnectionState?.Status}");
            #endregion

            #region Snippet:GetEkmPrivateEndpointsAsync
            // List all of the EKM proxy private endpoints on the Managed HSM.
            Response<IReadOnlyList<KeyVaultEkmPrivateEndpoint>> privateEndpoints = await Client.GetEkmPrivateEndpointsAsync();

            foreach (KeyVaultEkmPrivateEndpoint endpoint in privateEndpoints.Value)
            {
                Console.WriteLine($"EKM private endpoint {endpoint.Name} is in state {endpoint.ProvisioningState}");
            }
            #endregion

            Assert.That(privateEndpoints.Value.Any(pe => pe.Name == _privateEndpointName), Is.True);

            #region Snippet:CreatePrivateEkmConnectionAsync
            // Once the connection is approved, an EKM connection can reach the EKM proxy through the private
            // endpoint. To do so, set the connection's HostName to the private endpoint's name and its
            // ConnectivityMode to EkmConnectivityMode.PrivateEndpoint. Since the host is now the private endpoint's
            // name rather than the proxy's real DNS name, ServerSubjectCommonName must be set so the proxy's
            // certificate can still be validated.
#if SNIPPET
            byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");
            string serverSubjectCommonName = "ekm.contoso.com";
#else
            byte[] serverCaCertificate = ReadCaCertificate();
            string serverSubjectCommonName = TestEnvironment.EkmServerSubjectCommonName
                ?? throw new IgnoreException("EKM_SERVER_SUBJECT_COMMON_NAME is not defined.");
#endif
            KeyVaultEkmConnection connection = new KeyVaultEkmConnection(_privateEndpointName, new[] { serverCaCertificate })
            {
                PathPrefix = "/api/v1",
                ConnectivityMode = EkmConnectivityMode.PrivateEndpoint,
                ServerSubjectCommonName = serverSubjectCommonName,
            };

            Response<KeyVaultEkmConnection> createdConnection = await Client.CreateEkmConnectionAsync(connection);

            Console.WriteLine($"EKM connection created with connectivity mode: {createdConnection.Value.ConnectivityMode}");
            #endregion

            Assert.That(createdConnection.Value.ConnectivityMode, Is.EqualTo(EkmConnectivityMode.PrivateEndpoint));

            #region Snippet:DeleteEkmPrivateEndpointAsync
            // Deletion is rejected while an EKM connection still references the private endpoint, so we delete the
            // EKM connection first.
            await Client.DeleteEkmConnectionAsync();

            Operation<KeyVaultEkmPrivateEndpointOperation> deleteOperation = await Client.DeleteEkmPrivateEndpointAsync(
                WaitUntil.Completed, _privateEndpointName);

            Console.WriteLine($"EKM private endpoint deletion finished with status: {deleteOperation.Value.Status}");
            #endregion

            Assert.That(deleteOperation.Value.PrivateEndpointName, Is.EqualTo(_privateEndpointName));

            _privateEndpointName = null;
        }

        [RecordedTest]
        [SyncOnly]
        [ServiceVersion(Min = KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview)]
        public async Task EkmPrivateEndpointSync()
        {
            string privateLinkServiceAlias = TestEnvironment.EkmPrivateLinkServiceId
                ?? throw new IgnoreException("EKM_PRIVATE_LINK_SERVICE_ID is not defined.");

#if SNIPPET
            privateLinkServiceAlias = "<private_link_service_alias>";
#endif

            _privateEndpointName = Recording.GenerateId("ekm-pe-", 24);

            #region Snippet:CreateEkmPrivateEndpointSync
            // Create an EKM proxy private endpoint. A pool may have up to two private endpoints. This is a
            // long-running operation, so we wait for it to complete.
#if SNIPPET
            Operation<KeyVaultEkmPrivateEndpointOperation> createOperation = Client.CreateEkmPrivateEndpoint(
                WaitUntil.Completed,
                _privateEndpointName,
                privateLinkServiceAlias,
                requestMessage: "Please approve this connection from my Managed HSM");
#else
            Operation<KeyVaultEkmPrivateEndpointOperation> createOperation = Client.CreateEkmPrivateEndpoint(
                WaitUntil.Started,
                _privateEndpointName,
                privateLinkServiceAlias,
                requestMessage: "Please approve this connection from my Managed HSM");

            while (!createOperation.HasCompleted)
            {
                createOperation.UpdateStatus();
                await DelayAsync(TimeSpan.FromSeconds(3));
            }
#endif

            Console.WriteLine($"EKM private endpoint creation finished with status: {createOperation.Value.Status}");
            #endregion

            Assert.That(createOperation.Value.PrivateEndpointName, Is.EqualTo(_privateEndpointName));

            #region Snippet:GetEkmPrivateEndpointSync
            // The Private Link Service owner has to approve the connection before the private endpoint can be
            // used by an EKM connection.
            Response<KeyVaultEkmPrivateEndpoint> privateEndpoint = Client.GetEkmPrivateEndpoint(_privateEndpointName);

            Console.WriteLine($"Provisioning state: {privateEndpoint.Value.ProvisioningState}");
            Console.WriteLine($"Connection status: {privateEndpoint.Value.PrivateLinkServiceConnectionState?.Status}");
            #endregion

            #region Snippet:GetEkmPrivateEndpointsSync
            // List all of the EKM proxy private endpoints on the Managed HSM.
            Response<IReadOnlyList<KeyVaultEkmPrivateEndpoint>> privateEndpoints = Client.GetEkmPrivateEndpoints();

            foreach (KeyVaultEkmPrivateEndpoint endpoint in privateEndpoints.Value)
            {
                Console.WriteLine($"EKM private endpoint {endpoint.Name} is in state {endpoint.ProvisioningState}");
            }
            #endregion

            Assert.That(privateEndpoints.Value.Any(pe => pe.Name == _privateEndpointName), Is.True);

            #region Snippet:CreatePrivateEkmConnectionSync
            // Once the connection is approved, an EKM connection can reach the EKM proxy through the private
            // endpoint. To do so, set the connection's HostName to the private endpoint's name and its
            // ConnectivityMode to EkmConnectivityMode.PrivateEndpoint. Since the host is now the private endpoint's
            // name rather than the proxy's real DNS name, ServerSubjectCommonName must be set so the proxy's
            // certificate can still be validated.
#if SNIPPET
            byte[] serverCaCertificate = File.ReadAllBytes("ekm-proxy-ca.cer");
            string serverSubjectCommonName = "ekm.contoso.com";
#else
            byte[] serverCaCertificate = ReadCaCertificate();
            string serverSubjectCommonName = TestEnvironment.EkmServerSubjectCommonName
                ?? throw new IgnoreException("EKM_SERVER_SUBJECT_COMMON_NAME is not defined.");
#endif
            KeyVaultEkmConnection connection = new KeyVaultEkmConnection(_privateEndpointName, new[] { serverCaCertificate })
            {
                PathPrefix = "/api/v1",
                ConnectivityMode = EkmConnectivityMode.PrivateEndpoint,
                ServerSubjectCommonName = serverSubjectCommonName,
            };

            Response<KeyVaultEkmConnection> createdConnection = Client.CreateEkmConnection(connection);

            Console.WriteLine($"EKM connection created with connectivity mode: {createdConnection.Value.ConnectivityMode}");
            #endregion

            Assert.That(createdConnection.Value.ConnectivityMode, Is.EqualTo(EkmConnectivityMode.PrivateEndpoint));

            #region Snippet:DeleteEkmPrivateEndpointSync
            // Deletion is rejected while an EKM connection still references the private endpoint, so we delete the
            // EKM connection first.
            Client.DeleteEkmConnection();

#if SNIPPET
            Operation<KeyVaultEkmPrivateEndpointOperation> deleteOperation = Client.DeleteEkmPrivateEndpoint(
                WaitUntil.Completed, _privateEndpointName);
#else
            Operation<KeyVaultEkmPrivateEndpointOperation> deleteOperation = Client.DeleteEkmPrivateEndpoint(
                WaitUntil.Started, _privateEndpointName);

            while (!deleteOperation.HasCompleted)
            {
                deleteOperation.UpdateStatus();
                await DelayAsync(TimeSpan.FromSeconds(3));
            }
#endif

            Console.WriteLine($"EKM private endpoint deletion finished with status: {deleteOperation.Value.Status}");
            #endregion

            Assert.That(deleteOperation.Value.PrivateEndpointName, Is.EqualTo(_privateEndpointName));

            _privateEndpointName = null;
        }

        [TearDown]
        public async Task EnsureCleanedUp()
        {
            if (Mode == RecordedTestMode.Playback || Client is null || Recording is null)
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

        private byte[] ReadCaCertificate()
        {
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
