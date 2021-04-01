// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translator.DocumentTranslation
{
    /// <summary>
    /// Status information about a particular document within a translation operation.
    /// </summary>
    [CodeGenModel("DocumentStatusDetail")]
    public partial class DocumentStatusResult
    {
        /// <summary>
        /// Document Id.
        /// </summary>
        [CodeGenMember("Id")]
        public string DocumentId { get; }

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
        public string TranslateTo { get; }

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
        public TranslationStatus Status { get; }

        /// <summary>
        /// Gets the error explaining why the translation operation failed on this
        /// document. This property will have a value only when the document
        /// cannot be processed.
        /// </summary>
        public DocumentTranslationError Error { get; }

        /// <summary>
        /// Returns true if the translation on the document is completed, independent if it succeeded or failed.
        /// </summary>
        public bool HasCompleted => Status == TranslationStatus.Succeeded
                                    || Status == TranslationStatus.Failed
                                    || Status == TranslationStatus.Cancelled
                                    || Status == TranslationStatus.ValidationFailed;

        [CodeGenMember("Progress")]
        internal float Progress { get; }
    }
}
