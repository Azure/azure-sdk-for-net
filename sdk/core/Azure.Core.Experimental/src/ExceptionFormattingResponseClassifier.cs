// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Wrap ResponseClassifier and add exception formatting methods.
    /// </summary>
    internal class ExceptionFormattingResponseClassifier : ResponseClassifier
    {
        private ResponseClassifier _responseClassifier;
        private HttpMessageSanitizer _messageSanitizer;

        private bool _computedExceptionDetails;
        private string? _exceptionMessage;
        private string? _errorCode;

        public override bool IsErrorResponse(HttpMessage message) => _responseClassifier.IsErrorResponse(message);

        public override bool IsRetriable(HttpMessage message, Exception exception) => _responseClassifier.IsRetriable(message, exception);

        public override bool IsRetriableException(Exception exception) => _responseClassifier.IsRetriableException(exception);

        public override bool IsRetriableResponse(HttpMessage message) => _responseClassifier.IsRetriableResponse(message);

        /// <summary>
        /// </summary>
        public ExceptionFormattingResponseClassifier(ResponseClassifier responseClassifier, DiagnosticsOptions diagnostics)
        {
            _responseClassifier = responseClassifier;
            _messageSanitizer = ClientDiagnostics.CreateMessageSanitizer(diagnostics);
        }

        public string GetExceptionMessage(Response response)
        {
            if (!_computedExceptionDetails)
            {
                ComputeExceptionDetails(response);
            }

            return _exceptionMessage!;
        }

        public string GetErrorCode(Response response)
        {
            if (!_computedExceptionDetails)
            {
                ComputeExceptionDetails(response);
            }

            return _errorCode!;
        }

        private void ComputeExceptionDetails(Response response)
        {
            string? message = null;
            string? errorCode = null;

            string? content = ClientDiagnostics.ReadContentAsync(response, false).EnsureCompleted();
            ClientDiagnostics.ExtractAzureErrorContent(content, ref message, ref errorCode);
            _exceptionMessage = ClientDiagnostics.CreateRequestFailedMessageWithContent(response, message, content, errorCode, null, _messageSanitizer);
            _errorCode = errorCode;
            _computedExceptionDetails = true;
        }
    }
}
