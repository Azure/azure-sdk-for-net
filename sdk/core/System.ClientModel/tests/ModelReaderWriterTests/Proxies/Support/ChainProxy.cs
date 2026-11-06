// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// A proxy that can be configured to handle or decline reads.
    /// </summary>
    internal class ChainProxy : ConditionalModelProxy<SimpleModel>
    {
        private readonly bool _handleRead;
        public bool CreateWasCalled => ((TrackingModel)Model).CreateWasCalled;
        public object? CapturedProxiedModelOnCreate => ((TrackingModel)Model).CapturedProxiedModelOnBinaryCreate ?? ((TrackingModel)Model).CapturedProxiedModelOnReaderCreate;

        public ChainProxy(bool handleRead)
            : base(new TrackingModel())
        {
            _handleRead = handleRead;
        }

        public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => true;

        public override bool CanHandle(ReadOnlyMemory<byte> data, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handleRead;

        public override bool CanHandle(ref Utf8JsonReader reader, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _handleRead;

        public void Reset() => ((TrackingModel)Model).Reset();
    }
}
