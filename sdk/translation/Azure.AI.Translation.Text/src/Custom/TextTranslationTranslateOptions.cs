// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Client options for TextTranslationClient.Translate </summary>
    public partial class TextTranslationTranslateOptions
    {
        /// <summary>
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de and to=it to translate to German and Italian.
        /// </summary>
        public IEnumerable<string> TargetLanguages { get; }
        /// <summary>
        /// Array of the text to be translated.
        /// </summary>
        public IEnumerable<string> Content { get; }
        /// <summary>
        /// A client-generated GUID to uniquely identify the request.
        /// </summary>
        public string ClientTraceId { get; set; }
        /// <summary>
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </summary>
        public string SourceLanguage { get; set; }
        /// <summary>
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html.
        /// </summary>
        public TextType? TextType { get; set; }
        /// <summary>
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted.
        /// </summary>
        public ProfanityAction? ProfanityAction { get; set; }
        /// <summary>
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag.
        /// </summary>
        public ProfanityMarker? ProfanityMarker { get; set; }
        /// <summary>
        /// Specifies whether to include alignment projection from source text to translated text.
        /// Possible values are: true or false (default).
        /// </summary>
        public bool? IncludeAlignment { get; set; }
        /// <summary>
        /// Specifies whether to include sentence boundaries for the input text and the translated text.
        /// Possible values are: true or false (default).
        /// </summary>
        public bool? IncludeSentenceLength { get; set; }
        /// <summary>
        /// Specifies a fallback language if the language of the input text can&apos;t be identified.
        /// Language autodetection is applied when the from parameter is omitted. If detection fails,
        /// the SuggestedFrom language will be assumed.
        /// </summary>
        public string SuggestedFrom { get; set; }
        /// <summary>
        /// Specifies the script of the input text.
        /// </summary>
        public string FromScript { get; set; }
        /// <summary>
        /// Specifies the script of the translated text.
        /// </summary>
        public string ToScript { get; set; }
        /// <summary>
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// Possible values are: true (default) or false.
        ///
        /// AllowFallback=false specifies that the translation should only use systems trained for the category specified
        /// by the request. If a translation for language X to language Y requires chaining through a pivot language E,
        /// then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category.
        /// If no system is found with the specific category, the request will return a 400 status code. AllowFallback=true
        /// specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// </summary>
        public bool? AllowFallback { get; set; }

        /// <summary> Initializes new instance of TextTranslationTranslateOptions. </summary>
        /// <param name="targetLanguages">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated.</param>
        public TextTranslationTranslateOptions(IEnumerable<string> targetLanguages, IEnumerable<string> content)
        {
            Argument.AssertNotNull(targetLanguages, nameof(targetLanguages));
            Argument.AssertNotNull(content, nameof(content));
            TargetLanguages = targetLanguages;
            Content = content;
        }

        /// <summary> Initializes new instance of TextTranslationTranslateOptions. </summary>
        /// <param name="targetLanguage">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// </param>
        /// <param name="content">Text to be translated.</param>
        public TextTranslationTranslateOptions(string targetLanguage, string content)
        {
            Argument.AssertNotNullOrWhiteSpace(targetLanguage, nameof(targetLanguage));
            Argument.AssertNotNullOrWhiteSpace(content, nameof(content));
            TargetLanguages = new[] { targetLanguage };
            Content = new[] { content };
        }

        /// <summary> Initializes new instance of TextTranslationTranslateOptions. </summary>
        /// <param name="targetLanguages">
        /// Specifies the language of the output text. The target language must be one of the supported languages included
        /// in the translation scope. For example, use to=de to translate to German.
        /// It&apos;s possible to translate to multiple languages simultaneously by repeating the parameter in the query string.
        /// For example, use to=de&amp;to=it to translate to German and Italian.
        /// </param>
        /// <param name="content"> Array of the text to be translated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        /// <param name="sourceLanguage">
        /// Specifies the language of the input text. Find which languages are available to translate from by
        /// looking up supported languages using the translation scope. If the from parameter isn&apos;t specified,
        /// automatic language detection is applied to determine the source language.
        ///
        /// You must use the from parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <param name="category">
        /// A string specifying the category (domain) of the translation. This parameter is used to get translations
        /// from a customized system built with Custom Translator. Add the Category ID from your Custom Translator
        /// project details to this parameter to use your deployed customized system. Default value is: general.
        /// </param>
        /// <param name="profanityAction">
        /// Specifies how profanities should be treated in translations.
        /// Possible values are: NoAction (default), Marked or Deleted.
        /// </param>
        /// <param name="profanityMarker">
        /// Specifies how profanities should be marked in translations.
        /// Possible values are: Asterisk (default) or Tag.
        /// </param>
        /// <param name="includeAlignment">
        /// Specifies whether to include alignment projection from source text to translated text.
        /// Possible values are: true or false (default).
        /// </param>
        /// <param name="includeSentenceLength">
        /// Specifies whether to include sentence boundaries for the input text and the translated text.
        /// Possible values are: true or false (default).
        /// </param>
        /// <param name="suggestedFrom">
        /// Specifies a fallback language if the language of the input text can&apos;t be identified.
        /// Language autodetection is applied when the from parameter is omitted. If detection fails,
        /// the suggestedFrom language will be assumed.
        /// </param>
        /// <param name="fromScript"> Specifies the script of the input text. </param>
        /// <param name="toScript"> Specifies the script of the translated text. </param>
        /// <param name="allowFallback">
        /// Specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// Possible values are: true (default) or false.
        ///
        /// allowFallback=false specifies that the translation should only use systems trained for the category specified
        /// by the request. If a translation for language X to language Y requires chaining through a pivot language E,
        /// then all the systems in the chain (X → E and E → Y) will need to be custom and have the same category.
        /// If no system is found with the specific category, the request will return a 400 status code. allowFallback=true
        /// specifies that the service is allowed to fall back to a general system when a custom system doesn&apos;t exist.
        /// </param>
        public TextTranslationTranslateOptions(IEnumerable<string> targetLanguages, IEnumerable<string> content, string clientTraceId = null, string sourceLanguage = null, TextType? textType = null, string category = null, ProfanityAction? profanityAction = null, ProfanityMarker? profanityMarker = null, bool? includeAlignment = null, bool? includeSentenceLength = null, string suggestedFrom = null, string fromScript = null, string toScript = null, bool? allowFallback = null): base()
        {
            TargetLanguages = targetLanguages;
            Content = content;
            ClientTraceId = clientTraceId;
            SourceLanguage = sourceLanguage;
            TextType = textType;
            Category = category;
            ProfanityAction = profanityAction;
            ProfanityMarker = profanityMarker;
            IncludeAlignment = includeAlignment;
            IncludeSentenceLength = includeSentenceLength;
            SuggestedFrom = suggestedFrom;
            FromScript = fromScript;
            ToScript = toScript;
            AllowFallback = allowFallback;
        }
    }
}
