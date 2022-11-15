// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> A resolution for numeric entity instances. </summary>
    public partial class NumberResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of NumberResolution. </summary>
        /// <param name="numberKind"> The type of the extracted number entity. </param>
        /// <param name="value"> A numeric representation of what the extracted text denotes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal NumberResolution(NumberKind numberKind, string value)
        {
            Argument.AssertNotNull(value, nameof(value));

            NumberKind = numberKind;
            Value = value;
            ResolutionKind = ResolutionKind.NumberResolution;
        }

        /// <summary> Initializes a new instance of NumberResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="numberKind"> The type of the extracted number entity. </param>
        /// <param name="value"> A numeric representation of what the extracted text denotes. </param>
        internal NumberResolution(ResolutionKind resolutionKind, NumberKind numberKind, string value) : base(resolutionKind)
        {
            NumberKind = numberKind;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The type of the extracted number entity. </summary>
        public NumberKind NumberKind { get; }
        /// <summary> A numeric representation of what the extracted text denotes. </summary>
        public string Value { get; }
    }
}
