// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Keys.Tests;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Samples
{
    /// <summary>
    /// This sample demonstrates how to securely wrap a key generated inside a Managed HSM trusted execution
    /// environment (TEE) and securely unwrap it into a target TEE using the synchronous methods of
    /// <see cref="CryptographyClient"/>. Secure wrap and unwrap are only supported on Managed HSM with service
    /// version 2026-01-01-preview or newer, and are remote-only operations.
    /// </summary>
    public partial class SecureWrapUnwrapSample
    {
        [Test]
        public void SecureWrapUnwrapSync()
        {
            TestEnvironment.AssertManagedHsm();

            string managedHsmUrl = TestEnvironment.ManagedHsmUrl;
            Uri attestationUrl = TestEnvironment.AttestationUri;

            #region Snippet:KeysSample10KeyClient
            var keyClient = new KeyClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample10CreateKey
            // Secure wrap/unwrap keys must be created on a Managed HSM with the SecureWrapKey and SecureUnwrapKey
            // operations and a release policy. The release policy governs which target environments (TEEs) the
            // wrapping key may be released into.
            string keyName = $"SecureWrapKey-{Guid.NewGuid()}";
            BinaryData releasePolicyData = BinaryData.FromObjectAsJson(new
            {
                anyOf = new[]
                {
                    new
                    {
                        anyOf = new[] { new { claim = "sdk-test", equals = "true" } },
                        authority = attestationUrl,
                    },
                },
                version = "1.0.0",
            });

            var createOptions = new CreateRsaKeyOptions(keyName, hardwareProtected: true)
            {
                KeySize = 2048,
                KeyOperations = { KeyOperation.SecureWrapKey, KeyOperation.SecureUnwrapKey },
                ReleasePolicy = new KeyReleasePolicy(releasePolicyData),
            };

            KeyVaultKey wrappingKey = keyClient.CreateRsaKey(createOptions);
            Debug.WriteLine($"Wrapping key created with name {wrappingKey.Name} and type {wrappingKey.KeyType}");
            #endregion

            #region Snippet:KeysSample10CryptographyClient
            var cryptoClient = new CryptographyClient(wrappingKey.Id, new DefaultAzureCredential());
            #endregion

            #region Snippet:KeysSample10SecureWrapKey
            // Securely wrap a key generated inside the Managed HSM trusted execution environment.
            SecureWrapResult wrapResult = cryptoClient.SecureWrapKey(SecureKeyWrapAlgorithm.RsaOaep256);
            Debug.WriteLine($"Securely wrapped a key for {wrapResult.KeyId} using {wrapResult.Algorithm}.");
            #endregion

            // Secure unwrap requires a Microsoft Azure Attestation (MAA) token that proves the identity of the
            // target trusted execution environment (TEE). The token is opaque to the SDK; in a real application you
            // obtain it from your TEE / attestation flow. This sample uses a Key Vault test attestation site to
            // generate one.
            string targetAttestationToken = new AttestationClient(attestationUrl, new KeyClientOptions()).GetToken();

            #region Snippet:KeysSample10SecureUnwrapKey
            // Unwrap the key into the target TEE proven by the attestation token. The same algorithm used to wrap
            // must be used to unwrap.
            SecureUnwrapResult unwrapResult = cryptoClient.SecureUnwrapKey(
                wrapResult.Algorithm,
                wrapResult.EncryptedKey,
                targetAttestationToken);
            Debug.WriteLine($"Securely unwrapped the key for {unwrapResult.KeyId} using {unwrapResult.Algorithm}.");
            #endregion

            // Delete and purge the wrapping key when it is no longer needed.
            DeleteKeyOperation operation = keyClient.StartDeleteKey(keyName);
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            keyClient.PurgeDeletedKey(keyName);
        }
    }
}
