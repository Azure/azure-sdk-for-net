// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;

namespace Azure
{
    internal class ResponseContent : BinaryData
    {
        public ResponseContent(byte[] data) : base(data) { }

        public ResponseContent(string data) : base(data) { }

        public static new ResponseContent FromBytes(byte[] data) => new ResponseContent(data);

        public static new ResponseContent FromString(string data) => new ResponseContent(data);
    }
}
