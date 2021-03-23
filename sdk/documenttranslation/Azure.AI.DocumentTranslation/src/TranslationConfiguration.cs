// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    /// <summary> Definition for the input batch translation request. </summary>
    [CodeGenModel("BatchRequest")]
    public partial class TranslationConfiguration
    {
        /// <summary>
        /// Initializes a new instance of TranslationConfiguration.
        /// </summary>
        /// <param name="sourceUri">The SAS URI for the source container containing documents to be translated.</param>
        /// <param name="targetUri">The SAS URI for the target container to which the translated documents will be written.</param>
        /// <param name="targetLanguageCode">Language code to translate documents to. For supported languages see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/language-support#translate"/>.</param>
        /// <param name="glossary">Custom <see cref="TranslationGlossary"/> to be used in the translation operation. For supported file types see
        /// <see cref="DocumentTranslationClient.GetGlossaryFormatsAsync(System.Threading.CancellationToken)"/>.</param>
        public TranslationConfiguration(Uri sourceUri, Uri targetUri, string targetLanguageCode, TranslationGlossary glossary = default)
        {
            Source = new TranslationSource(sourceUri);
            var target = new TranslationTarget(targetUri, targetLanguageCode);
            if (glossary != null)
            {
                target.Glossaries.Add(glossary);
            }
            Targets.Add(target);
        }

        /// <summary>
        /// Add Translation Target to the configuration.
        /// </summary>
        /// <param name="targetUri">The SAS URI for the target container to which the translated documents will be written.</param>
        /// <param name="languageCode">Language code to translate documents to. For supported languages see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/language-support#translate"/>.</param>
        /// <param name="glossary">Custom <see cref="TranslationGlossary"/> to be used in the translation operation. For supported file types see
        /// <see cref="DocumentTranslationClient.GetGlossaryFormatsAsync(System.Threading.CancellationToken)"/>.</param>
        public void AddTarget(Uri targetUri, string languageCode, TranslationGlossary glossary = default)
        {
            var target = new TranslationTarget(targetUri, languageCode);
            if (glossary != null)
            {
                target.Glossaries.Add(glossary);
            }
            Targets.Add(target);
        }
    }
}
