// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Training
{
    /// <summary>
    /// </summary>
    [CodeGenSchema("TrainingDocumentInfo")]
    public partial class TrainingDocumentInfo
    {
        /// <summary>
        /// </summary>
        [CodeGenSchemaMember("pages")]
        public int PageCount { get; internal set; }
    }
}
