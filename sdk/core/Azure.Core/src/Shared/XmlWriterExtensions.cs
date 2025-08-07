// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Xml;

namespace Azure.Core
{
    internal static class XmlWriterExtensions
    {
        public static void WriteObjectValue(this XmlWriter writer, object value, string? nameHint)
        {
            switch (value)
            {
                case IXmlSerializable serializable:
                    serializable.Write(writer, nameHint);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void WriteValue(this XmlWriter writer, DateTimeOffset value, string format) =>
            writer.WriteValue(TypeFormatters.ToString(value, format));

        public static void WriteValue(this XmlWriter writer, TimeSpan value, string format) =>
            writer.WriteValue(TypeFormatters.ToString(value, format));

        public static void WriteValue(this XmlWriter writer, byte[] value, string format)
        {
            writer.WriteValue(TypeFormatters.ToString(value, format));
        }
    }
}
