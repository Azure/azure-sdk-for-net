// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal static class ReflectionUtil
    {
        private static MethodInfo DictionaryGetItemMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetBinaryMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetBooleanMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetDateTimeMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetDoubleMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetGuidMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetInt32MethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetInt64MethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetString64MethodInfo { get; }

        internal static HashSet<MethodInfo> s_dictionaryMethodsInfoHash = new HashSet<MethodInfo>();

        static ReflectionUtil()
        {
            DictionaryGetItemMethodInfo = typeof(IDictionary<string, object>).GetMethod("get_Item");
            DynamicDictionaryGetBinaryMethodInfo = typeof(DynamicTableEntity).GetMethod("GetBinary");
            DynamicDictionaryGetBooleanMethodInfo = typeof(DynamicTableEntity).GetMethod("GetBoolean");
            DynamicDictionaryGetDateTimeMethodInfo = typeof(DynamicTableEntity).GetMethod("GetDateTime");
            DynamicDictionaryGetDoubleMethodInfo = typeof(DynamicTableEntity).GetMethod("GetDouble");
            DynamicDictionaryGetGuidMethodInfo = typeof(DynamicTableEntity).GetMethod("GetGuid");
            DynamicDictionaryGetInt32MethodInfo = typeof(DynamicTableEntity).GetMethod("GetInt32");
            DynamicDictionaryGetInt64MethodInfo = typeof(DynamicTableEntity).GetMethod("GetInt64");
            DynamicDictionaryGetString64MethodInfo = typeof(DynamicTableEntity).GetMethod("GetString");

            s_dictionaryMethodsInfoHash.Add(DictionaryGetItemMethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetBinaryMethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetBooleanMethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetDateTimeMethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetDoubleMethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetGuidMethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetInt32MethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetInt64MethodInfo);
            s_dictionaryMethodsInfoHash.Add(DynamicDictionaryGetString64MethodInfo);
        }
    }
}
