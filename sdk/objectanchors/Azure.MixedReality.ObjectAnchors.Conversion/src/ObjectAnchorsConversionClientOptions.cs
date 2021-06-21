// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.MixedReality.Authentication;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// The <see cref="ObjectAnchorsConversionClientOptions"/>.
    /// Implements the <see cref="Azure.Core.ClientOptions" />.
    /// </summary>
    /// <seealso cref="Azure.Core.ClientOptions" />
    public class ObjectAnchorsConversionClientOptions : ClientOptions
    {
        internal string Version { get; }

        /// <summary>
        /// Gets the list of supported asset file types
        /// </summary>
        internal HashSet<AssetFileType> SupportedAssetFileTypes { get; }

        /// <summary>
        /// Gets the authentication endpoint.
        /// </summary>
        public Uri MixedRealityAuthenticationEndpoint { get; set; }

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        public Uri ServiceEndpoint { get; set; }

        /// <summary>
        /// Gets the authentication options.
        /// </summary>
        public MixedRealityStsClientOptions MixedRealityAuthenticationOptions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        public ObjectAnchorsConversionClientOptions(ServiceVersion version = ServiceVersion.V0_2_preview_0)
        {
            Version = version switch
            {
                ServiceVersion.V0_2_preview_0 => "0.2-preview.0",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };

            SupportedAssetFileTypes = version switch
            {
                ServiceVersion.V0_2_preview_0 => new HashSet<AssetFileType>
                {
                    AssetFileType.Fbx,
                    AssetFileType.Glb,
                    AssetFileType.Gltf,
                    AssetFileType.Obj,
                    AssetFileType.Ply
                },
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// The Azure Spatial Anchors service version.
        /// </summary>
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 0.2-preview.0 of the Azure Object Anchors service.
            /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
            V0_2_preview_0 = 1,
#pragma warning restore CA1707 // Identifiers should not contain underscores
        }
    }
}
