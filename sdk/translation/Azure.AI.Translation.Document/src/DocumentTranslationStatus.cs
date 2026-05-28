// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// List of possible statuses for a translation operation
    /// or for a document.
    /// </summary>
    [CodeGenModel("Status")]
    public partial struct DocumentTranslationStatus
    {
        /// <summary> Canceled. </summary>
        [CodeGenMember("Cancelled")]
        public static DocumentTranslationStatus Canceled { get; } = new DocumentTranslationStatus(CanceledValue);

        /// <summary> Canceling. </summary>
        [CodeGenMember("Cancelling")]
        public static DocumentTranslationStatus Canceling { get; } = new DocumentTranslationStatus(CancelingValue);
    }
}
