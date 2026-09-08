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
/// Specifies the action to post to service when the rule condition is
/// evaluated. The discriminator is always RuleWebhookAction in this case.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class RuleWebhookAction : AlertRuleAction
{
    /// <summary>
    /// the service uri to Post the notification when the alert activates or
    /// resolves.
    /// </summary>
    public BicepValue<Uri> ServiceUri
    {
        get { Initialize(); return _serviceUri!; }
        set { Initialize(); _serviceUri!.Assign(value); }
    }
    private BicepValue<Uri>? _serviceUri;

    /// <summary>
    /// the dictionary of custom properties to include with the post operation.
    /// These data are appended to the webhook payload.
    /// </summary>
    public BicepDictionary<string> Properties
    {
        get { Initialize(); return _properties!; }
        set { Initialize(); _properties!.Assign(value); }
    }
    private BicepDictionary<string>? _properties;

    /// <summary>
    /// Creates a new RuleWebhookAction.
    /// </summary>
    public RuleWebhookAction() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of RuleWebhookAction.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("odata.type", ["odata.type"], defaultValue: "Microsoft.Azure.Management.Insights.Models.RuleWebhookAction");
        _serviceUri = DefineProperty<Uri>("ServiceUri", ["serviceUri"]);
        _properties = DefineDictionaryProperty<string>("Properties", ["properties"]);
    }
}
