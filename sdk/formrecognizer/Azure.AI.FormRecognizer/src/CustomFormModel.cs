// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    public class CustomFormModel
    {
        internal CustomFormModel()
        {
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

        /// <summary>
        /// </summary>
        public IReadOnlyList<CustomFormSubModel> Models { get; }

        /// <summary>
        /// </summary>
        // TODO: for composed models, union what comes back on submodels into this single list.
        public IReadOnlyList<TrainingDocumentInfo> TrainingDocuments { get; }
    }
}
