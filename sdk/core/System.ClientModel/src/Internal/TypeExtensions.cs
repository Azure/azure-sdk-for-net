// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Internal;

internal static class TypeExtensions
{
    public static string ToFriendlyName(this Type type)
    {
        if (type == null)
        {
            return string.Empty;
        }

        // Handle generic types
        if (type.IsGenericType)
        {
            var typeName = type.GetGenericTypeDefinition().Name.Split('`')[0]; // Get the name without the arity
            var genericArgs = type.GetGenericArguments();
            var argNames = string.Join(", ", Array.ConvertAll(genericArgs, t => t.ToFriendlyName()));
            return $"{typeName}<{argNames}>";
        }

        // Handle arrays
        if (type.IsArray)
        {
            if (type.GetArrayRank() > 1)
            {
                return $"{type.GetElementType()!.ToFriendlyName()}[{new string(',', type.GetArrayRank() - 1)}]";
            }
            else
            {
                return $"{type.GetElementType()!.ToFriendlyName()}[]";
            }
        }

        // Handle nullable types
        if (Nullable.GetUnderlyingType(type) is Type underlyingType)
        {
            return underlyingType.ToFriendlyName();
        }

        return type.Name;
    }
}
