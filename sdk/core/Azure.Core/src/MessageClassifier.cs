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
    /// </summary>
    public abstract class MessageClassifier
    {
        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isError"></param>
        /// <returns></returns>
        public abstract bool TryClassify(HttpMessage message, out bool isError);
    }
}
