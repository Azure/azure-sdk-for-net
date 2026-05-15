// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: rename generated collection class to match GA 1.0.0 SDK name.
// The TypeSpec generator produces "EventCollection" but GA SDK shipped "ResourceHealthEventCollection".
// @@clientName cannot rename Collection classes; [CodeGenType] is the only mechanism.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> A class representing a collection of ResourceHealthEvent resources and their operations. </summary>
    [CodeGenType("EventCollection")]
    public partial class ResourceHealthEventCollection
    {
    }
}
