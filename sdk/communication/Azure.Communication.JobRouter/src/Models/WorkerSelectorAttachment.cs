// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("WorkerSelectorAttachment")]
    [JsonConverter(typeof(PolymorphicWriteOnlyJsonConverter<WorkerSelectorAttachment>))]
    public abstract partial class WorkerSelectorAttachment
    {
        /// <summary> Initializes a new instance of QueueSelectorAttachment. </summary>
        internal WorkerSelectorAttachment()
        {
        }

        /// <summary> The type discriminator describing the type of label selector attachment. </summary>
        protected string Kind { get; set; }
    }
}
