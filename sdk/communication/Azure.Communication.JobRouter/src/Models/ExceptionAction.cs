// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class ExceptionAction
    {
        /// <summary> The type discriminator describing a sub-type of ExceptionAction. </summary>
        public ExceptionActionKind Kind { get; protected set; }
    }
}
