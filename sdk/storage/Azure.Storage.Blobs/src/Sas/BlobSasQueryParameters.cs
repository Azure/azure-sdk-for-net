//// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// A <see cref="BlobSasQueryParameters"/> object represents the components
    /// that make up an Azure Storage Shared Access Signature's query
    /// parameters.  You can construct a new instance using
    /// <see cref="BlobSasBuilder"/>.
    /// 
    /// For more information, <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/constructing-a-service-sas"/>.
    /// </summary>
    public sealed class BlobSasQueryParameters : SasQueryParameters
    {
        /// <summary>
        /// Gets the Azure Active Directory object ID in GUID format.
        /// </summary>
        public string KeyObjectId => this.keyObjectId;

        /// <summary>
        /// Gets the Azure Active Directory tenant ID in GUID format
        /// </summary>
        public string KeyTenantId => this.keyTenantId;

        /// <summary>
        /// Gets the time at which the key becomes valid.
        /// </summary>
        public DateTimeOffset KeyStart => this.keyStart;

        /// <summary>
        /// Gets the time at which the key becomes expires.
        /// </summary>
        public DateTimeOffset KeyExpiry => this.keyExpiry;

        /// <summary>
        /// Gets the Storage service that accepts the key.
        /// </summary>
        public string KeyService => this.keyService;

        /// <summary>
        /// Gets the Storage service version that created the key.
        /// </summary>
        public string KeyVersion => this.keyVersion;

        /// <summary>
        /// Gets empty shared access signature query parameters.
        /// </summary>
        public static new BlobSasQueryParameters Empty => new BlobSasQueryParameters();

        internal BlobSasQueryParameters()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlobSasQueryParameters"/>
        /// type.
        /// 
        /// Expects decoded values.
        /// </summary>
        internal BlobSasQueryParameters(
            string version,
            string services,
            string resourceTypes,
            SasProtocol protocol,
            DateTimeOffset startTime,
            DateTimeOffset expiryTime,
            IPRange ipRange,
            string identifier,
            string resource,
            string permissions,
            string signature,
            string keyOid = default,
            string keyTid = default,
            DateTimeOffset keyStart = default,
            DateTimeOffset keyExpiry = default,
            string keyService = default,
            string keyVersion = default)
            : base(
                version,
                services,
                resourceTypes,
                protocol,
                startTime,
                expiryTime,
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
                keyVersion)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BlobSasQueryParameters"/>
        /// type based on the supplied query parameters <paramref name="values"/>.
        /// All SAS-related query parameters will be removed from
        /// <paramref name="values"/>.
        /// </summary>
        /// <param name="values">URI query parameters</param>
        /// <param name="includeBlobParameters">
        /// Optional flag indicating whether to process blob-specific query
        /// parameters.  The default value is false.
        /// </param>
        internal BlobSasQueryParameters(UriQueryParamsCollection values)
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
            this.Encode(includeBlobParameters: true);
    }
}
