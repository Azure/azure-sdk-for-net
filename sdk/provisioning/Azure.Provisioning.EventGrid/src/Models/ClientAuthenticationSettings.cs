// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Client authentication settings for namespace resource.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public partial class ClientAuthenticationSettings : ProvisionableConstruct
{
    /// <summary>
    /// Alternative authentication name sources related to client
    /// authentication settings for namespace resource.
    /// </summary>
    public BicepList<AlternativeAuthenticationNameSource> AlternativeAuthenticationNameSources
    {
        get { Initialize(); return _alternativeAuthenticationNameSources!; }
        set { Initialize(); _alternativeAuthenticationNameSources!.Assign(value); }
    }
    private BicepList<AlternativeAuthenticationNameSource>? _alternativeAuthenticationNameSources;

    /// <summary>
    /// Custom JWT authentication settings for namespace resource.
    /// </summary>
    public CustomJwtAuthenticationSettings CustomJwtAuthentication
    {
        get { Initialize(); return _customJwtAuthentication!; }
        set { Initialize(); AssignOrReplace(ref _customJwtAuthentication, value); }
    }
    private CustomJwtAuthenticationSettings? _customJwtAuthentication;

    /// <summary>
    /// Creates a new ClientAuthenticationSettings.
    /// </summary>
    public ClientAuthenticationSettings()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of ClientAuthenticationSettings.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _alternativeAuthenticationNameSources = DefineListProperty<AlternativeAuthenticationNameSource>("AlternativeAuthenticationNameSources", ["alternativeAuthenticationNameSources"]);
        _customJwtAuthentication = DefineModelProperty<CustomJwtAuthenticationSettings>("CustomJwtAuthentication", ["customJwtAuthentication"]);
    }
}
