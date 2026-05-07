// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Text
{
    [CodeGenSuppress("Equals")]
    public readonly partial struct RedactionCharacter
    {
        /// <summary> Equals sign character. </summary>
        public static RedactionCharacter EqualsSign { get; } = new RedactionCharacter(EqualsValue);
    }
}
