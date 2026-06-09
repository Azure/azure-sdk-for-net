// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GoogleBigQueryV2Source")]
    public partial class GoogleBigQueryV2Source
    {
        /// <summary> Initializes a new instance of <see cref="GoogleBigQueryV2Source"/>. </summary>
        public GoogleBigQueryV2Source()
        {
            CopySourceType = "GoogleBigQueryV2Source";
        }
    }
}
