// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Language.Conversations.Models
{
    public readonly partial struct RedactionCharacter
    {
        /// <summary> Equals sign character. </summary>
        [CodeGenMember("Equals")]
        public static RedactionCharacter EqualsSign { get; } = new RedactionCharacter(EqualsValue);
    }
}
