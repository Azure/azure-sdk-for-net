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
    private BicepValue<StorageProvisioningState> _legacyProvisioningState;
#pragma warning restore CS0618

    private BicepList<StoragePrivateEndpointConnection> _privateEndpointConnectionResources;

    private BicepList<StoragePrivateEndpointConnectionData> _privateEndpointConnections;

    // TypeSpec names this resource list PrivateEndpointConnections; retain the shipped PrivateEndpointConnectionResources name.
    [CodeGenMember("PrivateEndpointConnections")]
    public BicepList<StoragePrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            Initialize();
            return _privateEndpointConnectionResources;
        }
    }

    // TypeSpec generates a resource-list view; retain the shipped PrivateEndpointConnections data-model view.
    internal BicepList<StoragePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            Initialize();
            return _privateEndpointConnections;
        }
    }

    // The generator omits writable CustomDomain because the create body makes it settable while the resource graph is read-only.
    [CodeGenMember("CustomDomain")]
    public StorageCustomDomain CustomDomain
    {
        get { Initialize(); return _customDomain; }
        set { Initialize(); AssignOrReplace(ref _customDomain, value); }
    }

    // The generator omits writable SasPolicy because the create body makes it settable while the resource graph is read-only.
    [CodeGenMember("SasPolicy")]
    public StorageAccountSasPolicy SasPolicy
    {
        get { Initialize(); return _sasPolicy; }
        set { Initialize(); AssignOrReplace(ref _sasPolicy, value); }
    }

    // The generator omits KeyPolicy from the writable create graph; retain it so KeyExpirationPeriodInDays remains settable.
    [CodeGenMember("KeyPolicy")]
    internal KeyPolicy KeyPolicy
    {
        get { Initialize(); return _keyPolicy; }
    }

    // The generator omits writable Encryption because the create body makes it settable while the resource graph is read-only.
    [CodeGenMember("Encryption")]
    public StorageAccountEncryption Encryption
    {
        get { Initialize(); return _encryption; }
        set { Initialize(); AssignOrReplace(ref _encryption, value); }
    }

    // The generator omits writable AccessTier because the create body makes it settable while the resource graph is read-only.
    [CodeGenMember("AccessTier")]
    public BicepValue<StorageAccountAccessTier> AccessTier
    {
        get { Initialize(); return _accessTier; }
        set { Initialize(); _accessTier.Assign(value); }
    }

    // The generator omits writable NetworkRuleSet because the create body makes it settable while the resource graph is read-only.
    [CodeGenMember("NetworkRuleSet")]
    public StorageAccountNetworkRuleSet NetworkRuleSet
    {
        get { Initialize(); return _networkRuleSet; }
        set { Initialize(); AssignOrReplace(ref _networkRuleSet, value); }
    }

    // The generator omits writable KeyExpirationPeriodInDays; forward through KeyPolicy to preserve the shipped setter.
    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get { Initialize(); return KeyPolicy.KeyExpirationPeriodInDays; }
        set { Initialize(); KeyPolicy.KeyExpirationPeriodInDays = value; }
    }

#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    // TypeSpec uses StorageAccountProvisioningState; retain the shipped LegacyProvisioningState shared-enum view.
    internal BicepValue<StorageProvisioningState> LegacyProvisioningState
#pragma warning restore CS0618
    {
        get { Initialize(); return _legacyProvisioningState; }
    }

    partial void DefineAdditionalProperties()
    {
        // Remove these registrations when https://github.com/Azure/azure-sdk-for-net/issues/61011 is fixed.
        _customDomain = DefineModelProperty<StorageCustomDomain>(nameof(CustomDomain), new string[] { "customDomain" });
        _sasPolicy = DefineModelProperty<StorageAccountSasPolicy>(nameof(SasPolicy), new string[] { "sasPolicy" });
        _keyPolicy = DefineModelProperty<KeyPolicy>(nameof(KeyPolicy), new string[] { "keyPolicy" });
        _encryption = DefineModelProperty<StorageAccountEncryption>(nameof(Encryption), new string[] { "encryption" });
        _accessTier = DefineProperty<StorageAccountAccessTier>(nameof(AccessTier), new string[] { "accessTier" });
        _networkRuleSet = DefineModelProperty<StorageAccountNetworkRuleSet>(nameof(NetworkRuleSet), new string[] { "networkAcls" });

        _privateEndpointConnectionResources = DefineListProperty<StoragePrivateEndpointConnection>(nameof(PrivateEndpointConnectionResources), new string[] { "privateEndpointConnections" }, isOutput: true, isRequired: false);
        _privateEndpointConnections = DefineListProperty<StoragePrivateEndpointConnectionData>(nameof(PrivateEndpointConnections), new string[] { "privateEndpointConnections" }, isOutput: true, isRequired: false);

#pragma warning disable CS0618 // Compatibility property registration intentionally uses the obsolete shipped enum.
        _legacyProvisioningState = DefineProperty<StorageProvisioningState>(nameof(LegacyProvisioningState), new string[] { "provisioningState" }, isOutput: true);
#pragma warning restore CS0618
    }
}
