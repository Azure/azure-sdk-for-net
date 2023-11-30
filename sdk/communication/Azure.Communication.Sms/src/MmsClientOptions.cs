// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The options for communication <see cref="MmsClient"/>.
    /// </summary>
    public class MmsClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Mms service.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V2024_01_14_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MmsClientOptions"/>.
        /// </summary>
        public MmsClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2024_01_14_Preview => "2024-01-14-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Mms service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The version of the Mms service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2024_01_14_Preview = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
