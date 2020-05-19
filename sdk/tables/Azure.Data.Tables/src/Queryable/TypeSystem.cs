// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    internal static class TypeSystem
    {
        private static readonly Dictionary<MethodInfo, string> StaticExpressionMethodMap = new Dictionary<MethodInfo, string>
        {
            {typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), @"substringof"},
            {typeof(string).GetMethod("EndsWith", new Type[] { typeof(string)}), @"endswith"},
            {typeof(string).GetMethod("StartsWith", new Type[] { typeof(string)}), @"startswith" },
            {typeof(string).GetMethod("IndexOf", new Type[] { typeof(string) }), @"indexof"},
            {typeof(string).GetMethod("Replace", new Type[] { typeof(string), typeof(string) }), @"replace"},
            {typeof(string).GetMethod("Substring", new Type[] { typeof(int) }), @"substring"},
            {typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) }), @"substring"},
            {typeof(string).GetMethod("ToLower", Type.EmptyTypes), @"tolower"},
            {typeof(string).GetMethod("ToUpper", Type.EmptyTypes), @"toupper"},
            {typeof(string).GetMethod("Trim", Type.EmptyTypes), @"trim"},
            {typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }, null), @"concat"},
            {typeof(string).GetProperty("Length", typeof(int)).GetGetMethod(), @"length"},

            {typeof(DateTime).GetProperty("Day", typeof(int)).GetGetMethod(), @"day"},
            {typeof(DateTime).GetProperty("Hour", typeof(int)).GetGetMethod(), @"hour"},
            {typeof(DateTime).GetProperty("Month", typeof(int)).GetGetMethod(), @"month"},
            {typeof(DateTime).GetProperty("Minute", typeof(int)).GetGetMethod(), @"minute"},
            {typeof(DateTime).GetProperty("Second", typeof(int)).GetGetMethod(), @"second"},
            {typeof(DateTime).GetProperty("Year", typeof(int)).GetGetMethod(), @"year"},

            {typeof(Math).GetMethod("Round", new Type[] { typeof(double) }), @"round"},
            {typeof(Math).GetMethod("Round", new Type[] { typeof(decimal) }), @"round"},
            {typeof(Math).GetMethod("Floor", new Type[] { typeof(double) }), @"floor"},
            {typeof(Math).GetMethod("Floor", new Type[] { typeof(decimal) }), @"floor"},
            {typeof(Math).GetMethod("Ceiling", new Type[] { typeof(double) }), @"ceiling"},
            {typeof(Math).GetMethod("Ceiling", new Type[] { typeof(decimal) }), @"ceiling"},
        };

        private static readonly Dictionary<PropertyInfo, MethodInfo> StaticPropertiesAsMethodsMap = new Dictionary<PropertyInfo, MethodInfo>
        {
            {
                typeof(string).GetProperty("Length", typeof(int)),
                typeof(string).GetProperty("Length", typeof(int)).GetGetMethod()},
            {
                typeof(DateTime).GetProperty("Day", typeof(int)),
                typeof(DateTime).GetProperty("Day", typeof(int)).GetGetMethod()},
            {
                typeof(DateTime).GetProperty("Hour", typeof(int)),
                typeof(DateTime).GetProperty("Hour", typeof(int)).GetGetMethod()},
            {
                typeof(DateTime).GetProperty("Minute", typeof(int)),
                typeof(DateTime).GetProperty("Minute", typeof(int)).GetGetMethod()},
            {
                typeof(DateTime).GetProperty("Second", typeof(int)),
                typeof(DateTime).GetProperty("Second", typeof(int)).GetGetMethod()},
            {
                typeof(DateTime).GetProperty("Month", typeof(int)),
                typeof(DateTime).GetProperty("Month", typeof(int)).GetGetMethod()},
            {
                typeof(DateTime).GetProperty("Year", typeof(int)),
                typeof(DateTime).GetProperty("Year", typeof(int)).GetGetMethod()},
        };

        static TypeSystem()
        {
            Debug.Assert(StaticExpressionMethodMap.Count == 24, "expressionMethodMap.Count == ExpectedCount");
            Debug.Assert(StaticPropertiesAsMethodsMap.Count == 7, "propertiesAsMethodsMap.Count == 7");
        }

        internal static bool TryGetQueryOptionMethod(MethodInfo mi, out string methodName)
        {
            return StaticExpressionMethodMap.TryGetValue(mi, out methodName);
        }

        internal static bool TryGetPropertyAsMethod(PropertyInfo pi, out MethodInfo mi)
        {
            return StaticPropertiesAsMethodsMap.TryGetValue(pi, out mi);
        }

        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null)
            {
                return seqType;
            }

            return ienum.GetGenericArguments()[0];
        }

        internal static bool IsPrivate(PropertyInfo pi)
        {
            MethodInfo mi = pi.GetGetMethod() ?? pi.GetSetMethod();
            if (mi != null)
            {
                return mi.IsPrivate;
            }

            return true;
        }

        internal static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
            {
                return null;
            }

            if (seqType.IsArray)
            {
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            }

            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }

            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null)
                    {
                        return ienum;
                    }
                }
            }

            if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
            }

            return null;
        }
    }
}
