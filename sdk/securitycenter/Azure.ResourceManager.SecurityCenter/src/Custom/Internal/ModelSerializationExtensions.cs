// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    internal static partial class ModelSerializationExtensions
    {
        public static void WriteObjectValue(this Utf8JsonWriter writer, OfferingType value, ModelReaderWriterOptions options = null)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
