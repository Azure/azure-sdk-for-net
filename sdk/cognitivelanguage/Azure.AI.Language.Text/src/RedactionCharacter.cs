// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.Text
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("Equals")]
    public readonly partial struct RedactionCharacter
    {
        /// <summary> Equals sign character. </summary>
        public static RedactionCharacter EqualsSign { get; } = new RedactionCharacter(EqualsValue);
    }
}
