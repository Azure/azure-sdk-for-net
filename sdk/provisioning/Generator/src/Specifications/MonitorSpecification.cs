// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Monitor;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class MonitorSpecification() :
    Specification("Monitor", typeof(MonitorExtensions), serviceDirectory: "monitor")
{
    protected override void Customize()
    {
        // Naming requirements
        AddNameRequirements<MetricAlertResource>(min: 1, max: 260, lower: true, upper: true, digits: true, hyphen: true);

        // Remove properties that duplicate base class AlertRuleLeafCondition members
        RemoveProperties<ActivityLogAlertAnyOfOrLeafCondition>("Field", "EqualsValue", "ContainsAny");
    }
}
