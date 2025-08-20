// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Partner client authentication             Please note
/// Azure.ResourceManager.EventGrid.Models.PartnerClientAuthentication is the
/// base class. According to the scenario, a derived class of the base class
/// might need to be assigned here, or this property needs to be casted to one
/// of the possible derived classes.             The available derived classes
/// include
/// Azure.ResourceManager.EventGrid.Models.AzureADPartnerClientAuthentication.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class PartnerClientAuthentication : ProvisionableConstruct
{
    /// <summary>
    /// Creates a new PartnerClientAuthentication.
    /// </summary>
    public PartnerClientAuthentication()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of PartnerClientAuthentication.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
    }
}
