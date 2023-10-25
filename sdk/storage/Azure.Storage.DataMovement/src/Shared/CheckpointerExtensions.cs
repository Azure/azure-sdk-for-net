﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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

        internal static string ToSanitizedString(this Uri uri)
        {
            UriBuilder builder = new(uri);

            // Remove any query parameters (including SAS)
            builder.Query = string.Empty;
            return builder.Uri.AbsoluteUri;
        }
    }
}
