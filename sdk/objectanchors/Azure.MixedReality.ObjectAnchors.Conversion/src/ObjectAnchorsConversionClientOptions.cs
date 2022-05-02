// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        private readonly HashSet<AssetFileType> _supportedAssetFileTypes;

        /// <summary>
        /// Gets the authentication endpoint.
        /// </summary>
        public Uri? MixedRealityAuthenticationEndpoint { get; set; }

        /// <summary>
        /// Gets the authentication options.
        /// </summary>
        public MixedRealityStsClientOptions? MixedRealityAuthenticationOptions { get; set; }

        /// <summary>
        /// Gets the service endpoint.
        /// </summary>
        public Uri? ServiceEndpoint { get; set; }

        /// <summary>
        /// Gets the list of supported asset file types.
        /// </summary>
        internal IReadOnlyCollection<AssetFileType> SupportedAssetFileTypes => _supportedAssetFileTypes;

        /// <summary>
        /// Gets the version.
        /// </summary>
        internal string Version { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClientOptions"/> class.
        /// </summary>
        /// <param name="version">The version.</param>
        public ObjectAnchorsConversionClientOptions(ServiceVersion version = ServiceVersion.V0_3_preview_0)
        {
            Version = version switch
            {
                ServiceVersion.V0_2_preview_0 => "0.2.preview.0",
                ServiceVersion.V0_3_preview_0 => "0.3-preview.0",
                _ => throw new ArgumentException($"The service version {version} is not supported by this library.", nameof(version))
            };

            _supportedAssetFileTypes = version switch
            {
                ServiceVersion.V0_2_preview_0 or ServiceVersion.V0_3_preview_0 => new HashSet<AssetFileType>
                {
                    AssetFileType.Fbx,
                    AssetFileType.Glb,
                    AssetFileType.Obj,
                    AssetFileType.Ply
                },
                _ => throw new InvalidOperationException()
            };
        }

        /// <summary>
        /// The Azure Spatial Anchors service version.
        /// </summary>
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores")]
        [SuppressMessage("Usage", "AZC0016:Invalid ServiceVersion member name.")]
        public enum ServiceVersion
        {
            /// <summary>
            /// Version 0.2-preview.0 of the Azure Object Anchors service.
            /// </summary>
            V0_2_preview_0 = 1,

            /// <summary>
            /// Version 0.3-preview.0 of the Azure Object Anchors service.
            /// </summary>
            V0_3_preview_0 = 2,
        }

        /// <summary>
        /// Gets a value indicating if the specified asset file type is supported.
        /// </summary>
        /// <param name="assertFileType">Type of the assert file.</param>
        /// <returns><c>true</c> if the asset file type is supported, <c>false</c> otherwise.</returns>
        internal bool IsFileTypeSupported(AssetFileType assertFileType)
            => _supportedAssetFileTypes.Contains(assertFileType);
    }
}
