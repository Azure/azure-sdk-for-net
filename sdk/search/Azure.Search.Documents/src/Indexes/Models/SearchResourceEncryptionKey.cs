// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("EncryptionKey")]
    [CodeGenSuppress(nameof(SearchResourceEncryptionKey), typeof(string), typeof(string))]
    public partial class SearchResourceEncryptionKey
    {
        /// <summary>
        /// Creates a new instance of the <see cref="SearchResourceEncryptionKey"/> class.
        /// </summary>
        /// <param name="vaultUri">Required. The Azure Key Vault <see cref="Uri"/>.</param>
        /// <param name="keyName">Required. The name of the Azure Key Vault key to encrypt resources at rest.</param>
        /// <param name="keyVersion">Required. The version of the Azure Key Vault key to encrypt resources at rest.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/>, <paramref name="keyName"/>, or <paramref name="keyVersion"/> is null.</exception>
        public SearchResourceEncryptionKey(Uri vaultUri, string keyName, string keyVersion)
        {
            VaultUri = vaultUri ?? throw new ArgumentNullException(nameof(vaultUri));
            KeyName = keyName ?? throw new ArgumentNullException(nameof(keyName));
            KeyVersion = keyVersion ?? throw new ArgumentNullException(nameof(keyVersion));
        }

        [CodeGenMember("VaultUri")]
        private string _vaultUri;

        /// <summary>
        /// Gets the Azure Key Vault <see cref="Uri"/>.
        /// </summary>
        public Uri VaultUri
        {
            get => new Uri(_vaultUri);
            private set => _vaultUri = value.AbsoluteUri;
        }

        /// <summary>
        /// Gets the name of the Azure Key Vault key to encrypt resources at rest.
        /// </summary>
        [CodeGenMember("KeyVaultKeyName")]
        public string KeyName { get; }

        /// <summary>
        /// Gets the version of the Azure Key Vault key to encrypt resources at rest.
        /// </summary>
        /// <remarks>
        /// A version is required in case the key rotates.
        /// </remarks>
        [CodeGenMember("KeyVaultKeyVersion")]
        public string KeyVersion { get; }

        /// <summary>
        /// Gets or sets the application ID to access the Azure Key Vault specified in the <see cref="VaultUri"/>.
        /// The Azure Key Vault must be in the same tenant as the Azure Search service.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the application secret to access the Azure Key Vault specified in the <see cref="VaultUri"/>.
        /// The Azure Key Vault must be in the same tenant as the Azure Search service.
        /// </summary>
        public string ApplicationSecret { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="AzureActiveDirectoryApplicationCredentials"/> for de/serialization purposes only.
        /// </summary>
        [CodeGenMember("AccessCredentials")]
        private AzureActiveDirectoryApplicationCredentials AccessCredentialsInternal
        {
            get
            {
                if (ApplicationId != null || ApplicationSecret != null)
                {
                    return new AzureActiveDirectoryApplicationCredentials(ApplicationId, ApplicationSecret, serializedAdditionalRawData: null);
                }

                return null;
            }

            set
            {
                ApplicationId = value?.ApplicationId;
                ApplicationSecret = value?.ApplicationSecret;
            }
        }
    }
}
