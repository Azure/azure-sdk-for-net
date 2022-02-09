// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    internal class PerInvocationClassifier : ResponseClassifier
    {
        /// <summary>
        /// User-provided customization to the classifier for this invocation
        /// of an operation. This classifier has try-classifier semantics and may
        /// not provide classifications for every possible status code.
        /// </summary>
        private MessageClassifier _customization { get; }

        private ResponseClassifier _baseClassifier { get; }

        public PerInvocationClassifier(MessageClassifier customization, ResponseClassifier classifier)
        {
            _customization = customization;
            _baseClassifier = classifier;
        }

        internal override bool IsError(HttpMessage message)
        {
            bool isError;

            if (_customization?.TryClassify(message, out isError) ?? false)
            {
                return isError;
            }

            return _baseClassifier.IsError(message);
        }
    }
}
