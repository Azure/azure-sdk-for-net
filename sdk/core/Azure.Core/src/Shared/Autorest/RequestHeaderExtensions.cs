// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Globalization;

namespace Azure.Core
{
    internal static class RequestHeaderExtensions
    {
        public static void Add(this RequestHeaders headers, string name, bool value)
        {
            headers.Add(name, TypeFormatters.ToString(value));
        }

        public static void Add(this RequestHeaders headers, string name, float value)
        {
            headers.Add(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));
        }

        public static void Add(this RequestHeaders headers, string name, double value)
        {
            headers.Add(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));
        }

        public static void Add(this RequestHeaders headers, string name, int value)
        {
            headers.Add(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));
        }

        public static void Add(this RequestHeaders headers, string name, DateTimeOffset value, string format)
        {
            headers.Add(name, TypeFormatters.ToString(value, format));
        }

        public static void Add(this RequestHeaders headers, string name, TimeSpan value, string format)
        {
            headers.Add(name, TypeFormatters.ToString(value, format));
        }

        public static void Add(this RequestHeaders headers, string name, byte[] value)
        {
            headers.Add(name, Convert.ToBase64String(value));
        }

        public static void Add<T>(this RequestHeaders headers, string name, T value) where T: struct
        {
            headers.Add(name, value.ToString()!);
        }
    }
}
