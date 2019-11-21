// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class DetectLanguageInput
    {
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        public DetectLanguageInput(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets unique, non-empty document identifier.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// </summary>
        public string CountryHint { get; set; }

        /// <summary>
        /// </summary>
        public string Text { get; set; }
    }
}
