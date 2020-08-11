// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal static class ReflectionUtil
    {
        private static MethodInfo DictionaryGetItemMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetItemMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetBinaryMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetBooleanMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetDateTimeMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetDoubleMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetGuidMethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetInt32MethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetInt64MethodInfo { get; }
        private static MethodInfo DynamicDictionaryGetString64MethodInfo { get; }

        internal static HashSet<MethodInfo> s_dictionaryMethodInfosHash = new HashSet<MethodInfo>();

        static ReflectionUtil()
        {
            DictionaryGetItemMethodInfo = typeof(IDictionary<string, object>).GetMethod("get_Item");
            DynamicDictionaryGetItemMethodInfo = typeof(TableEntity).GetMethod("get_Item");
            DynamicDictionaryGetBinaryMethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetBinary));
            DynamicDictionaryGetBooleanMethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetBoolean));
            DynamicDictionaryGetDateTimeMethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetDateTime));
            DynamicDictionaryGetDoubleMethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetDouble));
            DynamicDictionaryGetGuidMethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetGuid));
            DynamicDictionaryGetInt32MethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetInt32));
            DynamicDictionaryGetInt64MethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetInt64));
            DynamicDictionaryGetString64MethodInfo = typeof(TableEntity).GetMethod(nameof(TableEntity.GetString));

            s_dictionaryMethodInfosHash.Add(DictionaryGetItemMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetItemMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetBinaryMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetBooleanMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetDateTimeMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetDoubleMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetGuidMethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetInt32MethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetInt64MethodInfo);
            s_dictionaryMethodInfosHash.Add(DynamicDictionaryGetString64MethodInfo);
        }
    }
}
