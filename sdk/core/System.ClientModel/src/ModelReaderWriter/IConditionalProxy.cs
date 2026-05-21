// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Internal non-generic interface implemented by <see cref="ConditionalModelProxy{T}"/>.
/// Enables non-generic code paths (JsonModelConverter, ReadInternal) to call CanHandle
/// and access the held model without knowing the generic type parameter at compile time.
/// </summary>
internal interface IConditionalProxy
{
    bool CanHandleData(ReadOnlyMemory<byte> data);
    bool CanHandleReader(ref Utf8JsonReader reader);
    bool CanHandleModel(object model);
    bool HasJsonModel { get; }
    IPersistableModel<object> GetModel();
    object? CreateFromData(BinaryData data, ModelReaderWriterOptions options);
    object? CreateFromReader(ref Utf8JsonReader reader, ModelReaderWriterOptions options);
    IJsonModel<object> AsJsonModelOfObject(object originalModel);
}
