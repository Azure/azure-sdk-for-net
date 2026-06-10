// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Search
{
    /// <summary> Possible origins of inbound traffic that can bypass the rules defined in the 'ipRules' section. </summary>
    public enum SearchBypass
    {
        /// <summary> Indicates that no origin can bypass the rules defined in the 'ipRules' section. This is the default. </summary>
        None,
        /// <summary> Indicates that requests originating from the Azure portal can bypass the rules defined in the 'ipRules' section. </summary>
        AzurePortal,
        /// <summary> Indicates that requests originating from Azure trusted services can bypass the rules defined in the 'ipRules' section. </summary>
        AzureServices,
    }
}
