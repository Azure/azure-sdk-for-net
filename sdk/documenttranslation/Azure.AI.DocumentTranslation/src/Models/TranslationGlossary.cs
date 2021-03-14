// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation.Models
{
    [CodeGenModel("Glossary")]
    public partial class TranslationGlossary
    {
        /// <summary>
        /// Location of the glossary.
        /// We will use the file extension to extract the formatting if the format parameter is not supplied.
        /// If the translation language pair is not present in the glossary, it will not be applied.
        /// </summary>
        [CodeGenMember("GlossaryUrl")]
        public Uri GlossaryUri { get; }

        /// <summary> Storage Source. </summary>
        [CodeGenMember("StorageSource")]
        internal string StorageSource { get; set; }

        /// <summary> Format. </summary>
        [CodeGenMember("Format")]
        public string FormatVersion { get; set; }
    }
}
