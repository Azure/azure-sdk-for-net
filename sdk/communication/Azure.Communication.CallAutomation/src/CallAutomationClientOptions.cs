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
        internal const ServiceVersion LatestVersion = ServiceVersion.V2023_01_15_Preview;

        internal string ApiVersion { get; }

        internal CommunicationUserIdentifier Source { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallAutomationClientOptions"/>.
        /// </summary>
        public CallAutomationClientOptions(ServiceVersion version = LatestVersion, CommunicationUserIdentifier source = null)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2023_01_15_Preview => "2023-01-15-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
            Source = source;
        }

        /// <summary>
        /// The CallAutomation service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The Beta of the CallAutomation service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2023_01_15_Preview = 1
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
