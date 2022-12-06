// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// An input to the detect language operation.  This object allows the
    /// caller to specify a unique document id, as well as the full text of a
    /// document and a hint indicating the document's country of origin to assist
    /// the predictive model in detecting the document's language.
    /// </summary>
    public class DetectLanguageInput : TextAnalyticsInput
    {
        /// <summary>
        /// A wild card that allows to set CountryHint to None
        /// so the service model doesn't use any default CountryHint.
        /// </summary>
        public const string None = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="DetectLanguageInput"/>
        /// class.
        /// </summary>
        /// <param name="id">The id of the document represented by this instance.
        /// The id must be unique within the batch of documents analyzed in a
        /// given detect language operation.</param>
        /// <param name="text">The text of the document.</param>
        public DetectLanguageInput(string id, string text) : base(id, text) { }

        /// <summary>
        /// Gets or sets a hint to assist the model in predicting
        /// the language the document is written in.  If unspecified, this value
        /// will be set to the default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.
        /// To remove this behavior, set to <see cref="None"/>.
        /// </summary>
        public string CountryHint { get; set; }
    }
}
