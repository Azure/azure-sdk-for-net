// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    internal partial class AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders
    {
        private readonly Response _response;
        public AzureSecurityKeyVaultAdministrationSelectiveKeyRestoreOperationHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> The recommended number of seconds to wait before calling the URI specified in Azure-AsyncOperation. </summary>
        public int? RetryAfter => _response.Headers.TryGetValue("Retry-After", out int? value) ? value : null;
        /// <summary> The URI to poll for completion status. </summary>
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
    }
}
