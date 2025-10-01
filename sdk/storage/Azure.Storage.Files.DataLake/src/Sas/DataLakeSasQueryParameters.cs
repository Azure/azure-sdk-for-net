// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// A <see cref="DataLakeSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="DataLakeSasBuilder"/>.
    ///
    /// For more information,
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/create-service-sas">
    /// Create a service SAS</see>.
    /// </summary>
    public sealed class DataLakeSasQueryParameters : SasQueryParameters
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

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static new DataLakeSasQueryParameters Empty => new DataLakeSasQueryParameters();

        internal DataLakeSasQueryParameters()
            : base()
        {
        }

        /// <summary>
        /// Creates a new BlobSasQueryParameters instance.
        /// </summary>
        internal DataLakeSasQueryParameters(
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
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default,
            string encryptionScope = default,
            string delegatedUserObjectId = default)
            : base(
                version: version,
                services: services,
                resourceTypes: resourceTypes,
                protocol: protocol,
                startsOn: startsOn,
                expiresOn: expiresOn,
                ipRange: ipRange,
                identifier: identifier,
                resource: resource,
                permissions: permissions,
                signature: signature,
                cacheControl: cacheControl,
                contentDisposition: contentDisposition,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentType: contentType,
                authorizedAadObjectId: authorizedAadObjectId,
                unauthorizedAadObjectId: unauthorizedAadObjectId,
                correlationId: correlationId,
                directoryDepth: directoryDepth,
                encryptionScope: encryptionScope,
                delegatedUserObjectId: delegatedUserObjectId)
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
        /// Creates a new instance of the <see cref="BlobSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        internal DataLakeSasQueryParameters(
            Dictionary<string, string> values)
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
            this.AppendProperties(sb);
            return sb.ToString();
        }
    }
}
