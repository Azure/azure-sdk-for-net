// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        /// 1.0.
        /// </summary>
        [Obsolete("This version is considered insecure. Applications are encouraged to migrate to version 2.0 or to one of Azure Storage's server-side encryption solutions. See http://aka.ms/azstorageclientencryptionblog for more details.")]
        V1_0 = 1,

        /// <summary>
        /// 2.0.
        /// </summary>
        V2_0 = 2
    }
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
