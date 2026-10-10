// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Cdn
{
    public partial class CdnOrigin
    {
        // Replace the duplicated flattened property until model-property flattening is fixed.
        /// <summary> Gets or sets the HostName. </summary>
        [CodeGenMember("HostName")]
        public BicepValue<string> HostName
        {
            get
            {
                return Properties is null ? default : Properties.HostName;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new OriginProperties();
                }
                Properties.HostName = value;
            }
        }
    }
}
