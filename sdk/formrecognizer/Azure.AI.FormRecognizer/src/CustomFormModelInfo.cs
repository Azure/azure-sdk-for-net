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
        /// <summary> Initializes a new instance of CustomFormModelInfo. </summary>
        /// <param name="modelId"> Model identifier. </param>
        /// <param name="status"> Status of the model. </param>
        /// <param name="trainingStartedOn"> Date and time (UTC) when the model was created. </param>
        /// <param name="trainingCompletedOn"> Date and time (UTC) when the status was last updated. </param>
        /// <param name="displayName"> Optional user defined model name (max length: 1024). </param>
        /// <param name="properties">Model properties, like for example, if a model is composed.</param>
        internal CustomFormModelInfo(string modelId, CustomFormModelStatus status, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, string displayName, CustomFormModelProperties properties)
        {
            ModelId = modelId;
            Status = status;
            TrainingStartedOn = trainingStartedOn;
            TrainingCompletedOn = trainingCompletedOn;
            DisplayName = displayName;
            Properties = properties ?? new CustomFormModelProperties();
        }

        /// <summary>
        /// The unique identifier of the model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// The optional display name of the model.
        /// </summary>
        [CodeGenMember("ModelName")]
        public string DisplayName { get; }

        /// <summary>
        /// Model properties, like for example, if a model is composed.
        /// </summary>
        [CodeGenMember("Attributes")]
        public CustomFormModelProperties Properties { get; }

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

    }
}
