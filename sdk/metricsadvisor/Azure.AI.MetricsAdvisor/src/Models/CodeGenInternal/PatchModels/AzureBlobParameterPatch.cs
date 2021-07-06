// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class AzureBlobParameterPatch
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullStringValue("connectionString", ConnectionString);
            writer.WriteNullStringValue("container", Container);
            writer.WriteNullStringValue("blobTemplate", BlobTemplate);
            writer.WriteEndObject();
        }
    }
}
