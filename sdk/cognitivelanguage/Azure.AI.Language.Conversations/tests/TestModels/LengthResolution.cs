// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the length entity resolution model. </summary>
    public partial class LengthResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of LengthResolution. </summary>
        /// <param name="unit"> The length Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal LengthResolution(LengthUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.LengthResolution;
        }

        /// <summary> Initializes a new instance of LengthResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The length Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal LengthResolution(ResolutionKind resolutionKind, LengthUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The length Unit of measurement. </summary>
        public LengthUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
