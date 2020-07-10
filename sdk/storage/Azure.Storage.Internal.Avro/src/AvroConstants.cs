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

        public const string Null = "null";
        public const string Boolean = "boolean";
        public const string Int = "int";
        public const string Long = "long";
        public const string Float = "float";
        public const string Double = "double";
        public const string Bytes = "bytes";
        public const string String = "string";
        public const string Record = "record";
        public const string Enum = "enum";
        public const string Map = "map";
        public const string Array = "array";
        public const string Union = "union";
        public const string Fixed = "fixed";

        public const string Aliases = "aliases";
        public const string Name = "name";
        public const string Fields = "fields";
        public const string Type = "type";
        public const string Symbols = "symbols";
        public const string Values = "values";
    }
}
