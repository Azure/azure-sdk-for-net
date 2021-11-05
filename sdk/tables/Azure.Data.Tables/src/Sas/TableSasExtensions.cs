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
    internal static partial class TableSasExtensions
    {
        private const string NoneName = null;
        private const string HttpsName = "https";
        private const string HttpsAndHttpName = "https,http";

        /// <summary>
        /// Gets a string representation of the protocol.
        /// </summary>
        /// <returns>A string representation of the protocol.</returns>
        internal static string ToProtocolString(this TableSasProtocol protocol)
        {
            switch (protocol)
            {
                case TableSasProtocol.Https:
                    return HttpsName;
                case TableSasProtocol.HttpsAndHttp:
                    return HttpsAndHttpName;
                case TableSasProtocol.None:
                default:
                    return null;
            }
        }

        /// <summary>
        /// Parse a string representation of a protocol.
        /// </summary>
        /// <param name="s">A string representation of a protocol.</param>
        /// <returns>A <see cref="TableSasProtocol"/>.</returns>
        public static TableSasProtocol ParseProtocol(string s)
        {
            switch (s)
            {
                case NoneName:
                case "":
                    return TableSasProtocol.None;
                case HttpsName:
                    return TableSasProtocol.Https;
                case HttpsAndHttpName:
                    return TableSasProtocol.HttpsAndHttp;
                default:
                    throw Errors.InvalidSasProtocol(nameof(s), nameof(TableSasProtocol));
            }
        }

        /// <summary>
        /// Parse a string representing which resource types are accessible
        /// from a shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which resource types are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="TableAccountSasResourceTypes"/> instance.
        /// </returns>
        /// <remarks>
        /// The order here matches the order used by the portal when generating SAS signatures.
        /// </remarks>
        internal static TableAccountSasResourceTypes ParseResourceTypes(string s)
        {
            TableAccountSasResourceTypes types = default;
            foreach (var ch in s)
            {
                types |= ch switch
                {
                    TableConstants.Sas.TableAccountResources.Service => TableAccountSasResourceTypes.Service,
                    TableConstants.Sas.TableAccountResources.Container => TableAccountSasResourceTypes.Container,
                    TableConstants.Sas.TableAccountResources.Object => TableAccountSasResourceTypes.Object,
                    _ => throw Errors.InvalidResourceType(ch),
                };
            }
            return types;
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
        internal static void AppendProperties(this TableAccountSasQueryParameters parameters, StringBuilder stringBuilder)
        {
            if (!string.IsNullOrWhiteSpace(parameters.Version))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Version, parameters.Version);
            }

            if (!(parameters is TableSasQueryParameters))
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Services, TableConstants.Sas.TableAccountServices.Table);
            }

            if (parameters.ResourceTypes != null)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.ResourceTypes, parameters.ResourceTypes.Value.ToPermissionsString());
            }

            if (parameters.Protocol != default)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.Protocol, parameters.Protocol.ToProtocolString());
            }

            if (parameters.StartsOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.StartTime, WebUtility.UrlEncode(parameters.StartsOnString));
            }

            if (parameters.ExpiresOn != DateTimeOffset.MinValue)
            {
                stringBuilder.AppendQueryParameter(TableConstants.Sas.Parameters.ExpiryTime, WebUtility.UrlEncode(parameters.ExpiresOnString));
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
