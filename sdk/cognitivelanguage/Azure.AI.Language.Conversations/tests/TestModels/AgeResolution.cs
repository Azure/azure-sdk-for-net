// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the Age entity resolution model. </summary>
    public partial class AgeResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of AgeResolution. </summary>
        /// <param name="unit"> The Age Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal AgeResolution(AgeUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.AgeResolution;
        }

        /// <summary> Initializes a new instance of AgeResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The Age Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal AgeResolution(ResolutionKind resolutionKind, AgeUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The Age Unit of measurement. </summary>
        public AgeUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
