// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Input for a translation operation. This requires that you have your source document or
    /// documents in an Azure Blob Storage container.
    /// The source document(s) are translated and written to the location provided
    /// in the <see cref="TranslationTarget"/>.
    /// </summary>
    [CodeGenModel("BatchRequest")]
    public partial class DocumentTranslationInput
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DocumentTranslationInput"/>.
        /// </summary>
        /// <param name="sourceUri">The SAS URI for the source container containing documents to be translated.
        /// See the service documentation for the supported SAS permissions for accessing
        /// source storage containers/blobs: <a href="https://aka.ms/azsdk/documenttranslation/sas-permissions"/>.</param>
        /// <param name="targetUri">The SAS URI for the target container to which the translated documents will be written.
        /// See the service documentation for the supported SAS permissions for accessing
        /// target storage containers/blobs: <a href="https://aka.ms/azsdk/documenttranslation/sas-permissions"/>.</param>
        /// <param name="targetLanguageCode">Language code to translate documents to. For supported languages see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/language-support#translate"/>.</param>
        /// <param name="glossary">Custom <see cref="TranslationGlossary"/> to be used in the translation operation. For supported file types see
        /// <see cref="DocumentTranslationClient.GetSupportedFormatsAsync(FileFormatType?, System.Threading.CancellationToken)"/>.</param>
        public DocumentTranslationInput(Uri sourceUri, Uri targetUri, string targetLanguageCode, TranslationGlossary glossary = default)
        {
            Source = new TranslationSource(sourceUri);
            var target = new TranslationTarget(targetUri, targetLanguageCode);
            if (glossary != null)
            {
                target.Glossaries.Add(glossary);
            }
            Targets = new List<TranslationTarget> { target };
        }

        /// <summary>
        /// Add a <see cref="TranslationTarget"/> to the translation input.
        /// </summary>
        /// <param name="targetUri">The SAS URI for the target container to which the translated documents will be written.
        /// See the service documentation for the supported SAS permissions for accessing
        /// target storage containers/blobs: <a href="https://aka.ms/azsdk/documenttranslation/sas-permissions"/>.</param>
        /// <param name="languageCode">Language code to translate documents to. For supported languages see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/language-support#translate"/>.</param>
        /// <param name="glossary">Custom <see cref="TranslationGlossary"/> to be used in the translation operation. For supported file types see
        /// <see cref="DocumentTranslationClient.GetSupportedFormatsAsync(FileFormatType?, System.Threading.CancellationToken)"/>.</param>
        /// <param name="categoryId">Category/custom model ID for using custom translation.</param>
        public void AddTarget(Uri targetUri, string languageCode, TranslationGlossary glossary = default, string categoryId = default)
        {
            var target = new TranslationTarget(targetUri, languageCode);
            if (glossary != null)
            {
                target.Glossaries.Add(glossary);
            }
            target.CategoryId = categoryId;

            Targets.Add(target);
        }

        /// <summary> Storage URI kind of the input documents source string. </summary>
        [CodeGenMember("StorageType")]
        public StorageInputUriKind? StorageUriKind { get; set; }
    }
}
