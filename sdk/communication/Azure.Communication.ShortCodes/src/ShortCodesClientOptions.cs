// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.ShortCodes
{
    /// <summary>
    /// The options for communication <see cref="ShortCodesClient"/>.
    /// </summary>
    public class ShortCodesClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Short Code service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2021_10_25_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortCodesClientOptions"/>.
        /// </summary>
        public ShortCodesClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_10_25_Preview => "2021-10-25-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Short Code service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Short Code service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_10_25_Preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
