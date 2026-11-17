// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    internal class TrackingModel : ModelProxy<SimpleModel>, IJsonModel<SimpleModel>
    {
        public bool CreateWasCalled { get; private set; }
        public bool WriteWasCalled { get; private set; }
        public object? CapturedProxiedModelOnBinaryCreate { get; private set; }
        public object? CapturedProxiedModelOnReaderCreate { get; private set; }
        public object? CapturedProxiedModelOnWrite { get; private set; }

        public void Reset()
        {
            CreateWasCalled = false;
            WriteWasCalled = false;
            CapturedProxiedModelOnBinaryCreate = null;
            CapturedProxiedModelOnReaderCreate = null;
            CapturedProxiedModelOnWrite = null;
        }

        public override SimpleModel Create(BinaryData data, ModelReaderWriterOptions options)
        {
            CreateWasCalled = true;
            CapturedProxiedModelOnBinaryCreate = options.ProxiedModel;
            return new SimpleModel();
        }

        SimpleModel IJsonModel<SimpleModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            CreateWasCalled = true;
            CapturedProxiedModelOnReaderCreate = options.ProxiedModel;
            using var doc = JsonDocument.ParseValue(ref reader);
            return new SimpleModel();
        }

        void IJsonModel<SimpleModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            WriteWasCalled = true;
            CapturedProxiedModelOnWrite = options.ProxiedModel;
            writer.WriteStartObject();
            writer.WriteEndObject();
        }

        public override BinaryData Write(ModelReaderWriterOptions options)
        {
            WriteWasCalled = true;
            CapturedProxiedModelOnWrite = options.ProxiedModel;
            return BinaryData.FromString("{}");
        }

        public override string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
