// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Text;

namespace Azure.Storage.Sas
{
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
        /// Convert the SAS query parameters into a URL encoded query string.
        /// </summary>
        /// <returns>
        /// A URL encoded query string representing the SAS.
        /// </returns>

        public override string ToString()
        {

            var sb = new StringBuilder();

            void AddToBuilder(string key, string value)
            =>
            sb
            .Append(sb.Length > 0 ? "&" : "")
            .Append(key)
            .Append('=')
            .Append(value);

            if (!string.IsNullOrWhiteSpace(_objectId))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyObjectId, _objectId);
            }

            if (!string.IsNullOrWhiteSpace(_tenantId))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyTenantId, _tenantId);
            }

            if (_startsOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.KeyStart, WebUtility.UrlEncode(_startsOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (_expiresOn != DateTimeOffset.MinValue)
            {
                AddToBuilder(Constants.Sas.Parameters.KeyExpiry, WebUtility.UrlEncode(_expiresOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (!string.IsNullOrWhiteSpace(_service))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyService, _service);
            }

            if (!string.IsNullOrWhiteSpace(_version))
            {
                AddToBuilder(Constants.Sas.Parameters.KeyVersion, _version);
            }

            return sb.ToString();

        }
    }
}
