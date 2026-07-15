// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary> Client options for <see cref="VoiceLiveClient"/>. </summary>
    public partial class VoiceLiveClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2026_07_15;

        /// <summary> Initializes a new instance of VoiceLiveClientOptions. </summary>
        /// <param name="version"> The service version. </param>
        public VoiceLiveClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2025_10_01 => "2025-10-01",
                ServiceVersion.V2026_01_01_PREVIEW => "2026-01-01-preview",
                ServiceVersion.V2026_04_10 => "2026-04-10",
                ServiceVersion.V2026_07_15 => "2026-07-15",
                _ => throw new NotSupportedException()
            };

            Headers = new Dictionary<string, string>();
        }

        /// <summary> Gets the Version. </summary>
        internal string Version { get; }

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> V2025_10_01. </summary>
            V2025_10_01 = 1,
            /// <summary>
            /// 2026-01-01-preview version.
            /// </summary>
            V2026_01_01_PREVIEW = 2,
            /// <summary>
            /// 2026-04-10 version.
            /// </summary>
            V2026_04_10 = 3,
            /// <summary>
            /// 2026-07-15 version.
            /// </summary>
            V2026_07_15 = 4
        }

        /// <summary>
        /// Additional headers to include on the initial connection.
        /// </summary>
        public IDictionary<string, string> Headers { get; }
    }
}
