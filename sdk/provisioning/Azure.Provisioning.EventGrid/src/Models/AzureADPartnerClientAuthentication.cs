// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Azure Active Directory Partner Client Authentication.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class AzureADPartnerClientAuthentication : PartnerClientAuthentication
{
    /// <summary>
    /// The Azure Active Directory Tenant ID to get the access token that will
    /// be included as the bearer token in delivery requests.
    /// </summary>
    public BicepValue<string> AzureActiveDirectoryTenantId
    {
        get { Initialize(); return _azureActiveDirectoryTenantId!; }
        set { Initialize(); _azureActiveDirectoryTenantId!.Assign(value); }
    }
    private BicepValue<string>? _azureActiveDirectoryTenantId;

    /// <summary>
    /// The Azure Active Directory Application ID or URI to get the access
    /// token that will be included as the bearer token in delivery requests.
    /// </summary>
    public BicepValue<Uri> AzureActiveDirectoryApplicationIdOrUri
    {
        get { Initialize(); return _azureActiveDirectoryApplicationIdOrUri!; }
        set { Initialize(); _azureActiveDirectoryApplicationIdOrUri!.Assign(value); }
    }
    private BicepValue<Uri>? _azureActiveDirectoryApplicationIdOrUri;

    /// <summary>
    /// Creates a new AzureADPartnerClientAuthentication.
    /// </summary>
    public AzureADPartnerClientAuthentication() : base()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of
    /// AzureADPartnerClientAuthentication.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        DefineProperty<string>("clientAuthenticationType", ["clientAuthenticationType"], defaultValue: "AzureAD");
        _azureActiveDirectoryTenantId = DefineProperty<string>("AzureActiveDirectoryTenantId", ["properties", "azureActiveDirectoryTenantId"]);
        _azureActiveDirectoryApplicationIdOrUri = DefineProperty<Uri>("AzureActiveDirectoryApplicationIdOrUri", ["properties", "azureActiveDirectoryApplicationIdOrUri"]);
    }
}
