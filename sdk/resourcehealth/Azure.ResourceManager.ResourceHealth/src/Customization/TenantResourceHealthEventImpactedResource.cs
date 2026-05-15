// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: rename generated resource class to match GA 1.0.0 SDK name.
// The TypeSpec generator produces "TenantEventImpactedResource" but GA SDK shipped "TenantResourceHealthEventImpactedResource".
// @@clientName cannot rename Resource classes; [CodeGenType] is the only mechanism.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ResourceHealth
{
    /// <summary> A Class representing a TenantResourceHealthEventImpactedResource along with the instance operations that can be performed on it. </summary>
    [CodeGenType("TenantEventImpactedResource")]
    public partial class TenantResourceHealthEventImpactedResource
    {
    }
}
