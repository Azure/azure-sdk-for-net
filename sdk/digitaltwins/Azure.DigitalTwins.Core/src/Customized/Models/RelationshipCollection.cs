// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.DigitalTwins.Core.Models
{
    internal partial class RelationshipCollection
    {
        // This class declaration makes the generated class of the same name use IReadOnlyList<string> instead of IReadOnlyList<object>
        // and makes the class internal; do not remove.

        internal IReadOnlyList<string> Value { get; }
    }
}
