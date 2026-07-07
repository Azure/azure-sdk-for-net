// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class JobMatchingMode
    {
        /// <summary> Initializes a new instance of JobMatchingMode for deserialization. </summary>
        protected JobMatchingMode() { }

        /// <summary> The type discriminator describing a sub-type of JobMatchingMode. </summary>
        public JobMatchingModeKind Kind { get; protected set; }
    }
}
