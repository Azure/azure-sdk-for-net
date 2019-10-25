// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Sas;

namespace Azure.Storage.Files.DataLake.Sas
{
    /// <summary>
    /// A <see cref="DataLakeSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="DataLakeSasBuilder"/>.
    ///
    /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas"/>.
    /// </summary>
    public sealed class DataLakeSasQueryParameters : SasQueryParameters
    {
        /// <summary>
        /// Gets the Azure Active Directory object ID in GUID format.
        /// </summary>
        public string KeyObjectId => _keyObjectId;

        /// <summary>
        /// Gets the Azure Active Directory tenant ID in GUID format
        /// </summary>
        public string KeyTenantId => _keyTenantId;

        /// <summary>
        /// Gets the time at which the key becomes valid.
        /// </summary>
        public DateTimeOffset KeyStart => _keyStart;

        /// <summary>
        /// Gets the time at which the key becomes expires.
        /// </summary>
        public DateTimeOffset KeyExpiry => _keyExpiry;

        /// <summary>
        /// Gets the Storage service that accepts the key.
        /// </summary>
        public string KeyService => _keyService;

        /// <summary>
        /// Gets the Storage service version that created the key.
        /// </summary>
        public string KeyVersion => _keyVersion;

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static new DataLakeSasQueryParameters Empty => new DataLakeSasQueryParameters();

        internal DataLakeSasQueryParameters()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DataLakeSasQueryParameters"/>
        /// type.
        ///
        /// Expects decoded values.
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
            string contentType = default)
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
                keyOid,
                keyTid,
                keyStart,
                keyExpiry,
                keyService,
                keyVersion,
                cacheControl,
                contentDisposition,
                contentEncoding,
                contentLanguage,
                contentType)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DataLakeSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        internal DataLakeSasQueryParameters(UriQueryParamsCollection values)
            : base(values, includeBlobParameters: true)
        {
        }

        /// <summary>
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>
        public override string ToString() =>
            Encode(includeBlobParameters: true);
    }
}
