// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class RouterRule
    {
        /// <summary> The type discriminator describing a sub-type of RouterRule. </summary>
        public RouterRuleKind Kind { get; protected set; }
    }
}
