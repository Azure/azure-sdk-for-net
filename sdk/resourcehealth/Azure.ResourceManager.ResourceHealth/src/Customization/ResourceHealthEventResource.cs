// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: rename generated resource class to match GA 1.0.0 SDK name.
// The TypeSpec generator produces "EventResource" from the TypeSpec "Event" model,
// but the GA SDK shipped this class as "ResourceHealthEventResource".
// @@clientName in client.tsp only renames the Data class (EventData → ResourceHealthEventData),
// it does NOT rename the Resource class. [CodeGenType] is the only mechanism to rename Resource classes.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> A Class representing a ResourceHealthEvent along with the instance operations that can be performed on it. </summary>
    [CodeGenType("EventResource")]
    public partial class ResourceHealthEventResource
    {
    }
}
