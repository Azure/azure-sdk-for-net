// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class AzureDataLakeStorageGen2ParameterPatch
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullObjectValue("accountName", AccountName);
            if (Optional.IsDefined(AccountKey))
            {
                writer.WritePropertyName("accountKey");
                writer.WriteStringValue(AccountKey);
            }
            writer.WriteNullObjectValue("fileSystemName", FileSystemName);
            writer.WriteNullObjectValue("directoryTemplate", DirectoryTemplate);
            writer.WriteNullObjectValue("fileTemplate", FileTemplate);
            writer.WriteEndObject();
        }
    }
}
