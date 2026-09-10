// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    /// <summary>
    /// Provides a compatibility shim for the SecureScoreControlDetails class.
    /// </summary>
    public partial class SecureScoreControlDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecureScoreControlDetails"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecureScoreControlDetails() { }
        /// <summary>
        /// Gets or sets the Definition value preserved from the previous public API surface.
        /// </summary>
        public SecureScoreControlDefinitionItem Definition { get; set; }
    }
}
