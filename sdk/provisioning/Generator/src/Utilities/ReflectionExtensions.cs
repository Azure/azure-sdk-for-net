// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Sql.Models;

namespace Azure.Provisioning.Generator;

public static class ReflectionExtensions
{
    public static bool IsNullableOf(this Type type, Func<Type, bool> predicate) =>
        type.IsGenericType &&
        type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
        predicate(type.GetGenericArguments()[0]);

    public static bool IsSimpleType(this Type type) =>
        type.IsPrimitive ||
        type == typeof(string) ||

        // Well-known System types that can be turned into strings
        type == typeof(Uri) ||
        type == typeof(DateTimeOffset) ||
        type == typeof(TimeSpan) ||
        type == typeof(Guid) ||
        type == typeof(IPAddress) ||

        // Well-known Azure types that can be turned into strings
        type == typeof(ETag) ||
        type == typeof(AzureLocation) ||
        type == typeof(ResourceType) ||
        type == typeof(ResourceIdentifier) ||

        // Or nullable of the above
        type.IsNullableOf(t => t.IsSimpleType());

    public static bool IsEnumLike(this Type type) =>
        type.IsEnum ||
        type.IsExtensibleEnum() ||
        type.IsNullableOf(t => t.IsEnumLike());

    public static bool IsExtensibleEnum(this Type type)
    {
        // Struct
        if (!type.IsValueType) { return false; }

        // Ignore handcrafted EEs with special behavior
        if (type == typeof(AzureLocation)) { return true; }

        // Single .ctor
        ConstructorInfo[] ctors = type.GetConstructors();
        if (ctors.Length != 1) { return false; }

        // Ctor only takes a string
        ParameterInfo[] parameters = ctors[0].GetParameters();
        if (parameters.Length != 1 || parameters[0].ParameterType != typeof(string)) { return false; }

        // Has implicit conversion from string
        MethodInfo? conv = type.GetMethod("op_Implicit", [typeof(string)]);
        if (conv is null) { return false; }

        // Has static readonly properties of its own type
        if (!type.GetProperties().Where(p => p.CanRead && !p.CanWrite && p.GetMethod!.IsStatic && p.PropertyType == type).Any()) { return false; }

        return true;
    }

    public static Type? GetDataTypeFromResource(Type resourceType)
    {
        if (!typeof(ArmResource).IsAssignableFrom(resourceType))
        {
            return null;
        }

        return resourceType.GetProperty("Data")?.PropertyType;
    }

    public static bool IsResourceData(this Type type) =>
        typeof(ResourceData).IsAssignableFrom(type) ||
        // hack for Sql
        typeof(ResourceWithWritableName).IsAssignableFrom(type) ||
        // hack for Network
        typeof(NetworkResourceData).IsAssignableFrom(type) ||
        typeof(NetworkWritableResourceData).IsAssignableFrom(type) ||
        typeof(NetworkTrackedResourceData).IsAssignableFrom(type);

    public static bool IsModelType(this Type type, List<Type>? visited = default) =>
        type.IsClass &&
        (type.GetInterfaces().Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IPersistableModel<>)).Any() ||
            type == typeof(Azure.ResourceManager.AppContainers.Models.ContainerAppManagedEnvironmentOutboundSettings) ||
            type == typeof(Azure.ResourceManager.ContainerRegistry.Models.ContainerRegistryWebhookCreateOrUpdateContent) ||
            type == typeof(Azure.ResourceManager.Search.Models.SearchManagementRequestOptions)
#pragma warning disable CS0618 // Type or member is obsolete
        // || type == typeof(Azure.ResourceManager.Network.Models.ProtocolCustomSettings)
#pragma warning restore CS0618 // Type or member is obsolete
        ) &&
        type.GetProperties().Select(p => p.PropertyType).All(t => t.IsUsableType(visited));

    public static Type? GetGenericInterface(this Type type, Type iface) =>
        (type.IsGenericType && type.GetGenericTypeDefinition() == iface) ?
            type :
            type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == iface);

    public static bool IsDictionary(this Type type) => type.IsDictionaryOf(_ => true);

    public static bool IsDictionaryOf(this Type type, Func<Type, bool> predicate)
    {
        Type? i = GetGenericInterface(type, typeof(IDictionary<,>)) ?? GetGenericInterface(type, typeof(IReadOnlyDictionary<,>));
        return i is not null && predicate(i.GetGenericArguments()[1]);
    }

    public static bool IsListOf(this Type type, Func<Type, bool> predicate)
    {
        Type? i = GetGenericInterface(type, typeof(IList<>)) ?? GetGenericInterface(type, typeof(IReadOnlyList<>));
        return i is not null && predicate(i.GetGenericArguments()[0]);
    }

    public static bool IsUsableType(this Type type, List<Type>? visited = default)
    {
        visited ??= [];
        if (visited.Contains(type)) { return true; }
        visited.Add(type);
        bool usable =
            type.IsSimpleType() ||
            type.IsEnumLike() ||
            type == typeof(BinaryData) ||
            type.IsListOf(t => t.IsUsableType(visited)) ||
            type.IsDictionaryOf(t => t.IsUsableType(visited)) ||
            type.IsResourceData() ||
            type.IsModelType(visited);
        if (!usable)
        {
            bool s = type.IsSimpleType();
            bool e = type.IsEnumLike();
            bool b = type == typeof(BinaryData);
            bool l = type.IsListOf(t => t.IsUsableType(visited));
            bool d = type.IsDictionaryOf(t => t.IsUsableType(visited));
            bool r = type.IsResourceData();
            bool m = type.IsModelType(visited);
            IList<PropertyInfo> failures = [.. type.GetProperties().Where(p => !p.PropertyType.IsUsableType(visited))];
            Console.WriteLine(type.FullName + ": " + string.Join(", ", failures.Select(p => p.Name)));
        }
        return usable;
    }
}