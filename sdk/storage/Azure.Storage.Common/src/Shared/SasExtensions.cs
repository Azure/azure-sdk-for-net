// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Extension methods for Sas.
    /// </summary>
    internal static partial class SasExtensions
    {
        /// <summary>
        /// Creates a string representing which resource types are allowed
        /// for <see cref="AccountSasBuilder.ResourceTypes"/>.
        /// </summary>
        /// <returns>
        /// A string representing which resource types are allowed.
        /// </returns>
        /// <remarks>
        /// The order here matches the order used by the portal when generating SAS signatures.
        /// </remarks>
        internal static string ToPermissionsString(this AccountSasResourceTypes resourceTypes)
        {
            var sb = new StringBuilder();
            if ((resourceTypes & AccountSasResourceTypes.Service) == AccountSasResourceTypes.Service)
            {
                sb.Append(Constants.Sas.AccountResources.Service);
            }
            if ((resourceTypes & AccountSasResourceTypes.Container) == AccountSasResourceTypes.Container)
            {
                sb.Append(Constants.Sas.AccountResources.Container);
            }
            if ((resourceTypes & AccountSasResourceTypes.Object) == AccountSasResourceTypes.Object)
            {
                sb.Append(Constants.Sas.AccountResources.Object);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a string representing which resource types are accessible
        /// from a shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which resource types are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasResourceTypes"/> instance.
        /// </returns>
        /// <remarks>
        /// The order here matches the order used by the portal when generating SAS signatures.
        /// </remarks>
        internal static AccountSasResourceTypes ParseResourceTypes(string s)
        {
            AccountSasResourceTypes types = default;
            foreach (var ch in s)
            {
                types |= ch switch
                {
                    Constants.Sas.AccountResources.Service => AccountSasResourceTypes.Service,
                    Constants.Sas.AccountResources.Container => AccountSasResourceTypes.Container,
                    Constants.Sas.AccountResources.Object => AccountSasResourceTypes.Object,
                    _ => throw Errors.InvalidResourceType(ch),
                };
            }
            return types;
        }

        private const string NoneName = null;
        private const string HttpsName = "https";
        private const string HttpsAndHttpName = "https,http";
        private const string HttpAndHttpsName = "http,https";

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
                case HttpAndHttpsName:
                    return SasProtocol.HttpsAndHttp;
                default:
                    throw Errors.InvalidSasProtocol(nameof(s), nameof(SasProtocol));
            }
        }

        /// <summary>
        /// Creates a string representing which services can be used for
        /// <see cref="AccountSasBuilder.Services"/>.
        /// </summary>
        /// <returns>
        /// A string representing which services are allowed.
        /// </returns>
        /// <remarks>
        /// The order here matches the order used by the portal when generating SAS signatures.
        /// </remarks>
        internal static string ToPermissionsString(this AccountSasServices services)
        {
            var sb = new StringBuilder();
            if ((services & AccountSasServices.Blobs) == AccountSasServices.Blobs)
            {
                sb.Append(Constants.Sas.AccountServices.Blob);
            }
            if ((services & AccountSasServices.Files) == AccountSasServices.Files)
            {
                sb.Append(Constants.Sas.AccountServices.File);
            }
            if ((services & AccountSasServices.Queues) == AccountSasServices.Queues)
            {
                sb.Append(Constants.Sas.AccountServices.Queue);
            }
            if ((services & AccountSasServices.Tables) == AccountSasServices.Tables)
            {
                sb.Append(Constants.Sas.AccountServices.Table);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Parse a string representing which services are accessible from a
        /// shared access signature.
        /// </summary>
        /// <param name="s">
        /// A string representing which services are accessible.
        /// </param>
        /// <returns>
        /// An <see cref="AccountSasServices"/> instance.
        /// </returns>
        internal static AccountSasServices ParseAccountServices(string s)
        {
            AccountSasServices svcs = default;
            foreach (var ch in s)
            {
                svcs |= ch switch
                {
                    Constants.Sas.AccountServices.Blob => AccountSasServices.Blobs,
                    Constants.Sas.AccountServices.Queue => AccountSasServices.Queues,
                    Constants.Sas.AccountServices.File => AccountSasServices.Files,
                    Constants.Sas.AccountServices.Table => AccountSasServices.Tables,
                    _ => throw Errors.InvalidService(ch),
                };
                ;
            }
            return svcs;
        }

        /// <summary>
        /// FormatTimesForSASSigning converts a time.Time to a snapshotTimeFormat string suitable for a
        /// SASField's StartTime or ExpiryTime fields. Returns "" if value.IsZero().
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal static string FormatTimesForSasSigning(DateTimeOffset time) =>
            // "yyyy-MM-ddTHH:mm:ssZ"
            (time == new DateTimeOffset()) ? "" : time.ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture);

        internal static string FormatRequestHeadersForSasSigning(Dictionary<string, List<string>> requestHeaders)
        {
            if (requestHeaders == null || requestHeaders.Count == 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var entry in requestHeaders)
            {
                sb
                .Append(entry.Key)
                .Append(':')
                .Append(string.Join(", ", entry.Value))
                .Append('\n');
            }
            return sb.ToString();
        }

        internal static string FormatRequestQueryParametersForSasSigning(Dictionary<string, List<string>> requestQueryParameters)
        {
            if (requestQueryParameters == null || requestQueryParameters.Count == 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var entry in requestQueryParameters)
            {
                sb
                .Append('\n')
                .Append(entry.Key)
                .Append(':')
                .Append(string.Join(",", entry.Value));
            }
            return sb.ToString();
        }

        internal static List<string> ConvertRequestDictToKeyList(Dictionary<string, List<string>> dict)
        {
            if (dict == null)
            {
                return null;
            }
            List<string> list = new List<string>();
            foreach (var kvp in dict)
            {
                list.Add(kvp.Key);
            }
            return list;
        }

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

        internal static string ValidateAndSanitizeRawPermissions(string permissions,
            List<char> validPermissionsInOrder)
        {
            if (permissions == null)
            {
                return null;
            }

            // Convert permissions string to lower case.
            permissions = permissions.ToLowerInvariant();

            HashSet<char> validPermissionsSet = new HashSet<char>(validPermissionsInOrder);
            HashSet<char> permissionsSet = new HashSet<char>();

            foreach (char permission in permissions)
            {
                // Check that each permission is a real SAS permission.
                if (!validPermissionsSet.Contains(permission))
                {
                    throw new ArgumentException($"{permission} is not a valid SAS permission");
                }

                // Add permission to permissionsSet for re-ordering.
                permissionsSet.Add(permission);
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (char permission in validPermissionsInOrder)
            {
                if (permissionsSet.Contains(permission))
                {
                    stringBuilder.Append(permission);
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// ComputeHMACSHA256 generates a base-64 hash signature string for an
        /// HTTP request or for a SAS.
        /// </summary>
        /// <param name="userDelegationKeyValue">
        /// A UserDelegationKey.Value used to sign with a key
        /// representing AD credentials.
        /// </param>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        internal static string ComputeHMACSHA256(string userDelegationKeyValue, string message) =>
            Convert.ToBase64String(
                new HMACSHA256(
                    Convert.FromBase64String(userDelegationKeyValue))
                .ComputeHash(Encoding.UTF8.GetBytes(message)));
    }
}
