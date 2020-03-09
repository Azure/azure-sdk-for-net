// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Custom
{
    public class ModelInfo
    {
        internal ModelInfo(ModelInfo_internal modelInfo)
        {
            ModelId = modelInfo.ModelId.ToString();
            TrainingStatus = modelInfo.Status;
            CreatedOn = modelInfo.CreatedDateTime;
            LastUpdatedOn = modelInfo.LastUpdatedDateTime;
        }

        public string ModelId { get; internal set; }

        public ModelStatus TrainingStatus { get; internal set; }

        public DateTimeOffset CreatedOn { get; internal set; }

        public DateTimeOffset LastUpdatedOn { get; internal set; }
    }
}
