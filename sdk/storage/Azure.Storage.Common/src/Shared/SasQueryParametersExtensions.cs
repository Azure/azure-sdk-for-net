// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Text;

namespace Azure.Storage.Sas
{
    internal static class SasQueryParametersExtensions
    {
        /// <summary>
        /// Helper method to add query param key value pairs to StringBuilder
        /// </summary>
        /// <param name="sb">StringBuilder instance</param>
        /// <param name="key">query key</param>
        /// <param name="value">query value</param>
        internal static void AddToBuilder(StringBuilder sb, string key, string value) =>
            sb
            .Append(sb.Length > 0 ? "&" : "")
            .Append(key)
            .Append('=')
            .Append(value);

        /// <summary>
        /// Builds the query parameter string for the SasQueryParameters instance.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="stringBuilder">
        /// StringBuilder instance to add the query params to
        /// </param>
        internal static void BuildParameterString(this SasQueryParameters parameters, StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(parameters.Version))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Version, parameters.Version);
            }

            if (parameters.Services != null)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Services, parameters.Services.Value.ToPermissionsString());
            }

            if (parameters.ResourceTypes != null)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ResourceTypes, parameters.ResourceTypes.Value.ToPermissionsString());
            }

            if (parameters.Protocol != default)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Protocol, parameters.Protocol.ToProtocolString());
            }

            if (parameters.StartsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.StartTime, WebUtility.UrlEncode(parameters.StartsOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (parameters.ExpiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(parameters.ExpiresOn.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            var ipr = parameters.IPRange.ToString();
            if (ipr.Length > 0)
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.IPRange, ipr);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Identifier))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Identifier, parameters.Identifier);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Resource))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Resource, parameters.Resource);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Permissions))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Permissions, parameters.Permissions);
            }

            if (!string.IsNullOrWhiteSpace(parameters.CacheControl))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.CacheControl, parameters.CacheControl);
            }

            if (!string.IsNullOrWhiteSpace(parameters.ContentDisposition))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentDisposition, parameters.ContentDisposition);
            }

            if (!string.IsNullOrWhiteSpace(parameters.ContentEncoding))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentEncoding, parameters.ContentEncoding);
            }

            if (!string.IsNullOrWhiteSpace(parameters.ContentLanguage))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentLanguage, parameters.ContentLanguage);
            }

            if (!string.IsNullOrWhiteSpace(parameters.ContentType))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.ContentType, parameters.ContentType);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Signature))
            {
                stringBuilder.AppendQueryParameter(Constants.Sas.Parameters.Signature, WebUtility.UrlEncode(parameters.Signature));
            }
        }
    }
}
