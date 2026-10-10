// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

/// <summary>
/// Serialization for the UnknownBicepStatement proxy. MRW routes abstract
/// BicepStatement reads through this type.
/// </summary>
internal partial class UnknownBicepStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) =>
        throw new InvalidOperationException("UnknownBicepStatement cannot be written.");

    BicepStatement IJsonModel<BicepStatement>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) =>
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure deserialization instead.");

    BinaryData IPersistableModel<BicepStatement>.Write(ModelReaderWriterOptions options) =>
        throw new InvalidOperationException("UnknownBicepStatement cannot be written.");

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options) =>
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure deserialization instead.");

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
