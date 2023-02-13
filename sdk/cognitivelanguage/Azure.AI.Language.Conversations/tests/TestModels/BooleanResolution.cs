// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> A resolution for boolean expressions. </summary>
    public partial class BooleanResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of BooleanResolution. </summary>
        /// <param name="value"></param>
        internal BooleanResolution(bool value)
        {
            Value = value;
            ResolutionKind = ResolutionKind.BooleanResolution;
        }

        /// <summary> Initializes a new instance of BooleanResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        /// <param name="value"></param>
        internal BooleanResolution(ResolutionKind resolutionKind, bool value) : base(resolutionKind)
        {
            Value = value;
            ResolutionKind = resolutionKind;
        }

        /// <summary> Gets the value. </summary>
        public bool Value { get; }
    }
}
