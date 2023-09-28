// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Client options for TextTranslationClient.Transliterate </summary>
    public partial class TextTranslationTransliterateOptions
    {
        /// <summary>
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </summary>
        public string Language { get; }
        /// <summary>
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </summary>
        public string FromScript { get; }
        /// <summary>
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </summary>
        public string ToScript { get; }
        /// <summary>
        /// Array of the text to be transliterated.
        /// </summary>
        public IEnumerable<string> Content { get; }
        /// <summary>
        /// A client-generated GUID to uniquely identify the request.
        /// </summary>
        public string ClientTraceId { get; set; }

        /// <summary> Initializes new instance of TextTranslationTransliterateOptions. </summary>
        /// <param name="language">
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </param>
        /// <param name="fromScript">
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </param>
        /// <param name="toScript">
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </param>
        /// <param name="content"> Array of the text to be transliterated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        public TextTranslationTransliterateOptions(string language, string fromScript, string toScript, IEnumerable<string> content, string clientTraceId = null): base()
        {
            Language = language;
            FromScript = fromScript;
            ToScript = toScript;
            Content = content;
            ClientTraceId = clientTraceId;
        }

        /// <summary> Initializes new instance of TextTranslationTransliterateOptions. </summary>
        /// <param name="language">
        /// Specifies the language of the text to convert from one script to another.
        /// Possible languages are listed in the transliteration scope obtained by querying the service
        /// for its supported languages.
        /// </param>
        /// <param name="fromScript">
        /// Specifies the script used by the input text. Look up supported languages using the transliteration scope,
        /// to find input scripts available for the selected language.
        /// </param>
        /// <param name="toScript">
        /// Specifies the output script. Look up supported languages using the transliteration scope, to find output
        /// scripts available for the selected combination of input language and input script.
        /// </param>
        /// <param name="content"> The text to be transliterated. </param>
        /// <param name="clientTraceId"> A client-generated GUID to uniquely identify the request. </param>
        public TextTranslationTransliterateOptions(string language, string fromScript, string toScript, string content, string clientTraceId = null)
        {
            Language = language;
            FromScript = fromScript;
            ToScript = toScript;
            Content = new[] { content };
            ClientTraceId = clientTraceId;
        }
    }
}
