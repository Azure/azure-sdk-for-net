// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Azure.Provisioning.Generator.Model;

public static class TypeRegistry
{
    private static readonly Dictionary<Type, ModelBase> _mapping = [];
    private static readonly List<ModelBase> _types = [];

    public static IReadOnlyList<ModelBase> Types => _types;

    static TypeRegistry()
    {
        // Primitives
        RegisterExternal<object>();
        RegisterExternal<bool>();
        RegisterExternal<int>();
        RegisterExternal<long>();
        RegisterExternal<float>();
        RegisterExternal<double>();
        RegisterExternal<string>();

        // Common BCL types
        RegisterExternal<BinaryData>();
        RegisterExternal<DateTimeOffset>();
        RegisterExternal<Guid>();
        RegisterExternal<IPAddress>();
        RegisterExternal<TimeSpan>();
        RegisterExternal<Uri>();

        // Azure types
        RegisterExternal<AzureLocation>();
        RegisterExternal<ContentType>();
        RegisterExternal<ETag>();
        RegisterExternal<ResponseError>();
        RegisterExternal<ResourceIdentifier>();
        RegisterExternal<ResourceType>();
    }

    public static void RegisterExternal<T>() =>
        Register(new ExternalModel(typeof(T)));

    public static void Register(ModelBase type)
    {
        ArgumentNullException.ThrowIfNull(type, nameof(type));
        if (_types.Contains(type)) { throw new ArgumentException($"Type {type.Name} has already been registered!", nameof(type)); }
        if (type?.ArmType is not null && _mapping.ContainsKey(type.ArmType)) { throw new ArgumentException($"{type.Name}'s ArmType has already been registered!", nameof(type)); }

        _types.Add(type!);
        if (type?.ArmType is not null)
        {
            _mapping[type.ArmType] = type;

            // if this type is a resource, we also register its data here so that next time we have a property with this type, we could return the built resource type
            if (type is Resource)
            {
                var dataType = ReflectionExtensions.GetDataTypeFromResource(type.ArmType);
                if (dataType is not null)
                {
                    _mapping[dataType] = type;
                }
            }
        }
    }

    public static ModelBase? Get<T>() => Get(typeof(T));

    public static ModelBase? Get(Type armType)
    {
        ArgumentNullException.ThrowIfNull(armType, nameof(armType));
        return _mapping.TryGetValue(armType, out ModelBase? type) ? type : null;
    }

    public static IEnumerable<string> CollectNamespaces(IEnumerable<ModelBase?> types, HashSet<string>? namespaces = default, HashSet<ModelBase>? visited = default)
    {
        namespaces ??= [];
        visited ??= [];
        foreach (ModelBase? type in types)
        {
            if (type is null || visited.Contains(type)) { continue; }
            visited.Add(type);

            if (type?.Namespace is null) { continue; }
            namespaces.Add(type.Namespace);

            Recurse(type);
        }
        return namespaces;

        void Recurse(ModelBase type)
        {
            if (type is SimpleModel simple)
            {
                CollectNamespaces(simple.Properties.Select(p => p.PropertyType), namespaces, visited);
            }
            else if (type is Resource resource)
            {
                CollectNamespaces(resource.Properties.Select(p => p.PropertyType), namespaces, visited);
            }
            else if (type is ListModel array)
            {
                CollectNamespaces([array.ElementType], namespaces, visited);
            }
            else if (type is DictionaryModel dict)
            {
                CollectNamespaces([dict.ElementType], namespaces, visited);
            }
        }
    }

    public static void Remove(ModelBase model)
    {
        _types.Remove(model);
        if (model.ArmType is not null)
        {
            _mapping.Remove(model.ArmType);
        }
    }
}