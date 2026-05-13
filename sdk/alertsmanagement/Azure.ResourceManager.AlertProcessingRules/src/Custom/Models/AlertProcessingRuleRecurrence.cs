// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AlertProcessingRules.Models
{
    // Compatibility shim: the previous AlertsManagement SDK exposed a protected parameterless
    // constructor for this polymorphic base type, but the TypeSpec generator only emits internal
    // discriminator constructors.
    [CodeGenSuppress("AlertProcessingRuleRecurrence")]
    public abstract partial class AlertProcessingRuleRecurrence
    {
#pragma warning disable CS1591 // Compatibility constructor matches the previous SDK surface.
        protected AlertProcessingRuleRecurrence() : this(default, null, null, null)
        {
        }
#pragma warning restore CS1591
    }
}
