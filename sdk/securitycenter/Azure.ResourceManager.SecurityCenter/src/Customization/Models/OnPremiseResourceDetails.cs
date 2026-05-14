// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Suppress a duplicate public constructor and bridge OnPremiseSqlResourceDetails' discriminator constructor order.
    [CodeGenSuppress("OnPremiseResourceDetails", typeof(string), typeof(string), typeof(string), typeof(string))]
    [CodeGenSuppress("OnPremiseResourceDetails", typeof(Azure.Core.ResourceIdentifier), typeof(string), typeof(string), typeof(string))]
    public partial class OnPremiseResourceDetails
    {
        /// <summary> Initializes a new instance of <see cref="OnPremiseResourceDetails"/>. </summary>
        /// <param name="source"> The source of the resource details. </param>
        /// <param name="workspaceId"> The workspace ID. </param>
        /// <param name="vmuuid"> The VM UUID. </param>
        /// <param name="sourceComputerId"> The source computer ID. </param>
        /// <param name="machineName"> The machine name. </param>
        protected internal OnPremiseResourceDetails(string source, string workspaceId, string vmuuid, string sourceComputerId, string machineName)
            : this(new Source(source), null, null, null, new Azure.Core.ResourceIdentifier(workspaceId), vmuuid, sourceComputerId, machineName)
        {
        }
    }
}
