// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Storage URI kind of the input documents source.
    /// </summary>
    [CodeGenModel("StorageInputType")]
    public enum StorageInputUriKind
    {
        /// <summary>
        /// File
        /// </summary>
        File,
        /// <summary>
        /// Folder
        /// </summary>
        Folder
    }
}
