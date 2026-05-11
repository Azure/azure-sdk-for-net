// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.TenantActivityLogAlerts.Models
{
    // The MPG generator emits a public AlertRuleProperties ctor that accepts IList<AlertRuleAnyOfOrLeafCondition>,
    // but TenantActivityLogAlertResourceData's public ctor (which takes IEnumerable<>) calls it with the IEnumerable
    // value directly, producing CS1503 (cannot convert IEnumerable<> to IList<>). Suppress the generated ctor and
    // re-emit one that accepts IEnumerable<> so both wrapper and properties have a consistent public surface.
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("AlertRuleProperties", typeof(IList<AlertRuleAnyOfOrLeafCondition>))]
    internal partial class AlertRuleProperties
    {
        public AlertRuleProperties(IEnumerable<AlertRuleAnyOfOrLeafCondition> conditionAllOf)
        {
            Argument.AssertNotNull(conditionAllOf, nameof(conditionAllOf));

            Scopes = new ChangeTrackingList<string>();
            Condition = new AlertRuleAllOfCondition(conditionAllOf.ToList());
        }
    }
}
