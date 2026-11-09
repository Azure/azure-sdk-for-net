// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.TestFramework
{
    internal static class AsyncEnumerableType
    {
        public static Type GetItemType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>))
            {
                return type.GenericTypeArguments[0];
            }

            return type.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>))
                ?.GenericTypeArguments[0];
        }

        public static bool IsInterface(Type type)
            => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>);
    }
}
