// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.IotHub.Models
{
    internal partial class PrivateLinkResources
    {
        internal static PrivateLinkResources FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializePrivateLinkResources(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
