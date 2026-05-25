// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SqlMISource")]
    public partial class SqlMISource
    {
        /// <summary> Initializes a new instance of <see cref="SqlMISource"/>. </summary>
        public SqlMISource() : base("SqlMISource")
        {
        }
    }
}
