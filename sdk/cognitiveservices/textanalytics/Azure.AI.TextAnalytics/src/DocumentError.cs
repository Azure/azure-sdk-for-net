// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct DocumentError
    {
        internal DocumentError(string id, string message)
        {
            Id = id;
            Message = message;
        }

        /// <summary>
        /// Gets input document unique identifier the error refers to.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets error message.
        /// </summary>
        public string Message { get; }
    }
}
