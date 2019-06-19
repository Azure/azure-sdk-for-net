//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics
{
    using Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for TextAnalyticsClient.
    /// </summary>
    public static partial class TextAnalyticsClientExtensions
    {
            /// <summary>
            /// The API returns the detected language and a numeric score between 0 and 1.
            /// </summary>
            /// <remarks>
            /// Scores close to 1 indicate 100% certainty that the identified language is
            /// true. A total of 120 languages are supported.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='showStats'>
            /// (optional) if set to true, response will contain input and document level
            /// statistics.
            /// </param>
            /// <param name='languageBatchInput'>
            /// Collection of documents to analyze.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<LanguageBatchResult> DetectLanguageBatchAsync(this ITextAnalyticsClient operations, LanguageBatchInput languageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
            {
                using (var _result = await operations.DetectLanguageWithHttpMessagesAsync(showStats, languageBatchInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The API returns a list of recognized entities in a given document.
            /// </summary>
            /// <remarks>
            /// To get even more information on each recognized entity we recommend using
            /// the Bing Entity Search API by querying for the recognized entities names.
            /// See the &lt;a
            /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/text-analytics-supported-languages"&gt;Supported
            /// languages in Text Analytics API&lt;/a&gt; for the list of enabled
            /// languages.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='showStats'>
            /// (optional) if set to true, response will contain input and document level
            /// statistics.
            /// </param>
            /// <param name='multiLanguageBatchInput'>
            /// Collection of documents to analyze.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EntitiesBatchResult> EntitiesBatchAsync(this ITextAnalyticsClient operations, MultiLanguageBatchInput multiLanguageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
            {
                using (var _result = await operations.EntitiesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The API returns a list of strings denoting the key talking points in the
            /// input text.
            /// </summary>
            /// <remarks>
            /// See the &lt;a
            /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
            /// Analytics Documentation&lt;/a&gt; for details about the languages that are
            /// supported by key phrase extraction.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='showStats'>
            /// (optional) if set to true, response will contain input and document level
            /// statistics.
            /// </param>
            /// <param name='multiLanguageBatchInput'>
            /// Collection of documents to analyze. Documents can now contain a language
            /// field to indicate the text language
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<KeyPhraseBatchResult> KeyPhrasesBatchAsync(this ITextAnalyticsClient operations, MultiLanguageBatchInput multiLanguageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
            {
                using (var _result = await operations.KeyPhrasesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// The API returns a numeric score between 0 and 1.
            /// </summary>
            /// <remarks>
            /// Scores close to 1 indicate positive sentiment, while scores close to 0
            /// indicate negative sentiment. A score of 0.5 indicates the lack of sentiment
            /// (e.g. a factoid statement). See the &lt;a
            /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
            /// Analytics Documentation&lt;/a&gt; for details about the languages that are
            /// supported by sentiment analysis.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='showStats'>
            /// (optional) if set to true, response will contain input and document level
            /// statistics.
            /// </param>
            /// <param name='multiLanguageBatchInput'>
            /// Collection of documents to analyze.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SentimentBatchResult> SentimentBatchAsync(this ITextAnalyticsClient operations, MultiLanguageBatchInput multiLanguageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
            {
                using (var _result = await operations.SentimentWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1.
        /// </summary>
        /// <remarks>
        /// Scores close to 1 indicate 100% certainty that the identified language is
        /// true. A total of 120 languages are supported.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='countryHint'>
        /// Contry hint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<LanguageBatchResult> DetectLanguageAsync(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string countryHint = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var languageBatchInput = new LanguageBatchInput(new List<LanguageInput> { new LanguageInput("1", inputText, countryHint) });
            using (var _result = await operations.DetectLanguageWithHttpMessagesAsync(showStats, languageBatchInput, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// The API returns a list of recognized entities in a given document.
        /// </summary>
        /// <remarks>
        /// To get even more information on each recognized entity we recommend using
        /// the Bing Entity Search API by querying for the recognized entities names.
        /// See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/text-analytics-supported-languages"&gt;Supported
        /// languages in Text Analytics API&lt;/a&gt; for the list of enabled
        /// languages.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='language'>
        /// Language code.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EntitiesBatchResult> EntitiesAsync(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string language = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput> { new MultiLanguageInput("1", inputText, language) });
            using (var _result = await operations.EntitiesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// The API returns a list of strings denoting the key talking points in the
        /// input text.
        /// </summary>
        /// <remarks>
        /// See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
        /// Analytics Documentation&lt;/a&gt; for details about the languages that are
        /// supported by key phrase extraction.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='language'>
        /// Language code.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<KeyPhraseBatchResult> KeyPhrasesAsync(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string language = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput> { new MultiLanguageInput("1", inputText, language) });
            using (var _result = await operations.KeyPhrasesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// The API returns a numeric score between 0 and 1.
        /// </summary>
        /// <remarks>
        /// Scores close to 1 indicate positive sentiment, while scores close to 0
        /// indicate negative sentiment. A score of 0.5 indicates the lack of sentiment
        /// (e.g. a factoid statement). See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
        /// Analytics Documentation&lt;/a&gt; for details about the languages that are
        /// supported by sentiment analysis.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='language'>
        /// Language code.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<SentimentBatchResult> SentimentAsync(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string language = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput> { new MultiLanguageInput("1", inputText, language) });
            using (var _result = await operations.SentimentWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1.
        /// </summary>
        /// <remarks>
        /// Scores close to 1 indicate 100% certainty that the identified language is
        /// true. A total of 120 languages are supported.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='languageBatchInput'>
        /// Collection of documents to analyze.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static LanguageBatchResult DetectLanguageBatch(this ITextAnalyticsClient operations, LanguageBatchInput languageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
        {
            var _result = operations.DetectLanguageWithHttpMessagesAsync(showStats, languageBatchInput, null, cancellationToken).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns a list of recognized entities in a given document.
        /// </summary>
        /// <remarks>
        /// To get even more information on each recognized entity we recommend using
        /// the Bing Entity Search API by querying for the recognized entities names.
        /// See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/text-analytics-supported-languages"&gt;Supported
        /// languages in Text Analytics API&lt;/a&gt; for the list of enabled
        /// languages.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='multiLanguageBatchInput'>
        /// Collection of documents to analyze.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static EntitiesBatchResult EntitiesBatch(this ITextAnalyticsClient operations, MultiLanguageBatchInput multiLanguageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
        {
            var _result = operations.EntitiesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns a list of strings denoting the key talking points in the
        /// input text.
        /// </summary>
        /// <remarks>
        /// See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
        /// Analytics Documentation&lt;/a&gt; for details about the languages that are
        /// supported by key phrase extraction.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='multiLanguageBatchInput'>
        /// Collection of documents to analyze. Documents can now contain a language
        /// field to indicate the text language
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static KeyPhraseBatchResult KeyPhrasesBatch(this ITextAnalyticsClient operations, MultiLanguageBatchInput multiLanguageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
        {
            var _result = operations.KeyPhrasesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns a numeric score between 0 and 1.
        /// </summary>
        /// <remarks>
        /// Scores close to 1 indicate positive sentiment, while scores close to 0
        /// indicate negative sentiment. A score of 0.5 indicates the lack of sentiment
        /// (e.g. a factoid statement). See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
        /// Analytics Documentation&lt;/a&gt; for details about the languages that are
        /// supported by sentiment analysis.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='multiLanguageBatchInput'>
        /// Collection of documents to analyze.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static SentimentBatchResult SentimentBatch(this ITextAnalyticsClient operations, MultiLanguageBatchInput multiLanguageBatchInput = default, bool? showStats = default, CancellationToken cancellationToken = default)
        {
            var _result = operations.SentimentWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1.
        /// </summary>
        /// <remarks>
        /// Scores close to 1 indicate 100% certainty that the identified language is
        /// true. A total of 120 languages are supported.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='countryHint'>
        /// Contry hint.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static LanguageBatchResult DetectLanguage(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string countryHint = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var languageBatchInput = new LanguageBatchInput(new List<LanguageInput> { new LanguageInput("1", inputText, countryHint) });
            var _result = operations.DetectLanguageWithHttpMessagesAsync(showStats, languageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns a list of recognized entities in a given document.
        /// </summary>
        /// <remarks>
        /// To get even more information on each recognized entity we recommend using
        /// the Bing Entity Search API by querying for the recognized entities names.
        /// See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/text-analytics-supported-languages"&gt;Supported
        /// languages in Text Analytics API&lt;/a&gt; for the list of enabled
        /// languages.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='language'>
        /// Language code.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static EntitiesBatchResult Entities(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string language = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput> { new MultiLanguageInput("1", inputText, language) });
            var _result = operations.EntitiesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns a list of strings denoting the key talking points in the
        /// input text.
        /// </summary>
        /// <remarks>
        /// See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
        /// Analytics Documentation&lt;/a&gt; for details about the languages that are
        /// supported by key phrase extraction.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='language'>
        /// Language code.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static KeyPhraseBatchResult KeyPhrases(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string language = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput> { new MultiLanguageInput("1", inputText, language) });
            var _result = operations.KeyPhrasesWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }

        /// <summary>
        /// The API returns a numeric score between 0 and 1.
        /// </summary>
        /// <remarks>
        /// Scores close to 1 indicate positive sentiment, while scores close to 0
        /// indicate negative sentiment. A score of 0.5 indicates the lack of sentiment
        /// (e.g. a factoid statement). See the &lt;a
        /// href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview#supported-languages"&gt;Text
        /// Analytics Documentation&lt;/a&gt; for details about the languages that are
        /// supported by sentiment analysis.
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='showStats'>
        /// (optional) if set to true, response will contain input and document level
        /// statistics.
        /// </param>
        /// <param name='inputText'>
        /// Input text of one document.
        /// </param>
        /// <param name='language'>
        /// Language code.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static SentimentBatchResult Sentiment(
            this ITextAnalyticsClient operations,
            string inputText = default,
            string language = "en",
            bool? showStats = default,
            CancellationToken cancellationToken = default)
        {
            var multiLanguageBatchInput = new MultiLanguageBatchInput(new List<MultiLanguageInput> { new MultiLanguageInput("1", inputText, language) });
            var _result = operations.SentimentWithHttpMessagesAsync(showStats, multiLanguageBatchInput, null, cancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();
            return _result.Body;
        }
    }
}
