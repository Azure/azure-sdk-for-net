// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace System
{
    using Collections.Generic;
    using Linq;
    using Microsoft.Azure.Search.Models;
    using Reflection;

    public static class TypeExtensions
    {
        public static bool CanBeNull(this Type type) => type.IsReferenceType() || type.IsNullable();

        public static Type GetIEnumerable(this Type type) =>
            type.IsGenericEnumerable() ? type : type.GetTypeInfo().ImplementedInterfaces.FirstOrDefault(IsGenericEnumerable);

        public static Type GetIResourceWithETag(this Type type)
        {
            TypeInfo typeInfo = type.GetTypeInfo();
            Type resourceWithETag = typeof(IResourceWithETag);
            return type == resourceWithETag ? type : typeInfo.ImplementedInterfaces.FirstOrDefault(t => t == resourceWithETag);
        }

        public static bool ImplementsGenericEquatable(this Type type) =>
            type.IsGenericEquatable() || type.GetTypeInfo().ImplementedInterfaces.Any(IsGenericEquatable);

        public static bool IsIEnumerable(this Type type) =>
            type.IsGenericEnumerable() || type.GetTypeInfo().ImplementedInterfaces.Any(IsGenericEnumerable);

        public static bool IsInteger(this Type type) => 
            type == typeof(byte) || type == typeof(short) || type == typeof(int) || type == typeof(long);

        public static bool IsNullable(this Type type) => type.IsGenericWithDefinition(typeof(Nullable<>));

        public static bool IsReferenceType(this Type type) => !type.GetTypeInfo().IsValueType;

        private static bool IsGenericEnumerable(this Type type) => type.IsGenericWithDefinition(typeof(IEnumerable<>));

        private static bool IsGenericEquatable(this Type type) => type.IsGenericWithDefinition(typeof(IEquatable<>));

        private static bool IsGenericWithDefinition(this Type type, Type genericTypeDef) =>
            type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == genericTypeDef;
    }
}
