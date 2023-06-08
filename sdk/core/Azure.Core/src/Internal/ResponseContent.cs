// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;

namespace Azure
{
    internal class ResponseContent : BinaryData
    {
        private readonly ProtocolOptions _protocolOptions;
        public ProtocolOptions ProtocolOptions { get => _protocolOptions; }

        public ResponseContent(ReadOnlyMemory<byte> data, ProtocolOptions options) : base(data)
        {
            _protocolOptions = options;
        }

        public ResponseContent(string data, ProtocolOptions options) : base(data)
        {
            _protocolOptions = options;
        }

        public static ResponseContent FromBytes(ReadOnlyMemory<byte> data, ProtocolOptions options) => new ResponseContent(data, options);

        public static ResponseContent FromString(string data, ProtocolOptions options) => new ResponseContent(data, options);
    }
}
