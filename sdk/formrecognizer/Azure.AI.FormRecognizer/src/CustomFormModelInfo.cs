// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Describes a model trained in a Cognitive Services Account and its status.
    /// </summary>
    [CodeGenModel("ModelInfo")]
    public partial class CustomFormModelInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormModelInfo"/> class.
        /// </summary>
        /// <param name="modelId">The unique identifier of the model.</param>
        /// <param name="trainingStartedOn">The date and time (UTC) when model training was started.</param>
        /// <param name="trainingCompletedOn">The date and time (UTC) when model training completed.</param>
        /// <param name="status">The status of the model.</param>
        internal CustomFormModelInfo(string modelId, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, CustomFormModelStatus status)
        {
            ModelId = modelId;
            TrainingStartedOn = trainingStartedOn;
            TrainingCompletedOn = trainingCompletedOn;
            Status = status;
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
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset TrainingStartedOn { get; }

        /// <summary>
        /// The date and time (UTC) when model training completed.
        /// </summary>
        [CodeGenMember("LastUpdatedDateTime")]
        public DateTimeOffset TrainingCompletedOn { get; }

        /// <summary> Optional user defined model name (max length: 1024). </summary>
        private string ModelName { get; }
        /// <summary> Optional model attributes. </summary>
        private Attributes Attributes { get; }
    }
}
