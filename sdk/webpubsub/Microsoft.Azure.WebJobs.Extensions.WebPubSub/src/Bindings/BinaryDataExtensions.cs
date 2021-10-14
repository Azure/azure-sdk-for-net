// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Newtonsoft.Json.Linq;

namespace System
{
    internal static class BinaryDataExtensions
    {
        public static object Convert(this BinaryData message, Type targetType)
        {
            if (targetType == typeof(JObject))
            {
                return JObject.FromObject(message.ToArray());
            }

            if (targetType == typeof(Stream))
            {
                return message.ToStream();
            }

            if (targetType == typeof(byte[]))
            {
                return message.ToArray();
            }

            if (targetType == typeof(string))
            {
                return message.ToString();
            }

            if (targetType == typeof(BinaryData))
            {
                return message;
            }

            return null;
        }
    }
}
