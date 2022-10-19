// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentModelDetails")]
    public partial class DocumentModelDetails
    {
        /// <summary>
        /// Date and time (UTC) when the model was created.
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Supported document types.
        /// </summary>
        [CodeGenMember("DocTypes")]
        public IReadOnlyDictionary<string, DocumentTypeDetails> DocumentTypes { get; }

        [CodeGenMember("ApiVersion")]
        internal string ApiVersion { get; }
    }
}
