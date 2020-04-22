// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Describes a model trained in a Cognitive Services Account and its status.
    /// </summary>
    public class CustomFormModelInfo
    {
        internal CustomFormModelInfo(ModelInfo_internal modelInfo)
        {
            ModelId = modelInfo.ModelId.ToString();
            CreatedOn = modelInfo.CreatedDateTime;
            LastModified = modelInfo.LastUpdatedDateTime;
            Status = modelInfo.Status;
        }

        /// <summary>
        /// The unique identifier of the model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// The status of the model.
        /// </summary>
        public CustomFormModelStatus Status { get; }

        /// <summary>
        /// The date and time (UTC) when model training was started.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// The date and time (UTC) when model training completed.
        /// </summary>
        public DateTimeOffset LastModified { get; }
    }
}
