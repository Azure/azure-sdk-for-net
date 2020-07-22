// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal static class ReflectionUtil
    {
        internal static MethodInfo DictionaryGetItemMethodInfo { get; }

        static ReflectionUtil()
        {
            DictionaryGetItemMethodInfo = typeof(IDictionary<string, object>).GetMethod("get_Item");
        }
    }
}
