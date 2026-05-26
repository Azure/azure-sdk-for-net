// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserve the GA constructor that accepts a Guid VM UUID while the generated model stores the wire value as a string.
    [CodeGenSuppress("OnPremiseResourceDetails", typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("OnPremiseResourceDetails", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(string), typeof(string))]
    public partial class OnPremiseResourceDetails
    {
        /// <summary> Initializes a new instance of <see cref="OnPremiseResourceDetails"/>. </summary>
        /// <param name="workspaceId"> The workspace ID. </param>
        /// <param name="vmUuid"> The VM UUID. </param>
        /// <param name="sourceComputerId"> The source computer ID. </param>
        /// <param name="machineName"> The machine name. </param>
        public OnPremiseResourceDetails(ResourceIdentifier workspaceId, System.Guid vmUuid, string sourceComputerId, string machineName)
            : this(new Source("OnPremise"), null, workspaceId, vmUuid.ToString(), sourceComputerId, machineName)
        {
        }
    }
}
