// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.AI.Translation.Document.Models;
namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Model factory that enables mocking for the Document Translation Library.
    /// </summary>
    [CodeGenModel("BatchDocumentTranslationModelFactory")]
    public static partial class DocumentTranslationModelFactory
    {
        #region Errors
        /// <summary>
        /// Initializes a new instance of <see cref="Document.DocumentTranslationError"/> for mocking purposes.
        /// </summary>
        /// <param name="errorCode">Sets the <see cref="DocumentTranslationError.ErrorCode"/> property.</param>
        /// <param name="message">Sets the <see cref="DocumentTranslationError.Message"/> property.</param>
        /// <param name="target">Sets the <see cref="DocumentTranslationError.Target"/> property.</param>
        /// <returns>A new instance of <see cref="Document.DocumentTranslationError"/> for mocking purposes.</returns>
        public static DocumentTranslationError DocumentTranslationError(
            DocumentTranslationErrorCode  errorCode,
            string message,
            string target
            )
        {
            return new DocumentTranslationError(errorCode, message, target, default);
        }
        #endregion Errors

        #region Statuses
        /// <summary>
        /// Initializes a new instance of <see cref="Document.DocumentStatus"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DocumentStatus.Id"/> property.</param>
        /// <param name="sourceDocumentUri">Sets the <see cref="DocumentStatus.SourceDocumentUri"/> property.</param>
        /// <param name="translatedDocumentUri">Sets the <see cref="DocumentStatus.TranslatedDocumentUri"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="DocumentStatus.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="DocumentStatus.LastModified"/> property.</param>
        /// <param name="status">Sets the <see cref="DocumentStatus.Status"/> property.</param>
        /// <param name="translatedTo">Sets the <see cref="DocumentStatus.TranslatedTo"/> property.</param>
        /// <param name="progress">Sets the <see cref="DocumentStatus.Progress"/> property.</param>
        /// <param name="charactersCharged">Sets the <see cref="DocumentStatus.CharactersCharged"/> property.</param>
        /// <returns>A new instance of <see cref="Document.DocumentStatus"/> for mocking purposes.</returns>
        public static DocumentStatus DocumentStatus(
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
            return new DocumentStatus(translatedDocumentUri, sourceDocumentUri, createdOn, lastModified, status, translatedTo, default, progress, id, charactersCharged);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Document.DocumentStatus"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="DocumentStatus.Id"/> property.</param>
        /// <param name="sourceDocumentUri">Sets the <see cref="DocumentStatus.SourceDocumentUri"/> property.</param>
        /// <param name="error">Sets the <see cref="DocumentStatus.Error"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="DocumentStatus.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="DocumentStatus.LastModified"/> property.</param>
        /// <param name="status">Sets the <see cref="DocumentStatus.Status"/> property.</param>
        /// <param name="translatedTo">Sets the <see cref="DocumentStatus.TranslatedTo"/> property.</param>
        /// <param name="progress">Sets the <see cref="DocumentStatus.Progress"/> property.</param>
        /// <param name="charactersCharged">Sets the <see cref="DocumentStatus.CharactersCharged"/> property.</param>
        /// <returns>A new instance of <see cref="Document.DocumentStatus"/> for mocking purposes.</returns>
        public static DocumentStatus DocumentStatus(
            string id,
            Uri sourceDocumentUri,
            DocumentTranslationError error,
            DateTimeOffset createdOn,
            DateTimeOffset lastModified,
            DocumentTranslationStatus status,
            string translatedTo,
            float progress,
            long charactersCharged
            )
        {
            return new DocumentStatus(default, sourceDocumentUri, createdOn, lastModified, status, translatedTo, error, progress, id, charactersCharged);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Document.TranslationStatus"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="TranslationStatus.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="TranslationStatus.CreatedOn"/> property.</param>
        /// <param name="lastModified">Sets the <see cref="TranslationStatus.LastModified"/> property.</param>
        /// <param name="status">Sets the <see cref="TranslationStatus.Status"/> property.</param>
        /// <param name="error">Sets the <see cref="TranslationStatus.Error"/> property.</param>
        /// <param name="total">Sets the <see cref="StatusSummary.Total"/> and the <see cref="TranslationStatus.DocumentsTotal"/> properties.</param>
        /// <param name="failed">Sets the <see cref="StatusSummary.Failed"/> and the <see cref="TranslationStatus.DocumentsFailed"/> properties.</param>
        /// <param name="success">Sets the <see cref="StatusSummary.Success"/> and the <see cref="TranslationStatus.DocumentsSucceeded"/> properties.</param>
        /// <param name="inProgress">Sets the <see cref="StatusSummary.InProgress"/> and the <see cref="TranslationStatus.DocumentsInProgress"/> properties.</param>
        /// <param name="notYetStarted">Sets the <see cref="StatusSummary.NotYetStarted"/> and the <see cref="TranslationStatus.DocumentsNotStarted"/> properties.</param>
        /// <param name="canceled">Sets the <see cref="StatusSummary.Cancelled"/> and the <see cref="TranslationStatus.DocumentsCanceled"/> properties.</param>
        /// <param name="totalCharacterCharged">Sets the <see cref="StatusSummary.TotalCharacterCharged"/> and the <see cref="TranslationStatus.TotalCharactersCharged"/> properties.</param>
        /// <returns>A new instance of <see cref="Document.TranslationStatus"/> for mocking purposes.</returns>
        public static TranslationStatus TranslationStatus(
            string id,
            DateTimeOffset createdOn,
            DateTimeOffset lastModified,
            DocumentTranslationStatus status,
            DocumentTranslationError error,
            int total,
            int failed,
            int success,
            int inProgress,
            int notYetStarted,
            int canceled,
            long totalCharacterCharged
            )
        {
            StatusSummary newSummary = new StatusSummary(total, failed, success, inProgress, notYetStarted, canceled, totalCharacterCharged);
            return new TranslationStatus(id, createdOn, lastModified, status, error, newSummary);
        }
        #endregion Statuses
    }
}
