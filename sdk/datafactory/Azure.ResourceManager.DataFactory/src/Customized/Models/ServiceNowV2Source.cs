// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("ServiceNowV2Source")]
    public partial class ServiceNowV2Source
    {
        /// <summary> Initializes a new instance of <see cref="ServiceNowV2Source"/>. </summary>
        public ServiceNowV2Source()
        {
            CopySourceType = "ServiceNowV2Source";
        }
    }
}
