// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// An input representing an individual text document to
    /// be analyzed by the Text Analytics predictive model for a given operation.
    /// </summary>
    public class TextAnalyticsInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsInput"/>
        /// class for the specified service instance.
        /// </summary>
        internal TextAnalyticsInput(string id, string text)
        {
            Id = id;
            Text = text;
        }

        /// <summary>
        /// Gets the unique, non-empty identifier for the document.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the text of the document.
        /// </summary>
        public string Text { get; }
    }
}
