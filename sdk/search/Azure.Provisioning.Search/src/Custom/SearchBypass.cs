// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Search
{
    // Preserve enum compatibility until the generator can append compatibility values.
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/60442
    [CodeGenType("SearchBypass")]
    public enum SearchBypass
    {
        None,
        AzurePortal,
        AzureServices,
    }
}
