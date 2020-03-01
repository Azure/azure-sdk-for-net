// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Custom model training result. </summary>
    internal partial class TrainResult_internal
    {
        /// <summary> List of the documents used to train the model and any errors reported in each document. </summary>
        public ICollection<TrainingDocumentInfo> TrainingDocuments { get; set; } = new System.Collections.Generic.List<Azure.AI.FormRecognizer.Models.TrainingDocumentInfo>();
        /// <summary> List of fields used to train the model and the train operation error reported by each. </summary>
        public ICollection<FormFieldsReport_internal> Fields { get; set; }
        /// <summary> Average accuracy. </summary>
        public float? AverageModelAccuracy { get; set; }
        /// <summary> Errors returned during the training operation. </summary>
        public ICollection<FormRecognizerError> Errors { get; set; }
    }
}
