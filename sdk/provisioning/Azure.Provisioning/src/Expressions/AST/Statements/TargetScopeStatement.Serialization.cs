// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Provisioning;

namespace Azure.Provisioning.Expressions;

public partial class TargetScopeStatement : IJsonModel<BicepStatement>
{
    void IJsonModel<BicepStatement>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        // TargetScope is written as a simple string at the file level, not as a statement JSON node
        // This is handled by the Infrastructure serializer
        writer.WriteStringValue(Scope.ToString().Trim('\''));
    }

    BicepStatement IJsonModel<BicepStatement>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    BinaryData IPersistableModel<BicepStatement>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<BicepStatement>)this).GetFormatFromOptions(options) : options.Format;
        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options, AzureProvisioningContext.Default);
            case "bicep":
                return new BinaryData(new BicepWriter().Append(this).ToString());
            default:
                throw new FormatException($"The model {nameof(TargetScopeStatement)} does not support writing '{format}' format.");
        }
    }

    BicepStatement IPersistableModel<BicepStatement>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException("BicepStatement deserialization requires the statement type context. Use Infrastructure.DeserializeInfrastructure instead.");
    }

    string IPersistableModel<BicepStatement>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public override bool Equals(BicepStatement? other) => other is TargetScopeStatement t && Scope.Equals(t.Scope);
    public override int GetHashCode() => (typeof(TargetScopeStatement).GetHashCode() * 31 + (Scope?.GetHashCode() ?? 0));
}
