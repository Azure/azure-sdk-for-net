//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class MultiLanguageInput
    {
        /// <summary>
        /// Initializes a new instance of the MultiLanguageInput class.
        /// </summary>
        public MultiLanguageInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MultiLanguageInput class.
        /// </summary>
        /// <param name="language">This is the 2 letter ISO 639-1
        /// representation of a language. For example, use "en" for English;
        /// "es" for Spanish etc.,</param>
        /// <param name="id">Unique, non-empty document identifier.</param>
        public MultiLanguageInput(string id = default, string text = default, string language = default)
        {
            Language = language;
            Id = id;
            Text = text;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets this is the 2 letter ISO 639-1 representation of a
        /// language. For example, use "en" for English; "es" for Spanish etc.,
        /// </summary>
        [JsonProperty(PropertyName = "language", Order = 3)]
        public string Language { get; set; }

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
