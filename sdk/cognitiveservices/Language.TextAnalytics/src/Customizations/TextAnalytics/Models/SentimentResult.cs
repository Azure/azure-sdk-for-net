//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models
{
    using Newtonsoft.Json;

    public partial class SentimentResult
    {
        /// <summary>
        /// Initializes a new instance of the SentimentResult class.
        /// </summary>
        public SentimentResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SentimentResult class.
        /// </summary>
        /// <param name="score">A decimal number between 0 and 1 denoting the
        /// sentiment of the document. A score above 0.7 usually refers to a
        /// positive document while a score below 0.3 normally has a negative
        /// connotation. Mid values refer to neutral text.</param>
        /// <param name="errorMessage">Error or Warning related to the document.</param>
        /// <param name="statistics">(Optional) if showStats=true was specified
        /// in the request this field will contain information about the
        /// request payload.</param>
        public SentimentResult(double? score = default(double?), string errorMessage = default(string), RequestStatistics statistics = default(RequestStatistics))
        {
            Score = score;
            ErrorMessage = errorMessage;
            Statistics = statistics;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a decimal number between 0 and 1 denoting the
        /// sentiment of the document. A score above 0.7 usually refers to a
        /// positive document while a score below 0.3 normally has a negative
        /// connotation. Mid values refer to neutral text.
        /// </summary>
        [JsonProperty(PropertyName = "score")]
        public double? Score { get; set; }

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
        public RequestStatistics Statistics { get; set; }
    }
}
