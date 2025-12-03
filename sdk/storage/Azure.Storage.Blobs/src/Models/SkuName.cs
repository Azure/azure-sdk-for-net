// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

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
        [CodeGenMember("StandardLRS")]
        StandardLrs,

        /// <summary>
        /// Standard_GRS
        /// </summary>
        [CodeGenMember("StandardGRS")]
        StandardGrs,

        /// <summary>
        /// Standard_RAGRS
        /// </summary>
        StandardRagrs,

        /// <summary>
        /// Standard_ZRS
        /// </summary>
        [CodeGenMember("StandardZRS")]
        StandardZrs,

        /// <summary>
        /// Premium_LRS
        /// </summary>
        [CodeGenMember("PremiumLRS")]
        PremiumLrs,

        /// <summary>
        /// Standard_GZRS
        /// </summary>
        [CodeGenMember("StandardGZRS")]
        StandardGzrs,

        /// <summary>
        /// Premium_ZRS
        /// </summary>
        [CodeGenMember("PremiumZRS")]
        PremiumZrs,

        /// <summary>
        /// Standard_RAGZRS
        /// </summary>
        [CodeGenMember("StandardRAGZRS")]
        StandardRagzrs,
    }
}
