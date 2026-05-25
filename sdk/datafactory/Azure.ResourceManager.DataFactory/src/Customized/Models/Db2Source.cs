// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Db2Source")]
    public partial class Db2Source
    {
        /// <summary> Initializes a new instance of <see cref="Db2Source"/>. </summary>
        public Db2Source() : base("Db2Source")
        {
        }
    }
}
