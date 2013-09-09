// -----------------------------------------------------------------------------------------
// <copyright file="TypeSystem.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Table.Queryable
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    internal static class TypeSystem
    {
        private static readonly Dictionary<MethodInfo, string> StaticExpressionMethodMap;

        private static readonly Dictionary<string, string> StaticExpressionVBMethodMap;

        private static readonly Dictionary<PropertyInfo, MethodInfo> StaticPropertiesAsMethodsMap;

#if !ASTORIA_LIGHT
        private const string VisualBasicAssemblyFullName = "Microsoft.VisualBasic, Version=10.0.0.0, Culture=neutral, PublicKeyToken=" + "b03f5f7f11d50a3a"; // MicrosoftPublicKeyToken
#else
        private const string VisualBasicAssemblyFullName = "Microsoft.VisualBasic, Version=2.0.5.0, Culture=neutral, PublicKeyToken=" + AssemblyRef.MicrosoftSilverlightPublicKeyToken;
#endif

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Cleaner code")]
        static TypeSystem()
        {
#if !ASTORIA_LIGHT
            const int ExpectedCount = 24;
#else
            const int ExpectedCount = 22;
#endif
#if WINDOWS_DESKTOP
            StaticExpressionMethodMap = new Dictionary<MethodInfo, string>(ExpectedCount, EqualityComparer<MethodInfo>.Default);
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), @"substringof");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) }), @"endswith");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) }), @"startswith");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("IndexOf", new Type[] { typeof(string) }), @"indexof");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("Replace", new Type[] { typeof(string), typeof(string) }), @"replace");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("Substring", new Type[] { typeof(int) }), @"substring");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) }), @"substring");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("ToLower", Type.EmptyTypes), @"tolower");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("ToUpper", Type.EmptyTypes), @"toupper");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("Trim", Type.EmptyTypes), @"trim");
            StaticExpressionMethodMap.Add(typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }, null), @"concat");   
            StaticExpressionMethodMap.Add(typeof(string).GetProperty("Length", typeof(int)).GetGetMethod(), @"length");

            StaticExpressionMethodMap.Add(typeof(DateTime).GetProperty("Day", typeof(int)).GetGetMethod(), @"day");
            StaticExpressionMethodMap.Add(typeof(DateTime).GetProperty("Hour", typeof(int)).GetGetMethod(), @"hour");
            StaticExpressionMethodMap.Add(typeof(DateTime).GetProperty("Month", typeof(int)).GetGetMethod(), @"month");
            StaticExpressionMethodMap.Add(typeof(DateTime).GetProperty("Minute", typeof(int)).GetGetMethod(), @"minute");
            StaticExpressionMethodMap.Add(typeof(DateTime).GetProperty("Second", typeof(int)).GetGetMethod(), @"second");
            StaticExpressionMethodMap.Add(typeof(DateTime).GetProperty("Year", typeof(int)).GetGetMethod(), @"year");

            StaticExpressionMethodMap.Add(typeof(Math).GetMethod("Round", new Type[] { typeof(double) }), @"round");
            StaticExpressionMethodMap.Add(typeof(Math).GetMethod("Round", new Type[] { typeof(decimal) }), @"round");
            StaticExpressionMethodMap.Add(typeof(Math).GetMethod("Floor", new Type[] { typeof(double) }), @"floor");
#if !ASTORIA_LIGHT
            StaticExpressionMethodMap.Add(typeof(Math).GetMethod("Floor", new Type[] { typeof(decimal) }), @"floor");
#endif
            StaticExpressionMethodMap.Add(typeof(Math).GetMethod("Ceiling", new Type[] { typeof(double) }), @"ceiling");
#if !ASTORIA_LIGHT
            StaticExpressionMethodMap.Add(typeof(Math).GetMethod("Ceiling", new Type[] { typeof(decimal) }), @"ceiling");
#endif

            Debug.Assert(StaticExpressionMethodMap.Count == ExpectedCount, "expressionMethodMap.Count == ExpectedCount");

            StaticExpressionVBMethodMap = new Dictionary<string, string>(EqualityComparer<string>.Default);

            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.Trim", @"trim");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.Len", @"length");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.Mid", @"substring");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.UCase", @"toupper");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.LCase", @"tolower");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Year", @"year");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Month", @"month");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Day", @"day");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Hour", @"hour");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Minute", @"minute");
            StaticExpressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Second", @"second");
#elif WINDOWS_RT
            expressionMethodMap = new Dictionary<MethodInfo, string>(ExpectedCount, EqualityComparer<MethodInfo>.Default);
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("Contains", new Type[] { typeof(string) }), @"substringof");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("EndsWith", new Type[] { typeof(string) }), @"endswith");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("StartsWith", new Type[] { typeof(string) }), @"startswith");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("IndexOf", new Type[] { typeof(string) }), @"indexof");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("Replace", new Type[] { typeof(string), typeof(string) }), @"replace");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("Substring", new Type[] { typeof(int) }), @"substring");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("Substring", new Type[] { typeof(int), typeof(int) }), @"substring");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("ToLower", Type.EmptyTypes), @"tolower");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("ToUpper", Type.EmptyTypes), @"toupper");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("Trim", Type.EmptyTypes), @"trim");
            expressionMethodMap.Add(typeof(string).GetRuntimeMethod("Concat", new Type[] { typeof(string), typeof(string) }), @"concat");
            expressionMethodMap.Add(typeof(string).GetRuntimeProperty("Length").GetMethod, @"length");

            expressionMethodMap.Add(typeof(DateTime).GetRuntimeProperty("Day").GetMethod, @"day");
            expressionMethodMap.Add(typeof(DateTime).GetRuntimeProperty("Hour").GetMethod, @"hour");
            expressionMethodMap.Add(typeof(DateTime).GetRuntimeProperty("Month").GetMethod, @"month");
            expressionMethodMap.Add(typeof(DateTime).GetRuntimeProperty("Minute").GetMethod, @"minute");
            expressionMethodMap.Add(typeof(DateTime).GetRuntimeProperty("Second").GetMethod, @"second");
            expressionMethodMap.Add(typeof(DateTime).GetRuntimeProperty("Year").GetMethod, @"year");

            expressionMethodMap.Add(typeof(Math).GetRuntimeMethod("Round", new Type[] { typeof(double) }), @"round");
            expressionMethodMap.Add(typeof(Math).GetRuntimeMethod("Round", new Type[] { typeof(decimal) }), @"round");
            expressionMethodMap.Add(typeof(Math).GetRuntimeMethod("Floor", new Type[] { typeof(double) }), @"floor");
#if !ASTORIA_LIGHT
            expressionMethodMap.Add(typeof(Math).GetRuntimeMethod("Floor", new Type[] { typeof(decimal) }), @"floor");
#endif
            expressionMethodMap.Add(typeof(Math).GetRuntimeMethod("Ceiling", new Type[] { typeof(double) }), @"ceiling");
#if !ASTORIA_LIGHT
            expressionMethodMap.Add(typeof(Math).GetRuntimeMethod("Ceiling", new Type[] { typeof(decimal) }), @"ceiling");
#endif

            Debug.Assert(expressionMethodMap.Count == ExpectedCount, "expressionMethodMap.Count == ExpectedCount");

            expressionVBMethodMap = new Dictionary<string, string>(EqualityComparer<string>.Default);

            expressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.Trim", @"trim");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.Len", @"length");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.Mid", @"substring");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.UCase", @"toupper");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.Strings.LCase", @"tolower");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Year", @"year");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Month", @"month");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Day", @"day");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Hour", @"hour");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Minute", @"minute");
            expressionVBMethodMap.Add("Microsoft.VisualBasic.DateAndTime.Second", @"second");
#endif
            Debug.Assert(StaticExpressionVBMethodMap.Count == 11, "expressionVBMethodMap.Count == 11");
          
            StaticPropertiesAsMethodsMap = new Dictionary<PropertyInfo, MethodInfo>(EqualityComparer<PropertyInfo>.Default);
#if WINDOWS_DESKTOP
             StaticPropertiesAsMethodsMap.Add(
                typeof(string).GetProperty("Length", typeof(int)), 
                typeof(string).GetProperty("Length", typeof(int)).GetGetMethod());
            StaticPropertiesAsMethodsMap.Add(
                typeof(DateTime).GetProperty("Day", typeof(int)), 
                typeof(DateTime).GetProperty("Day", typeof(int)).GetGetMethod());
            StaticPropertiesAsMethodsMap.Add(
                typeof(DateTime).GetProperty("Hour", typeof(int)), 
                typeof(DateTime).GetProperty("Hour", typeof(int)).GetGetMethod());
            StaticPropertiesAsMethodsMap.Add(
                typeof(DateTime).GetProperty("Minute", typeof(int)), 
                typeof(DateTime).GetProperty("Minute", typeof(int)).GetGetMethod());
            StaticPropertiesAsMethodsMap.Add(
                typeof(DateTime).GetProperty("Second", typeof(int)), 
                typeof(DateTime).GetProperty("Second", typeof(int)).GetGetMethod());
            StaticPropertiesAsMethodsMap.Add(
                typeof(DateTime).GetProperty("Month", typeof(int)),
                typeof(DateTime).GetProperty("Month", typeof(int)).GetGetMethod());
            StaticPropertiesAsMethodsMap.Add(
                typeof(DateTime).GetProperty("Year", typeof(int)), 
                typeof(DateTime).GetProperty("Year", typeof(int)).GetGetMethod());
#elif WINDOWS_RT
            propertiesAsMethodsMap.Add(
               typeof(string).GetRuntimeProperty("Length"),
               typeof(string).GetRuntimeProperty("Length").GetMethod);
            propertiesAsMethodsMap.Add(
                typeof(DateTime).GetRuntimeProperty("Day"),
                typeof(DateTime).GetRuntimeProperty("Day").GetMethod);
            propertiesAsMethodsMap.Add(
                typeof(DateTime).GetRuntimeProperty("Hour"),
                typeof(DateTime).GetRuntimeProperty("Hour").GetMethod);
            propertiesAsMethodsMap.Add(
                typeof(DateTime).GetRuntimeProperty("Minute"),
                typeof(DateTime).GetRuntimeProperty("Minute").GetMethod);
            propertiesAsMethodsMap.Add(
                typeof(DateTime).GetRuntimeProperty("Second"),
                typeof(DateTime).GetRuntimeProperty("Second").GetMethod);
            propertiesAsMethodsMap.Add(
                typeof(DateTime).GetRuntimeProperty("Month"),
                typeof(DateTime).GetRuntimeProperty("Month").GetMethod);
            propertiesAsMethodsMap.Add(
                typeof(DateTime).GetRuntimeProperty("Year"),
                typeof(DateTime).GetRuntimeProperty("Year").GetMethod);
#endif

            Debug.Assert(StaticPropertiesAsMethodsMap.Count == 7, "propertiesAsMethodsMap.Count == 7");
        }

        internal static bool TryGetQueryOptionMethod(MethodInfo mi, out string methodName)
        {
            return StaticExpressionMethodMap.TryGetValue(mi, out methodName) ||
                (mi.DeclaringType.Assembly.FullName == VisualBasicAssemblyFullName &&
                 StaticExpressionVBMethodMap.TryGetValue(mi.DeclaringType.FullName + "." + mi.Name, out methodName));
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