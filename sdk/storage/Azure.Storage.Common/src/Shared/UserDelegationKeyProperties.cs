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
    internal class UserDelegationKeyProperties
    {
        // skoid
        internal string _objectId { get; set; }

        // sktid
        internal string _tenantId { get; set; }

        // skt
        internal DateTimeOffset _startsOn { get; set; }

        // ske
        internal DateTimeOffset _expiresOn { get; set; }

        // sks
        internal string _service { get; set; }

        // skv
        internal string _version { get; set; }

        /// <summary>
        /// Builds up the UserDelegationKey portion of the SAS query parameter string.
        /// </summary>
        public void AppendProperties(StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_objectId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyObjectId, _objectId);
            }

            if (!string.IsNullOrWhiteSpace(_tenantId))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyTenantId, _tenantId);
            }

            if (_startsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(_startsOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (_expiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(_expiresOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrWhiteSpace(_service))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyService, _service);
            }

            if (!string.IsNullOrWhiteSpace(_version))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.KeyVersion, _version);
            }
        }
    }
}
