// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

/// <summary> Properties of the storage account. </summary>
internal partial class StorageAccountProperties
{
    private StorageCustomDomain _customDomain;
    private StorageAccountSasPolicy _sasPolicy;
    private KeyPolicy _keyPolicy;
    private StorageAccountEncryption _encryption;
    private BicepValue<StorageAccountAccessTier> _accessTier;
    private StorageAccountNetworkRuleSet _networkRuleSet;
#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    // TypeSpec uses StorageAccountProvisioningState; retain the shipped shared-enum view on the same response path.
    private BicepValue<StorageProvisioningState> _legacyProvisioningState;
#pragma warning restore CS0618

    // TypeSpec generates a nested resource list named PrivateEndpointConnections, but the shipped new API names it PrivateEndpointConnectionResources.
    private BicepList<StoragePrivateEndpointConnection> _privateEndpointConnectionResources;

    // The shipped old API keeps the PrivateEndpointConnections name with its data-model element type.
    private BicepList<StoragePrivateEndpointConnectionData> _privateEndpointConnections;

    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<StoragePrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            Initialize();
            return _privateEndpointConnectionResources;
        }
    }

    internal BicepList<StoragePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    [CodeGenMember("CustomDomain")]
    public StorageCustomDomain CustomDomain
    {
        get { Initialize(); return _customDomain; }
        set { Initialize(); AssignOrReplace(ref _customDomain, value); }
    }

    [CodeGenMember("SasPolicy")]
    public StorageAccountSasPolicy SasPolicy
    {
        get { Initialize(); return _sasPolicy; }
        set { Initialize(); AssignOrReplace(ref _sasPolicy, value); }
    }

    [CodeGenMember("KeyPolicy")]
    internal KeyPolicy KeyPolicy
    {
        get { Initialize(); return _keyPolicy; }
    }

    [CodeGenMember("Encryption")]
    public StorageAccountEncryption Encryption
    {
        get { Initialize(); return _encryption; }
        set { Initialize(); AssignOrReplace(ref _encryption, value); }
    }

    [CodeGenMember("AccessTier")]
    public BicepValue<StorageAccountAccessTier> AccessTier
    {
        get { Initialize(); return _accessTier; }
        set { Initialize(); _accessTier.Assign(value); }
    }

    [CodeGenMember("NetworkRuleSet")]
    public StorageAccountNetworkRuleSet NetworkRuleSet
    {
        get { Initialize(); return _networkRuleSet; }
        set { Initialize(); AssignOrReplace(ref _networkRuleSet, value); }
    }

    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get { Initialize(); return KeyPolicy.KeyExpirationPeriodInDays; }
        set { Initialize(); KeyPolicy.KeyExpirationPeriodInDays = value; }
    }

#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    internal BicepValue<StorageProvisioningState> LegacyProvisioningState
#pragma warning restore CS0618
    {
        get { Initialize(); return _legacyProvisioningState; }
    }

    partial void DefineAdditionalProperties()
    {
        // The create body makes these properties writable, but the resource model marks them as read-only. Remove this
        // workaround when resource and create-body model graphs are recursively combined: https://github.com/Azure/azure-sdk-for-net/issues/61011.
        _customDomain = DefineModelProperty<StorageCustomDomain>(nameof(CustomDomain), new string[] { "customDomain" });
        _sasPolicy = DefineModelProperty<StorageAccountSasPolicy>(nameof(SasPolicy), new string[] { "sasPolicy" });
        _keyPolicy = DefineModelProperty<KeyPolicy>(nameof(KeyPolicy), new string[] { "keyPolicy" });
        _encryption = DefineModelProperty<StorageAccountEncryption>(nameof(Encryption), new string[] { "encryption" });
        _accessTier = DefineProperty<StorageAccountAccessTier>(nameof(AccessTier), new string[] { "accessTier" });
        _networkRuleSet = DefineModelProperty<StorageAccountNetworkRuleSet>(nameof(NetworkRuleSet), new string[] { "networkAcls" });

        // Both output aliases share the response path because they preserve the shipped new and old views of the same wire property.
        _privateEndpointConnectionResources = DefineListProperty<StoragePrivateEndpointConnection>(nameof(PrivateEndpointConnectionResources), new string[] { "privateEndpointConnections" }, isOutput: true, isRequired: false);
        _privateEndpointConnections = DefineListProperty<StoragePrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" }, isOutput: true, isRequired: false);

#pragma warning disable CS0618 // Compatibility property registration intentionally uses the obsolete shipped enum.
        _legacyProvisioningState = DefineProperty<StorageProvisioningState>(nameof(LegacyProvisioningState), new string[] { "provisioningState" }, isOutput: true);
#pragma warning restore CS0618
    }
}
