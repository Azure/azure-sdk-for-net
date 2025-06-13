// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The rest client for the KeyVault Access Control service.
    /// </summary>
    [CodeGenType("KeyVaultAccessControlRestClient")]
    internal partial class KeyVaultAccessControlRestClient
    {
        /// <summary> Initializes a new instance of KeyVaultAccessControlRestClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal KeyVaultAccessControlRestClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new KeyVaultAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of KeyVaultAccessControlRestClient. </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        internal KeyVaultAccessControlRestClient(Uri endpoint, TokenCredential credential, KeyVaultAdministrationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new KeyVaultAdministrationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _tokenCredential = credential;
            Pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification));
            _endpoint = endpoint;
            _apiVersion = options.GetVersionString();
        }
    }
}