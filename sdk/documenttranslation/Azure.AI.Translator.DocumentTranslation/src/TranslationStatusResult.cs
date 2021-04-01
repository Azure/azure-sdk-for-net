// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Translator.DocumentTranslation.Models;
using Azure.Core;

namespace Azure.AI.Translator.DocumentTranslation
{
    /// <summary>
    /// Status information about the translation operation.
    /// </summary>
    [CodeGenModel("BatchStatusDetail")]
    public partial class TranslationStatusResult
    {
        /// <summary>
        /// Id of the translation operation.
        /// </summary>
        [CodeGenMember("Id")]
        public string TranslationId { get; }

        /// <summary>
        /// The date time when the translation operation was created.
        /// </summary>
        [CodeGenMember("CreatedDateTimeUtc")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// The date time when the translation operation's status was last updated.
        /// </summary>
        [CodeGenMember("LastActionDateTimeUtc")]
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// Total number of expected translated documents.
        /// </summary>
        public int DocumentsTotal => Summary.Total;

        /// <summary>
        /// Number of documents failed to translate.
        /// </summary>
        public int DocumentsFailed => Summary.Failed;

        /// <summary>
        /// Number of documents translated successfully.
        /// </summary>
        public int DocumentsSucceeded => Summary.Success;

        /// <summary>
        /// Number of documents in progress.
        /// </summary>
        public int DocumentsInProgress => Summary.InProgress;

        /// <summary>
        /// Number of documents in queue for translation.
        /// </summary>
        public int DocumentsNotStarted => Summary.NotYetStarted;

        /// <summary>
        /// Number of documents cancelled.
        /// </summary>
        public int DocumentsCancelled => Summary.Cancelled;

        /// <summary>
        /// Total characters charged by the Document Translation service
        /// </summary>
        public long TotalCharactersCharged => Summary.TotalCharacterCharged;

        /// <summary> Returns true if the translation operation is completed. </summary>
        public bool HasCompleted => Status == TranslationStatus.Succeeded
                                    || Status == TranslationStatus.Failed
                                    || Status == TranslationStatus.Cancelled
                                    || Status == TranslationStatus.ValidationFailed;

        /// <summary> The Status Summary of the operation. </summary>
        [CodeGenMember("Summary")]
        internal StatusSummary Summary { get; set; }
    }
}
