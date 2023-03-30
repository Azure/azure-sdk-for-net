// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("OperationKind")]
    public partial struct DocumentOperationKind
    {
        /// <summary>
        /// documentClassifierBuild.
        /// </summary>
        internal static DocumentOperationKind DocumentClassifierBuild { get; } = new DocumentOperationKind(DocumentClassifierBuildValue);
    }
}
