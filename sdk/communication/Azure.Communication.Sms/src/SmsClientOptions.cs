// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.Sms
{
    /// <summary>
    /// The options for communication <see cref="SmsClient"/>.
    /// </summary>
    public class SmsClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Sms service.
        /// </summary>
        private const ServiceVersion LatestVersion = ServiceVersion.V2025_05_29_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsClientOptions"/>.
        /// </summary>
        public SmsClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_03_07 => "2021-03-07",
                ServiceVersion.V2025_05_29_Preview => "2025-05-29-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Sms service version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The "2021-03-07" version of the Sms service.
            /// </summary>
            V2021_03_07 = 1,
            /// <summary>
            /// The "2025-05-29-preview" of the Sms service.
            /// </summary>
            V2025_05_29_Preview = 2
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
