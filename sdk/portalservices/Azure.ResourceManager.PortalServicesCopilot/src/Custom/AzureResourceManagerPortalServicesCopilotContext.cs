// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.PortalServicesCopilot
{
    [ModelReaderWriterBuildable(typeof(ResponseError))]
    [ModelReaderWriterBuildable(typeof(SystemData))]
    public partial class AzureResourceManagerPortalServicesCopilotContext
    {
    }
}
