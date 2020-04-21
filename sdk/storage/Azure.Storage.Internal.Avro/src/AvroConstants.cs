// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Internal.Avro
{
    internal class AvroConstants
    {
        public const int SyncMarkerSize = 16;
        public static byte[] InitBytes =
        {
            (byte)'O',
            (byte)'b',
            (byte)'j',
            (byte)1
        };
        public const string CodecKey = "avro.codec";
        public const string SchemaKey = "avro.schema";
        public const string DeflateCodec = "deflate";
    }
}
