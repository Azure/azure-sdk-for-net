// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.Files.Shares.ChangeFeed
{
    /// <summary>
    /// Extension methods for creating <see cref="ShareChangeFeedClient"/> instances
    /// from existing Azure Files clients.
    /// </summary>
    public static class ShareChangeFeedExtensions
    {
        /// <summary>
        /// Creates a <see cref="ShareChangeFeedClient"/> for reading the change feed
        /// of the file share represented by this <see cref="ShareClient"/>.
        /// The share client's URI (including any SAS token) is used for authentication.
        /// </summary>
        /// <param name="shareClient">The <see cref="ShareClient"/> for the file share whose change feed will be read.</param>
        /// <param name="options">Optional <see cref="ShareChangeFeedClientOptions"/> for tuning change feed behavior.</param>
        /// <returns>A new <see cref="ShareChangeFeedClient"/> instance.</returns>
        public static ShareChangeFeedClient GetShareChangeFeedClient(
            this ShareClient shareClient,
            ShareChangeFeedClientOptions options = default)
            => new ShareChangeFeedClient(
                shareClient.Uri,
                shareClient.Name,
                options);
    }
}
