// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.CosmosDB;

namespace Azure.ResourceManager.CosmosDB.Models
{
    public partial class CosmosDBSqlClientEncryptionKeyResourceInfo
    {
        /// <summary> Wrapped (encrypted) form of the key represented as a byte array. </summary>
        [WirePath("wrappedDataEncryptionKey")]
        public byte[] WrappedDataEncryptionKey { get; set; }
    }
}
