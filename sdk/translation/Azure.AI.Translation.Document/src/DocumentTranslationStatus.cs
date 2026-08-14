// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// List of possible statuses for a translation operation
    /// or for a document.
    /// </summary>
    [CodeGenType("Status")]
    public partial struct DocumentTranslationStatus
    {
        /// <summary> Canceled. </summary>
        [CodeGenMember("Cancelled")]
        public static DocumentTranslationStatus Canceled { get; } = new DocumentTranslationStatus(CancelledValue);

        /// <summary> Canceling. </summary>
        [CodeGenMember("Cancelling")]
        public static DocumentTranslationStatus Canceling { get; } = new DocumentTranslationStatus(CancellingValue);
    }
}
