// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class StaticQueueSelectorAttachment
    {
        /// <summary> Initializes a new instance of StaticQueueSelectorAttachment. </summary>
        /// <param name="queueSelector">
        /// Describes a condition that must be met against a set of labels for queue
        /// selection
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueSelector"/> is null. </exception>
        public StaticQueueSelectorAttachment(RouterQueueSelector queueSelector)
        {
            Argument.AssertNotNull(queueSelector, nameof(queueSelector));

            Kind = QueueSelectorAttachmentKind.Static;
            QueueSelector = queueSelector;
        }
    }
}
