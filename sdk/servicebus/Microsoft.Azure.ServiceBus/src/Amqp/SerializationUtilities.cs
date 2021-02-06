// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;

    // WARNING: Consult filter engine owner before modifying this enum.
    // Introducing a new member here has impact to filtering engine in data type precedence and data conversion.
    // ALWAYS insert new types before Unknown!
    enum PropertyValueType
    {
        Null,
        Byte, SByte, Char, Int16, UInt16, Int32, UInt32, Int64, UInt64, Single, Double, Decimal, // Numeric types
        Boolean, Guid, String, Uri, DateTime, DateTimeOffset, TimeSpan,
        Stream,
        Unknown,
    }

    class SerializationUtilities
    {
        static readonly Dictionary<Type, PropertyValueType> TypeToIntMap = new Dictionary<Type, PropertyValueType>
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

            if (TypeToIntMap.TryGetValue(value.GetType(), out var propertyValueType))
            {
                return propertyValueType;
            }

            return PropertyValueType.Unknown;
        }

        public static bool IsSupportedPropertyType(Type type)
        {
            return TypeToIntMap.ContainsKey(type);
        }

        public static int GetStringSize(string value)
        {
            return Encoding.UTF8.GetByteCount(value);
        }

        public static byte[] ConvertNativeValueToByteArray(PropertyValueType propertyTypeId, object value)
        {
            switch (propertyTypeId)
            {
                case PropertyValueType.Guid:
                    return ((Guid)value).ToByteArray();

                case PropertyValueType.Boolean:
                    return BitConverter.GetBytes((bool)value);

                case PropertyValueType.Byte:
                    return new byte[] { (byte)value };

                case PropertyValueType.SByte:
                    return new byte[] { unchecked((byte)((sbyte)value)) };

                case PropertyValueType.Char:
                    return BitConverter.GetBytes((char)value);

                case PropertyValueType.TimeSpan:
                    return BitConverter.GetBytes(((TimeSpan)value).Ticks);

                case PropertyValueType.DateTime:
                    return BitConverter.GetBytes(((DateTime)value).ToBinary());

                case PropertyValueType.Double:
                    return BitConverter.GetBytes((double)value);

                case PropertyValueType.Single:
                    return BitConverter.GetBytes((float)value);

                case PropertyValueType.Int32:
                    return BitConverter.GetBytes((int)value);

                case PropertyValueType.Int64:
                    return BitConverter.GetBytes((long)value);

                case PropertyValueType.Int16:
                    return BitConverter.GetBytes((short)value);

                case PropertyValueType.UInt32:
                    return BitConverter.GetBytes((uint)value);

                case PropertyValueType.UInt64:
                    return BitConverter.GetBytes((ulong)value);

                case PropertyValueType.UInt16:
                    return BitConverter.GetBytes((ushort)value);

                case PropertyValueType.String:
                    return Encoding.UTF8.GetBytes((string)value);

                case PropertyValueType.Uri:
                    return Encoding.UTF8.GetBytes(value.ToString());

                case PropertyValueType.DateTimeOffset:
                    DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
                    byte[] dateTimeTicks = BitConverter.GetBytes(dateTimeOffset.Ticks);
                    byte[] offsetTicks = BitConverter.GetBytes(dateTimeOffset.Offset.Ticks);
                    byte[] dateTimeOffsetBytes = new byte[16];
                    Buffer.BlockCopy(dateTimeTicks, 0, dateTimeOffsetBytes, 0, 8);
                    Buffer.BlockCopy(offsetTicks, 0, dateTimeOffsetBytes, 8, 8);

                    return dateTimeOffsetBytes;

                case PropertyValueType.Decimal:
                    int[] bits = decimal.GetBits((decimal)value);

                    byte[] lowBytes = BitConverter.GetBytes(bits[0]);
                    byte[] midBytes = BitConverter.GetBytes(bits[1]);
                    byte[] highBytes = BitConverter.GetBytes(bits[2]);
                    byte[] flagsBytes = BitConverter.GetBytes(bits[3]);

                    byte[] decimalBytes = new byte[16];
                    Buffer.BlockCopy(lowBytes, 0, decimalBytes, 0, 4);
                    Buffer.BlockCopy(midBytes, 0, decimalBytes, 4, 4);
                    Buffer.BlockCopy(highBytes, 0, decimalBytes, 8, 4);
                    Buffer.BlockCopy(flagsBytes, 0, decimalBytes, 12, 4);

                    return decimalBytes;

                default:
                    throw new SerializationException(string.Format("Serialization operation failed due to unsupported type {0}.", value.GetType().FullName));
            }
        }

    }
}