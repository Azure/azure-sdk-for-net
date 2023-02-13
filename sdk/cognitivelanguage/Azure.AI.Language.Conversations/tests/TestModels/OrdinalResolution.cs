// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> A resolution for ordinal numbers entity instances. </summary>
    public partial class OrdinalResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of OrdinalResolution. </summary>
        /// <param name="offset"> The offset With respect to the reference (e.g., offset = -1 in &quot;show me the second to last&quot;. </param>
        /// <param name="relativeTo"> The reference point that the ordinal number denotes. </param>
        /// <param name="value"> A simple arithmetic expression that the ordinal denotes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="offset"/> or <paramref name="value"/> is null. </exception>
        internal OrdinalResolution(string offset, RelativeTo relativeTo, string value)
        {
            Argument.AssertNotNull(offset, nameof(offset));
            Argument.AssertNotNull(value, nameof(value));

            Offset = offset;
            RelativeTo = relativeTo;
            Value = value;
            ResolutionKind = ResolutionKind.OrdinalResolution;
        }

        /// <summary> Initializes a new instance of OrdinalResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="offset"> The offset With respect to the reference (e.g., offset = -1 in &quot;show me the second to last&quot;. </param>
        /// <param name="relativeTo"> The reference point that the ordinal number denotes. </param>
        /// <param name="value"> A simple arithmetic expression that the ordinal denotes. </param>
        internal OrdinalResolution(ResolutionKind resolutionKind, string offset, RelativeTo relativeTo, string value) : base(resolutionKind)
        {
            Offset = offset;
            RelativeTo = relativeTo;
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> The offset With respect to the reference (e.g., offset = -1 in &quot;show me the second to last&quot;. </summary>
        public string Offset { get; }
        /// <summary> The reference point that the ordinal number denotes. </summary>
        public RelativeTo RelativeTo { get; }
        /// <summary> A simple arithmetic expression that the ordinal denotes. </summary>
        public string Value { get; }
    }
}
