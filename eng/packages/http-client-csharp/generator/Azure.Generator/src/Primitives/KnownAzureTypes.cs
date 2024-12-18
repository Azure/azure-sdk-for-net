// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;

namespace Azure.Generator.Primitives
{
    internal static class KnownAzureTypes
    {
        private record struct KnownAzureType(string Id, Type Type, ValueExpression SerializationExpression, ValueExpression DeserializationExpression);

        private static readonly KnownAzureType[] _allKnownAzureTypes = [
            new(UuidId, typeof(Guid), null!, null!)
            ];

        private static readonly IReadOnlyDictionary<string, CSharpType> _idToTypes = _allKnownAzureTypes.ToDictionary(t => t.Id, t => new CSharpType(t.Type));
        private static readonly IReadOnlyDictionary<Type, ValueExpression> _typeToSerializationExpression = _allKnownAzureTypes.ToDictionary(t => t.Type, t => t.SerializationExpression);
        private static readonly IReadOnlyDictionary<Type, ValueExpression> _typeToDeserializationExpression = _allKnownAzureTypes.ToDictionary(t => t.Type, t => t.DeserializationExpression);

        private const string UuidId = "Azure.Core.uuid";
        private const string IPv4AddressId = "Azure.Core.ipV4Address";
        private const string IPv6AddressId = "Azure.Core.ipV6Address";
        private const string ETagId = "Azure.Core.eTag";
        private const string AzureLocationId = "Azure.Core.azureLocation";
        private const string ArmIdId = "Azure.Core.armResourceIdentifier";

        private static readonly IReadOnlyDictionary<string, CSharpType> PrimitiveTypes = new Dictionary<string, CSharpType>
        {
            [UuidId] = typeof(Guid),
            [IPv4AddressId] = typeof(IPAddress),
            [IPv6AddressId] = typeof(IPAddress),
            [ETagId] = typeof(ETag),
            [AzureLocationId] = typeof(AzureLocation),
            [ArmIdId] = typeof(ResourceIdentifier),
        };

        internal static bool TryGetPrimitiveType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToTypes.TryGetValue(id, out type);

        internal static ValueExpression? TryGetSerializationExpression(Type type) => _typeToSerializationExpression.TryGetValue(type, out var expression) ? expression : null;

        internal static ValueExpression GetDeserializationExpression(Type type)
        {

        }
    }
}
