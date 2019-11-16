// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Encapsulates the shared properties used by both
    /// BlobSasQueryParameters and DataLakeSasQueryParameters.
    /// </summary>
    internal struct UserDelegationKeyProperties
    {
        // skoid
        internal string _objectId;

        // sktid
        internal string _tenantId;

        // skt
        internal DateTimeOffset _startsOn;

        // ske
        internal DateTimeOffset _expiresOn;

        // sks
        internal string _service;

        // skv
        internal string _version;

        /// <summary>
        /// Builds up the UserDelegationKey portion of the SAS query parameter string.
        /// </summary>
        public void BuildParameterString(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_objectId))
            {
                stringBuilder.AddQueryParam(Constants.Sas.Parameters.KeyObjectId, _objectId);
            }

            if (!string.IsNullOrWhiteSpace(_tenantId))
            {
                stringBuilder.AddQueryParam(Constants.Sas.Parameters.KeyTenantId, _tenantId);
            }

            if (_startsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AddQueryParam(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(_startsOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (_expiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AddQueryParam(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(_expiresOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrWhiteSpace(_service))
            {
                stringBuilder.AddQueryParam(Constants.Sas.Parameters.KeyService, _service);
            }

            if (!string.IsNullOrWhiteSpace(_version))
            {
                stringBuilder.AddQueryParam(Constants.Sas.Parameters.KeyVersion, _version);
            }
        }
    }
}
