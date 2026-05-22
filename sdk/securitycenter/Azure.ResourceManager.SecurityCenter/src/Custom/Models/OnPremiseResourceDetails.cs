// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Suppress duplicate generated constructors and restore the legacy constructor shape.
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
