// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using Newtonsoft.Json.Linq;

namespace System
{
    internal static class BinaryDataExtensions
    {
        public static object Convert(this BinaryData data, Type targetType)
        {
            if (targetType == typeof(JObject))
            {
                return JObject.FromObject(data.ToArray());
            }

            if (targetType == typeof(Stream))
            {
                return data.ToStream();
            }

            if (targetType == typeof(byte[]))
            {
                return data.ToArray();
            }

            if (targetType == typeof(string))
            {
                return data.ToString();
            }

            if (targetType == typeof(BinaryData))
            {
                return data;
            }

            return null;
        }
    }
}
