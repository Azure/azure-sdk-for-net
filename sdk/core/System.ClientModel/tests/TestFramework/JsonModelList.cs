// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace ClientModel.Tests.Internal;

internal class JsonModelList<TModel> : List<TModel>, IJsonModel<JsonModelList<TModel>>
    where TModel : IJsonModel<TModel>
{
    public JsonModelList<TModel> Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<JsonModelList<TModel>>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(JsonModelList<TModel>)} does not support reading '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeJsonModelList(document.RootElement, options);
    }

    public JsonModelList<TModel> Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<JsonModelList<TModel>>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeJsonModelList(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(JsonModelList<TModel>)} does not support reading '{options.Format}' format.");
        }
    }

    internal static JsonModelList<TModel> DeserializeJsonModelList(JsonElement element, ModelReaderWriterOptions? options = null)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind != JsonValueKind.Array)
        {
            throw new InvalidOperationException("Cannot deserialize JsonModelList from JSON that is not an array.");
        }

        JsonModelList<TModel> list = new();

        foreach (JsonElement item in element.EnumerateArray())
        {
            // TODO: Make efficient
            TModel? value = ModelReaderWriter.Read<TModel>(BinaryData.FromString(item.ToString()), options) ??
                throw new InvalidOperationException("Failed to deserialized array element.");
            list.Add(value);
        }

        return list;
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<JsonModelList<TModel>>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(JsonModelList<TModel>)} does not support writing '{format}' format.");
        }

        writer.WriteStartArray();

        foreach (IJsonModel<TModel> item in this)
        {
            item.Write(writer, options);
        }

        writer.WriteEndArray();
    }

    public BinaryData Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<JsonModelList<TModel>>)this).GetFormatFromOptions(options) : options.Format;

        return format switch
        {
            "J" => ModelReaderWriter.Write(this, options),
            _ => throw new FormatException($"The model {nameof(JsonModelList<TModel>)} does not support writing '{options.Format}' format."),
        };
    }
}
