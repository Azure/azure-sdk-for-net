// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// The action that is performed when the alert rule becomes active, and when
/// an alert condition is resolved.             Please note
/// Azure.ResourceManager.Monitor.Models.AlertRuleAction is the base class.
/// According to the scenario, a derived class of the base class might need to
/// be assigned here, or this property needs to be casted to one of the
/// possible derived classes.             The available derived classes
/// include Azure.ResourceManager.Monitor.Models.RuleEmailAction and
/// Azure.ResourceManager.Monitor.Models.RuleWebhookAction.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class AlertRuleAction : ProvisionableConstruct
{
    /// <summary>
    /// Creates a new AlertRuleAction.
    /// </summary>
    public AlertRuleAction()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of AlertRuleAction.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
