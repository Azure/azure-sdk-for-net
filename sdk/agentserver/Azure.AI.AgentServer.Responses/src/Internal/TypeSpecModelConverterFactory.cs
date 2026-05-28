// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// JSON converter factory for types implementing <see cref="IJsonModel{T}"/>.
/// Bridges the TypeSpec-generated <see cref="IJsonModel{T}"/> serialization with
/// <see cref="System.Text.Json.JsonSerializer"/>.
/// </summary>
internal sealed class TypeSpecModelConverterFactory : JsonConverterFactory
{
    private static readonly ConcurrentDictionary<Type, bool> TypesUsingJsonModel = new();
    private static readonly ConcurrentDictionary<Type, Type> ProxyTypeCache = new();

    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
        return TypesUsingJsonModel.GetOrAdd(typeToConvert, type =>
            type.GetInterfaces().Any(i =>
                i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IJsonModel<>)));
    }

    /// <inheritdoc/>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var converterType = typeof(TypeSpecModelConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }

    /// <summary>
    /// Gets the proxy type for an abstract type (via <see cref="PersistableModelProxyAttribute"/>).
    /// </summary>
    internal static Type GetProxyType(Type abstractType)
    {
        return ProxyTypeCache.GetOrAdd(abstractType, type =>
        {
            var proxyAttribute = type.GetCustomAttribute<PersistableModelProxyAttribute>();
            return proxyAttribute?.ProxyType ?? type;
        });
    }
}

/// <summary>
/// JSON converter for a specific type implementing <see cref="IJsonModel{T}"/>.
/// </summary>
internal sealed class TypeSpecModelConverter<T> : JsonConverter<T>
{
    /// <inheritdoc/>
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return default;
        }

        // Snapshot reader state before consuming (for IJsonModel.Create)
        var readerSnapshot = reader;

        // Parse to advance the reader past this value
        using var jsonDoc = JsonDocument.ParseValue(ref reader);

        var modelTypeToCreate = typeToConvert;
        if (typeToConvert.IsAbstract)
        {
            modelTypeToCreate = TypeSpecModelConverterFactory.GetProxyType(typeToConvert);
        }

        try
        {
            if (Activator.CreateInstance(modelTypeToCreate, nonPublic: true) is IJsonModel<T> model)
            {
                return model.Create(ref readerSnapshot, ModelReaderWriterOptions.Json);
            }
        }
        catch (MissingMethodException)
        {
            // Fall through to standard deserialization
        }

        return JsonSerializer.Deserialize<T>(jsonDoc.RootElement, options);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        if (value is IJsonModel<T> model)
        {
            model.Write(writer, ModelReaderWriterOptions.Json);
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
