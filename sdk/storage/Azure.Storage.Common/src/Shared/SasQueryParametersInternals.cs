// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Helper to access protected static members of SasQueryParameters.
    /// </summary>
    internal class SasQueryParametersInternals : SasQueryParameters
    {
        internal static new SasQueryParameters Create(IDictionary<string, string> values) =>
            SasQueryParameters.Create(values);

        internal static new SasQueryParameters Create(
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
            string cacheControl = default,
            string contentDisposition = default,
            string contentEncoding = default,
            string contentLanguage = default,
            string contentType = default,
            string authorizedAadObjectId = default,
            string unauthorizedAadObjectId = default,
            string correlationId = default,
            int? directoryDepth = default) =>
            SasQueryParameters.Create(
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
                directoryDepth: directoryDepth);
    }
}
