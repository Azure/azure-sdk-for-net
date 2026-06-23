// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds a parameterless constructor to the FrontDoorSecretProperties abstract base class for backward API compatibility with the previous SDK.
    // Reason: The TypeSpec generator produces a protected constructor with a discriminator parameter (typeName) for polymorphic base classes,
    // but the old SDK provided a parameterless protected constructor. Derived classes may depend on the parameterless constructor,
    // so it is preserved here and marked as EditorBrowsable.Never.
    public abstract partial class FrontDoorSecretProperties
    {
        /// <summary> Initializes a new instance of <see cref="FrontDoorSecretProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected FrontDoorSecretProperties()
        {
        }
    }
}
