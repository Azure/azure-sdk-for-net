// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// Model info.
    /// </summary>
    public class DocumentModelDetails
    {
        internal DocumentModelDetails(DocumentModel model)
            : this(model.ModelId, model.Description, model.CreatedOn, model.Tags, model.DocTypes)
        {
        }

        internal DocumentModelDetails(string modelId, string description, DateTimeOffset createdOn, IReadOnlyDictionary<string, string> tags, IReadOnlyDictionary<string, DocTypeInfo> docTypes)
        {
            ModelId = modelId;
            Description = description;
            CreatedOn = createdOn;
            Tags = tags;
            DocTypes = docTypes;
        }

        /// <summary>
        /// Unique model name.
        /// </summary>
        public string ModelId { get; }

        /// <summary>
        /// Model description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Date and time (UTC) when the model was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// List of key-value tag attributes associated with the model.
        /// </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary>
        /// Supported document types.
        /// </summary>
        public IReadOnlyDictionary<string, DocTypeInfo> DocTypes { get; }
    }
}
