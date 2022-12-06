// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.MixedReality.ObjectAnchors.Conversion.Models;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// Represents an asset conversion configuration.
    /// </summary>
    [CodeGenModel("IngestionConfiguration")]
    public partial class AssetConversionConfiguration
    {
        /// <summary>
        /// Creates an asset conversion configuration from the gravity vector and a model scale.
        /// </summary>
        /// <param name="gravity">Gravity vector with respect to object's nominal position.</param>
        /// <param name="scale">Scale of transformation of asset units into meter space.</param>
        /// <param name="disableDetectScaleUnits">Whether or not disable automatic detection of FBX scale units.</param>
        internal AssetConversionConfiguration(System.Numerics.Vector3 gravity, float scale, bool disableDetectScaleUnits)
            : this(new Vector3(gravity), scale)
        {
            if (!gravity.IsNormalized())
            {
                throw new ArgumentException("The value must be normalized.", nameof(gravity));
            }

            DisableDetectScaleUnits = disableDetectScaleUnits;
        }

        /// <summary>
        /// Creates an asset conversion configuration from the gravity vector and a model scale.
        /// </summary>
        /// <param name="gravityWrapper">Gravity vector with respect to object's nominal position.</param>
        /// <param name="scale">Scale of transformation of asset units into meter space.</param>
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
            DisableDetectScaleUnits = false;
            TestTrajectoryCameraPoses = new List<TrajectoryPose>();
        }

        /// <summary>
        /// Scale of transformation of asset units into meter space.
        /// </summary>
        public float Scale { get; internal set; }

        /// <summary> Whether or not disable the scale units in the model metadata. </summary>
        public bool DisableDetectScaleUnits { get; internal set; }

        /// <summary>
        /// Ground truth trajectory.
        /// </summary>
        [CodeGenMember("GtTrajectory")]
        public IReadOnlyList<TrajectoryPose> GroundTruthTrajectoryCameraPoses { get; }

        /// <summary>
        /// Dimensions of the asset.
        /// </summary>
        public System.Numerics.Vector3? AssetDimensions { get => AssetDimensionsWrapper == null ? null : (System.Numerics.Vector3)AssetDimensionsWrapper; }

        /// <summary>
        /// BoundingBoxCenter of the asset.
        /// </summary>
        public System.Numerics.Vector3? BoundingBoxCenter { get => BoundingBoxCenterWrapper == null ? null : (System.Numerics.Vector3)BoundingBoxCenterWrapper; }

        /// <summary>
        /// Gravity vector with respect to object's nominal position.
        /// </summary>
        public System.Numerics.Vector3 Gravity { get => (System.Numerics.Vector3)GravityWrapper; internal set => GravityWrapper = (Vector3)value; }

        /// <summary>
        /// Orientation of model's bounding box.
        /// </summary>
        public System.Numerics.Quaternion? PrincipalAxis { get => PrincipalAxisWrapper == null ? null : PrincipalAxisWrapper; }

        /// <summary>
        /// Definition of supporting plane.
        /// </summary>
        public System.Numerics.Vector4? SupportingPlane { get => SupportingPlaneWrapper == null ? null : SupportingPlaneWrapper; }

        /// <summary>
        /// Indices of Key Frames.
        /// </summary>
        public IReadOnlyList<int> KeyFrameIndexes { get; }

        /// <summary>
        /// Test Trajectory.
        /// </summary>
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
