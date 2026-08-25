// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Roles;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.SignalR;

/// <summary> A class representing a resource. </summary>
[CodeGenType("SignalR")]
public partial class SignalRService
{
    private BicepList<SignalRPrivateEndpointConnectionData> _privateEndpointConnections;
    private BicepList<SignalRSharedPrivateLinkResourceData> _sharedPrivateLinkResources;

    /// <summary> Gets the private endpoint connection resources. </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<SignalRPrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new SignalRProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
    }

    /// <summary> Gets the shared private link resources. </summary>
    [CodeGenMember("SharedPrivateLinkResources")]
    public BicepList<SignalRSharedPrivateLink> SharedPrivateLinkResourceItems
    {
        get
        {
            if (Properties is null)
            {
                Properties = new SignalRProperties();
            }
            return Properties.SharedPrivateLinkResources;
        }
    }

    /// <summary> Gets the private endpoint connection data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
    public BicepList<SignalRPrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    /// <summary> Gets the shared private link resource data models. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use SharedPrivateLinkResourceItems instead.")]
    public BicepList<SignalRSharedPrivateLinkResourceData> SharedPrivateLinkResources
    {
        get
        {
            Initialize();
            return _sharedPrivateLinkResources;
        }
    }

    /// <summary> Gets or sets whether client certificate authentication is enabled. </summary>
    [CodeGenMember("TlsIsClientCertEnabled")]
    public BicepValue<bool> IsClientCertEnabled
    {
        get => Properties is null ? default! : Properties.TlsIsClientCertEnabled;
        set
        {
            if (Properties is null)
            {
                Properties = new SignalRProperties();
            }
            Properties.TlsIsClientCertEnabled = value;
        }
    }

    /// <summary> Gets the access keys for this SignalR service. </summary>
    /// <returns> The access keys for this SignalR service. </returns>
    public SignalRKeys GetKeys()
    {
        SignalRKeys key = new();
        ((IBicepValue)key).Expression = new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys"));
        return key;
    }

    /// <summary> Creates a role assignment for a user-assigned identity. </summary>
    public RoleAssignment CreateRoleAssignment(SignalRBuiltInRole role, UserAssignedIdentity identity) =>
        new($"{BicepIdentifier}_{identity.BicepIdentifier}_{SignalRBuiltInRole.GetBuiltInRoleName(role)}")
        {
            Name = BicepFunction.CreateGuid(Id, identity.PrincipalId, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = identity.PrincipalId
        };

    /// <summary> Creates a role assignment for a principal. </summary>
    public RoleAssignment CreateRoleAssignment(SignalRBuiltInRole role, BicepValue<RoleManagementPrincipalType> principalType, BicepValue<Guid> principalId, string? bicepIdentifierSuffix = default) =>
        new($"{BicepIdentifier}_{SignalRBuiltInRole.GetBuiltInRoleName(role)}{(bicepIdentifierSuffix is null ? "" : "_")}{bicepIdentifierSuffix}")
        {
            Name = BicepFunction.CreateGuid(Id, principalId, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(BicepIdentifier),
            PrincipalType = principalType,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = principalId
        };

    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // These properties are intentionally preserved for compatibility.
        _privateEndpointConnections = DefineListProperty<SignalRPrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "properties", "privateEndpointConnections" }, isOutput: true);
        _sharedPrivateLinkResources = DefineListProperty<SignalRSharedPrivateLinkResourceData>(nameof(SharedPrivateLinkResources), new string[] { "properties", "sharedPrivateLinkResources" }, isOutput: true);
#pragma warning restore CS0618
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2018-10-01". </summary>
        public static readonly string V2018_10_01 = "2018-10-01";
        /// <summary> API version "2020-05-01". </summary>
        public static readonly string V2020_05_01 = "2020-05-01";
        /// <summary> API version "2021-10-01". </summary>
        public static readonly string V2021_10_01 = "2021-10-01";
        /// <summary> API version "2022-02-01". </summary>
        public static readonly string V2022_02_01 = "2022-02-01";
        /// <summary> API version "2023-02-01". </summary>
        public static readonly string V2023_02_01 = "2023-02-01";
        /// <summary> API version "2024-03-01". </summary>
        public static readonly string V2024_03_01 = "2024-03-01";
    }
}
