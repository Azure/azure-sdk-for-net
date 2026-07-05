// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds the Errors property to the internal CanMigrateProperties class to expose migration error information.
    // Reason: The TypeSpec generator may not have correctly exposed this nested property, or the property was lost during flattening.
    // The Errors property is manually added here with a WirePath attribute to specify its JSON path for correct deserialization.
    internal partial class CanMigrateProperties
    {
        /// <summary> Gets the Errors. </summary>
        [WirePath("errors")]
        public IReadOnlyList<MigrationErrorType> Errors { get; }
    }
}
