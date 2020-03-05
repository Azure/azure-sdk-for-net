// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    public class CustomModelTrainingStatus
    {
        internal CustomModelTrainingStatus(ModelInfo_internal modelInfo)
        {
            ModelId = modelInfo.ModelId.ToString();
            CreatedOn = modelInfo.CreatedDateTime;
            LastUpdatedOn = modelInfo.LastUpdatedDateTime;
            TrainingStatus = modelInfo.Status;
        }

        /// <summary>
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// </summary>
        public ModelStatus TrainingStatus { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset? LastUpdatedOn { get; }
    }
}
