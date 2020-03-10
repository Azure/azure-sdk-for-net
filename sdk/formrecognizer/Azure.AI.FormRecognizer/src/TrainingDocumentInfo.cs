// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{
    [CodeGenSchema("TrainingDocumentInfo")]
    public partial class TrainingDocumentInfo
    {
        [CodeGenSchemaMember("pages")]
        public int PageCount { get; set; }
    }
}
