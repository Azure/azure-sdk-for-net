//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models
{
    using Newtonsoft.Json;

    public partial class LanguageInput
    {
        /// <summary>
        /// Initializes a new instance of the LanguageInput class.
        /// </summary>
        public LanguageInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the LanguageInput class.
        /// </summary>
        /// <param name="id">Unique, non-empty document identifier.</param>
        public LanguageInput(string id = default, string text = default, string countryHint = default)
        {
            CountryHint = countryHint;
            Id = id;
            Text = text;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "countryHint", Order = 3)]
        public string CountryHint { get; set; }

        /// <summary>
        /// Gets or sets unique, non-empty document identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id", Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "text", Order = 2)]
        public string Text { get; set; }

    }
}
