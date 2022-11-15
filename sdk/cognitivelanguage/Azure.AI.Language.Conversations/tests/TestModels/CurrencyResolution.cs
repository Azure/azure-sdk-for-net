// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the currency entity resolution model. </summary>
    public partial class CurrencyResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of CurrencyResolution. </summary>
        /// <param name="unit"> The unit of the amount captured in the extracted entity. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unit"/> is null. </exception>
        internal CurrencyResolution(string unit, double value)
        {
            Argument.AssertNotNull(unit, nameof(unit));

            Unit = unit;
            Value = value;
            ResolutionKind = ResolutionKind.CurrencyResolution;
        }

        /// <summary> Initializes a new instance of CurrencyResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="isO4217"> The alphabetic code based on another ISO standard, ISO 3166, which lists the codes for country names. The first two letters of the ISO 4217 three-letter code are the same as the code for the country name, and, where possible, the third letter corresponds to the first letter of the currency name. </param>
        /// <param name="unit"> The unit of the amount captured in the extracted entity. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal CurrencyResolution(ResolutionKind resolutionKind, string isO4217, string unit, double value) : base(resolutionKind)
        {
            ISO4217 = isO4217;
            Unit = unit;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The alphabetic code based on another ISO standard, ISO 3166, which lists the codes for country names. The first two letters of the ISO 4217 three-letter code are the same as the code for the country name, and, where possible, the third letter corresponds to the first letter of the currency name. </summary>
        public string ISO4217 { get; }
        /// <summary> The unit of the amount captured in the extracted entity. </summary>
        public string Unit { get; }
        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
