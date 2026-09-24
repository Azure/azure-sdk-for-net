// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MultiServiceSharedModels.Combined.Models
{
    // TODO: Remove these suppressions after the fix in Azure/typespec-azure#5517 is released and
    // adopted. The ARM common types v3 projection causes the merged-service model factory to emit
    // invalid global-namespace references for the resource properties models.
    [CodeGenSuppress("VirtualMachineData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(VirtualMachineProperties))]
    [CodeGenSuppress("StorageAccountData", typeof(string), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(StorageAccountProperties))]
    public static partial class ArmMultiServiceSharedModelsCombinedModelFactory
    {
    }
}
