// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translator.DocumentTranslation
{
    [CodeGenModel("TargetInput")]
    public partial class TranslationTarget
    {
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

        /// <summary>
        /// Location of the container with your documents.
        /// This should be a SAS Uri.
        /// </summary>
        [CodeGenMember("TargetUrl")]
        public Uri TargetUri { get; }

        /// <summary>
        /// Language code to translate documents to. For supported languages see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/language-support#translate"/>.
        /// </summary>
        [CodeGenMember("Language")]
        public string LanguageCode { get; }

        /// <summary>
        /// Category / custom model ID for using custom translation.
        /// </summary>
        [CodeGenMember("Category")]
        public string CategoryId { get; set; }
    }
}
