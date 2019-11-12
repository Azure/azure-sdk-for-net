// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Sas
{
    /// <summary>
    /// Extension methods for Sas.
    /// </summary>
    [Obsolete("This type is only available for backwards compatibility with the 12.0.0 version of Storage libraries. It should not be used for new development.", true)]
    internal static partial class SasExtensions
    {
        /// <summary>
        /// Creates a string representing which resource types are allowed
        /// for <see cref="AccountSasBuilder.ResourceTypes"/>.
        /// </summary>
        /// <returns>
        /// A string representing which resource types are allowed.
        /// </returns>
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
        /// Creates a string representing which services can be used for
        /// <see cref="AccountSasBuilder.Services"/>.
        /// </summary>
        /// <returns>
        /// A string representing which services are allowed.
        /// </returns>
        internal static string ToPermissionsString(this AccountSasServices services)
        {
            var sb = new StringBuilder();
            if ((services & AccountSasServices.Blobs) == AccountSasServices.Blobs)
            {
                sb.Append(Constants.Sas.AccountServices.Blob);
            }
            if ((services & AccountSasServices.Queues) == AccountSasServices.Queues)
            {
                sb.Append(Constants.Sas.AccountServices.Queue);
            }
            if ((services & AccountSasServices.Files) == AccountSasServices.Files)
            {
                sb.Append(Constants.Sas.AccountServices.File);
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
                    _ => throw Errors.InvalidService(ch),
                };
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
            (time == new DateTimeOffset()) ? "" : time.ToString(Constants.SasTimeFormat, CultureInfo.InvariantCulture);
    }
}
