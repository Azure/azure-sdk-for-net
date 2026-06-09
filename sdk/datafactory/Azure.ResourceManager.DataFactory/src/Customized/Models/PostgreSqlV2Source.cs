// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("PostgreSqlV2Source")]
    public partial class PostgreSqlV2Source
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlV2Source"/>. </summary>
        public PostgreSqlV2Source()
        {
            CopySourceType = "PostgreSqlV2Source";
        }
    }
}
