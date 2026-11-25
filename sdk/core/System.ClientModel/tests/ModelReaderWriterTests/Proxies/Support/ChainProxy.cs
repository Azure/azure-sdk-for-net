// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// A proxy that can be configured to handle or decline reads.
    /// </summary>
    internal class ChainProxy : TrackingModel
    {
        private readonly bool _handleRead;
        public object? CapturedProxiedModelOnCreate => CapturedProxiedModelOnBinaryCreate ?? CapturedProxiedModelOnReaderCreate;

        public ChainProxy(bool handleRead)
        {
            _handleRead = handleRead;
        }

        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options) => _handleRead;

        public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => _handleRead;
    }
}
