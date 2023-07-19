// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Amqp
{
    // WARNING: Consult filter engine owner before modifying this enum.
    // Introducing a new member here has impact to filtering engine in data type precedence and data conversion.
    // ALWAYS insert new types before Unknown!
    internal enum PropertyValueType
    {
        Null,
        Byte, SByte, Char, Int16, UInt16, Int32, UInt32, Int64, UInt64, Single, Double, Decimal, // Numeric types
        Boolean, Guid, String, Uri, DateTime, DateTimeOffset, TimeSpan,
        Stream,
        Unknown,
    }

    internal class SerializationUtilities
    {
        private static readonly Dictionary<Type, PropertyValueType> s_typeToIntMap = new Dictionary<Type, PropertyValueType>
        {
            { typeof(byte), PropertyValueType.Byte },
            { typeof(sbyte), PropertyValueType.SByte },
            { typeof(char), PropertyValueType.Char },
            { typeof(short), PropertyValueType.Int16 },
            { typeof(ushort), PropertyValueType.UInt16 },
            { typeof(int), PropertyValueType.Int32 },
            { typeof(uint), PropertyValueType.UInt32 },
            { typeof(long), PropertyValueType.Int64 },
            { typeof(ulong), PropertyValueType.UInt64 },
            { typeof(float), PropertyValueType.Single },
            { typeof(double), PropertyValueType.Double },
            { typeof(decimal), PropertyValueType.Decimal },
            { typeof(bool), PropertyValueType.Boolean },
            { typeof(Guid), PropertyValueType.Guid },
            { typeof(string), PropertyValueType.String },
            { typeof(Uri), PropertyValueType.Uri },
            { typeof(DateTime), PropertyValueType.DateTime },
            { typeof(DateTimeOffset), PropertyValueType.DateTimeOffset },
            { typeof(TimeSpan), PropertyValueType.TimeSpan },
            ////{ typeof(BufferedInputStream), PropertyValueType.Stream },
        };

        public static PropertyValueType GetTypeId(object value)
        {
            if (value == null)
            {
                return PropertyValueType.Null;
            }

            if (s_typeToIntMap.TryGetValue(value.GetType(), out var propertyValueType))
            {
                return propertyValueType;
            }

            return PropertyValueType.Unknown;
        }

        public static bool IsSupportedPropertyType(Type type)
        {
            return s_typeToIntMap.ContainsKey(type);
        }
    }
}
