// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AmazonRdsForSqlServerSource")]
    public partial class AmazonRdsForSqlServerSource
    {
        /// <summary> Initializes a new instance of <see cref="AmazonRdsForSqlServerSource"/>. </summary>
        public AmazonRdsForSqlServerSource()
        {
            CopySourceType = "AmazonRdsForSqlServerSource";
        }
    }
}
