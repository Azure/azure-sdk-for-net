// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents resolutions for quantities. </summary>
    public partial class QuantityResolution
    {
        /// <summary> Initializes a new instance of QuantityResolution. </summary>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        internal QuantityResolution(double value)
        {
            Value = value;
        }

        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
    }
}
