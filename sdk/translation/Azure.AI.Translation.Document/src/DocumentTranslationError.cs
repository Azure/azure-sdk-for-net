// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Translation.Document.Models;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Represents an error that occurred during a translation operation.
    /// </summary>
    [CodeGenModel("TranslationError")]
    public readonly partial struct DocumentTranslationError
    {
        /// <summary>
        /// Error code that serves as an indicator of the HTTP error code.
        /// </summary>
        [CodeGenMember("Code")]
        public DocumentTranslationErrorCode ErrorCode { get; }

        /// <summary>
        /// Message that contains more information about the reason of the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the source of the error.
        /// For example it would be 'documents' or 'document id' in case of invalid document.
        /// </summary>
        public string Target { get; }

        internal readonly InnerTranslationError InnerError { get; }

        internal DocumentTranslationError(DocumentTranslationErrorCode errorCode, string message, string target, InnerTranslationError innerError)
        {
            if (innerError != null)
            {
                // Assigns the inner error, which should be only one level down.
                ErrorCode = innerError.Code;
                Message = innerError.Message;
                Target = innerError.Target;
            }
            else
            {
                ErrorCode = errorCode;
                Message = message;
                Target = target;
            }

            InnerError = null;
        }
    }
}
