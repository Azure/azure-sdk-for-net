// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using Microsoft.Hadoop.Avro.Schema;

    internal static class TypeExtensions
    {
        /// <summary>
        ///     Checks if type t has a public parameter-less constructor.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>True if type t has a public parameter-less constructor, false otherwise.</returns>
        public static bool HasParameterlessConstructor(this Type type)
        {
            return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null) != null;
        }

        /// <summary>
        ///     Determines whether the type is definitely unsupported for schema generation.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if the type is unsupported; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUnsupported(this Type type)
        {
            return type == typeof(IntPtr)
                || type == typeof(UIntPtr)
                || type == typeof(object)
                || type.ContainsGenericParameters
                || (!type.IsArray
                && !type.IsValueType
                && !type.IsAnonymous()
                && !type.HasParameterlessConstructor()
                && type != typeof(string)
                && type != typeof(Uri)
                && !type.IsAbstract
                && !type.IsInterface
                && !(type.IsGenericType && SupportedInterfaces.Contains(type.GetGenericTypeDefinition())));
        }

        /// <summary>
        /// The natively supported types.
        /// </summary>
        private static readonly HashSet<Type> NativelySupported = new HashSet<Type>
        {
            typeof(char),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(uint),
            typeof(int),
            typeof(bool),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(string),
            typeof(Uri),
            typeof(byte[]),
            typeof(DateTime),
            typeof(DateTimeOffset),
            typeof(Guid)
        };

        public static bool IsNativelySupported(this Type type)
        {
            var notNullable = Nullable.GetUnderlyingType(type) ?? type;
            return NativelySupported.Contains(notNullable)
                || type.IsArray
                || type.IsKeyValuePair()
                || type.GetAllInterfaces()
                       .FirstOrDefault(t => t.IsGenericType && 
                                            t.GetGenericTypeDefinition() == typeof(IEnumerable<>)) != null;
        }

        private static readonly HashSet<Type> SupportedInterfaces = new HashSet<Type>
        {
            typeof(IList<>),
            typeof(IDictionary<,>)
        };

        public static bool IsAnonymous(this Type type)
        {
            return type.IsClass
                && type.GetCustomAttributes(false).Any(a => a is CompilerGeneratedAttribute)
                && !type.IsNested
                && type.Name.StartsWith("<>", StringComparison.Ordinal)
                && type.Name.Contains("__Anonymous");
        }

        public static PropertyInfo GetPropertyByName(
            this Type type, string name, BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance)
        {
            return type.GetProperty(name, flags);
        }

        public static MethodInfo GetMethodByName(this Type type, string shortName, params Type[] arguments)
        {
            var result = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .SingleOrDefault(m => m.Name == shortName && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(arguments));

            if (result != null)
            {
                return result;
            }

            return
                type
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .FirstOrDefault(m => (m.Name.EndsWith(shortName, StringComparison.Ordinal) ||
                                       m.Name.EndsWith("." + shortName, StringComparison.Ordinal))
                                 && m.GetParameters().Select(p => p.ParameterType).SequenceEqual(arguments));
        }

        /// <summary>
        /// Gets all fields of the type.
        /// </summary>
        /// <param name="t">The type.</param>
        /// <returns>Collection of fields.</returns>
        public static IEnumerable<FieldInfo> GetAllFields(this Type t)
        {
            if (t == null)
            {
                return Enumerable.Empty<FieldInfo>();
            }

            const BindingFlags Flags = 
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly;
            return t
                .GetFields(Flags)
                .Where(f => !f.IsDefined(typeof(CompilerGeneratedAttribute), false))
                .Concat(GetAllFields(t.BaseType));
        }

        /// <summary>
        /// Gets all properties of the type.
        /// </summary>
        /// <param name="t">The type.</param>
        /// <returns>Collection of properties.</returns>
        public static IEnumerable<PropertyInfo> GetAllProperties(this Type t)
        {
            if (t == null)
            {
                return Enumerable.Empty<PropertyInfo>();
            }

            const BindingFlags Flags =
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly;

            return t
                .GetProperties(Flags)
                .Where(p => !p.IsDefined(typeof(CompilerGeneratedAttribute), false)
                            && p.GetIndexParameters().Length == 0)
                .Concat(GetAllProperties(t.BaseType));
        }

        public static IEnumerable<Type> GetAllInterfaces(this Type t)
        {
            foreach (var i in t.GetInterfaces())
            {
                yield return i;
            }
        }

        public static string GetStrippedFullName(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (string.IsNullOrEmpty(type.Namespace))
            {
                return StripAvroNonCompatibleCharacters(type.Name);
            }

            return StripAvroNonCompatibleCharacters(type.Namespace + "." + type.Name);
        }

        public static string StripAvroNonCompatibleCharacters(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return Regex.Replace(value, @"[^A-Za-z0-9_\.]", string.Empty, RegexOptions.None);
        }

        public static bool IsFlagEnum(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return type.GetCustomAttributes(false).ToList().Find(a => a is FlagsAttribute) != null;
        }

        public static bool CanContainNull(this Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            return !type.IsValueType || underlyingType != null;
        }

        public static bool IsKeyValuePair(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);
        }

        public static bool CanBeKnownTypeOf(this Type type, Type baseType)
        {
            return !type.IsAbstract
                   && ! type.IsUnsupported()
                   && (type.IsSubclassOf(baseType) 
                   || type == baseType 
                   || (baseType.IsInterface && baseType.IsAssignableFrom(type))
                   || (baseType.IsGenericType && baseType.IsInterface && baseType.GenericIsAssignable(type)
                           && type.GetGenericArguments()
                                  .Zip(baseType.GetGenericArguments(), (type1, type2) => new Tuple<Type, Type>(type1, type2))
                                  .ToList()
                                  .TrueForAll(tuple => CanBeKnownTypeOf(tuple.Item1, tuple.Item2))));
        }

        internal static bool GenericIsAssignable(this Type type, Type instanceType)
        {
            if (!type.IsGenericType || !instanceType.IsGenericType)
            {
                return false;
            }

            var args = type.GetGenericArguments();
            var typeDefinition = instanceType.GetGenericTypeDefinition();
            var args2 = typeDefinition.GetGenericArguments();
            return args.Any() && args.Length == args2.Length && type.IsAssignableFrom(typeDefinition.MakeGenericType(args));
        }

        public static IEnumerable<Type> GetAllKnownTypes(this Type t)
        {
            if (t == null)
            {
                return Enumerable.Empty<Type>();
            }

            return t.GetCustomAttributes(true)
                .OfType<KnownTypeAttribute>()
                .Select(a => a.Type);
        }

        public static int ReadAllRequiredBytes(this Stream stream, byte[] buffer, int offset, int count)
        {
            int toRead = count;
            int currentOffset = offset;
            int currentRead;
            do
            {
                currentRead = stream.Read(buffer, currentOffset, toRead);
                currentOffset += currentRead;
                toRead -= currentRead;
            }
            while (toRead > 0 && currentRead != 0);
            return currentOffset - offset;
        }

        public static void CheckPropertyGetters(IEnumerable<PropertyInfo> properties)
        {
            var missingGetter = properties.FirstOrDefault(p => p.GetGetMethod(true) == null);
            if (missingGetter != null)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Property '{0}' of class '{1}' does not have a getter.", missingGetter.Name, missingGetter.DeclaringType.FullName));
            }
        }

        public static DataMemberAttribute GetDataMemberAttribute(this PropertyInfo property)
        {
            return property
                .GetCustomAttributes(false)
                .OfType<DataMemberAttribute>()
                .SingleOrDefault();
        }

        public static IList<PropertyInfo> RemoveDuplicates(IEnumerable<PropertyInfo> properties)
        {
            var result = new List<PropertyInfo>();
            foreach (var p in properties)
            {
                if (result.Find(s => s.Name == p.Name) == null)
                {
                    result.Add(p);
                }
            }

            return result;
        }

        /// <summary>
        /// According to Avro, name must:
        ///     start with [A-Za-z_] 
        ///     subsequently contain only [A-Za-z0-9_] 
        /// http://avro.apache.org/docs/current/spec.html#schema_record.
        /// </summary>
        /// <param name="type">
        /// The entity type.
        /// </param>
        /// <returns>
        /// The type name that comply with avro spec.
        /// </returns>
        internal static string AvroSchemaName(this Type type)
        {
            string result = type.Name;
            if (type.IsGenericType)
            {
                result = type.Name + "_" + string.Join("_", type.GetGenericArguments().Select(AvroSchemaName));
            }

            if (type.IsArray)
            {
                Type elementType = type.GetElementType();
                result = elementType.AvroSchemaName() + "__";
            }

            return result.Replace("`1", string.Empty).Replace("`2", string.Empty).Replace("`3", string.Empty);
        }
    }
}
