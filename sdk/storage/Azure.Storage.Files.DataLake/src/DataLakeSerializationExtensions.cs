// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    /// <summary>
    /// These extension methods are generated from swagger schema.
    /// Please use https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/template/Azure.Template
    /// to generate this code until new generator fully supports storage sdk.
    /// </summary>
    internal static partial class DataLakeSerializationExtensions
    {
        internal static SetAccessControlRecursiveResponse DeserializeSetAccessControlRecursiveResponse(this JsonElement element)
        {
            SetAccessControlRecursiveResponse result = new SetAccessControlRecursiveResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("directoriesSuccessful"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DirectoriesSuccessful = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("filesSuccessful"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.FilesSuccessful = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failureCount"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.FailureCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedEntries"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    var failedEntries = new List<AclFailedEntry>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        failedEntries.Add(item.DeserializeAclFailedEntry());
                    }
                    result.FailedEntries = failedEntries;
                    continue;
                }
            }
            return result;
        }

        internal static AclFailedEntry DeserializeAclFailedEntry(this JsonElement element)
        {
            AclFailedEntry result = new AclFailedEntry();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errorMessage"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ErrorMessage = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
