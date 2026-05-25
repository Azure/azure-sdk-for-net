// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SqlServerSource")]
    public partial class SqlServerSource
    {
        /// <summary> Initializes a new instance of <see cref="SqlServerSource"/>. </summary>
        public SqlServerSource() : base("SqlServerSource")
        {
        }
    }
}
