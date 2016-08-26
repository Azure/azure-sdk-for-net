// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Client class to perform cryptographic key operations and vault
    /// operations against the Key Vault service.
    /// </summary>
    public partial interface IKeyVaultClient : IDisposable
    {
        /// <summary>
        /// Gets the certificate operation response.
        /// </summary>
        /// <param name='vault'>
        /// The vault name, e.g. https://myvault.vault.azure.net
        /// </param>
        /// <param name='certificateName'>
        /// The name of the certificate
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<string>> GetPendingCertificateSigningRequestWithHttpMessagesAsync(string vault, string certificateName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
