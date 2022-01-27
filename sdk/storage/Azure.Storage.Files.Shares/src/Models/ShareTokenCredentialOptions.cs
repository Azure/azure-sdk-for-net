// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Token Credential parameters.
    /// </summary>
    public class ShareTokenCredentialOptions
    {
        /// <summary>
        /// The token credential used to sign requests.
        /// </summary>
        public TokenCredential Credential { get; set; }

        /// <summary>
        /// Request Intent.
        /// </summary>
        public ShareFileRequestIntent? FileRequestIntent { get; set; }

        /// <summary>
        /// The token credential used to sign requests.
        /// </summary>
        /// <param name="credential">
        /// Token Credential parameters.
        /// </param>
        public ShareTokenCredentialOptions(TokenCredential credential)
        {
            Credential = credential;
        }
    }
}
