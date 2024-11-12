// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class DocumentClassifierDetails
    {
        /// <summary>
        /// Date and time (UTC) when the document classifier was created.
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Date and time (UTC) when the document classifier will expire.
        /// </summary>
        [CodeGenMember("ExpirationDateTime")]
        public DateTimeOffset? ExpiresOn { get; }

        /// <summary>
        /// The list of document types to classify against.
        /// </summary>
        [CodeGenMember("DocTypes")]
        public IReadOnlyDictionary<string, ClassifierDocumentTypeDetails> DocumentTypes { get; }

        /// <summary>
        /// Service version used to create this document classifier.
        /// </summary>
        [CodeGenMember("ApiVersion")]
        public string ServiceVersion { get; }
    }
}
