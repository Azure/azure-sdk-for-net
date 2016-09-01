// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    // WARNING: Consult filter engine owner before modifying this enum.
    // Introducing a new member here has impact to filtering engine in data type precedence and data conversion.
    // ALWASYS insert new types before Unknown!
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
        const int ShortSize = 2;
        const int IntSize = 4;
        const int LongSize = 8;
        const int TimeSpanSize = 8;
        const int DateTimeSize = 8;
        const int GuidSize = 16;
        const int BooleanSize = 1;

        readonly static Dictionary<Type, PropertyValueType> typeToIntMap = new Dictionary<Type, PropertyValueType>
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

            PropertyValueType typeId;
            if (typeToIntMap.TryGetValue(value.GetType(), out typeId))
            {
                return typeId;
            }

            return PropertyValueType.Unknown;
        }

        public static byte[] ConvertNativeValueToByteArray(int messageVersion, PropertyValueType propertyTypeId, object value)
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
                    if (messageVersion >= BrokeredMessage.MessageVersion3)
                    {
                        return BitConverter.GetBytes(((TimeSpan)value).Ticks);
                    }
                    else
                    {
                        return BitConverter.GetBytes(((TimeSpan)value).TotalMilliseconds);
                    }

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
                    if (messageVersion >= BrokeredMessage.MessageVersion3)
                    {
                        DateTimeOffset dateTimeOffset = (DateTimeOffset)value;
                        byte[] dateTimeTicks = BitConverter.GetBytes(dateTimeOffset.Ticks);
                        byte[] offsetTicks = BitConverter.GetBytes(dateTimeOffset.Offset.Ticks);
                        byte[] dateTimeOffsetBytes = new byte[16];
                        Buffer.BlockCopy(dateTimeTicks, 0, dateTimeOffsetBytes, 0, 8);
                        Buffer.BlockCopy(offsetTicks, 0, dateTimeOffsetBytes, 8, 8);

                        return dateTimeOffsetBytes;
                    }
                    else
                    {
                        return Encoding.UTF8.GetBytes(XmlConvert.ToString((DateTimeOffset)value));
                    }

                case PropertyValueType.Decimal:
                    if (messageVersion >= BrokeredMessage.MessageVersion3)
                    {
                        int[] bits = decimal.GetBits((decimal)value);

                        byte[] loBytes = BitConverter.GetBytes(bits[0]);
                        byte[] midBytes = BitConverter.GetBytes(bits[1]);
                        byte[] hiBytes = BitConverter.GetBytes(bits[2]);
                        byte[] flagsBytes = BitConverter.GetBytes(bits[3]);

                        byte[] decimalBytes = new byte[16];
                        Buffer.BlockCopy(loBytes, 0, decimalBytes, 0, 4);
                        Buffer.BlockCopy(midBytes, 0, decimalBytes, 4, 4);
                        Buffer.BlockCopy(hiBytes, 0, decimalBytes, 8, 4);
                        Buffer.BlockCopy(flagsBytes, 0, decimalBytes, 12, 4);

                        return decimalBytes;
                    }
                    else
                    {
                        return Encoding.UTF8.GetBytes(XmlConvert.ToString((decimal)value));
                    }

                case PropertyValueType.Stream:
                    BufferedInputStream inputStream = value as BufferedInputStream;
                    if (inputStream != null)
                    {
                        long bufferSize = inputStream.Length;
                        byte[] buffer = new byte[bufferSize];

                        inputStream.Position = 0;
                        inputStream.Read(buffer, 0, (int)bufferSize);

                        return buffer;
                    }
                    else
                    {
                        //TODO: throw FxTrace.Exception.AsError(new NotImplementedException());
                        throw new NotImplementedException();
                       
                    }

                default:
                    //TODO: throw FxTrace.Exception.AsError(new SerializationException(SRClient.FailedToSerializeUnsupportedType(value.GetType().FullName)));
                    throw new SerializationException(value.GetType().FullName);
            }
        }

        public static object ConvertByteArrayToNativeValue(int messageVersion, PropertyValueType propertyTypeId, byte[] bytes)
        {
            switch (propertyTypeId)
            {
                case PropertyValueType.Guid:
                    return new Guid(bytes);

                case PropertyValueType.Boolean:
                    return BitConverter.ToBoolean(bytes, 0);

                case PropertyValueType.Byte:
                    return bytes[0];

                case PropertyValueType.SByte:
                    return unchecked((sbyte)bytes[0]);

                case PropertyValueType.Char:
                    return BitConverter.ToChar(bytes, 0);

                case PropertyValueType.TimeSpan:
                    if (messageVersion >= BrokeredMessage.MessageVersion3)
                    {
                        long ticks = BitConverter.ToInt64(bytes, 0);
                        return TimeSpan.FromTicks(ticks);
                    }
                    else
                    {
                        double dval = BitConverter.ToDouble(bytes, 0);
                        if (dval.CompareTo(TimeSpan.MaxValue.TotalMilliseconds) == 0)
                        {
                            return TimeSpan.MaxValue;
                        }
                        else
                        {
                            return TimeSpan.FromMilliseconds(dval);
                        }
                    }

                case PropertyValueType.DateTime:
                    return DateTime.FromBinary(BitConverter.ToInt64(bytes, 0));

                case PropertyValueType.Double:
                    return BitConverter.ToDouble(bytes, 0);

                case PropertyValueType.Single:
                    return BitConverter.ToSingle(bytes, 0);

                case PropertyValueType.Int32:
                    return BitConverter.ToInt32(bytes, 0);

                case PropertyValueType.Int64:
                    return BitConverter.ToInt64(bytes, 0);

                case PropertyValueType.Int16:
                    return BitConverter.ToInt16(bytes, 0);

                case PropertyValueType.UInt32:
                    return BitConverter.ToUInt32(bytes, 0);

                case PropertyValueType.UInt64:
                    return BitConverter.ToUInt64(bytes, 0);

                case PropertyValueType.UInt16:
                    return BitConverter.ToUInt16(bytes, 0);

                case PropertyValueType.String:
                    return Encoding.UTF8.GetString(bytes);

                case PropertyValueType.Uri:
                    return new Uri(Encoding.UTF8.GetString(bytes));

                case PropertyValueType.DateTimeOffset:
                    if (messageVersion >= BrokeredMessage.MessageVersion3)
                    {
                        long dateTicks = BitConverter.ToInt64(bytes, 0);
                        long offsetTicks = BitConverter.ToInt64(bytes, 8);

                        return new DateTimeOffset(dateTicks, TimeSpan.FromTicks(offsetTicks));
                    }
                    else
                    {
                        return XmlConvert.ToDateTimeOffset(Encoding.UTF8.GetString(bytes));
                    }

                case PropertyValueType.Decimal:
                    if (messageVersion >= BrokeredMessage.MessageVersion3)
                    {
                        int[] bits = new int[4];
                        bits[0] = BitConverter.ToInt32(bytes, 0);
                        bits[1] = BitConverter.ToInt32(bytes, 4);
                        bits[2] = BitConverter.ToInt32(bytes, 8);
                        bits[3] = BitConverter.ToInt32(bytes, 12);

                        return new Decimal(bits);
                    }
                    else
                    {
                        return XmlConvert.ToDecimal(Encoding.UTF8.GetString(bytes));
                    }

                case PropertyValueType.Stream:
                    InternalBufferManager bufferManager = ThrottledBufferManager.GetBufferManager();
                    int length = bytes.Length;
                    byte[] buffer = bufferManager.TakeBuffer(length);
                    Buffer.BlockCopy(bytes, 0, buffer, 0, length);
                    BufferedInputStream inputStream = new BufferedInputStream(buffer, length, bufferManager);
                    return inputStream;

                case PropertyValueType.Null:
                    return null;

                default:
                    //throw Fx.Exception.AsError(new SerializationException(SRClient.FailedToDeserializeUnsupportedProperty(propertyTypeId.ToString())));
                    throw new SerializationException("FailedToDeserializeUnsupportedProperty");
            }
        }

        public static int GetStringSize(string value)
        {
            return Encoding.UTF8.GetByteCount(value);
        }

        public static int GetTimeSpanSize(TimeSpan value)
        {
            return SerializationUtilities.TimeSpanSize;
        }

        public static int GetDateTimeSize(DateTime value)
        {
            return SerializationUtilities.DateTimeSize;
        }

        public static int GetLongSize(long value)
        {
            return SerializationUtilities.LongSize;
        }

        public static int GetGuidSize(Guid value)
        {
            return SerializationUtilities.GuidSize;
        }

        public static int GetIntSize(int value)
        {
            return SerializationUtilities.IntSize;
        }

        public static int GetShortSize(short value)
        {
            return SerializationUtilities.ShortSize;
        }

        public static int GetStreamSize(Stream value)
        {
            return value.CanSeek ? (int)value.Length : int.MaxValue;
        }

        public static int GetBooleanSize(bool value)
        {
            return SerializationUtilities.BooleanSize;
        }

        public static byte[] ReadBytes(XmlReader reader, int bytesToRead)
        {
            byte[] bytes = new byte[bytesToRead];
            int bytesRead = 0;

            while (bytesRead < bytesToRead)
            {
                int lastReadCount = reader.ReadContentAsBase64(bytes, bytesRead, bytes.Length - bytesRead);
                bytesRead += lastReadCount;
                if (lastReadCount == 0)
                {
                    break;
                }
            }

            if (bytesRead < bytesToRead)
            {
                throw Fx.Exception.AsError(new InvalidOperationException("Insufficient data in the byte-stream"));
            }

            return bytes;
        }
    }
}
