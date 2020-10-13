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
    }
}
