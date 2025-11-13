// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
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
using System.Linq;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Primitives
{
    internal class KnownManagementTypes
    {
        public const string ArmResourceId = "Azure.ResourceManager.CommonTypes.Resource";
        public const string ResourceUpdateModelId = "Azure.ResourceManager.Foundations.ResourceUpdateModel";

        public delegate MethodBodyStatement SerializationExpression(ValueExpression value, ScopedApi<Utf8JsonWriter> writer, ScopedApi<ModelReaderWriterOptions> options, SerializationFormat format);
        public delegate ValueExpression DeserializationExpression(CSharpType valueType, ScopedApi<JsonElement> element, SerializationFormat format);

        private static readonly IReadOnlyDictionary<string, CSharpType> _idToInheritableSystemTypeMap = new Dictionary<string, CSharpType>()
        {
            ["Azure.ResourceManager.CommonTypes.ProxyResource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.ExtensionResource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.Resource"] = typeof(ResourceData),
            ["Azure.ResourceManager.CommonTypes.TrackedResource"] = typeof(TrackedResourceData),
            ["Azure.ResourceManager.Legacy.TrackedResourceWithOptionalLocation"] = typeof(TrackedResourceData),
        };

        private static readonly IReadOnlyDictionary<string, CSharpType> _idToSystemTypeMap = new Dictionary<string, CSharpType>()
        {
            ["Azure.ResourceManager.CommonTypes.ExtendedLocation"] = typeof(ExtendedLocation),
            ["Azure.ResourceManager.CommonTypes.ExtendedLocationType"] = typeof(ExtendedLocationType),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentity"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.Legacy.ManagedServiceIdentityV4"] = typeof(ManagedServiceIdentity),
            ["Azure.ResourceManager.CommonTypes.ManagedServiceIdentityType"] = typeof(ManagedServiceIdentityType),
            ["Azure.ResourceManager.CommonTypes.OperationStatusResult"] = typeof(OperationStatusResult),
            ["Azure.ResourceManager.CommonTypes.SystemData"] = typeof(SystemData),
            ["Azure.ResourceManager.CommonTypes.UserAssignedIdentity"] = typeof(UserAssignedIdentity),
            ["Azure.ResourceManager.Models.SubResource"] = typeof(SubResource),
            ["Azure.ResourceManager.CommonTypes.ErrorDetail"] = typeof(ResponseError),
        };

        private static readonly Dictionary<string, CSharpType> _idToPrimitiveTypeMap = new Dictionary<string, CSharpType>()
        {
            ["Azure.Core.armResourceType"] = typeof(ResourceType),
        };

        public static bool TryGetPrimitiveType(string crossLanguageDefinitionId, [MaybeNullWhen(false)] out CSharpType primitiveType)
            => _idToPrimitiveTypeMap.TryGetValue(crossLanguageDefinitionId, out primitiveType);

        private static MethodBodyStatement SerializeTypeWithImplicitOperatorToString(ValueExpression value, ScopedApi<Utf8JsonWriter> writer, ScopedApi<ModelReaderWriterOptions> options, SerializationFormat format)
            => writer.WriteStringValue(value);

        private static ValueExpression DeserializeNewInstanceStringLikeType(CSharpType valueType, ScopedApi<JsonElement> element, SerializationFormat format)
            => New.Instance(valueType, element.GetString());

        private static readonly IReadOnlyDictionary<Type, SerializationExpression> _typeToSerializationExpression = new Dictionary<Type, SerializationExpression>
        {
            [typeof(ResourceType)] = SerializeTypeWithImplicitOperatorToString,
        };

        private static readonly IReadOnlyDictionary<Type, DeserializationExpression> _typeToDeserializationExpression = new Dictionary<Type, DeserializationExpression>
        {
            [typeof(ResourceType)] = DeserializeNewInstanceStringLikeType,
        };

        private static readonly HashSet<CSharpType> _knownTypes = _idToInheritableSystemTypeMap.Values.Concat(_idToSystemTypeMap.Values).ToHashSet(new CSharpFullNameComparer());

        public static bool IsKnownManagementType(CSharpType type) => _knownTypes.Contains(type);

        public static bool TryGetInheritableSystemType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToInheritableSystemTypeMap.TryGetValue(id, out type);

        public static bool TryGetSystemType(string id, [MaybeNullWhen(false)] out CSharpType type) => _idToSystemTypeMap.TryGetValue(id, out type);

        // The comparison could be CSharpType from Azure.ResourceManager, which is a framework type
        // and CSharpType from InheritableSystemObjectModelProvider, which is not a framework type, they should still be equal if namespace and name match
        // Then, the default Equals of CSharpType doesn't apply here
        private class CSharpFullNameComparer : IEqualityComparer<CSharpType>
        {
            public bool Equals(CSharpType? x, CSharpType? y)
            {
                if (x is null)
                {
                    if (y is null)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return x.AreNamesEqual(y);
                }
            }

            public int GetHashCode([DisallowNull] CSharpType obj)
            {
                return HashCode.Combine(obj.Namespace, obj.Name);
            }
        }

        public static bool TryGetJsonSerializationExpression(Type type, [MaybeNullWhen(false)] out SerializationExpression expression)
            => _typeToSerializationExpression.TryGetValue(type, out expression);

        public static bool TryGetJsonDeserializationExpression(Type type, [MaybeNullWhen(false)] out DeserializationExpression expression)
            => _typeToDeserializationExpression.TryGetValue(type, out expression);
    }
}
