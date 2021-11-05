// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.DigitalTwins.Core
{
    internal partial class RelationshipCollection
    {
        // The method is overridden so that autorest does not create the function in the generated code.
        internal static void DeserializeRelationshipCollection(JsonElement element) { _ = element; }
    }
}
