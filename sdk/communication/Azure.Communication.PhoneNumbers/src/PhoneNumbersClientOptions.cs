// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// The options for phone number management client options. <see cref="PhoneNumbersClientOptions"/>
    /// </summary>
    public class PhoneNumbersClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the Phone number management service.
        /// </summary>
        public const ServiceVersion LatestVersion = ServiceVersion.V2021_03_07;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumbersClientOptions"/>.
        /// </summary>
        public PhoneNumbersClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2021_03_07 => "2021_03_07",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The phone number configuration service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V2021_03_07  of the phone number configuration service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2021_03_07 = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
