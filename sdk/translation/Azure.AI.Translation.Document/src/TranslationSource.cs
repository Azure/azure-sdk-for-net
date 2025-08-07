// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    [CodeGenModel("SourceInput")]
    public partial class TranslationSource
    {
        [CodeGenMember("TranslationStorageSource")]
        internal string TranslationStorageSource { get; set; }

        /// <summary>
        /// Location of the folder / container or single file with your documents.
        /// See the service documentation for the supported SAS permissions for accessing
        /// source storage containers/blobs: <a href="https://aka.ms/azsdk/documenttranslation/sas-permissions"/>.
        /// </summary>
        [CodeGenMember("SourceUrl")]
        public Uri SourceUri { get; }

        /// <summary>
        /// Language code for the source documents.
        /// If none is specified, the source language will be auto-detected for each document.
        /// </summary>
        [CodeGenMember("Language")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// A case-sensitive prefix string to filter documents in the source path for translation.
        /// For example, when using a Azure storage blob Uri, use the prefix to restrict sub folders for translation.
        /// </summary>
        public string Prefix
        {
            get => Filter?.Prefix;
            set
            {
                if (Filter == null)
                    Filter = new DocumentFilter();
                Filter.Prefix = value;
            }
        }

        /// <summary>
        /// A case-sensitive suffix string to filter documents in the source path for translation.
        /// This is most often use for file extensions.
        /// </summary>
        public string Suffix
        {
            get => Filter?.Suffix;
            set
            {
                if (Filter == null)
                    Filter = new DocumentFilter();
                Filter.Suffix = value;
            }
        }

        /// <summary>
        /// The set of options that can be specified to filter the documents by name
        /// using prefix and suffix.
        /// </summary>
        [CodeGenMember("Filter")]
        internal DocumentFilter Filter { get; set; }

        /// <summary> Initializes a new instance of <see cref="TranslationSource"/>. </summary>
        /// <param name="sourceUri"> Location of the folder / container or single file with your documents. </param>
        /// <param name="languageCode">
        /// Language code
        /// If none is specified, we will perform auto detect on the document
        /// </param>
        /// <param name="storageSource"> Storage Source. </param>
        /// <param name="prefix"> Document prefix filter. </param>
        /// <param name="suffix"> Document suffix filter. </param>
        public TranslationSource(Uri sourceUri, string languageCode = default, string storageSource = default, string prefix = default, string suffix = default)
        {
            SourceUri = sourceUri;
            if (languageCode != null)
            {
                LanguageCode = languageCode;
            }
            if (storageSource != null)
            {
                TranslationStorageSource = storageSource;
            }
            if (prefix != null)
            {
                Prefix = prefix;
            }
            if (suffix != null)
            {
                Suffix = suffix;
            }
        }
    }
}
