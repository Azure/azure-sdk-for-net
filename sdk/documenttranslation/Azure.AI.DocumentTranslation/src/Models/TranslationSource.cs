// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation.Models
{
    [CodeGenModel("SourceInput")]
    public partial class TranslationSource
    {
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

        /// <summary> Location of the folder / container or single file with your documents. </summary>
        [CodeGenMember("SourceUrl")]
        public Uri SourceUri { get; }

        /// <summary> filter documents in the source path for translation by prefix or suffix. </summary>
        [CodeGenMember("Filter")]
        public DocumentFilter Filter { get; set; }

        /// <summary>
        /// Language code
        /// If none is specified, we will perform auto detect on the document.
        /// </summary>
        [CodeGenMember("Language")]
        public string LanguageCode { get; set; }
    }
}
