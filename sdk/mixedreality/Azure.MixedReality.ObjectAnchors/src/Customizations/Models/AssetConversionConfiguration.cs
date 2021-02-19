// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.MixedReality.ObjectAnchors.Models;

namespace Azure.MixedReality.ObjectAnchors
{
    /// <summary> Represents an asset conversion configuration. </summary>
    [CodeGenModel("IngestionConfiguration")]
    public partial class AssetConversionConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetConversionConfiguration"/> class.
        /// </summary>
        /// <param name="gravity">The asset gravity, which must be normalized.</param>
        /// <param name="scale">The asset scale.</param>
        internal AssetConversionConfiguration(System.Numerics.Vector3 gravity, float scale) : this(new Vector3(gravity), scale)
        {
            if (!gravity.IsNormalized())
            {
                throw new ArgumentException("The value must be normalized.", nameof(gravity));
            }
        }

        internal AssetConversionConfiguration(Vector3 gravityWrapper, float scale)
        {
            if (gravityWrapper == null)
            {
                throw new ArgumentNullException(nameof(gravityWrapper));
            }

            GravityWrapper = gravityWrapper;
            KeyFrameIndexes = new ChangeTrackingList<int>();
            GroundTruthTrajectoryCameraPoses = new List<TrajectoryPose>();
            Scale = scale;
            TestTrajectoryCameraPoses = new List<TrajectoryPose>();
        }

        /// <summary> Scale of transformation of asset units into meter space. </summary>
        public float Scale { get; internal set; }
        /// <summary> Ground truth trajectory. </summary>
        [CodeGenMember("GtTrajectory")]
        public IReadOnlyList<TrajectoryPose> GroundTruthTrajectoryCameraPoses { get; }
        /// <summary> Dimensions of the asset. </summary>
        public System.Numerics.Vector3? AssetDimensions { get => AssetDimensionsWrapper == null ? null : AssetDimensionsWrapper.data; }
        /// <summary> BoundingBoxCenter of the asset. </summary>
        public System.Numerics.Vector3? BoundingBoxCenter { get => BoundingBoxCenterWrapper == null ? null : BoundingBoxCenterWrapper.data; }
        /// <summary> Gravity vector with respect to object's nominal position. </summary>
        public System.Numerics.Vector3 Gravity { get => GravityWrapper.data; internal set => GravityWrapper.data = value; }
        /// <summary> Orientation of model's bounding box. </summary>
        public System.Numerics.Quaternion? PrincipalAxis { get => PrincipalAxisWrapper == null ? null : PrincipalAxisWrapper.data; }

        /// <summary> Definition of supporting plane. </summary>
        public System.Numerics.Vector4? SupportingPlane { get => SupportingPlaneWrapper == null ? null : SupportingPlaneWrapper.data; }

        /// <summary> Indices of Key Frames. </summary>
        public IReadOnlyList<int> KeyFrameIndexes { get; }
        /// <summary> Test Trajectory. </summary>
        [CodeGenMember("TestTrajectory")]
        public IReadOnlyList<TrajectoryPose> TestTrajectoryCameraPoses { get; }

        [CodeGenMember("Dimensions")]
        internal Vector3 AssetDimensionsWrapper { get; set; }

        [CodeGenMember("BoundingBoxCenter")]
        internal Vector3 BoundingBoxCenterWrapper { get; set; }

        [CodeGenMember("Gravity")]
        internal Vector3 GravityWrapper { get; set; }

        [CodeGenMember("PrincipalAxis")]
        internal Quaternion PrincipalAxisWrapper { get; set; }

        /// <summary> Scale of transformation of asset units into meter space. </summary>
        [CodeGenMember("SupportingPlane")]
        internal Vector4 SupportingPlaneWrapper { get; set; }

        /// <summary>
        /// Returns true if the values of the object contain valid data.
        /// </summary>
        /// <param name="invalidMessage">The invalid message.</param>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        internal bool IsValid(out string invalidMessage)
        {
            invalidMessage = string.Empty;

            if (!this.Gravity.IsNormalized())
            {
                invalidMessage = $"The value for {nameof(AssetConversionConfiguration.Gravity)} must be normalized.";
            }

            return invalidMessage.Length == 0;
        }
    }
}
