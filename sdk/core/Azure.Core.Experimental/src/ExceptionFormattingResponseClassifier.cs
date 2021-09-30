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

        internal HttpMessageSanitizer MessageSanitizer { get; set; }

        public override bool IsErrorResponse(HttpMessage message) => _responseClassifier.IsErrorResponse(message);

        public override bool IsRetriable(HttpMessage message, Exception exception) => _responseClassifier.IsRetriable(message, exception);

        public override bool IsRetriableException(Exception exception) => _responseClassifier.IsRetriableException(exception);

        public override bool IsRetriableResponse(HttpMessage message) => _responseClassifier.IsRetriableResponse(message);

        /// <summary>
        /// </summary>
        public ExceptionFormattingResponseClassifier(ResponseClassifier responseClassifier, DiagnosticsOptions diagnostics)
        {
            _responseClassifier = responseClassifier;
            MessageSanitizer = ClientDiagnostics.CreateMessageSanitizer(diagnostics);
        }
    }
}
