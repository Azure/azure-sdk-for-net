// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public struct DocumentError
    {
        /// <summary>
        /// Gets or sets input document unique identifier the error refers to.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets or sets error message.
        /// </summary>
        public string Message { get; internal set; }
    }
}
