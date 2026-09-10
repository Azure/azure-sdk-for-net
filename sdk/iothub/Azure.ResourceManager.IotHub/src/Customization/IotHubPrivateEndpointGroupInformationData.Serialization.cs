// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.IotHub
{
    public partial class IotHubPrivateEndpointGroupInformationData
    {
        internal static IotHubPrivateEndpointGroupInformationData FromResponse(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeIotHubPrivateEndpointGroupInformationData(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
