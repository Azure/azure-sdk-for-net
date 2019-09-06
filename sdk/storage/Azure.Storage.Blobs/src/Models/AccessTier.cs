// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// AccessTier helpers
    /// </summary>
    static partial class BlobExtensions
    {
        /// <summary>
        /// Convert an AccessTier into an AccessTier value.
        /// </summary>
        /// <param name="tier">The AccessTier.</param>
        /// <returns>An AccessTier value.</returns>
        internal static AccessTier ToAccessTier(this AccessTier tier) =>
            (AccessTier)tier.ToString();
    }
}
