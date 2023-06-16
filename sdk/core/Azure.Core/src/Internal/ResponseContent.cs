// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;

namespace Azure
{
    internal class ResponseContent : BinaryData
    {
        private readonly ProtocolMethodOptions _protocolOptions;
        public ProtocolMethodOptions ProtocolOptions { get => _protocolOptions; }

        public ResponseContent(ReadOnlyMemory<byte> data, ProtocolMethodOptions options) : base(data)
        {
            _protocolOptions = options;
        }

        public ResponseContent(string data, ProtocolMethodOptions options) : base(data)
        {
            _protocolOptions = options;
        }

        public static ResponseContent FromBytes(ReadOnlyMemory<byte> data, ProtocolMethodOptions options) => new ResponseContent(data, options);

        public static ResponseContent FromString(string data, ProtocolMethodOptions options) => new ResponseContent(data, options);
    }
}
