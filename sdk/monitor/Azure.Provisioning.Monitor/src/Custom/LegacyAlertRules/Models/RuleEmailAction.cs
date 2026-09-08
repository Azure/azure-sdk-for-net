// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.Monitor;

// This compatibility type preserves the previously shipped classic Alert Rule API, which is not represented in the current TypeSpec specification.
/// <summary>
/// Specifies the action to send email when the rule condition is evaluated.
/// The discriminator is always RuleEmailAction in this case.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class RuleEmailAction : AlertRuleAction
{
    /// <summary>
    /// Whether the administrators (service and co-administrators) of the
    /// service should be notified when the alert is activated.
    /// </summary>
    public BicepValue<bool> SendToServiceOwners
    {
        get { Initialize(); return _sendToServiceOwners!; }
        set { Initialize(); _sendToServiceOwners!.Assign(value); }
    }
    private BicepValue<bool>? _sendToServiceOwners;

    /// <summary>
    /// the list of administrator&apos;s custom email addresses to notify of
    /// the activation of the alert.
    /// </summary>
    public BicepList<string> CustomEmails
    {
        get { Initialize(); return _customEmails!; }
        set { Initialize(); _customEmails!.Assign(value); }
    }
    private BicepList<string>? _customEmails;

    /// <summary>
    /// Creates a new RuleEmailAction.
    /// </summary>
    public RuleEmailAction() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of RuleEmailAction.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("odata.type", ["odata.type"], defaultValue: "Microsoft.Azure.Management.Insights.Models.RuleEmailAction");
        _sendToServiceOwners = DefineProperty<bool>("SendToServiceOwners", ["sendToServiceOwners"]);
        _customEmails = DefineListProperty<string>("CustomEmails", ["customEmails"]);
    }
}
