// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Storage
{
#pragma warning disable CA1707 // Identifiers should not contain underscores
    /// <summary>
    /// The version of clientside encryption to use.
    /// </summary>
    public enum ClientSideEncryptionVersion
    {
        /// <summary>
        /// 1.0. This version is considered insecure. Applications are encouraged to migrate to
        /// <see cref="V2_0" /> or to one of our server-side encryption solutions. See
        /// <a href="https://techcommunity.microsoft.com/t5/azure-storage-blog/preview-azure-storage-updating-client-side-encryption-in-sdk-to/ba-p/3522620">this article</a>
        /// for more details.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        V1_0 = 1,

        /// <summary>
        /// 2.0.
        /// </summary>
        V2_0 = 2
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
