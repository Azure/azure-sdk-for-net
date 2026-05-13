// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AlertProcessingRules.Models
{
    // Compatibility shim: the old AlertsManagement SDK exposed EqualsValue because Equals
    // collides with System.Object.Equals; the TypeSpec customization also exposes EqualTo.
    public readonly partial struct AlertProcessingRuleOperator
    {
        /// <summary> Equals. </summary>
        public static AlertProcessingRuleOperator EqualsValue => EqualTo;
    }
}
