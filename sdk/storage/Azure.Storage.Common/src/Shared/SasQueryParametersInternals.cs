// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

#pragma warning disable AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
namespace Azure.Storage.Sas
#pragma warning restore AZC0001 // Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
{
    /// <summary>
    /// Helper to access protected static members of SasQueryParameters.
    /// </summary>
    internal class SasQueryParametersInternals : SasQueryParameters
    {
        /// <summary>
        /// Settable internal property to allow different versions in test.
        /// </summary>
        internal static string DefaultSasVersionInternal { get; set; } = DefaultSasVersion;

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
