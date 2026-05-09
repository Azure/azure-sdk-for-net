// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.CosmosDB;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The TypeSpec spec models `wrappedDataEncryptionKey` as `bytes` (base64-encoded
    // string on the wire). The legacy AutoRest SDK exposed it as `byte[]` directly
    // on `CosmosDBSqlClientEncryptionKeyResourceInfo`. The MPG generator currently
    // either drops the property from the resource-info type or surfaces it on a
    // sibling, so re-declare the historical `byte[] WrappedDataEncryptionKey { get; set; }`
    // here so the legacy back-compat surface compiles and round-trips through the
    // wirepath `wrappedDataEncryptionKey`.
    public partial class CosmosDBSqlClientEncryptionKeyResourceInfo
    {
        /// <summary> Wrapped (encrypted) form of the key represented as a byte array. </summary>
        [WirePath("wrappedDataEncryptionKey")]
        public byte[] WrappedDataEncryptionKey { get; set; }
    }
}
