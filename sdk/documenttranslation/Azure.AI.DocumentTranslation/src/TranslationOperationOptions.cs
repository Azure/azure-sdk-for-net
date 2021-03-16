// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.DocumentTranslation
{
    /// <summary>
    /// TranslationOperationOptions
    /// </summary>
    public class TranslationOperationOptions
    {
        /// <summary>
        /// SourceLanguage
        /// </summary>
        public string SourceLanguage { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        public DocumentFilter Filter { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// StorageType
        /// </summary>
        public StorageType? StorageType { get; set; }
    }
}
