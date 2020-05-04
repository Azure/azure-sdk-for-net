// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Data.Tables.Sas
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
            string contentType = default) =>
            SasQueryParameters.Create(
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
                contentType);
    }
}
