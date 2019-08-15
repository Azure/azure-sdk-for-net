//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class EntitiesResult
    {
        /// <summary>
        /// Initializes a new instance of the EntitiesResult class.
        /// </summary>
        public EntitiesResult()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EntitiesResult class.
        /// </summary>
        /// <param name="entities">Recognized entities in the document.</param>
        /// <param name="errorMessage">Error or Warning related to the document.</param>
        /// <param name="statistics">(Optional) if showStats=true was specified
        /// in the request this field will contain information about the
        /// request payload.</param>
        public EntitiesResult(IList<EntityRecord> entities = default(IList<EntityRecord>), string errorMessage = default(string), RequestStatistics statistics = default(RequestStatistics))
        {
            Entities = entities;
            ErrorMessage = errorMessage;
            Statistics = statistics;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets recognized entities in the document.
        /// </summary>
        [JsonProperty(PropertyName = "entities")]
        public IList<EntityRecord> Entities { get; private set; }

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
