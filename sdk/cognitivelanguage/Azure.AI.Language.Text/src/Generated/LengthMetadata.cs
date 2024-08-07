// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Language.Text
{
    /// <summary> Represents the Length entity Metadata model. </summary>
    public partial class LengthMetadata : BaseMetadata
    {
        /// <summary> Initializes a new instance of <see cref="LengthMetadata"/>. </summary>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        /// <param name="unit"> Unit of measure for length. </param>
        internal LengthMetadata(double value, LengthUnit unit)
        {
            MetadataKind = MetadataKind.LengthMetadata;
            Value = value;
            Unit = unit;
        }

        /// <summary> Initializes a new instance of <see cref="LengthMetadata"/>. </summary>
        /// <param name="metadataKind"> The entity Metadata object kind. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="value"> The numeric value that the extracted text denotes. </param>
        /// <param name="unit"> Unit of measure for length. </param>
        internal LengthMetadata(MetadataKind metadataKind, IDictionary<string, BinaryData> serializedAdditionalRawData, double value, LengthUnit unit) : base(metadataKind, serializedAdditionalRawData)
        {
            Value = value;
            Unit = unit;
        }

        /// <summary> Initializes a new instance of <see cref="LengthMetadata"/> for deserialization. </summary>
        internal LengthMetadata()
        {
        }

        /// <summary> The numeric value that the extracted text denotes. </summary>
        public double Value { get; }
        /// <summary> Unit of measure for length. </summary>
        public LengthUnit Unit { get; }
    }
}
