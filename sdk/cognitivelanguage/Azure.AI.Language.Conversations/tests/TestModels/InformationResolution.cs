// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the information (data) entity resolution model. </summary>
    public partial class InformationResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of InformationResolution. </summary>
        /// <param name="unit"> The information (data) Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal InformationResolution(InformationUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.InformationResolution;
        }

        /// <summary> Initializes a new instance of InformationResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The information (data) Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal InformationResolution(ResolutionKind resolutionKind, InformationUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The information (data) Unit of measurement. </summary>
        public InformationUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
