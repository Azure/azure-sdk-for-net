// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Dynamic;

namespace Azure
{
    internal class ResponseContent : BinaryData
    {
        private DynamicDataOptions _dynamicOptions;
        public DynamicDataOptions DynamicOptions { get => _dynamicOptions; }

        public ResponseContent(ReadOnlyMemory<byte> data, DynamicDataOptions options) : base(data)
        {
            _dynamicOptions = options;
        }

        public ResponseContent(string data, DynamicDataOptions options) : base(data)
        {
            _dynamicOptions = options;
        }

        public static ResponseContent FromBytes(ReadOnlyMemory<byte> data, DynamicDataOptions options) => new ResponseContent(data, options);

        public static ResponseContent FromString(string data, DynamicDataOptions options) => new ResponseContent(data, options);
    }
}
