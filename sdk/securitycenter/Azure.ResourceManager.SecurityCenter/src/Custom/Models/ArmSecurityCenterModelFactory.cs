// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [CodeGenSuppress(
        "SecurityAlertsSuppressionRuleData",
        typeof(ResourceIdentifier),
        typeof(string),
        typeof(ResourceType),
        typeof(SystemData),
        typeof(string),
        typeof(DateTimeOffset?),
        typeof(DateTimeOffset?),
        typeof(string),
        typeof(RuleState?),
        typeof(string),
        typeof(IEnumerable<SuppressionAlertsScopeElement>))]
    public static partial class ArmSecurityCenterModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="SecurityCenter.SecurityAlertsSuppressionRuleData"/>. </summary>
        public static SecurityAlertsSuppressionRuleData SecurityAlertsSuppressionRuleData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string alertType = default, DateTimeOffset? lastModifiedOn = default, DateTimeOffset? expireOn = default, string reason = default, SecurityAlertsSuppressionRuleState? state = default, string comment = default, IEnumerable<SuppressionAlertsScopeElement> suppressionAlertsScopeAllOf = default)
        {
            return new SecurityAlertsSuppressionRuleData(
                id,
                name,
                resourceType,
                systemData,
                alertType is null && lastModifiedOn is null && expireOn is null && reason is null && state is null && comment is null && suppressionAlertsScopeAllOf is null ? default : new AlertsSuppressionRuleProperties(
                    alertType,
                    lastModifiedOn,
                    expireOn,
                    reason,
                    state.HasValue ? state.Value.ToString().ToRuleState() : default,
                    comment,
                    suppressionAlertsScopeAllOf is null ? default : new SuppressionAlertsScope(suppressionAlertsScopeAllOf),
                    new ChangeTrackingDictionary<string, BinaryData>()),
                new ChangeTrackingDictionary<string, BinaryData>());
        }
    }
}
