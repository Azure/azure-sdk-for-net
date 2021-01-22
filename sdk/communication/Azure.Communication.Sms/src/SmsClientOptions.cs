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
        private const ServiceVersion LatestVersion = ServiceVersion.V1;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsClientOptions"/>.
        /// </summary>
        public SmsClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V1 => "2020-07-20-preview1",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The Sms service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Sms service.
            /// </summary>
            V1 = 1
        }
    }
}
