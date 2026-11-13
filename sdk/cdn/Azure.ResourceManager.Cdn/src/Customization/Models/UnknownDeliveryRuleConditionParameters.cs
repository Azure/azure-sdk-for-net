// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenType to rename the generator-produced UnknownDeliveryRuleConditionProperties to
    // UnknownDeliveryRuleConditionParameters, maintaining backward API compatibility with the previous SDK.
    // Reason: The old SDK named this polymorphic Condition parameters unknown type as UnknownDeliveryRuleConditionParameters,
    // but the TypeSpec generator renamed it to UnknownDeliveryRuleConditionProperties based on the new type hierarchy.
    // The CodeGenType attribute maps the generated class name to the old name to preserve API compatibility.
    [CodeGenType("UnknownDeliveryRuleConditionProperties")]
    internal partial class UnknownDeliveryRuleConditionParameters
    { }
}
