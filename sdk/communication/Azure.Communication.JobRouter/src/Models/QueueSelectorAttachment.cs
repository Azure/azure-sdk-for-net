// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    public abstract partial class QueueSelectorAttachment
    {
        /// <summary> Initializes a new instance of QueueSelectorAttachment for deserialization. </summary>
        protected QueueSelectorAttachment() { }

        /// <summary> The type discriminator describing a sub-type of QueueSelectorAttachment. </summary>
        public QueueSelectorAttachmentKind Kind { get; protected set; }
    }
}
