// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage
{
#pragma warning disable CA1707 // Identifiers should not contain underscores
    /// <summary>
    /// The version of clientside encryption to use.
    /// </summary>
    public enum ClientSideEncryptionVersion
    {
        /// <summary>
        /// 1.0
        /// </summary>
        V1_0 = 1,

        /// <summary>
        /// 2.0
        /// </summary>
        V2_0 = 2
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
