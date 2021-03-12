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
        internal string StorageSource { get; set;}

        /// <summary> Location of the folder / container with your documents. </summary>
        [CodeGenMember("TargetUrl")]
        public Uri TargetUrl { get; }

        /// <summary> Initializes a new instance of TargetInput. </summary>
        /// <param name="targetUrl"> Location of the folder / container with your documents. </param>
        /// <param name="language"> Target Language. </param>
        /// <param name="glossaries"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="targetUrl"/> or <paramref name="language"/> is null. </exception>
        public TranslationTarget(Uri targetUrl, string language, IList<TranslationGlossary> glossaries)
        {
            if (targetUrl == null)
            {
                throw new ArgumentNullException(nameof(targetUrl));
            }
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }
            if (glossaries == null)
            {
                throw new ArgumentNullException(nameof(glossaries));
            }

            TargetUrl = targetUrl;
            Language = language;
            Glossaries = glossaries;
        }
    }
}
