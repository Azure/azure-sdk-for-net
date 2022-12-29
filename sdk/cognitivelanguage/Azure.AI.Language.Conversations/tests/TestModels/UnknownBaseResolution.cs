// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownBaseResolution. </summary>
    internal partial class UnknownBaseResolution : BaseResolution
    {
        /// <summary> Initializes a new instance of UnknownBaseResolution. </summary>
        /// <param name="resolutionKind"> The entity resolution object kind. </param>
        internal UnknownBaseResolution(ResolutionKind resolutionKind) : base(resolutionKind)
        {
            ResolutionKind = resolutionKind;
        }
    }
}
