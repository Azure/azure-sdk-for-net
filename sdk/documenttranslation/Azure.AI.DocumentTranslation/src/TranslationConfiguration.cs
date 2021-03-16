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
        /// <param name="sourceUri"></param>
        /// <param name="targetUri"></param>
        /// <param name="targetLanguageCode"></param>
        /// <param name="glossary"></param>
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

        /// <summary> Initializes a new instance of TranslationConfiguration. </summary>
        /// <param name="source"> Source of the input documents. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="source"/> is null. </exception>
        public TranslationConfiguration(TranslationSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            Source = source;
        }

        /// <summary>
        /// Add Translation Target to the configuration.
        /// </summary>
        /// <param name="targetUri"></param>
        /// <param name="languageCode"></param>
        /// <param name="glossary"></param>
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
