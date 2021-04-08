// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Models
{
    /// <summary> The ConversionErrorCode. </summary>
    public readonly partial struct ConversionErrorCode
    {
        /// <summary> UNKNOWN. </summary>
        [CodeGenMember("Unknown")]
        public static ConversionErrorCode Unknown { get; } = new ConversionErrorCode(UnknownValue);
        /// <summary> NO_ERROR. </summary>
        [CodeGenMember("NOError")]
        public static ConversionErrorCode NoError { get; } = new ConversionErrorCode(NoErrorValue);
        /// <summary> SERVICE_ERROR. </summary>
        [CodeGenMember("ServiceError")]
        public static ConversionErrorCode ServiceError { get; } = new ConversionErrorCode(ServiceErrorValue);
        /// <summary> INVALID_ASSET_URI. </summary>
        [CodeGenMember("InvalidAssetURI")]
        public static ConversionErrorCode InvalidAssetUri { get; } = new ConversionErrorCode(InvalidAssetUriValue);
        /// <summary> INVALID_JOB_ID. </summary>
        [CodeGenMember("InvalidJOBID")]
        public static ConversionErrorCode InvalidJobId { get; } = new ConversionErrorCode(InvalidJobIdValue);
        /// <summary> INVALID_GRAVITY. </summary>
        [CodeGenMember("InvalidGravity")]
        public static ConversionErrorCode InvalidGravity { get; } = new ConversionErrorCode(InvalidGravityValue);
        /// <summary> INVALID_SCALE. </summary>
        [CodeGenMember("InvalidScale")]
        public static ConversionErrorCode InvalidScale { get; } = new ConversionErrorCode(InvalidScaleValue);
        /// <summary> ASSET_SIZE_TOO_LARGE. </summary>
        [CodeGenMember("AssetSizeTOOLarge")]
        public static ConversionErrorCode AssetSizeTooLarge { get; } = new ConversionErrorCode(AssetSizeTooLargeValue);
        /// <summary> ASSET_DIMENSIONS_OUT_OF_BOUNDS. </summary>
        [CodeGenMember("AssetDimensionsOUTOFBounds")]
        public static ConversionErrorCode AssetDimensionsOutOfBounds { get; } = new ConversionErrorCode(AssetDimensionsOutOfBoundsValue);
        /// <summary> ZERO_FACES. </summary>
        [CodeGenMember("ZeroFaces")]
        public static ConversionErrorCode ZeroFaces { get; } = new ConversionErrorCode(ZeroFacesValue);
        /// <summary> INVALID_FACE_VERTICES. </summary>
        [CodeGenMember("InvalidFaceVertices")]
        public static ConversionErrorCode InvalidFaceVertices { get; } = new ConversionErrorCode(InvalidFaceVerticesValue);
        /// <summary> ZERO_TRAJECTORIES_GENERATED. </summary>
        [CodeGenMember("ZeroTrajectoriesGenerated")]
        public static ConversionErrorCode ZeroTrajectoriesGenerated { get; } = new ConversionErrorCode(ZeroTrajectoriesGeneratedValue);
        /// <summary> TOO_MANY_RIG_POSES. </summary>
        [CodeGenMember("TOOManyRIGPoses")]
        public static ConversionErrorCode TooManyRigPoses { get; } = new ConversionErrorCode(TooManyRigPosesValue);
        /// <summary> ASSET_CANNOT_BE_CONVERTED. </summary>
        [CodeGenMember("AssetCannotBEConverted")]
        public static ConversionErrorCode AssetCannotBeConverted { get; } = new ConversionErrorCode(AssetCannotBeConvertedValue);
    }
}
