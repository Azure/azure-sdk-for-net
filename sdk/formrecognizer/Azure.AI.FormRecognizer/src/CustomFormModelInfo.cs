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
        /// <param name="modelName"> An optional, user-defined name to associate with your model. </param>
        /// <param name="properties">Model properties, like for example, if a model is composed.</param>
        internal CustomFormModelInfo(string modelId, CustomFormModelStatus status, DateTimeOffset trainingStartedOn, DateTimeOffset trainingCompletedOn, string modelName, CustomFormModelProperties properties)
        {
            ModelId = modelId;
            Status = status;
            TrainingStartedOn = trainingStartedOn;
            TrainingCompletedOn = trainingCompletedOn;
            ModelName = modelName;
            Properties = properties ?? new CustomFormModelProperties();
        }

        /// <summary>
        /// The unique identifier of the model.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// An optional, user-defined name to associate with your model.
        /// </summary>
        public string ModelName { get; }

        /// <summary>
        /// Properties of a model, such as whether the model is a composed model or not.
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
