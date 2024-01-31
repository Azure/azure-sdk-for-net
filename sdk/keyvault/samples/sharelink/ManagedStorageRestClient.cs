// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;

namespace Azure.Security.KeyVault.Storage
{
    [CodeGenClient("AzureSecurityKeyVaultStorageRestClient")]
    internal partial class ManagedStorageRestClient
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ManagedStorageRestClient"/> class.
        /// The client is initialized similar to how SecretClient is initialized using a new pipeline
        /// that automatically adds the challenge-based authentication policy required by Key Vault.
        /// </summary>
        /// <param name="vaultUri">The <see cref="Uri"/> of the Key Vault to manage.</param>
        /// <param name="credential">The credentials used to authenticate to the Key Vault.</param>
        /// <param name="options">A <see cref="ClientOptions"/> used to initialize the pipeline and diagnostics.</param>
        /// <returns>A new <see cref="ManagedStorageRestClient"/>.</returns>
        internal static ManagedStorageRestClient Create(Uri vaultUri, TokenCredential credential, ClientOptions options)
        {
            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options ?? throw new ArgumentNullException(nameof(options)),
                new ChallengeBasedAuthenticationPolicy(credential ?? throw new ArgumentNullException(nameof(credential)), true));

            ClientDiagnostics diagnostics = new ClientDiagnostics(options);
            return new ManagedStorageRestClient(diagnostics, pipeline, vaultUri.AbsoluteUri);
        }
    }
}
