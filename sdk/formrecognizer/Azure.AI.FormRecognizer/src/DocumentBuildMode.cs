// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("DocumentBuildMode")]
    public readonly partial struct DocumentBuildMode
    {
        /// <summary> template. </summary>
        public static DocumentBuildMode Template { get; } = new DocumentBuildMode(TemplateValue);

        /// <summary> neural. </summary>
        public static DocumentBuildMode Neural { get; } = new DocumentBuildMode(NeuralValue);
    }
}
