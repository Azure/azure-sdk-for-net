// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> represents the resolution of numeric intervals. </summary>
    public partial class NumericRangeResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of NumericRangeResolution. </summary>
        /// <param name="rangeKind"> The kind of range that the resolution object represents. </param>
        /// <param name="minimum"> The beginning value of  the interval. </param>
        /// <param name="maximum"> The ending value of the interval. </param>
        internal NumericRangeResolution(RangeKind rangeKind, double minimum, double maximum)
        {
            RangeKind = rangeKind;
            Minimum = minimum;
            Maximum = maximum;
            ResolutionKind = ResolutionKind.NumericRangeResolution;
        }

        /// <summary> Initializes a new instance of NumericRangeResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="rangeKind"> The kind of range that the resolution object represents. </param>
        /// <param name="minimum"> The beginning value of  the interval. </param>
        /// <param name="maximum"> The ending value of the interval. </param>
        internal NumericRangeResolution(ResolutionKind resolutionKind, RangeKind rangeKind, double minimum, double maximum) : base(resolutionKind)
        {
            RangeKind = rangeKind;
            Minimum = minimum;
            Maximum = maximum;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The kind of range that the resolution object represents. </summary>
        public RangeKind RangeKind { get; }
        /// <summary> The beginning value of  the interval. </summary>
        public double Minimum { get; }
        /// <summary> The ending value of the interval. </summary>
        public double Maximum { get; }
    }
}
