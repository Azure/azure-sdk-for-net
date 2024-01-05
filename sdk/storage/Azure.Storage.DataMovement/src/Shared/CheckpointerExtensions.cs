// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal static partial class CheckpointerExtensions
    {
        public static string ToString(this byte[] bytes, long length)
        {
            return Encoding.UTF8.GetString(bytes, 0, (int)length);
        }

        public static long ToLong(this byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0);
        }

        public static ushort ToUShort(this byte[] bytes)
        {
            return BitConverter.ToUInt16(bytes, 0);
        }

        internal static IDictionary<string, string> ToDictionary(this string str, string elementName)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] splitSemiColon = str.Split(';');
            foreach (string value in splitSemiColon)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] splitEqual = value.Split('=');
                    if (splitEqual.Length != 2)
                    {
                        throw Errors.InvalidStringToDictionary(elementName, str);
                    }
                    dictionary.Add(splitEqual[0], splitEqual[1]);
                }
            }
            return dictionary;
        }

        internal static string DictionaryToString(this IDictionary<string, string> dict)
        {
            string concatStr = "";
            foreach (KeyValuePair<string, string> kv in dict)
            {
                // e.g. store like "header=value;"
                concatStr = string.Concat(concatStr, $"{kv.Key}={kv.Value};");
            }
            return concatStr;
        }

        /// <summary>
        /// Writes the given length and offset and increments currentOffset accordingly.
        /// </summary>
        internal static void WriteVariableLengthFieldInfo(
            this BinaryWriter writer,
            int length,
            ref int currentOffset)
        {
            // Write the offset, -1 if size is 0
            if (length > 0)
            {
                writer.Write(currentOffset);
                currentOffset += length;
            }
            else
            {
                writer.Write(-1);
            }

            // Write the length
            writer.Write(length);
        }

        /// <summary>
        /// Reads a length and offset pair.
        /// </summary>
        internal static (int Offset, int Length) ReadVariableLengthFieldInfo(this BinaryReader reader)
        {
            return (reader.ReadInt32(), reader.ReadInt32());
        }

        internal static void WritePaddedString(this BinaryWriter writer, string value, int setSizeInBytes)
        {
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);
            writer.Write(valueBytes);

            int padding = setSizeInBytes - valueBytes.Length;
            if (padding > 0)
            {
                char[] paddingArray = new char[padding];
                writer.Write(paddingArray);
            }
        }

        /// <summary>
        /// Writes a boolean plus int32 to represent a nulable int.
        /// </summary>
        internal static void Write(this BinaryWriter writer, int? value)
        {
            writer.Write(value.HasValue);
            writer.Write(value ?? 0);
        }

        /// <summary>
        /// Reads a boolean plus int32 as a nullable int.
        /// </summary>
        internal static int? ReadNullableInt32(this BinaryReader reader)
        {
            bool hasValue = reader.ReadBoolean();
            int value = reader.ReadInt32();
            return hasValue ? value : default;
        }

        /// <summary>
        /// Writes a boolean plus int64 to represent a nulable long.
        /// </summary>
        internal static void Write(this BinaryWriter writer, long? value)
        {
            writer.Write(value.HasValue);
            writer.Write(value ?? 0L);
        }

        /// <summary>
        /// Reads a boolean plus int64 as a nullable long.
        /// </summary>
        internal static long? ReadNullableInt64(this BinaryReader reader)
        {
            bool hasValue = reader.ReadBoolean();
            long value = reader.ReadInt64();
            return hasValue ? value : default;
        }

        /// <summary>
        /// Writes a boolean plus two int64s to represent a nullable DateTimeOffset.
        /// The first long is datetime ticks and the second is offset ticks.
        /// </summary>
        internal static void Write(this BinaryWriter writer, DateTimeOffset? value)
        {
            writer.Write(value.HasValue);
            writer.Write(value?.Ticks ?? 0L);
            writer.Write(value?.Offset.Ticks ?? 0L);
        }

        /// <summary>
        /// Reads a boolean plus two int64s as a nullable DateTimeOffset.
        /// The first long is datetime ticks and the second is offset ticks.
        /// </summary>
        internal static DateTimeOffset? ReadNullableDateTimeOffset(this BinaryReader reader)
        {
            bool hasValue = reader.ReadBoolean();
            long valueTicks = reader.ReadInt64();
            long valueOffsetTicks = reader.ReadInt64();
            return hasValue ? new DateTimeOffset(valueTicks, new TimeSpan(valueOffsetTicks)) : default;
        }

        internal static string ReadPaddedString(this BinaryReader reader, int numBytes)
        {
            byte[] stringBytes = reader.ReadBytes(numBytes);
            return stringBytes.ToString(numBytes).TrimEnd('\0');
        }

        internal static string ToSanitizedString(this Uri uri)
        {
            UriBuilder builder = new(uri);

            // Remove any query parameters (including SAS)
            builder.Query = string.Empty;
            return builder.Uri.AbsoluteUri;
        }
    }
}
