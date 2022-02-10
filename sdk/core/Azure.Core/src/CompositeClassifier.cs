// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Composes a response classifier applying customization precedence rules as follows:
    ///   - First, try any per-invocation customizations
    ///   - Then, try any per-client customizations
    ///   - Finally, apply default logic for the operation using the base classifier, which
    ///     may have either per-operation or per-client scope.
    /// We need this class because most response classifiers are static instances,
    /// or owned outside the client, so we cannot modify them.
    /// </summary>
    internal class CompositeClassifier : ResponseClassifier
    {
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
        /// of an operation. This classifier has try-classifier semantics and may
        /// not provide classifications for every possible status code.
        /// </summary>
        internal MessageClassifier? PerCallClassifier { get; set; }

        /// <summary>
        /// </summary>
        internal MessageClassifier? PerClientClassifier { get; set; }

        internal override bool TryClassify(HttpMessage message, out bool isError)
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
