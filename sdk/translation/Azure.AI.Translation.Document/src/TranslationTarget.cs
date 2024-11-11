// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    [CodeGenModel("TargetInput")]
    public partial class TranslationTarget
    {
        [CodeGenMember("TranslationStorageSource")]
        internal string TranslationStorageSource { get; set; }

        /// <summary>
        /// Location of the container with your documents.
        /// See the service documentation for the supported SAS permissions for accessing
        /// target storage containers/blobs: <a href="https://aka.ms/azsdk/documenttranslation/sas-permissions"/>.
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
