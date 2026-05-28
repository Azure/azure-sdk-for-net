//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class KeyPhraseResult
    {
        /// <summary>
        /// Initializes a new instance of the KeyPhraseResult class.
        /// </summary>
        public KeyPhraseResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the KeyPhraseResult class.
        /// </summary>
        /// <param name="keyPhrases">A list of representative words or phrases.
        /// The number of key phrases returned is proportional to the number of
        /// words in the input document.</param>
        /// <param name="errorMessage">Error or Warning related to the document.</param>
        /// <param name="statistics">(Optional) if showStats=true was specified
        /// in the request this field will contain information about the
        /// request payload.</param>
        public KeyPhraseResult(IList<string> keyPhrases = default(IList<string>), string errorMessage = default(string), RequestStatistics statistics = default(RequestStatistics))
        {
            KeyPhrases = keyPhrases;
            ErrorMessage = errorMessage;
            Statistics = statistics;
            CustomInit();
        }


        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets a list of representative words or phrases. The number of key
        /// phrases returned is proportional to the number of words in the
        /// input document.
        /// </summary>
        [JsonProperty(PropertyName = "keyPhrases")]
        public IList<string> KeyPhrases { get; private set; }

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
