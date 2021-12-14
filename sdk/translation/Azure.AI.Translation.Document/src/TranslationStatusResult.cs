// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.AI.Translation.Document.Models;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Status information about the translation operation.
    /// </summary>
    [CodeGenModel("TranslationStatus")]
    public partial class TranslationStatusResult
    {
        [CodeGenMember("Error")]
        private readonly JsonElement _error;

        /// <summary>
        /// Id of the translation operation.
        /// </summary>
        [CodeGenMember("Id")]
        public string Id { get; }

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
        /// Number of documents canceled.
        /// </summary>
        public int DocumentsCanceled => Summary.Cancelled;

        /// <summary>
        /// Total characters charged by the Document Translation service
        /// </summary>
        public long TotalCharactersCharged => Summary.TotalCharacterCharged;

        /// <summary>
        /// This contains an outer error with the error code, message, details, target and an inner error with more descriptive details.
        /// </summary>
        public ResponseError Error => _error.ValueKind == JsonValueKind.Undefined ? null : JsonSerializer.Deserialize<ResponseError>(_error.GetRawText());

        /// <summary> The Status Summary of the operation. </summary>
        [CodeGenMember("Summary")]
        internal StatusSummary Summary { get; set; }
    }
}
