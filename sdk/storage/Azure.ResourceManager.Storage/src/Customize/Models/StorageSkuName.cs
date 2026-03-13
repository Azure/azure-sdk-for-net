// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Adds many hidden enum aliases with older casing for SKU names.
// Could use @@clientName on enum values in spec.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct StorageSkuName
    {
        /// <summary> Standard_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardLrs => StandardLRS;

        /// <summary> Standard_GRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardGrs => StandardGRS;

        /// <summary> Standard_RAGRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardRagrs => StandardRAGRS;

        /// <summary> Standard_ZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardZrs => StandardZRS;

        /// <summary> Premium_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName PremiumLrs => PremiumLRS;

        /// <summary> Premium_ZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName PremiumZrs => PremiumZRS;

        /// <summary> Standard_GZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardGzrs => StandardGZRS;

        /// <summary> Standard_RAGZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardRagzrs => StandardRAGZRS;

        /// <summary> StandardV2_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardV2Lrs => StandardV2LRS;

        /// <summary> StandardV2_GRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardV2Grs => StandardV2GRS;

        /// <summary> StandardV2_ZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardV2Zrs => StandardV2ZRS;

        /// <summary> StandardV2_GZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName StandardV2Gzrs => StandardV2GZRS;

        /// <summary> PremiumV2_LRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName PremiumV2Lrs => PremiumV2LRS;

        /// <summary> PremiumV2_ZRS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSkuName PremiumV2Zrs => PremiumV2ZRS;
    }
}
