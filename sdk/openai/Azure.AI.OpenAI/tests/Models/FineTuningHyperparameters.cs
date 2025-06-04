// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Tests.Models;

public class FineTuningHyperparameters : IJsonModel<FineTuningHyperparameters>
{
    private Dictionary<string, JsonElement> _values = new();

    public AutoOrLongValue? BatchSize
    {
        get => Get("batch_size");
        set => Set("batch_size", value);
    }

    public AutoOrLongValue? LearningRateMultiplier
    {
        get => Get("learning_rate_multiplier");
        set => Set("learning_rate_multiplier", value);
    }

    public AutoOrLongValue? NumEpochs
    {
        get => Get("n_epochs");
        set => Set("n_epochs", value);
    }

    private AutoOrLongValue? Get(string key)
    {
        if (_values.TryGetValue(key, out JsonElement element))
        {
            return AutoOrLongValue.FromJsonElement(element);
        }

        return null;
    }

    private void Set(string key, AutoOrLongValue? value)
    {
        JsonElement? element = value?.ToJsonElement();
        if (element == null)
        {
            _values.Remove(key);
        }
        else
        {
            _values[key] = element.Value;
        }
    }

    FineTuningHyperparameters IJsonModel<FineTuningHyperparameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(ref reader);
        FineTuningHyperparameters instance = new();
        instance._values = dict ?? new Dictionary<string, JsonElement>();
        return instance;
    }

    FineTuningHyperparameters IPersistableModel<FineTuningHyperparameters>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        ReadOnlyMemory<byte> rawData = data.ToMemory();
        var reader = new Utf8JsonReader(rawData.Span);
        return ((IJsonModel<FineTuningHyperparameters>)this).Create(ref reader, options);
    }

    string IPersistableModel<FineTuningHyperparameters>.GetFormatFromOptions(ModelReaderWriterOptions options)
        => ModelReaderWriterOptions.Json.Format;

    void IJsonModel<FineTuningHyperparameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        foreach (var kvp in _values)
        {
            writer.WritePropertyName(kvp.Key);
            kvp.Value.WriteTo(writer);
        }
        writer.WriteEndObject();
    }

    BinaryData IPersistableModel<FineTuningHyperparameters>.Write(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options);
}
