// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Information about the WebHook of the partner destination.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class WebhookPartnerDestinationInfo : PartnerDestinationInfo
{
    /// <summary>
    /// The URL that represents the endpoint of the partner destination.
    /// </summary>
    public BicepValue<Uri> EndpointUri
    {
        get { Initialize(); return _endpointUri!; }
        set { Initialize(); _endpointUri!.Assign(value); }
    }
    private BicepValue<Uri>? _endpointUri;

    /// <summary>
    /// The base URL that represents the endpoint of the partner destination.
    /// </summary>
    public BicepValue<Uri> EndpointBaseUri
    {
        get { Initialize(); return _endpointBaseUri!; }
        set { Initialize(); _endpointBaseUri!.Assign(value); }
    }
    private BicepValue<Uri>? _endpointBaseUri;

    /// <summary>
    /// Partner client authentication             Please note
    /// Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication is
    /// the base class. According to the scenario, a derived class of the base
    /// class might need to be assigned here, or this property needs to be
    /// casted to one of the possible derived classes.             The
    /// available derived classes include
    /// Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication.
    /// </summary>
    public PartnerClientAuthentication ClientAuthentication
    {
        get { Initialize(); return _clientAuthentication!; }
        set { Initialize(); AssignOrReplace(ref _clientAuthentication, value); }
    }
    private PartnerClientAuthentication? _clientAuthentication;

    /// <summary>
    /// Creates a new WebhookPartnerDestinationInfo.
    /// </summary>
    public WebhookPartnerDestinationInfo() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// WebhookPartnerDestinationInfo.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("endpointType", ["endpointType"], defaultValue: "WebHook");
        _endpointUri = DefineProperty<Uri>("EndpointUri", ["properties", "endpointUrl"]);
        _endpointBaseUri = DefineProperty<Uri>("EndpointBaseUri", ["properties", "endpointBaseUrl"]);
        _clientAuthentication = DefineModelProperty<PartnerClientAuthentication>("ClientAuthentication", ["properties", "clientAuthentication"]);
    }
}
