// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// An enum listing the supported properties that can be used in sorting
    /// when listing all submitted translation operations.
    /// </summary>
    public enum TranslationFilterProperty
    {
        /// <summary>
        /// Sorting property corresponding to <see cref="TranslationStatusResult.CreatedOn"/>.
        /// </summary>
        CreatedOn = 0,
    }
}
