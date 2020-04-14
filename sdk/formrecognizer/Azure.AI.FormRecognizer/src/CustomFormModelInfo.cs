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
            CreatedOn = modelInfo.CreatedDateTime;
            LastModified = modelInfo.LastUpdatedDateTime;
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
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// </summary>
        public DateTimeOffset LastModified { get; }
    }
}
