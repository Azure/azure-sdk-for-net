// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    // TODO: make serializable
    /// <summary>
    /// </summary>
    public sealed class LanguageResult
    {
        internal LanguageResult()
        {
            DetectedLanguages = new List<DetectedLanguage>();
        }

        /// <summary>
        /// Gets or sets a list of extracted languages.
        /// </summary>
        public List<DetectedLanguage> DetectedLanguages { get; private set; }

        /// <summary>
        /// Gets error or warning for the request.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Gets (Optional) if showStats=true was specified in the request this
        /// field will contain information about the request payload.
        /// </summary>
        public RequestStatistics Statistics { get; private set; }
    }
}
