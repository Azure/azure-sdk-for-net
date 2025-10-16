// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// A <see cref="ShareSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="ShareSasBuilder"/>.
    ///
    /// For more information,
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-service-sas">
    /// Create a service SAS</see>.
    /// </summary>
    public sealed class ShareSasQueryParameters : SasQueryParameters
    {
        internal UserDelegationKeyProperties KeyProperties { get; set; }

        /// <summary>
        /// Gets the Azure Active Directory object ID in GUID format.
        /// </summary>
        public string KeyObjectId => KeyProperties?.ObjectId;

        /// <summary>
        /// Gets the Azure Active Directory tenant ID in GUID format
        /// </summary>
        public string KeyTenantId => KeyProperties?.TenantId;

        /// <summary>
        /// Gets the time at which the key becomes valid.
        /// </summary>
        public DateTimeOffset KeyStartsOn => KeyProperties == null ? default : KeyProperties.StartsOn;

        /// <summary>
        /// Gets the time at which the key becomes expires.
        /// </summary>
        public DateTimeOffset KeyExpiresOn => KeyProperties == null ? default : KeyProperties.ExpiresOn;

        /// <summary>
        /// Gets the Storage service that accepts the key.
        /// </summary>
        public string KeyService => KeyProperties?.Service;

        /// <summary>
        /// Gets the Storage service version that created the key.
        /// </summary>
        public string KeyVersion => KeyProperties?.Version;

        internal ShareSasQueryParameters() : base()
        {
        }

        /// <summary>
        /// Creates a new BlobSasQueryParameters instance.
        /// </summary>
        internal ShareSasQueryParameters(
            string version,
            AccountSasServices? services,
            AccountSasResourceTypes? resourceTypes,
            SasProtocol protocol,
            DateTimeOffset startsOn,
            DateTimeOffset expiresOn,
            SasIPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature,
            string keyOid = default,
            string keyTid = default,
            DateTimeOffset keyStart = default,
            DateTimeOffset keyExpiry = default,
            string keyService = default,
            string keyVersion = default,
            string cacheControl = default,
            string contentDisposition = default,
            string contentEncoding = default,
            string contentLanguage = default,
            string contentType = default,
            string delegatedUserObjectId = default)
            : base(
                version,
                services,
                resourceTypes,
                protocol,
                startsOn,
                expiresOn,
                ipRange,
                identifier,
                resource,
                permissions,
                signature,
                cacheControl,
                contentDisposition,
                contentEncoding,
                contentLanguage,
                contentType,
                authorizedAadObjectId: null,
                unauthorizedAadObjectId: null,
                correlationId: null,
                directoryDepth: null,
                encryptionScope: null,
                delegatedUserObjectId)
        {
            KeyProperties = new UserDelegationKeyProperties
            {
                ObjectId = keyOid,
                TenantId = keyTid,
                StartsOn = keyStart,
                ExpiresOn = keyExpiry,
                Service = keyService,
                Version = keyVersion
            };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ShareSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        internal ShareSasQueryParameters(
            IDictionary<string, string> values)
            : base(values)
        {
            this.ParseKeyProperties(values);
        }

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            KeyProperties.AppendProperties(sb);
            AppendProperties(sb);
            return sb.ToString();
        }
    }
}
