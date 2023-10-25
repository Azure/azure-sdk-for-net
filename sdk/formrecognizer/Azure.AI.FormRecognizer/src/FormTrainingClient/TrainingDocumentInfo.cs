// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.FormRecognizer.Models;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a document that has been used to train a model.
    /// </summary>
    [CodeGenModel("TrainingDocumentInfo")]
    public partial class TrainingDocumentInfo
    {
        /// <summary> Initializes a new instance of TrainingDocumentInfo. </summary>
        /// <param name="name"> Training document name. </param>
        /// <param name="pageCount"> Total number of pages trained. </param>
        /// <param name="errors"> List of errors. </param>
        /// <param name="status"> Status of the training operation. </param>
        /// <param name="modelId">The unique identifier of the model.</param>
        internal TrainingDocumentInfo(string name, int pageCount, IReadOnlyList<FormRecognizerError> errors, TrainingStatus status, string modelId)
        {
            Name = name;
            PageCount = pageCount;
            Errors = errors;
            Status = status;
            ModelId = modelId;
        }

        /// <summary>
        /// Training document name.
        /// </summary>
        [CodeGenMember("DocumentName")]
        public string Name { get; }

        /// <summary>
        /// The number of pages the document has.
        /// </summary>
        [CodeGenMember("Pages")]
        public int PageCount { get; }

        /// <summary>
        /// The unique identifier of the model.
        /// </summary>
        /// <remarks>
        /// This property only has value for <see cref="FormRecognizerClientOptions.ServiceVersion.V2_1"/> and newer.
        /// </remarks>
        public string ModelId { get; }
    }
}
