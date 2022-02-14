// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes an HTTP message and determines if the response it holds
    /// should be treated as an error response. A classifier of this type may use information
    /// from the request, the response, or other message property to decide
    /// whether and how to classify the message.
    /// <para/>
    /// This type's <code>TryClassify</code> method allows chaining together classifiers,
    /// such that if a classifier in the chain returns false from
    /// <code>TryClassify</code>, it means that the classifier has no opinion regarding whether
    /// the response should be treated an error by the pipeline. If it returns true, its classification
    /// will be used and no other classifiers in the chain will be called.
    /// </summary>
    public abstract class HttpMessageClassifier
    {
        /// <summary>
        /// Populates the <code>isError</code> out parameter to indicate whether or not
        /// to classify the message's response as an error.
        /// </summary>
        /// <param name="message">The message to classify.</param>
        /// <param name="isError">Whether the message's response should be considered an error.</param>
        /// <returns><code>true</code> if the classifier was able to classify this message; <code>false</code> otherwise.</returns>
        public abstract bool TryClassify(HttpMessage message, out bool isError);
    }
}
