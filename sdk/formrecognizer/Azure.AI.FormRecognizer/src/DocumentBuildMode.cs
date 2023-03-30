// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// The technique to use to build a custom model. For more information see
    /// <see href="https://aka.ms/azsdk/formrecognizer/buildmode">here</see>.
    /// </summary>
    public readonly partial struct DocumentBuildMode
    {
        /// <summary>
        /// The recommended mode when the custom documents all have the same layout. Fields
        /// are expected to be in the same place across documents. Build time tends to be
        /// considerably shorter than <see cref="Neural"/> mode.
        /// </summary>
        public static DocumentBuildMode Template { get; } = new DocumentBuildMode(TemplateValue);

        /// <summary>
        /// The recommended mode when custom documents have different layouts. Fields are
        /// expected to be the same but they can be placed in different positions across
        /// documents.
        /// </summary>
        public static DocumentBuildMode Neural { get; } = new DocumentBuildMode(NeuralValue);
    }
}
