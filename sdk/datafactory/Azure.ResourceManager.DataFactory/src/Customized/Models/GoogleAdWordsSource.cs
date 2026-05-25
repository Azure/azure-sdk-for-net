// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Restores the correct leaf discriminator dropped by MPG generator (issue #59298).

#nullable disable

namespace Azure.ResourceManager.DataFactory.Models
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GoogleAdWordsSource")]
    public partial class GoogleAdWordsSource
    {
        /// <summary> Initializes a new instance of <see cref="GoogleAdWordsSource"/>. </summary>
        public GoogleAdWordsSource() : base("GoogleAdWordsSource")
        {
        }
    }
}
