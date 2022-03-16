// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("CustomDocumentModelsInfo")]
    public partial class AccountProperties
    {
        /// <summary>
        /// Number of custom models in the current resource.
        /// </summary>
        [CodeGenMember("Count")]
        public int DocumentModelCount { get; }

        /// <summary>
        /// Maximum number of custom models supported in the current resource.
        /// </summary>
        [CodeGenMember("Limit")]
        public int DocumentModelLimit { get; }
    }
}
