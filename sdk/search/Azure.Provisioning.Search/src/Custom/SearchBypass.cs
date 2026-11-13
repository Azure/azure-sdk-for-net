// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Search
{
    // Preserve enum compatibility until the generator can append compatibility values.
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/60442
    /// <summary> Possible origins of inbound traffic that can bypass the rules defined in the IP rules section. </summary>
    [CodeGenType("SearchBypass")]
    public enum SearchBypass
    {
        /// <summary> No origin can bypass the configured IP rules. </summary>
        None,
        /// <summary> Requests originating from the Azure portal can bypass the configured IP rules. </summary>
        AzurePortal,
        /// <summary> Requests originating from Azure trusted services can bypass the configured IP rules. </summary>
        AzureServices,
    }
}
