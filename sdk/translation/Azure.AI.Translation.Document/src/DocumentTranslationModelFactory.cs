// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Model factory that enables mocking for the Document Translation Library.
    /// </summary>
    [CodeGenModel("AITranslationDocumentModelFactory")]
    public static partial class DocumentTranslationModelFactory
    {
        #region Statuses
        /// <summary>
        /// Initializes a new instance of <see cref="Document.DocumentStatusResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DocumentStatusResult.Id"/> property.</param>
        /// <param name="sourceDocumentUri">Sets the <see cref="DocumentStatusResult.SourceDocumentUri"/> property.</param>
        /// <param name="translatedDocumentUri">Sets the <see cref="DocumentStatusResult.TranslatedDocumentUri"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="DocumentStatusResult.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="DocumentStatusResult.LastModified"/> property.</param>
        /// <param name="status">Sets the <see cref="DocumentStatusResult.Status"/> property.</param>
        /// <param name="translatedTo">Sets the <see cref="DocumentStatusResult.TranslatedToLanguageCode"/> property.</param>
        /// <param name="progress">Sets the <see cref="DocumentStatusResult.Progress"/> property.</param>
        /// <param name="charactersCharged">Sets the <see cref="DocumentStatusResult.CharactersCharged"/> property.</param>
        /// <returns>A new instance of <see cref="Document.DocumentStatusResult"/> for mocking purposes.</returns>
        public static DocumentStatusResult DocumentStatusResult(
            string id,
            Uri sourceDocumentUri,
            Uri translatedDocumentUri,
            DateTimeOffset createdOn,
            DateTimeOffset lastModified,
            DocumentTranslationStatus status,
            string translatedTo,
            float progress,
            long charactersCharged
            )
        {
            return new DocumentStatusResult(translatedDocumentUri, sourceDocumentUri, createdOn, lastModified, status, translatedTo, default, progress, id, charactersCharged);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Document.DocumentStatusResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DocumentStatusResult.Id"/> property.</param>
        /// <param name="sourceDocumentUri">Sets the <see cref="DocumentStatusResult.SourceDocumentUri"/> property.</param>
        /// <param name="error">Sets the <see cref="DocumentStatusResult.Error"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="DocumentStatusResult.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="DocumentStatusResult.LastModified"/> property.</param>
        /// <param name="status">Sets the <see cref="DocumentStatusResult.Status"/> property.</param>
        /// <param name="translatedTo">Sets the <see cref="DocumentStatusResult.TranslatedToLanguageCode"/> property.</param>
        /// <param name="progress">Sets the <see cref="DocumentStatusResult.Progress"/> property.</param>
        /// <param name="charactersCharged">Sets the <see cref="DocumentStatusResult.CharactersCharged"/> property.</param>
        /// <returns>A new instance of <see cref="Document.DocumentStatusResult"/> for mocking purposes.</returns>
        public static DocumentStatusResult DocumentStatusResult(
            string id,
            Uri sourceDocumentUri,
            BinaryData error,
            DateTimeOffset createdOn,
            DateTimeOffset lastModified,
            DocumentTranslationStatus status,
            string translatedTo,
            float progress,
            long charactersCharged
            )
        {
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new DocumentStatusResult(default, sourceDocumentUri, createdOn, lastModified, status, translatedTo, errorJson, progress, id, charactersCharged);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Document.TranslationStatusResult"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TranslationStatusResult.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="TranslationStatusResult.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="TranslationStatusResult.LastModified"/> property.</param>
        /// <param name="status">Sets the <see cref="TranslationStatusResult.Status"/> property.</param>
        /// <param name="error">Sets the <see cref="TranslationStatusResult.Error"/> property.</param>
        /// <param name="total">Sets the <see cref="TranslationStatusSummary.Total"/> and the <see cref="TranslationStatusResult.DocumentsTotal"/> properties.</param>
        /// <param name="failed">Sets the <see cref="TranslationStatusSummary.Failed"/> and the <see cref="TranslationStatusResult.DocumentsFailed"/> properties.</param>
        /// <param name="success">Sets the <see cref="TranslationStatusSummary.Success"/> and the <see cref="TranslationStatusResult.DocumentsSucceeded"/> properties.</param>
        /// <param name="inProgress">Sets the <see cref="TranslationStatusSummary.InProgress"/> and the <see cref="TranslationStatusResult.DocumentsInProgress"/> properties.</param>
        /// <param name="notYetStarted">Sets the <see cref="TranslationStatusSummary.NotYetStarted"/> and the <see cref="TranslationStatusResult.DocumentsNotStarted"/> properties.</param>
        /// <param name="canceled">Sets the <see cref="TranslationStatusSummary.Cancelled"/> and the <see cref="TranslationStatusResult.DocumentsCanceled"/> properties.</param>
        /// <param name="totalCharacterCharged">Sets the <see cref="TranslationStatusSummary.TotalCharacterCharged"/> and the <see cref="TranslationStatusResult.TotalCharactersCharged"/> properties.</param>
        /// <returns>A new instance of <see cref="Document.TranslationStatusResult"/> for mocking purposes.</returns>
        public static TranslationStatusResult TranslationStatusResult(
            string id,
            DateTimeOffset createdOn,
            DateTimeOffset lastModified,
            DocumentTranslationStatus status,
            BinaryData error,
            int total,
            int failed,
            int success,
            int inProgress,
            int notYetStarted,
            int canceled,
            long totalCharacterCharged
            )
        {
            TranslationStatusSummary newSummary = new TranslationStatusSummary(total, failed, success, inProgress, notYetStarted, canceled, totalCharacterCharged);
            JsonElement errorJson = error.ToObjectFromJson<JsonElement>();
            return new TranslationStatusResult(id, createdOn, lastModified, status, errorJson, newSummary);
        }
        #endregion Statuses

        /// <summary> Initializes a new instance of <see cref="Document.DocumentTranslateContent"/>. </summary>
        /// <param name="document"> Document to be translated in the form. </param>
        /// <param name="glossary"> Glossary-translation memory will be used during translation in the form. </param>
        /// <returns> A new <see cref="Document.DocumentTranslateContent"/> instance for mocking. </returns>
        public static DocumentTranslateContent DocumentTranslateContent(Stream document = null, IEnumerable<Stream> glossary = null)
        {
            glossary ??= new List<Stream>();
            var multipartGlossary = new List<MultipartFormFileData>();
            foreach (var item in glossary) {
                multipartGlossary.Add(new MultipartFormFileData(null, item, null));
            }

            return new DocumentTranslateContent(new MultipartFormFileData(null, document, null), multipartGlossary, serializedAdditionalRawData: null);
        }
    }
}
