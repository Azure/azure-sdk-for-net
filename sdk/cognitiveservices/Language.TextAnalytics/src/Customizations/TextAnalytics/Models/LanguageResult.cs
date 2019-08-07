//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public partial class LanguageResult
    {
        /// <summary>
        /// Initializes a new instance of the LanguageResult class.
        /// </summary>
        public LanguageResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the LanguageResult class.
        /// </summary>
        /// <param name="detectedLanguages">A list of extracted languages.</param>
        /// <param name="errorMessage">Error or Warning related to the document.</param>
        /// <param name="statistics">(Optional) if showStats=true was specified
        /// in the request this field will contain information about the
        /// request payload.</param>
        public LanguageResult(IList<DetectedLanguage> detectedLanguages = default(IList<DetectedLanguage>), string errorMessage = default(string), RequestStatistics statistics = default(RequestStatistics))
        {
            DetectedLanguages = detectedLanguages;
            ErrorMessage = errorMessage;
            Statistics = statistics;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a list of extracted languages.
        /// </summary>
        [JsonProperty(PropertyName = "detectedLanguages")]
        public IList<DetectedLanguage> DetectedLanguages { get; set; }

        /// <summary>
        /// Gets error or warning for the request.
        /// </summary>
        [JsonProperty(PropertyName = "ErrorMessage")]
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Gets (Optional) if showStats=true was specified in the request this
        /// field will contain information about the request payload.
        /// </summary>
        [JsonProperty(PropertyName = "statistics")]
        public RequestStatistics Statistics { get; private set; }

    }
}
