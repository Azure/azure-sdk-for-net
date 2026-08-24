// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccount : ProvisionableResource
{
    // TypeSpec treats several response-marked storage account properties as get-only.
    // Keep the setters and aliases that shipped from the previous provisioning generator.
    /// <summary> Gets or sets the access tier used for billing. </summary>
    public BicepValue<StorageAccountAccessTier> AccessTier
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            return Properties.AccessTier;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.AccessTier = value;
        }
    }

    /// <summary> Gets or sets the custom domain assigned to the storage account. </summary>
    public StorageCustomDomain CustomDomain
    {
        get { return Properties is null ? default! : Properties.CustomDomain; }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.CustomDomain = value;
        }
    }

    /// <summary> Gets or sets the encryption settings for the storage account. </summary>
    public StorageAccountEncryption Encryption
    {
        get { return Properties is null ? default! : Properties.Encryption; }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.Encryption = value;
        }
    }

    /// <summary> Gets or sets whether blob geo-priority replication is enabled. </summary>
    public BicepValue<bool> IsBlobEnabled
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            return Properties.IsBlobEnabled;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.IsBlobEnabled = value;
        }
    }

    /// <summary> Gets or sets the key expiration period in days. </summary>
    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            return Properties.KeyExpirationPeriodInDays;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.KeyExpirationPeriodInDays = value;
        }
    }

    /// <summary> Gets or sets the network rule set. </summary>
    public StorageAccountNetworkRuleSet NetworkRuleSet
    {
        get { return Properties is null ? default! : Properties.NetworkRuleSet; }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.NetworkRuleSet = value;
        }
    }

    /// <summary> Gets or sets the SAS policy assigned to the storage account. </summary>
    public StorageAccountSasPolicy SasPolicy
    {
        get { return Properties is null ? default! : Properties.SasPolicy; }
        set
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            Properties.SasPolicy = value;
        }
    }

    /// <summary> Gets the resource-specific storage account provisioning state. </summary>
    public BicepValue<StorageAccountProvisioningState> StorageAccountProvisioningState
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            return Properties.ProvisioningState;
        }
    }

    /// <summary> Gets the storage account SKU conversion status. </summary>
    public StorageAccountSkuConversionStatus StorageAccountSkuConversionStatus
    {
        get { return Properties is null ? default! : Properties.StorageAccountSkuConversionStatus; }
    }

    // TypeSpec models private endpoint connections as resources. Preserve both the shipped
    // resource-list name and the older data-model list on the same output path.
    /// <summary>
    /// Gets the private endpoint connection resources associated with the storage account.
    /// </summary>
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<StoragePrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get { Initialize(); return _privateEndpointConnectionResources!; }
    }
    private BicepList<StoragePrivateEndpointConnection>? _privateEndpointConnectionResources;

    /// <summary>
    /// List of private endpoint connection associated with the specified
    /// storage account.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="StorageAccount.PrivateEndpointConnectionResources"/> instead.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepList<StoragePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get { Initialize(); return _privateEndpointConnections!; }
    }
    private BicepList<StoragePrivateEndpointConnectionData>? _privateEndpointConnections;

    // TypeSpec now emits a resource-specific provisioning-state enum. Keep the shared enum
    // that shipped on StorageAccount while retaining its historical ordinal values.
    /// <summary>
    /// Gets the status of the storage account at the time the operation was called.
    /// </summary>
    public BicepValue<StorageProvisioningState> ProvisioningState
    {
        get { Initialize(); return _provisioningState!; }
    }
    private BicepValue<StorageProvisioningState>? _provisioningState;

    partial void DefineAdditionalProperties()
    {
        _privateEndpointConnectionResources = DefineListProperty<StoragePrivateEndpointConnection>("PrivateEndpointConnectionResources", ["properties", "privateEndpointConnections"], isOutput: true);
        _privateEndpointConnections = DefineListProperty<StoragePrivateEndpointConnectionData>("PrivateEndpointConnections", ["properties", "privateEndpointConnections"], isOutput: true);
        _provisioningState = DefineProperty<StorageProvisioningState>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);

        // TypeSpec defines ARM common properties in a different order. Reinsert the generated
        // values in the shipped order so existing Bicep output remains stable.
        string[] propertyOrder =
        [
            "Name",
            "Kind",
            "Location",
            "Sku",
            "Properties",
            "ExtendedLocation",
            "Identity",
            "Tags",
            "Placement",
            "Zones"
        ];
        Dictionary<string, IBicepValue> properties = new(ProvisionableProperties);
        ProvisionableProperties.Clear();
        foreach (string propertyName in propertyOrder)
        {
            if (properties.TryGetValue(propertyName, out IBicepValue? property) && property is not null)
            {
                ProvisionableProperties.Add(propertyName, property);
                properties.Remove(propertyName);
            }
        }
        foreach (KeyValuePair<string, IBicepValue> property in properties)
        {
            ProvisionableProperties.Add(property.Key, property.Value);
        }
    }

    // TypeSpec generation omits the convenience expressions and role helpers from the
    // reflection-based generator. Preserve them because callers use their Bicep behavior.
    /// <summary> Get access keys for this StorageAccount resource. </summary>
    /// <returns>The keys for this StorageAccount resource.</returns>
    public BicepList<StorageAccountKey> GetKeys()
    {
        return BicepList<StorageAccountKey>.FromExpression(
            e =>
            {
                StorageAccountKey key = new();
                ((IBicepValue)key).Expression = e;
                return key;
            },
            new MemberExpression(new FunctionCallExpression(new MemberExpression(new IdentifierExpression(BicepIdentifier), "listKeys")), "keys"));
    }

    /// <summary> Creates a role assignment for a user-assigned identity. </summary>
    /// <param name="role">The role to grant.</param>
    /// <param name="identity">The user-assigned identity.</param>
    /// <returns>The role assignment.</returns>
    public RoleAssignment CreateRoleAssignment(StorageBuiltInRole role, UserAssignedIdentity identity) =>
        new($"{BicepIdentifier}_{identity.BicepIdentifier}_{StorageBuiltInRole.GetBuiltInRoleName(role)}")
        {
            Name = BicepFunction.CreateGuid(Id, identity.PrincipalId, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(BicepIdentifier),
            PrincipalType = RoleManagementPrincipalType.ServicePrincipal,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = identity.PrincipalId
        };

    /// <summary> Creates a role assignment for a principal. </summary>
    /// <param name="role">The role to grant.</param>
    /// <param name="principalType">The type of principal.</param>
    /// <param name="principalId">The principal identifier.</param>
    /// <param name="bicepIdentifierSuffix">Optional role assignment identifier suffix.</param>
    /// <returns>The role assignment.</returns>
    public RoleAssignment CreateRoleAssignment(
        StorageBuiltInRole role,
        BicepValue<RoleManagementPrincipalType> principalType,
        BicepValue<Guid> principalId,
        string? bicepIdentifierSuffix = default) =>
        new($"{BicepIdentifier}_{StorageBuiltInRole.GetBuiltInRoleName(role)}{(bicepIdentifierSuffix is null ? "" : "_")}{bicepIdentifierSuffix}")
        {
            Name = BicepFunction.CreateGuid(Id, principalId, BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())),
            Scope = new IdentifierExpression(BicepIdentifier),
            PrincipalType = principalType,
            RoleDefinitionId = BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString()),
            PrincipalId = principalId
        };
}
