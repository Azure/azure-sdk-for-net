// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the temperature entity resolution model. </summary>
    public partial class TemperatureResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of TemperatureResolution. </summary>
        /// <param name="unit"> The temperature Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal TemperatureResolution(TemperatureUnit unit, double value)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.TemperatureResolution;
        }

        /// <summary> Initializes a new instance of TemperatureResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="unit"> The temperature Unit of measurement. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal TemperatureResolution(ResolutionKind resolutionKind, TemperatureUnit unit, double value) : base(resolutionKind)
        {
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The temperature Unit of measurement. </summary>
        public TemperatureUnit Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
