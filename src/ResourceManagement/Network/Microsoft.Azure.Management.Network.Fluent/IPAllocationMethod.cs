// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for IPAllocationMethod.
    /// </summary>
    public class IPAllocationMethod : ExpandableStringEnum<IPAllocationMethod>
    {
        public static readonly IPAllocationMethod Static = new IPAllocationMethod() { Value = "Static" };
        public static readonly IPAllocationMethod Dynamic = new IPAllocationMethod() { Value = "Dynamic" };
    }
}
