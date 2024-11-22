// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
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

        /// <summary> The Translation Status Summary of the operation. </summary>
        [CodeGenMember("Summary")]
        internal TranslationStatusSummary Summary { get; set; }

        /// <summary> Initializes a new instance of <see cref="TranslationStatusResult"/>. </summary>
        /// <param name="id"> Id of the operation. </param>
        /// <param name="createdOn"> Operation created date time. </param>
        /// <param name="lastModified"> Date time in which the operation's status has been updated. </param>
        /// <param name="status"> List of possible statuses for job or document. </param>
        /// <param name="error">
        /// This contains an outer error with error code, message, details, target and an
        /// inner error with more descriptive details.
        /// </param>
        /// <param name="summary"> Status Summary. </param>
        internal TranslationStatusResult(string id, DateTimeOffset createdOn, DateTimeOffset lastModified, DocumentTranslationStatus status, JsonElement error, TranslationStatusSummary summary)
        {
            Id = id;
            CreatedOn = createdOn;
            LastModified = lastModified;
            Status = status;
            _error = error;
            Summary = summary;
        }
    }
}
