// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Sas;
using Azure.Storage.Sas.Shared;
using SasInternals = Azure.Storage.Files.DataLake.Sas.Shared;

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
        internal
#if RELEASE
            new
#endif
            UserDelegationKeyProperties _keyProperties;

        /// <summary>
        /// Gets the Azure Active Directory object ID in GUID format.
        /// </summary>
        public string KeyObjectId => _keyProperties._objectId;

        /// <summary>
        /// Gets the Azure Active Directory tenant ID in GUID format
        /// </summary>
        public string KeyTenantId => _keyProperties._tenantId;

        /// <summary>
        /// Gets the time at which the key becomes valid.
        /// </summary>
        public DateTimeOffset KeyStartsOn => _keyProperties._startsOn;

        /// <summary>
        /// Gets the time at which the key becomes expires.
        /// </summary>
        public DateTimeOffset KeyExpiresOn => _keyProperties._expiresOn;

        /// <summary>
        /// Gets the Storage service that accepts the key.
        /// </summary>
        public string KeyService => _keyProperties._service;

        /// <summary>
        /// Gets the Storage service version that created the key.
        /// </summary>
        public string KeyVersion => _keyProperties._version;

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
        internal static DataLakeSasQueryParameters Create(
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
        {
            var dataLakeParameters = new DataLakeSasQueryParameters();
            dataLakeParameters._keyProperties._objectId = keyOid;
            dataLakeParameters._keyProperties._tenantId = keyTid;
            dataLakeParameters._keyProperties._startsOn = keyStart;
            dataLakeParameters._keyProperties._expiresOn = keyExpiry;
            dataLakeParameters._keyProperties._service = keyService;
            dataLakeParameters._keyProperties._version = keyVersion;
            SasQueryParameters.Create(
            version: version ?? SasQueryParameters.DefaultSasVersion,
            services: services,
            resourceTypes: resourceTypes,
            protocol: protocol,
            startsOn: startsOn,
            expiresOn: expiresOn,
            ipRange: ipRange,
            identifier: identifier,
            resource: resource,
            permissions: permissions,
            signature: signature,  // Should never be null
            keyOid: keyOid,
            keyTid: keyTid,
            keyStart: keyStart,
            keyExpiry: keyExpiry,
            keyService: keyService,
            keyVersion: keyVersion,
            cacheControl: cacheControl,
            contentDisposition: contentDisposition,
            contentEncoding: contentEncoding,
            contentLanguage: contentLanguage,
            contentType: contentType,
            instance: dataLakeParameters);
            return dataLakeParameters;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        internal static DataLakeSasQueryParameters Create(
            Dictionary<string, string> values)
        {
            var dataLakeParameters = new DataLakeSasQueryParameters();
            SasInternals.SasQueryParametersExtensions.ParseKeyProperties(
                dataLakeParameters,
                values,
                preserve: true);
            return
                (DataLakeSasQueryParameters)SasQueryParameters.Create(
                    values,
                    includeBlobParameters: true,
                    dataLakeParameters);
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
