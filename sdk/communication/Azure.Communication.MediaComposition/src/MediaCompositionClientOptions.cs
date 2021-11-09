// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.MediaComposition
{
    /// <summary>
    /// The options for the Media Composition client.
    /// </summary>
    public class MediaCompositionClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2021_12_31_Preview;

        internal string ApiVersion { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaCompositionClientOptions"/> class.
        /// </summary>
        public MediaCompositionClientOptions(ServiceVersion serviceVersion = LatestVersion)
        {
            ApiVersion = serviceVersion switch
            {
                ServiceVersion.V2021_12_31_Preview => "2021-12-31-preview",
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion))
            };
        }

        /// <summary>
        /// The Media Composition service version.
        /// </summary>
        public enum ServiceVersion
        {
#pragma warning disable CA1707 // Identifiers should not contain underscores
            /// <summary>
            /// The Private Preview of the Media Composition service.
            /// </summary>
            V2021_12_31_Preview = 1
#pragma warning restore CA1707
        }
    }
}
