// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary> Client options for <see cref="VoiceLiveClient"/>. </summary>
    public partial class VoiceLiveClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2025_05_01_Preview;

        /// <summary> Initializes a new instance of VoiceLiveClientOptions. </summary>
        /// <param name="version"> The service version. </param>
        public VoiceLiveClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2025_05_01_Preview => "2025-05-01-preview",
                _ => throw new NotSupportedException()
            };
        }

        /// <summary> Gets the Version. </summary>
        internal string Version { get; }

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> V2025_05_01_Preview. </summary>
            V2025_05_01_Preview = 1
        }
    }
}
