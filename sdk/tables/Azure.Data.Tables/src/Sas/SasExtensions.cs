// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Text;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// Extension methods for Sas.
    /// </summary>
    internal static partial class SasExtensions
    {
        private const string NoneName = null;
        private const string HttpsName = "https";
        private const string HttpsAndHttpName = "https,http";

        /// <summary>
        /// Gets a string representation of the protocol.
        /// </summary>
        /// <returns>A string representation of the protocol.</returns>
        internal static string ToProtocolString(this SasProtocol protocol)
        {
            switch (protocol)
            {
                case SasProtocol.Https:
                    return HttpsName;
                case SasProtocol.HttpsAndHttp:
                    return HttpsAndHttpName;
                case SasProtocol.None:
                default:
                    return null;
            }
        }

        /// <summary>
        /// Parse a string representation of a protocol.
        /// </summary>
        /// <param name="s">A string representation of a protocol.</param>
        /// <returns>A <see cref="SasProtocol"/>.</returns>
        public static SasProtocol ParseProtocol(string s)
        {
            switch (s)
            {
                case NoneName:
                case "":
                    return SasProtocol.None;
                case HttpsName:
                    return SasProtocol.Https;
                case HttpsAndHttpName:
                    return SasProtocol.HttpsAndHttp;
                default:
                    throw Errors.InvalidSasProtocol(nameof(s), nameof(SasProtocol));
            }
        }

        /// <summary>
        /// FormatTimesForSASSigning converts a time.Time to a snapshotTimeFormat string suitable for a
        /// SASField's StartTime or ExpiryTime fields. Returns "" if value.IsZero().
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal static string FormatTimesForSasSigning(DateTimeOffset time) =>
            // "yyyy-MM-ddTHH:mm:ssZ"
            (time == new DateTimeOffset()) ? "" : time.ToString(TableConstants.Sas.SasTimeFormat, CultureInfo.InvariantCulture);

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
        internal static void AppendProperties(this TableSasQueryParameters parameters, StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(parameters.Version))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Version, parameters.Version);
            }

            if (parameters.Protocol != default)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Protocol, parameters.Protocol.ToProtocolString());
            }

            if (parameters.StartsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.StartTime, WebUtility.UrlEncode(parameters.StartsOn.ToString(TableConstants.Sas.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            if (parameters.ExpiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(parameters.ExpiresOn.ToString(TableConstants.Sas.SasTimeFormat, CultureInfo.InvariantCulture)));
            }

            var ipr = parameters.IPRange.ToString();
            if (ipr.Length > 0)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.IPRange, ipr);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Identifier))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Identifier, parameters.Identifier);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Resource))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Resource, parameters.Resource);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Permissions))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Permissions, parameters.Permissions);
            }

            if (!string.IsNullOrWhiteSpace(parameters.Signature))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Signature, WebUtility.UrlEncode(parameters.Signature));
            }
        }

        /// <summary>
        /// Appends a query parameter to the string builder.
        /// </summary>
        /// <param name="sb">string builder instance.</param>
        /// <param name="key">query parameter key.</param>
        /// <param name="value">query parameter value.</param>
        internal static void AppendQueryParameter(this StringBuilder sb, string key, string value) =>
            sb
            .Append(sb.Length > 0 ? "&" : "")
            .Append(key)
            .Append('=')
            .Append(value);
    }
}
