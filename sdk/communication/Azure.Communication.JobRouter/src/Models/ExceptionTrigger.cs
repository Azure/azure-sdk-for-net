// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class ExceptionTrigger
    {
        /// <summary> The type discriminator describing a sub-type of ExceptionTrigger. </summary>
        public ExceptionTriggerKind Kind { get; protected set; }
    }
}
