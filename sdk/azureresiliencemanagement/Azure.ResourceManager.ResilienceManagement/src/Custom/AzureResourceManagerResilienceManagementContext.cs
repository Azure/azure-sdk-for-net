// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ResilienceManagement
{
    // Register OperationStatusResult (declared in Azure.ResourceManager.Models, not this package)
    // so the AOT-safe ModelReaderWriter.Read<T>(data, options, context) overload can resolve it.
    // The mgmt generator only auto-registers types it itself defined.
    [ModelReaderWriterBuildable(typeof(OperationStatusResult))]
    public partial class AzureResourceManagerResilienceManagementContext
    {
    }
}
