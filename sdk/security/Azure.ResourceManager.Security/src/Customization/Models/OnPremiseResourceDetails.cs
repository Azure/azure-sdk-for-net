// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security.Models
{
    [CodeGenSuppress("OnPremiseResourceDetails", typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class OnPremiseResourceDetails
    {
        protected internal OnPremiseResourceDetails(string source, string workspaceId, string vmuuid, string sourceComputerId, string machineName)
            : this(new Source(source), null, null, null, workspaceId, vmuuid, sourceComputerId, machineName)
        {
        }
    }
}
