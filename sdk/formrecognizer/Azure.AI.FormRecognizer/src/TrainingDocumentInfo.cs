// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// Represents a document that has been used to train a model.
    /// </summary>
    [CodeGenModel("TrainingDocumentInfo")]
    public partial class TrainingDocumentInfo
    {
        /// <summary>
        /// Training document name.
        /// </summary>
        [CodeGenMember("documentName")]
        public string Name { get; }

        /// <summary>
        /// The number of pages the document has.
        /// </summary>
        [CodeGenMember("pages")]
        public int PageCount { get; }
    }
}
