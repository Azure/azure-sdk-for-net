// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.ClientModel.Snippets;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Primitives
{
    internal static class KnownAzureTypes
    {
        public delegate MethodBodyStatement SerializationExpression(ValueExpression value, ScopedApi<Utf8JsonWriter> writer, ScopedApi<ModelReaderWriterOptions> options, SerializationFormat format);
        public delegate ValueExpression DeserializationExpression(CSharpType valueType, ScopedApi<JsonElement> element, SerializationFormat format);

        private const string UuidId = "Azure.Core.uuid";
        private const string IPv4AddressId = "Azure.Core.ipV4Address";
        private const string IPv6AddressId = "Azure.Core.ipV6Address";
        private const string ETagId = "Azure.Core.eTag";
        private const string AzureLocationId = "Azure.Core.azureLocation";
        private const string ArmIdId = "Azure.Core.armResourceIdentifier";
        private const string AzureError = "Azure.Core.Foundations.Error";
        private const string EmbeddingVector = "Azure.Core.EmbeddingVector";

        private static MethodBodyStatement SerializeTypeWithImplicitOperatorToString(ValueExpression value, ScopedApi<Utf8JsonWriter> writer, ScopedApi<ModelReaderWriterOptions> options, SerializationFormat format)
            => writer.WriteStringValue(value);

        private static ValueExpression DeserializeNewInstanceStringLikeType(CSharpType valueType, ScopedApi<JsonElement> element, SerializationFormat format)
            => New.Instance(valueType, element.GetString());

        private static MethodBodyStatement SerializeTypeWithToString(ValueExpression value, ScopedApi<Utf8JsonWriter> writer, ScopedApi<ModelReaderWriterOptions> options, SerializationFormat format)
            => writer.WriteStringValue(value.InvokeToString());

        private static ValueExpression DeserializeParsableStringLikeType(CSharpType valueType, ScopedApi<JsonElement> element, SerializationFormat format)
            => Static(valueType).Invoke("Parse", element.GetString());

        private static MethodBodyStatement SerializeResponseError(ValueExpression value, ScopedApi<Utf8JsonWriter> writer, ScopedApi<ModelReaderWriterOptions> options, SerializationFormat format)
            => Static(typeof(JsonSerializer)).Invoke(nameof(JsonSerializer.Serialize), writer, value).Terminate();

        private static ValueExpression DeserializeResponseError(CSharpType valueType,
            ScopedApi<JsonElement> element,
            SerializationFormat format)
            => Static(typeof(JsonSerializer)).Invoke(nameof(JsonSerializer.Deserialize), arguments: [element.GetRawText()], typeArguments: [valueType], callAsAsync: false);

        private static readonly IReadOnlyDictionary<string, Type> _idToTypes = new Dictionary<string, Type>
        {
            [UuidId] = typeof(Guid),
            [IPv4AddressId] = typeof(IPAddress),
            [IPv6AddressId] = typeof(IPAddress),
            [ETagId] = typeof(ETag),
            [AzureLocationId] = typeof(AzureLocation),
            [ArmIdId] = typeof(ResourceIdentifier),
            // [AzureError] = typeof(ResponseError),
            [EmbeddingVector] = typeof(ReadOnlyMemory<>)
        };

        private static readonly IReadOnlyDictionary<Type, SerializationExpression> _typeToSerializationExpression = new Dictionary<Type, SerializationExpression>
        {
            [typeof(Guid)] = SerializeTypeWithImplicitOperatorToString,
            [typeof(IPAddress)] = SerializeTypeWithToString,
            [typeof(ETag)] = SerializeTypeWithToString,
            [typeof(AzureLocation)] = SerializeTypeWithImplicitOperatorToString,
            [typeof(ResourceIdentifier)] = SerializeTypeWithImplicitOperatorToString,
            [typeof(ResponseError)] = SerializeResponseError,
        };

        private static readonly IReadOnlyDictionary<Type, DeserializationExpression> _typeToDeserializationExpression = new Dictionary<Type, DeserializationExpression>
        {
            [typeof(Guid)] = DeserializeNewInstanceStringLikeType,
            [typeof(IPAddress)] = DeserializeParsableStringLikeType,
            [typeof(ETag)] = DeserializeNewInstanceStringLikeType,
            [typeof(AzureLocation)] = DeserializeNewInstanceStringLikeType,
            [typeof(ResourceIdentifier)] = DeserializeNewInstanceStringLikeType,
            [typeof(ResponseError)] = DeserializeResponseError,
        };

        public static bool TryGetKnownType(string id, [MaybeNullWhen(false)] out Type type) => _idToTypes.TryGetValue(id, out type);

        public static bool TryGetJsonSerializationExpression(Type type, [MaybeNullWhen(false)] out SerializationExpression expression) => _typeToSerializationExpression.TryGetValue(type, out expression);

        public static bool TryGetJsonDeserializationExpression(Type type, [MaybeNullWhen(false)] out DeserializationExpression expression) => _typeToDeserializationExpression.TryGetValue(type, out expression);
    }
}
