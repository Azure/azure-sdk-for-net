// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translator.DocumentTranslation
{
    [CodeGenModel("SourceInput")]
    public partial class TranslationSource
    {
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

        /// <summary>
        /// Location of the folder / container or single file with your documents.
        /// This should be a SAS Uri.
        /// </summary>
        [CodeGenMember("SourceUrl")]
        public Uri SourceUri { get; }

        /// <summary>
        /// The set of options that can be specified to filter the documents by name
        /// using prefix and suffix.
        /// </summary>
        [CodeGenMember("Filter")]
        public DocumentFilter Filter { get; set; }

        /// <summary>
        /// Language code for the source documents.
        /// If none is specified, the source language will be auto-detected for each document.
        /// </summary>
        [CodeGenMember("Language")]
        public string LanguageCode { get; set; }
    }
}
