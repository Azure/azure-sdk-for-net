// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class PassThroughQueueSelectorAttachment
    {
        /// <summary> Describes how the value of the label is compared to the value passed through. </summary>
        public LabelOperator LabelOperator { get; internal set; }

        /// <summary> Initializes a new instance of PassThroughQueueSelectorAttachment. </summary>
        /// <param name="key"> The label key to query against. </param>
        /// <param name="labelOperator"> Describes how the value of the label is compared to the value passed through. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public PassThroughQueueSelectorAttachment(string key, LabelOperator labelOperator)
        {
            Argument.AssertNotNullOrWhiteSpace(key, nameof(key));
            Argument.AssertNotNull(labelOperator, nameof(labelOperator));

            Kind = QueueSelectorAttachmentKind.PassThrough;
            Key = key;
            LabelOperator = labelOperator;
        }
    }
}
