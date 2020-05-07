// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Text.Json;

namespace Azure.Data.Tables
{
    internal static class Utf8JsonWriterTableExtensions
    {
        /// <summary>
        /// Writes the appropriate Odata type annotation for a given propertyName value pair.
        /// </summary>
        public static void WriteOdataTypeAnnotation(this Utf8JsonWriter writer, string propertyName, object value)
        {
            switch (value)
            {
                case byte[] _:
                    writer.WriteOdataTypeString(propertyName);
                    writer.WriteStringValue(TableConstants.Odata.EdmBinary);
                    break;
                case long _:
                    writer.WriteOdataTypeString(propertyName);
                    writer.WriteStringValue(TableConstants.Odata.EdmInt64);
                    break;
                case double _:
                    writer.WriteOdataTypeString(propertyName);
                    writer.WriteStringValue(TableConstants.Odata.EdmDouble);
                    break;
                case Guid _:
                    writer.WriteOdataTypeString(propertyName);
                    writer.WriteStringValue(TableConstants.Odata.EdmGuid);
                    break;
                case DateTimeOffset _:
                    writer.WriteOdataTypeString(propertyName);
                    writer.WriteStringValue(TableConstants.Odata.EdmDateTime);
                    break;
                case DateTime _:
                    writer.WriteOdataTypeString(propertyName);
                    writer.WriteStringValue(TableConstants.Odata.EdmDateTime);
                    break;
            }
        }

        private static void WriteOdataTypeString(this Utf8JsonWriter writer, string name)
        {
            writer.WritePropertyName($"{name}{TableConstants.Odata.OdataTypeString}");
        }
    }
}
