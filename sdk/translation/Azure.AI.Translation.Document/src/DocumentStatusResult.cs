// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Status information about a particular document within a translation operation.
    /// </summary>
    [CodeGenModel("DocumentStatus")]
    public partial class DocumentStatusResult
    {
        [CodeGenMember("Error")]
        private readonly JsonElement _error;

        /// <summary>
        /// Document Id.
        /// </summary>
        [CodeGenMember("Id")]
        public string Id { get; }

        /// <summary>
        /// Location of the translated document in the target container.
        /// </summary>
        [CodeGenMember("Path")]
        public Uri TranslatedDocumentUri { get; }

        /// <summary>
        /// Location of the original document in the source container.
        /// </summary>
        [CodeGenMember("SourcePath")]
        public Uri SourceDocumentUri { get; }

        /// <summary>
        /// The language code of the language the document was translated to.
        /// This property will have a value only when the document was successfully processed.
        /// </summary>
        [CodeGenMember("To")]
        public string TranslatedToLanguageCode { get; }

        /// <summary>
        /// The date time when the document was created.
        /// </summary>
        [CodeGenMember("CreatedDateTimeUtc")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// The date time when the document's status was last updated.
        /// </summary>
        [CodeGenMember("LastActionDateTimeUtc")]
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// Characters charged for the document by the Document Translation service.
        /// </summary>
        [CodeGenMember("CharacterCharged")]
        public long CharactersCharged { get; }

        /// <summary>
        /// Progress of the translation if available. Value is between [0, 100].
        /// </summary>
        public float TranslationProgressPercentage => Progress * 100;

        /// <summary>
        /// Status of the document.
        /// </summary>
        public DocumentTranslationStatus Status { get; }

        /// <summary>
        /// Gets the error explaining why the translation operation failed on this
        /// document. This property will have a value only when the document
        /// cannot be processed.
        /// </summary>
        public ResponseError Error => _error.ValueKind == JsonValueKind.Undefined ? null : JsonSerializer.Deserialize<ResponseError>(_error.GetRawText());

        [CodeGenMember("Progress")]
        internal float Progress { get; }
    }
}
