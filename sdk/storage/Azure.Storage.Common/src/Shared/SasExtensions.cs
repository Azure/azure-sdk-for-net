// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

#if CommonSDK
using Internals = Azure.Storage.Shared.Common;
namespace Azure.Storage.Sas.Shared.Common
#else
using Internals = Azure.Storage.Shared;
namespace Azure.Storage.Sas.Shared
#endif
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
        internal static string ToPermissionsString(this AccountSasResourceTypes resourceTypes)
        {
            var sb = new StringBuilder();
            if ((resourceTypes & AccountSasResourceTypes.Service) == AccountSasResourceTypes.Service)
            {
                sb.Append(Internals.Constants.Sas.AccountResources.Service);
            }
            if ((resourceTypes & AccountSasResourceTypes.Container) == AccountSasResourceTypes.Container)
            {
                sb.Append(Internals.Constants.Sas.AccountResources.Container);
            }
            if ((resourceTypes & AccountSasResourceTypes.Object) == AccountSasResourceTypes.Object)
            {
                sb.Append(Internals.Constants.Sas.AccountResources.Object);
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
                    Internals.Constants.Sas.AccountResources.Service => AccountSasResourceTypes.Service,
                    Internals.Constants.Sas.AccountResources.Container => AccountSasResourceTypes.Container,
                    Internals.Constants.Sas.AccountResources.Object => AccountSasResourceTypes.Object,
                    _ => throw Internals.Errors.InvalidResourceType(ch),
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
                    throw Internals.Errors.InvalidSasProtocol(nameof(s), nameof(SasProtocol));
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
                sb.Append(Internals.Constants.Sas.AccountServices.Blob);
            }
            if ((services & AccountSasServices.Queues) == AccountSasServices.Queues)
            {
                sb.Append(Internals.Constants.Sas.AccountServices.Queue);
            }
            if ((services & AccountSasServices.Files) == AccountSasServices.Files)
            {
                sb.Append(Internals.Constants.Sas.AccountServices.File);
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
                    Internals.Constants.Sas.AccountServices.Blob => AccountSasServices.Blobs,
                    Internals.Constants.Sas.AccountServices.Queue => AccountSasServices.Queues,
                    Internals.Constants.Sas.AccountServices.File => AccountSasServices.Files,
                    _ => throw Internals.Errors.InvalidService(ch),
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
            (time == new DateTimeOffset()) ? "" : time.ToString(Internals.Constants.SasTimeFormat, CultureInfo.InvariantCulture);
    }
}
