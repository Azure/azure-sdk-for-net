// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the DdosProtectionPlanData type. </summary>
    public partial class DdosProtectionPlanData
    {
        /// <summary> Invokes the base compatibility operation. </summary>
        public DdosProtectionPlanData(AzureLocation location) : base(location)
        {
        }
    }
}
