using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Data.TextAnalytics
{
    // TODO: make serializable
    /// <summary>
    /// </summary>
    public sealed class LanguageResult
    {
        internal LanguageResult()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="detectedLanguages"></param>
        /// <param name="errorMessage"></param>
        /// <param name="statistics"></param>
        public LanguageResult(IList<DetectedLanguage> detectedLanguages = default(IList<DetectedLanguage>), string errorMessage = default(string), RequestStatistics statistics = default(RequestStatistics))
        {
            DetectedLanguages = detectedLanguages;
            ErrorMessage = errorMessage;
            Statistics = statistics;
        }

        /// <summary>
        /// Gets or sets a list of extracted languages.
        /// </summary>
        public IList<DetectedLanguage> DetectedLanguages { get; set; }

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
