// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Avs.Models
{
    public partial class AvsHostPatch
    {
        // Customized: use the standard patch-model property name instead of exposing the internal update model name.
        /// <summary> The licenses assigned to the host. </summary>
        [CodeGenMember("HostUpdateLicenses")]
        public IList<HostLicense> Licenses
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new HostUpdateProperties();
                }
                return Properties.Licenses;
            }
        }
    }
}
