// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// An input to the detect language operation.  This object allows the
    /// caller to specify a unique document id, as well as the full text of a
    /// document and a hint indicating the document's country of origin to assist
    /// the text analytics predictive model in detecting the document's language.
    /// </summary>
    public class DetectLanguageInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetectLanguageInput"/>
        /// class.
        /// </summary>
        /// <param name="id">The id of the document represented by this instance.
        /// The id must be unique within the batch of documents analyzed in a
        /// given detect language operation.</param>
        /// <param name="text">The text of the document.</param>
        public DetectLanguageInput(string id, string text)
        {
            Id = id;
            Text = text;
        }

        /// <summary>
        /// Gets the unique, non-empty identifier for this input document.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets or sets a hint to assist the text analytics model in predicting
        /// the language the document is written in.  If unspecified, this value
        /// will be set to the default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.  If set to an empty string, the
        /// service will apply a model where the country is explicitly set to
        /// "None".
        /// </summary>
        public string CountryHint { get; set; }

        /// <summary>
        /// Gets the text of the document.
        /// </summary>
        public string Text { get; }
    }
}
