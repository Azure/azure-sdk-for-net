// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public readonly partial struct ParagraphRole
    {
        /// <summary>
        /// formulaBlock.
        /// </summary>
        internal static ParagraphRole FormulaBlock { get; } = new ParagraphRole(FormulaBlockValue);
    }
}
