// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.DocumentTranslation.Models
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
        public string LanguageCode { get; }

        /// <summary> Initializes a new instance of TargetInput. </summary>
        /// <param name="targetUri"> Location of the folder / container with your documents. </param>
        /// <param name="languageCode"> Target Language. </param>
        /// <param name="glossaries"> List of <see cref="TranslationGlossary"/>. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetUri"/> or <paramref name="languageCode"/> is null. </exception>
        public TranslationTarget(Uri targetUri, string languageCode, IList<TranslationGlossary> glossaries)
        {
            if (targetUri == null)
            {
                throw new ArgumentNullException(nameof(targetUri));
            }
            if (languageCode == null)
            {
                throw new ArgumentNullException(nameof(languageCode));
            }
            if (glossaries == null)
            {
                throw new ArgumentNullException(nameof(glossaries));
            }

            TargetUri = targetUri;
            LanguageCode = languageCode;
            Glossaries = glossaries;
        }
    }
}
