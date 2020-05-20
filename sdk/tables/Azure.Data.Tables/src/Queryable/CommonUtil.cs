// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;

namespace Azure.Data.Tables.Queryable
{
    internal static class CommonUtil
    {
        private static readonly Type[] UnsupportedTypes = new Type[]
        {
                typeof(System.Dynamic.IDynamicMetaObjectProvider),
                typeof(System.Tuple<>),
                typeof(System.Tuple<,>),
                typeof(System.Tuple<,,>),
                typeof(System.Tuple<,,,>),
                typeof(System.Tuple<,,,,>),
                typeof(System.Tuple<,,,,,>),
                typeof(System.Tuple<,,,,,,>),
                typeof(System.Tuple<,,,,,,,>)
        };

        internal static bool IsUnsupportedType(Type type)
        {
            if (type.IsGenericType)
            {
                type = type.GetGenericTypeDefinition();
            }

            if (UnsupportedTypes.Any(t => t.IsAssignableFrom(type)))
            {
                return true;
            }

            Debug.Assert(!type.FullName.StartsWith("System.Tuple", StringComparison.Ordinal), "System.Tuple is not blocked by unsupported type check");
            return false;
        }

        internal static bool IsClientType(Type t)
        {
            return typeof(ITableEntity).IsAssignableFrom(t);
        }
    }
}
