// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.SourceGeneration.Tests.SubNamespace;
using System.Text.Json;

namespace System.ClientModel.SourceGeneration.Tests
{
#pragma warning disable SA1649 // File name should match first type name
    internal class JsonModel : IJsonModel<JsonModel>
#pragma warning restore SA1649 // File name should match first type name
    {
        public JsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();

        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class PersistableModel : IPersistableModel<PersistableModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;

        PersistableModel IPersistableModel<PersistableModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new PersistableModel();
    }

    [PersistableModelProxy(typeof(UnknownBaseJsonModel))]
#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SCM0005 // Type must have a parameterless constructor
    internal abstract class BaseJsonModel : IJsonModel<BaseJsonModel>
#pragma warning restore SCM0005 // Type must have a parameterless constructor
#pragma warning restore SA1402 // File may only contain a single type
    {
        public BaseJsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownBaseJsonModel();

        public BaseJsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownBaseJsonModel();

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}

namespace System.ClientModel.SourceGeneration.Tests.SubNamespace
{
#pragma warning disable SA1402 // File may only contain a single type
    internal class JsonModel : IJsonModel<JsonModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        public JsonModel Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new JsonModel();

        public JsonModel Create(BinaryData data, ModelReaderWriterOptions options) => new JsonModel();

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
        }

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class UnknownBaseJsonModel : BaseJsonModel, IJsonModel<BaseJsonModel>
#pragma warning restore SA1402 // File may only contain a single type
    {
        BaseJsonModel IJsonModel<BaseJsonModel>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new UnknownBaseJsonModel();

        BaseJsonModel IPersistableModel<BaseJsonModel>.Create(BinaryData data, ModelReaderWriterOptions options) => new UnknownBaseJsonModel();

        string IPersistableModel<BaseJsonModel>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<BaseJsonModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        BinaryData IPersistableModel<BaseJsonModel>.Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class AvailabilitySetData : IJsonModel<AvailabilitySetData>
#pragma warning restore SA1402 // File may only contain a single type
    {
        public AvailabilitySetData Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => new AvailabilitySetData();

        public AvailabilitySetData Create(BinaryData data, ModelReaderWriterOptions options) => new AvailabilitySetData();

        public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }

        public BinaryData Write(ModelReaderWriterOptions options) => BinaryData.Empty;
    }
}
