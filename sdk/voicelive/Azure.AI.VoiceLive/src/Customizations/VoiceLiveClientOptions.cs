// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary> Client options for <see cref="VoiceLiveClient"/>. </summary>
    public partial class VoiceLiveClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2025_10_01;

        /// <summary> Initializes a new instance of VoiceLiveClientOptions. </summary>
        /// <param name="version"> The service version. </param>
        public VoiceLiveClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2025_10_01 => "2025-10-01",
                ServiceVersion.V2026_01_01_PREVIEW => "2026-01-01-preview",
                _ => throw new NotSupportedException()
            };

            InternalOptions = new VoiceLiveClientOptionsInternal();
            Headers = new Dictionary<string, string>();
        }

        internal VoiceLiveClientOptionsInternal InternalOptions { get; }

        /// <summary>
        /// Gets the client diagnostic options.
        /// </summary>
        public DiagnosticsOptions Diagnostics { get => InternalOptions.Diagnostics; }

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
            V2026_01_01_PREVIEW = 2
        }

        /// <summary>
        /// Additional headers to include on the initial connection.
        /// </summary>
        public IDictionary<string, string> Headers { get; }
    }
}
