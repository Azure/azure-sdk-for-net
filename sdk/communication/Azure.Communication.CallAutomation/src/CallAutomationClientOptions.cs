// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The latest version of the Call Automation.
    /// </summary>
    public class CallAutomationClientOptions : ClientOptions
    {
        /// <summary>
        /// The latest version of the CallAutomation service.
        /// </summary>
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_10_03_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// The caller source of the call automation client.
        /// </summary>
        public CommunicationUserIdentifier Source { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallAutomationClientOptions"/>.
        /// </summary>
        public CallAutomationClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2023_03_06 => "2023-03-06",
                ServiceVersion.V2023_06_15_Preview => "2023-06-15-preview",
                ServiceVersion.V2023_10_15 => "2023-10-15",
                ServiceVersion.V2023_10_03_Preview => "2023-10-03-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }

        /// <summary>
        /// The CallAutomation service version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The GA1 (1.0.0) of the CallAutomation service.
            /// </summary>
            V2023_03_06 = 1,

            /// <summary>
            /// The BETA2 (1.1.0-beta) of the CallAutomation service.
            /// </summary>
            V2023_06_15_Preview = 2,

            /// <summary>
            /// The GA2 (1.1.0) of the CallAutomation service.
            /// </summary>
            V2023_10_15 = 3,

            /// <summary>
            /// Latest ALPHA3 (1.2.0-alpha) preview of the CallAutomation service.
            /// </summary>
            V2023_10_03_Preview = 4
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
