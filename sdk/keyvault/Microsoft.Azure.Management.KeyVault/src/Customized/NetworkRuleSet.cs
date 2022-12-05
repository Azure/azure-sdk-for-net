// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.KeyVault.Models
{
    /// <summary>
    /// A set of rules governing the network accessibility of a vault.
    /// </summary>
    public partial class NetworkRuleSet
    {
        public static readonly string BypassOptionAzureServices = "AzureServices";
        public static readonly string DefaultActionOptionAllow = "Allow";

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit()
        {
            Bypass = Bypass ?? NetworkRuleSet.BypassOptionAzureServices;
            DefaultAction = DefaultAction ?? NetworkRuleSet.DefaultActionOptionAllow;

            // default values for properties IpRules and VirtualNetworkRules are 'null'
            // and so no explicit customization is necessary.
        }
    }
}