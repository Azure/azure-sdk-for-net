// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.MixedReality.ObjectAnchors.Conversion.Models;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// Object Understanding model factory that enables mocking for the Object Understanding client library.
    /// </summary>
    public static class ObjectAnchorsConversionModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionConfiguration"/> for mocking purposes.
        /// </summary>
        /// <param name="assetDimensions"> Dimensions of the asset. </param>
        /// <param name="boundingBoxCenter"> BoundingBoxCenter of the asset. </param>
        /// <param name="gravity"> Gravity vector with respect to object's nominal position. </param>
        /// <param name="keyFrameIndexes"> Indices of Key Frames. </param>
        /// <param name="groundTruthTrajectoryCameraPoses"> Ground truth trajectory. </param>
        /// <param name="principalAxis"> Orientation of model's bounding box. </param>
        /// <param name="scale"> Scale of transformation of asset units into meter space. </param>
        /// <param name="disableDetectScaleUnits">Whether or not disable automatic detection of FBX scale units.</param>
        /// <param name="supportingPlane"> Definition of supporting plane. </param>
        /// <param name="testTrajectoryCameraPoses"> Test Trajectory. </param>
        /// <returns> A new instance of the <see cref="AssetConversionConfiguration"/> for mocking purposes. </returns>
        public static AssetConversionConfiguration AssetConversionConfiguration(
            System.Numerics.Vector3 assetDimensions,
            System.Numerics.Vector3 boundingBoxCenter,
            System.Numerics.Vector3 gravity,
            IReadOnlyList<int> keyFrameIndexes,
            IReadOnlyList<TrajectoryPose> groundTruthTrajectoryCameraPoses,
            System.Numerics.Quaternion principalAxis,
            float scale,
            bool disableDetectScaleUnits,
            System.Numerics.Vector4 supportingPlane,
            IReadOnlyList<TrajectoryPose> testTrajectoryCameraPoses)
        {
            return new AssetConversionConfiguration(new Vector3(assetDimensions), new Vector3(boundingBoxCenter), new Vector3(gravity), keyFrameIndexes, groundTruthTrajectoryCameraPoses, new Quaternion(principalAxis), scale, disableDetectScaleUnits, new Vector4(supportingPlane), testTrajectoryCameraPoses);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="clientErrorDetails"> Information about the cause of a ClientError AssetConversionStatus. </param>
        /// <param name="serverErrorDetails"> Information about the cause of a ServerError AssetConversionStatus. </param>
        /// <param name="conversionErrorCode">The error code of the AOA asset conversion job.</param>
        /// <param name="jobId"> Identifier for the AOA Asset Conversion Job. </param>
        /// <param name="outputModelUri"> The URI for downloading the generated AOA Model. </param>
        /// <param name="assetConversionStatus"> The status of the AOA asset conversion job. </param>
        /// <param name="assetFileType"> The file type of the original 3D asset. Examples include: &quot;ply&quot;, &quot;obj&quot;, &quot;fbx&quot;, &quot;glb&quot;, &quot;gltf&quot;, etc. </param>
        /// <param name="uploadedInputAssetUri"> The Uri to the Asset to be ingested by the AOA Asset Conversion Service. This asset needs to have been uploaded to the service using an endpoint provided from a call to the GetUploadUri API. </param>
        /// <param name="accountId"> Identifier for the Account owning the AOA asset conversion Job. </param>
        /// <param name="assetConversionConfiguration"> The configuration of the AOA asset conversion job. </param>
        /// <param name="scaledAssetDimensions">The scaled dimensions of the asset.</param>
        /// <returns> A new instance of the <see cref="AssetConversionProperties"/> for mocking purposes. </returns>
        public static AssetConversionProperties AssetConversionProperties(
            string clientErrorDetails,
            string serverErrorDetails,
            ConversionErrorCode conversionErrorCode,
            Guid? jobId,
            Uri outputModelUri,
            AssetConversionStatus? assetConversionStatus,
            AssetFileType assetFileType,
            Uri uploadedInputAssetUri,
            Guid? accountId,
            AssetConversionConfiguration assetConversionConfiguration,
            System.Numerics.Vector3 scaledAssetDimensions)
        {
            return new AssetConversionProperties(
            clientErrorDetails,
            serverErrorDetails,
            conversionErrorCode,
            jobId,
            outputModelUri.AbsoluteUri,
            assetConversionStatus,
            assetFileType.ToString(),
            uploadedInputAssetUri.AbsoluteUri,
            accountId,
            assetConversionConfiguration,
            new Vector3(scaledAssetDimensions));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrajectoryPose"/> for mocking purposes.
        /// </summary>
        /// <param name="rotation"> The pose's rotation. </param>
        /// <param name="translation"> The pose's translation. </param>
        /// <returns> A new instance of the <see cref="TrajectoryPose"/> for mocking purposes. </returns>
        public static TrajectoryPose TrajectoryPose(System.Numerics.Quaternion rotation, System.Numerics.Vector3 translation)
        {
            return new TrajectoryPose(rotation, translation);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetUploadUriResult"/> for mocking purposes.
        /// </summary>
        /// <param name="uploadedInputAssetUri"> The blob upload URI where a model should be uploaded to the service for conversion. </param>
        /// <returns> A new instance of the <see cref="GetAssetUploadUriResult"/> for mocking purposes. </returns>
        public static AssetUploadUriResult GetAssetUploadUriResult(Uri uploadedInputAssetUri)
        {
            return new AssetUploadUriResult(uploadedInputAssetUri.AbsoluteUri);
        }
    }
}
