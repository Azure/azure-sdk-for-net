// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Azure.Core
{
    internal static class RequestUriBuilderExtensions
    {
        public static void AppendPath(this RequestUriBuilder builder, bool value, bool escape = false)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, float value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, double value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, int value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, byte[] value, string format, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, IEnumerable<string> value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, DateTimeOffset value, string format, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, TimeSpan value, string format, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, Guid value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendPath(this RequestUriBuilder builder, long value, bool escape = true)
        {
            builder.AppendPath(TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, bool value, bool escape = false)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, float value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, DateTimeOffset value, string format, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, TimeSpan value, string format, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, double value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, decimal value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, int value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, long value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, TimeSpan value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, byte[] value, string format, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value, format), escape);
        }

        public static void AppendQuery(this RequestUriBuilder builder, string name, Guid value, bool escape = true)
        {
            builder.AppendQuery(name, TypeFormatters.ConvertToString(value), escape);
        }

        public static void AppendQueryDelimited<T>(this RequestUriBuilder builder, string name, IEnumerable<T> value, string delimiter, bool escape = true)
        {
            var stringValues = value.Select(v => TypeFormatters.ConvertToString(v));
            builder.AppendQuery(name, string.Join(delimiter, stringValues), escape);
        }

        public static void AppendQueryDelimited<T>(this RequestUriBuilder builder, string name, IEnumerable<T> value, string delimiter, string format, bool escape = true)
        {
            var stringValues = value.Select(v => TypeFormatters.ConvertToString(v, format));
            builder.AppendQuery(name, string.Join(delimiter, stringValues), escape);
        }
    }
}
