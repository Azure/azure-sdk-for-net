// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{
    /// <summary>
    /// </summary>
    [CodeGenSchema("TrainingDocumentInfo")]
    public partial class TrainingDocumentInfo
    {
        internal TrainingDocumentInfo()
        {
        }

        /// <summary>
        /// </summary>
        [CodeGenSchemaMember("pages")]
        public int PageCount { get; set; }
    }
}
