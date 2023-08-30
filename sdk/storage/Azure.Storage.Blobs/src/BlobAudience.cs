// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Audiences available for Blobs
    /// </summary>
    public readonly partial struct BlobAudience : IEquatable<BlobAudience>
    {
        private readonly string _audience;

        /// <summary>
        /// Intializes new instance of <see cref="BlobAudience"/>.
        /// </summary>
        /// <param name="audience">
        /// The Azure Active Directory audience to use when forming authorization scopes.
        /// For the Language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.
        /// For more information: <see href="https://learn.microsoft.com/en-us/azure/storage/blobs/authorize-access-azure-active-directory" />.
        /// </param>
        /// <remarks>Please use one of the static constant members over creating a custom value unless you have specific scenario for doing so.</remarks>
        public BlobAudience(string audience)
        {
            Argument.AssertNotNullOrEmpty(audience, nameof(audience));
            _audience = audience;
        }

        private const string _publicAudience = "https://storage.azure.com/.default";

        /// <summary>
        /// Default Audience. Use to acquire a token for authorizing requests to any Azure Storage account
        ///
        /// Resource ID: &quot;https://storage.azure.com/.default &quot;.
        ///
        /// If no audience is specified, this is the default value.
        /// </summary>
        public static BlobAudience PublicAudience { get; } = new(_publicAudience);

        /// <summary>
        /// The service endpoint for a given storage account.
        /// Use this method to acquire a token for authorizing requests to that specific Azure Storage account and service only.
        /// </summary>
        /// <param name="storageAccountName"></param>
        /// <returns></returns>
        public static BlobAudience BlobServiceAccountAudience(string storageAccountName) => new($"https://{storageAccountName}.blob.core.windows.net/.default");

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BlobAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(BlobAudience other) => string.Equals(_audience, other._audience, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _audience?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _audience;
    }
}
