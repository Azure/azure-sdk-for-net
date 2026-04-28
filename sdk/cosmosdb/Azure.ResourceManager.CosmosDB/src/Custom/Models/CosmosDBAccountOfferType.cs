// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary>
    /// Compatibility stub for the legacy <c>CosmosDBAccountOfferType</c> enum.
    /// The TypeSpec spec models this as a constant string literal "Standard" rather than an enum;
    /// however the auto-generated <see cref="ArmCosmosDBModelFactory"/> back-compat overload still
    /// references this type. This stub keeps the <c>[EditorBrowsable(Never)]</c> compatibility
    /// overload compiling without re-exposing the type in IntelliSense.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CosmosDBAccountOfferType
    {
        /// <summary> Standard. </summary>
        Standard
    }
}
