// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.AI.Translation.Document.Models;

namespace Azure.AI.Translation.Document
{
    [CodeGenModel("SourceInput")]
    public partial class TranslationSource
    {
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

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
    }
}
