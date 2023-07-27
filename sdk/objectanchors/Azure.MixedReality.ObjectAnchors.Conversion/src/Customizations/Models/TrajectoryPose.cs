// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.MixedReality.ObjectAnchors.Conversion.Models;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// The Pose of a trajectory.
    /// </summary>
    [CodeGenModel("Pose")]
    public partial struct TrajectoryPose : IEquatable<TrajectoryPose>
    {
        /// <summary>
        /// Creates the Pose of a trajectory.
        /// </summary>
        /// <param name="rotation">The pose's rotation.</param>
        /// <param name="translation">The pose's translation.</param>
        internal TrajectoryPose(System.Numerics.Quaternion rotation, System.Numerics.Vector3 translation)
            : this(new Quaternion(rotation), new Vector3(translation))
        {
        }

        /// <summary>
        /// Creates the Pose of a trajectory.
        /// </summary>
        /// <param name="rotationWrapper">The pose's rotation.</param>
        /// <param name="translationWrapper">The pose's translation.</param>
        internal TrajectoryPose(Quaternion rotationWrapper, Vector3 translationWrapper)
        {
            RotationWrapper = rotationWrapper;
            TranslationWrapper = translationWrapper;
        }

        /// <summary>
        /// The pose's rotation.
        /// </summary>
        public System.Numerics.Quaternion Rotation { get => RotationWrapper; }

        /// <summary>
        /// The pose's translation.
        /// </summary>
        public System.Numerics.Vector3 Translation { get => (System.Numerics.Vector3)TranslationWrapper; }

        [CodeGenMember("Rotation")]
        internal readonly Quaternion RotationWrapper;

        [CodeGenMember("Translation")]
        internal readonly Vector3 TranslationWrapper;

        /// <summary>
        /// Returns whether a Trajectory pose's content matches that of another.
        /// </summary>
        public bool Equals(TrajectoryPose other)
        {
            return this.Rotation.Equals(other.Rotation)
                && this.Translation.Equals(other.Translation);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is TrajectoryPose && this.Equals(obj as Vector4);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return Tuple.Create(RotationWrapper, TranslationWrapper).GetHashCode();
        }
    }
}
