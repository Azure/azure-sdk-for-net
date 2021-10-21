// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// An enum listing the supported properties that can be used in sorting
    /// when listing all document statuses for a certain translation operation.
    /// </summary>
    public enum DocumentFilterProperty
    {
        /// <summary>
        /// Sorting property corresponding to <see cref="DocumentStatusResult.CreatedOn"/>.
        /// </summary>
        CreatedOn = 0,
    }
}
