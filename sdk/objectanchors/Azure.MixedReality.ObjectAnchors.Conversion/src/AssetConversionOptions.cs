// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    using Azure.Core;
    using System;

    /// <summary>
    /// Represents an Object Anchors asset conversion job request's options.
    /// </summary>
    public class AssetConversionOptions
    {
        /// <summary>
        /// Gets the asset configuration values.
        /// </summary>
        internal AssetConversionConfiguration ConversionConfiguration { get; }

        /// <summary>
        /// The file type of the asset.
        /// </summary>
        public AssetFileType InputAssetFileType { get; }

        /// <summary>
        /// The path to the Asset to be ingested by the Object Anchors service.
        /// </summary>
        public Uri InputAssetUri { get; }

        /// <summary>
        /// Identifier for the Object Anchors Asset Conversion job.
        /// </summary>
        public Guid JobId { get; set; } = Guid.NewGuid();

        /// <summary> Gravity vector with respect to object's nominal position. </summary>
        public System.Numerics.Vector3 Gravity { get => ConversionConfiguration.Gravity; }

        /// <summary> Scale of transformation of asset units into meter space. </summary>
        public float Scale { get => ConversionConfiguration.Scale; }

        /// <summary> Whether or not disable automatic detection of FBX scale units. </summary>
        public bool DisableDetectScaleUnits { get => ConversionConfiguration.DisableDetectScaleUnits; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionOptions"/> class.
        /// </summary>
        /// <param name="inputAssetUri">The path to the Asset in storage to be ingested by the Object Anchors service.</param>
        /// <param name="assetGravity">The asset gravity.</param>
        /// <param name="assetScale">The asset scale.</param>
        /// <param name="disableDetectScaleUnits">Whether or not disable automatic detection of FBX scale units.</param>
        /// <param name="inputAssetFileType">The model's file type.</param>
        public AssetConversionOptions(Uri inputAssetUri, AssetFileType inputAssetFileType, System.Numerics.Vector3 assetGravity, float assetScale, bool disableDetectScaleUnits = false)
            : this(inputAssetUri, inputAssetFileType, new AssetConversionConfiguration(assetGravity, assetScale, disableDetectScaleUnits))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionOptions"/> class.
        /// </summary>
        /// <param name="inputAssetUri">The path to the Asset to be ingested by the Object Anchors service.</param>
        /// <param name="assetGravity">The asset gravity.</param>
        /// <param name="unit">The unit of measurement, which is translated to a numeric scale for the model.</param>
        /// <param name="disableDetectScaleUnits">Whether or not disable automatic detection of FBX scale units.</param>
        /// <param name="inputAssetFileType">The model's file type.</param>
        public AssetConversionOptions(Uri inputAssetUri, AssetFileType inputAssetFileType, System.Numerics.Vector3 assetGravity, AssetLengthUnit unit, bool disableDetectScaleUnits = false)
            : this(inputAssetUri, inputAssetFileType, new AssetConversionConfiguration(assetGravity, AssetScaleGenerator.GetAssetScale(unit), disableDetectScaleUnits))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionOptions"/> class.
        /// </summary>
        /// <param name="inputAssetUri">The path to the Asset to be ingested by the Object Anchors service.</param>
        /// <param name="conversionConfiguration">The asset configuration.</param>
        /// <param name="inputAssetFileType">The model's file type.</param>
        internal AssetConversionOptions(Uri inputAssetUri, AssetFileType inputAssetFileType, AssetConversionConfiguration conversionConfiguration)
        {
            Argument.AssertNotNull(inputAssetUri, nameof(inputAssetUri));
            Argument.AssertNotNull(conversionConfiguration, nameof(conversionConfiguration));

            if (!conversionConfiguration.IsValid(out string assetConfigurationInvalidMessage))
            {
                throw new ArgumentException(assetConfigurationInvalidMessage, nameof(conversionConfiguration));
            }

            this.InputAssetUri = inputAssetUri;
            this.InputAssetFileType = inputAssetFileType;
            this.ConversionConfiguration = conversionConfiguration;
        }
    }
}
