// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("ModelSummary")]
    public partial class DocumentModelInfo
    {
        /// <summary>
        /// Date and time (UTC) when the model was created.
        /// </summary>
        [CodeGenMember("CreatedDateTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// A list of user-defined key-value tag attributes associated with the model.
        /// </summary>
        public IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary> API version used to create this model. </summary>
        internal string ApiVersion { get; }
    }
}
