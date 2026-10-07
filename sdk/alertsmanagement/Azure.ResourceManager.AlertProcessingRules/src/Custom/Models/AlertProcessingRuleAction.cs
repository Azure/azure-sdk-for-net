// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AlertProcessingRules.Models
{
    // Compatibility shim: the previous AlertsManagement SDK exposed a protected parameterless
    // constructor for this polymorphic base type, but the TypeSpec generator only emits internal
    // discriminator constructors.
    public abstract partial class AlertProcessingRuleAction
    {
        /// <summary> Initializes a new instance of <see cref="AlertProcessingRuleAction"/>. </summary>
        protected AlertProcessingRuleAction() : this(default, null)
        {
        }
    }
}
