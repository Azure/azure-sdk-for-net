// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class WorkerSelectorAttachment
    {
        /// <summary> The type discriminator describing a sub-type of WorkerSelectorAttachment. </summary>
        public WorkerSelectorAttachmentKind Kind { get; protected set; }
    }
}
