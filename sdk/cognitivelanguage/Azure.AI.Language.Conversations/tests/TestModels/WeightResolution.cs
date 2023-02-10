// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the weight entity resolution model. </summary>
    public partial class WeightResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of WeightResolution. </summary>
        /// <param name="unit"> The weight Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal WeightResolution(WeightUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.WeightResolution;
        }

        /// <summary> Initializes a new instance of WeightResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The weight Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal WeightResolution(ResolutionKind resolutionKind, WeightUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The weight Unit of measurement. </summary>
        public WeightUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
