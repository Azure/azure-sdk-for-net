// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Identifies the sku name of the account.
    /// </summary>
    public enum SkuName
    {
        /// <summary>
        /// Standard_LRS
        /// </summary>
        StandardLrs,

        /// <summary>
        /// Standard_GRS
        /// </summary>
        StandardGrs,

        /// <summary>
        /// Standard_RAGRS
        /// </summary>
        StandardRagrs,

        /// <summary>
        /// Standard_ZRS
        /// </summary>
        StandardZrs,

        /// <summary>
        /// Premium_LRS
        /// </summary>
        PremiumLrs
    }
}
