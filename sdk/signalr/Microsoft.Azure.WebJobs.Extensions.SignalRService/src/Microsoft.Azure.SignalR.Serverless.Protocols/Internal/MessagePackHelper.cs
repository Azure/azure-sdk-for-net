// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using MessagePack;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    internal class MessagePackHelper
    {
        public static void SkipHeaders(byte[] input, ref int offset)
        {
            var headerCount = ReadMapLength(input, ref offset, "headers");
            if (headerCount > 0)
            {
                for (var i = 0; i < headerCount; i++)
                {
                    ReadString(input, ref offset, $"headers[{i}].Key");
                    ReadString(input, ref offset, $"headers[{i}].Value");
                }
            }
        }

        public static string ReadInvocationId(byte[] input, ref int offset)
        {
            return ReadString(input, ref offset, "invocationId");
        }

        public static string ReadTarget(byte[] input, ref int offset)
        {
            return ReadString(input, ref offset, "target");
        }

        public static object[] ReadArguments(byte[] input, ref int offset)
        {
            var argumentCount = ReadArrayLength(input, ref offset, "arguments");
            var array = new object[argumentCount];
            for (int i = 0; i < argumentCount; i++)
            {
                array[i] = ReadObject(input, ref offset);
            }
            return array;
        }

        public static int ReadInt32(byte[] input, ref int offset, string field)
        {
            Exception msgPackException = null;
            try
            {
                var readInt = MessagePackBinary.ReadInt32(input, offset, out var readSize);
                offset += readSize;
                return readInt;
            }
            catch (Exception e)
            {
                msgPackException = e;
            }

            throw new InvalidDataException($"Reading '{field}' as Int32 failed.", msgPackException);
        }

        public static string ReadString(byte[] input, ref int offset, string field)
        {
            Exception msgPackException = null;
            try
            {
                var readString = MessagePackBinary.ReadString(input, offset, out var readSize);
                offset += readSize;
                return readString;
            }
            catch (Exception e)
            {
                msgPackException = e;
            }

            throw new InvalidDataException($"Reading '{field}' as String failed.", msgPackException);
        }

        public static bool ReadBoolean(byte[] input, ref int offset, string field)
        {
            Exception msgPackException = null;
            try
            {
                var readBool = MessagePackBinary.ReadBoolean(input, offset, out var readSize);
                offset += readSize;
                return readBool;
            }
            catch (Exception e)
            {
                msgPackException = e;
            }

            throw new InvalidDataException($"Reading '{field}' as Boolean failed.", msgPackException);
        }

        public static long ReadMapLength(byte[] input, ref int offset, string field)
        {
            Exception msgPackException = null;
            try
            {
                var readMap = MessagePackBinary.ReadMapHeader(input, offset, out var readSize);
                offset += readSize;
                return readMap;
            }
            catch (Exception e)
            {
                msgPackException = e;
            }

            throw new InvalidDataException($"Reading map length for '{field}' failed.", msgPackException);
        }

        public static long ReadArrayLength(byte[] input, ref int offset, string field)
        {
            Exception msgPackException = null;
            try
            {
                var readArray = MessagePackBinary.ReadArrayHeader(input, offset, out var readSize);
                offset += readSize;
                return readArray;
            }
            catch (Exception e)
            {
                msgPackException = e;
            }

            throw new InvalidDataException($"Reading array length for '{field}' failed.", msgPackException);
        }

        public static object ReadObject(byte[] input, ref int offset)
        {
            var type = MessagePackBinary.GetMessagePackType(input, offset);
            int size;
            switch (type)
            {
                case MessagePackType.Integer:
                    var intValue = MessagePackBinary.ReadInt64(input, offset, out size);
                    offset += size;
                    return intValue;
                case MessagePackType.Nil:
                    MessagePackBinary.ReadNil(input, offset, out size);
                    offset += size;
                    return null;
                case MessagePackType.Boolean:
                    var boolValue = MessagePackBinary.ReadBoolean(input, offset, out size);
                    offset += size;
                    return boolValue;
                case MessagePackType.Float:
                    var doubleValue = MessagePackBinary.ReadDouble(input, offset, out size);
                    offset += size;
                    return doubleValue;
                case MessagePackType.String:
                    var textValue = MessagePackBinary.ReadString(input, offset, out size);
                    offset += size;
                    return textValue;
                case MessagePackType.Binary:
                    var binaryValue = MessagePackBinary.ReadBytes(input, offset, out size);
                    offset += size;
                    return binaryValue;
                case MessagePackType.Array:
                    var argumentCount = ReadArrayLength(input, ref offset, "arguments");
                    var array = new object[argumentCount];
                    for (int i = 0; i < argumentCount; i++)
                    {
                        array[i] = ReadObject(input, ref offset);
                    }
                    return array;
                case MessagePackType.Map:
                    var propertyCount = MessagePackBinary.ReadMapHeader(input, offset, out size);
                    offset += size;
                    var map = new Dictionary<string, object>();
                    for (int i = 0; i < propertyCount; i++)
                    {
                        textValue = MessagePackBinary.ReadString(input, offset, out size);
                        offset += size;
                        var value = ReadObject(input, ref offset);
                        map[textValue] = value;
                    }
                    return map;
                case MessagePackType.Extension:
                case MessagePackType.Unknown:
                default:
                    return null;
            }
        }
    }
}