// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    [CodeGenModel("TargetInput")]
    public partial class TranslationTarget
    {
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

        /// <summary> Location of the folder / container with your documents. </summary>
        [CodeGenMember("TargetUrl")]
        public Uri TargetUri { get; }

        /// <summary> Target Language. </summary>
        [CodeGenMember("Language")]
        public string LanguageCode { get; }

        /// <summary> Category / custom system for translation request. </summary>
        [CodeGenMember("Category")]
        public string CategoryId { get; set; }

        /// <summary>
        /// Add a translation glossary to the target.
        /// </summary>
        /// <param name="glossary"></param>
        public void AddGlossary(TranslationGlossary glossary)
        {
            if (glossary == null)
            {
                throw new ArgumentNullException(nameof(glossary));
            }
            Glossaries.Add(glossary);
        }

        /// <summary>
        /// Add a translation glossary to the target.
        /// </summary>
        /// <param name="glossaryUri"></param>
        /// <param name="formatVersion"></param>
        public void AddGlossary(Uri glossaryUri, string formatVersion = default)
        {
            if (glossaryUri == null)
            {
                throw new ArgumentNullException(nameof(glossaryUri));
            }
            Glossaries.Add(new TranslationGlossary(glossaryUri) { FormatVersion = formatVersion });
        }
    }
}
