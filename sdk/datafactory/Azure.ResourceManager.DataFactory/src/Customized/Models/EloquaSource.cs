// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("EloquaSource")]
    public partial class EloquaSource
    {
        /// <summary> Initializes a new instance of <see cref="EloquaSource"/>. </summary>
        public EloquaSource() : base("EloquaSource")
        {
        }
    }
}
