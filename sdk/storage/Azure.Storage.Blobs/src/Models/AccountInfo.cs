// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// AccountInfo.
    /// </summary>
    public partial class AccountInfo
    {
        /// <summary>
        /// Identifies the sku name of the account.
        /// </summary>
        public SkuName SkuName { get; internal set; }

        /// <summary>
        /// Identifies the account kind.
        /// </summary>
        public AccountKind AccountKind { get; internal set; }

        /// <summary>
        /// Version 2019-07-07 and newer. Indicates if the account has a hierarchical namespace enabled.
        /// </summary>
        public bool IsHierarchicalNamespaceEnabled { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of AccountInfo instances.
        /// You can use BlobsModelFactory.AccountInfo instead.
        /// </summary>
        internal AccountInfo() { }
    }
}
