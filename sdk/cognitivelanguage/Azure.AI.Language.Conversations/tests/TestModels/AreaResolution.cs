// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the area entity resolution model. </summary>
    public partial class AreaResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of AreaResolution. </summary>
        /// <param name="unit"> The area Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal AreaResolution(AreaUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.AreaResolution;
        }

        /// <summary> Initializes a new instance of AreaResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The area Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal AreaResolution(ResolutionKind resolutionKind, AreaUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The area Unit of measurement. </summary>
        public AreaUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
