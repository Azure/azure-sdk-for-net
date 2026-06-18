// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec-generated abstract polymorphic base does not expose the GA protected parameterless constructor used for derivation and mocking; keep that constructor in this partial.
    /// <summary>
    /// Provides a compatibility shim for the SecurityConnectorEnvironment class.
    /// </summary>
    public abstract partial class SecurityConnectorEnvironment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConnectorEnvironment"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected SecurityConnectorEnvironment() { }
    }
}
