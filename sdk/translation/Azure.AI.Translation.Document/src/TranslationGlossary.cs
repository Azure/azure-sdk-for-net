// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    [CodeGenModel("Glossary")]
    public partial class TranslationGlossary
    {
        /// <summary>
        /// Location of the glossary file. This should be a SAS URL to
        /// the glossary file in the storage blob container. If the translation language pair is
        /// not present in the glossary, it will not be applied.
        /// </summary>
        [CodeGenMember("GlossaryUrl")]
        public Uri GlossaryUri { get; }

        /// <summary>
        /// Storage Source. Default value: "AzureBlob".
        /// Currently only "AzureBlob" is supported.
        /// </summary>
        [CodeGenMember("TranslationStorageSource")]
        internal string TranslationStorageSource { get; set; }

        /// <summary>
        /// Optional file format version. If not specified, the service will
        /// use the <see cref="DocumentTranslationFileFormat.DefaultFormatVersion"/> for the file format returned from the
        /// <see cref="DocumentTranslationClient.GetSupportedFormatsAsync(FileFormatType?, System.Threading.CancellationToken)"/> client method.
        /// </summary>
        [CodeGenMember("Version")]
        public string FormatVersion { get; set; }

        /// <summary>
        /// Format of the glossary file. To see supported formats,
        /// use the <see cref="DocumentTranslationClient.GetSupportedFormatsAsync(FileFormatType?, System.Threading.CancellationToken)"/> client method.
        /// </summary>
        public string Format { get; }
    }
}
