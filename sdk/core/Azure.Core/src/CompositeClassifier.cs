// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Composes a response classifier applying customization precedence rules as follows:
    ///   - First, if a custom per-invocation classifier added via <see cref="RequestContext.AddClassifier(int, bool)"/>
    ///     or <see cref="RequestContext.AddClassifier(HttpMessageClassifier)"/> applies to the message,
    ///     return its classification result.
    ///   - Then, if the custom per-client classifier apply added via
    ///     <see cref="HttpPipelineBuilder.Build(ClientOptions, HttpPipelinePolicy[], HttpPipelinePolicy[], HttpMessageClassifier)"/>
    ///     applies to the message, return its classification result.
    ///   - Finally, apply default classification logic for the operation using the base classifier,
    ///     which may have either per-operation or per-client scope.
    /// </summary>
    internal class CompositeClassifier : ResponseClassifier
    {
        // Note: We need this class because most base classifiers are either static instances
        // or owned outside the client, so we cannot modify them directly.

        /// <summary>
        /// The base classifier.
        /// </summary>
        private ResponseClassifier _classifier { get; }

        public CompositeClassifier(ResponseClassifier classifier)
        {
            _classifier = classifier;
        }

        /// <summary>
        /// User-provided customization to the classifier for this invocation
        /// of an operation. This classifier has try-classify semantics and may
        /// not provide classification for every status code or message.
        /// </summary>
        internal HttpMessageClassifier? PerCallClassifier { get; set; }

        /// <summary>
        /// User-provided customization to the classifier for all client methods.
        /// This classifier has try-classify semantics and may not provide classifications
        /// for every status code or message.
        /// </summary>
        internal HttpMessageClassifier? PerClientClassifier { get; set; }

        public override bool TryClassify(HttpMessage message, out bool isError)
        {
            if (PerCallClassifier?.TryClassify(message, out isError) ?? false)
            {
                return true;
            }

            if (PerClientClassifier?.TryClassify(message, out isError) ?? false)
            {
                return true;
            }

            isError = false;
            return false;
        }

        public override bool IsErrorResponse(HttpMessage message)
        {
            return _classifier.IsErrorResponse(message);
        }
    }
}
