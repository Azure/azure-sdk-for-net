// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the volume entity resolution model. </summary>
    public partial class VolumeResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of VolumeResolution. </summary>
        /// <param name="unit"> The Volume Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal VolumeResolution(VolumeUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.VolumeResolution;
        }

        /// <summary> Initializes a new instance of VolumeResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The Volume Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal VolumeResolution(ResolutionKind resolutionKind, VolumeUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The Volume Unit of measurement. </summary>
        public VolumeUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
