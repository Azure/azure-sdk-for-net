// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.MediaComposition
{
    /// <summary> Client options for Media Composition Client. </summary>
    public partial class MediaCompositionClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2022_07_16_Preview;

        internal string ApiVersion { get; }

        /// <summary> Initializes new instance of MediaCompositionClientOptions. </summary>
        public MediaCompositionClientOptions(ServiceVersion version = LatestVersion)
        {
            ApiVersion = version switch
            {
                ServiceVersion.V2022_07_16_Preview => "2022-07-16-preview",
                _ => throw new NotSupportedException()
            };
        }

        /// <summary> The Media Composition Version. </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// The V1 of the Media Composition service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V2022_07_16_Preview = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
