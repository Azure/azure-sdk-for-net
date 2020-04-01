// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomFormModelInfo
    {
        internal CustomFormModelInfo(ModelInfo_internal modelInfo)
        {
            ModelId = modelInfo.ModelId.ToString();
            CreatedOn = new DateTime(modelInfo.CreatedDateTime.Ticks, DateTimeKind.Utc);
            LastUpdatedOn = new DateTime(modelInfo.LastUpdatedDateTime.Ticks, DateTimeKind.Utc);
            Status = modelInfo.Status;
        }

        /// <summary>
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// </summary>
        public CustomFormModelStatus Status { get; }

        /// <summary>
        /// </summary>
        public DateTime CreatedOn { get; }

        /// <summary>
        /// </summary>
        public DateTime LastUpdatedOn { get; }
    }
}
