// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SalesforceV2Source")]
    public partial class SalesforceV2Source
    {
        /// <summary> Initializes a new instance of <see cref="SalesforceV2Source"/>. </summary>
        public SalesforceV2Source()
        {
            CopySourceType = "SalesforceV2Source";
        }
    }
}
