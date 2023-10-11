// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Security.KeyVault.Administration.Models
{
    internal partial class SASTokenParameter
    {
        /// <summary>
        /// Creates a new instance of the <see cref="SASTokenParameter"/> class.
        /// </summary>
        /// <param name="storageResourceUri">The URI for the blob storage resource.</param>
        /// <param name="sasToken">
        /// Optional Shared Access Signature (SAS) token to authorize access to the blob. Sets <see cref="Token"/>.
        /// If null, <see cref="UseManagedIdentity"/> will be set to true and Managed Identity will be used to authenticate instead.
        /// </param>
        public SASTokenParameter(string storageResourceUri, string sasToken)
            : this(storageResourceUri)
        {
            Token = sasToken;
            UseManagedIdentity = sasToken == null;
        }
    }
}
