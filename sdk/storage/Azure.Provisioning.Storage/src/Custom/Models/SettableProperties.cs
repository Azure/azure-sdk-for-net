// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Storage;

public partial class BlobRestoreContent
{
    // TypeSpec marks restore inputs as read-only. Preserve the shipped setters because these
    // values are required when authoring a restore request.
    private BicepValue<DateTimeOffset> _compatTimeToRestore;
    private BicepList<BlobRestoreRange> _compatBlobRanges;

    /// <summary> Gets or sets the restore point. </summary>
    public BicepValue<DateTimeOffset> TimeToRestore
    {
        get { Initialize(); return _compatTimeToRestore; }
        set { Initialize(); _compatTimeToRestore.Assign(value); }
    }

    /// <summary> Gets or sets the blob ranges to restore. </summary>
    public BicepList<BlobRestoreRange> BlobRanges
    {
        get { Initialize(); return _compatBlobRanges; }
        set { Initialize(); _compatBlobRanges.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatTimeToRestore = DefineProperty<DateTimeOffset>(nameof(TimeToRestore), ["timeToRestore"], format: "O");
        _compatBlobRanges = DefineListProperty<BlobRestoreRange>(nameof(BlobRanges), ["blobRanges"]);
    }
}

public partial class BlobRestoreRange
{
    // TypeSpec marks restore range bounds as read-only. Preserve the shipped setters so callers
    // can continue constructing restore ranges.
    private BicepValue<string> _compatStartRange;
    private BicepValue<string> _compatEndRange;

    /// <summary> Gets or sets the start of the restore range. </summary>
    public BicepValue<string> StartRange
    {
        get { Initialize(); return _compatStartRange; }
        set { Initialize(); _compatStartRange.Assign(value); }
    }

    /// <summary> Gets or sets the end of the restore range. </summary>
    public BicepValue<string> EndRange
    {
        get { Initialize(); return _compatEndRange; }
        set { Initialize(); _compatEndRange.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatStartRange = DefineProperty<string>(nameof(StartRange), ["startRange"]);
        _compatEndRange = DefineProperty<string>(nameof(EndRange), ["endRange"]);
    }
}

internal partial class StorageAccountProperties
{
    // TypeSpec marks these authoring properties as response-only and emits a new nested alias.
    // Preserve the shipped setters and IsBlobEnabled name while keeping one properties object.
    private BicepValue<StorageAccountAccessTier> _compatAccessTier;
    private StorageCustomDomain _compatCustomDomain;
    private StorageAccountEncryption _compatEncryption;
    private BicepValue<bool> _compatIsBlobEnabled;
    private BicepValue<int> _compatKeyExpirationPeriodInDays;
    private StorageAccountNetworkRuleSet _compatNetworkRuleSet;
    private StorageAccountSasPolicy _compatSasPolicy;

    public BicepValue<StorageAccountAccessTier> AccessTier
    {
        get { Initialize(); return _compatAccessTier; }
        set { Initialize(); _compatAccessTier.Assign(value); }
    }

    public StorageCustomDomain CustomDomain
    {
        get { Initialize(); return _compatCustomDomain; }
        set { Initialize(); AssignOrReplace(ref _compatCustomDomain, value); }
    }

    public StorageAccountEncryption Encryption
    {
        get { Initialize(); return _compatEncryption; }
        set { Initialize(); AssignOrReplace(ref _compatEncryption, value); }
    }

    public BicepValue<bool> IsBlobEnabled
    {
        get { Initialize(); return _compatIsBlobEnabled; }
        set { Initialize(); _compatIsBlobEnabled.Assign(value); }
    }

    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get { Initialize(); return _compatKeyExpirationPeriodInDays; }
        set { Initialize(); _compatKeyExpirationPeriodInDays.Assign(value); }
    }

    public StorageAccountNetworkRuleSet NetworkRuleSet
    {
        get { Initialize(); return _compatNetworkRuleSet; }
        set { Initialize(); AssignOrReplace(ref _compatNetworkRuleSet, value); }
    }

    public StorageAccountSasPolicy SasPolicy
    {
        get { Initialize(); return _compatSasPolicy; }
        set { Initialize(); AssignOrReplace(ref _compatSasPolicy, value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatAccessTier = DefineProperty<StorageAccountAccessTier>(nameof(AccessTier), ["accessTier"]);
        _compatCustomDomain = DefineModelProperty<StorageCustomDomain>(nameof(CustomDomain), ["customDomain"]);
        _compatEncryption = DefineModelProperty<StorageAccountEncryption>(nameof(Encryption), ["encryption"]);
        _compatIsBlobEnabled = DefineProperty<bool>(nameof(IsBlobEnabled), ["geoPriorityReplicationStatus", "isBlobEnabled"]);
        _compatKeyExpirationPeriodInDays = DefineProperty<int>(nameof(KeyExpirationPeriodInDays), ["keyPolicy", "keyExpirationPeriodInDays"]);
        _compatNetworkRuleSet = DefineModelProperty<StorageAccountNetworkRuleSet>(nameof(NetworkRuleSet), ["networkAcls"]);
        _compatSasPolicy = DefineModelProperty<StorageAccountSasPolicy>(nameof(SasPolicy), ["sasPolicy"]);

        // TypeSpec follows service-model declaration order. Reinsert properties in the order
        // emitted by the previous provisioning generator to preserve stable Bicep output.
        string[] propertyOrder =
        [
            "AccessTier",
            "AllowBlobPublicAccess",
            "AllowCrossTenantReplication",
            "AllowedCopyScope",
            "AllowSharedKeyAccess",
            "AzureFilesIdentityBasedAuthentication",
            "CustomDomain",
            "DnsEndpointType",
            "EnableHttpsTrafficOnly",
            "Encryption",
            "ImmutableStorageWithVersioning",
            "IsBlobEnabled",
            "IsDefaultToOAuthAuthentication",
            "IsExtendedGroupEnabled",
            "IsHnsEnabled",
            "IsIPv6EndpointToBePublished",
            "IsLocalUserEnabled",
            "IsNfsV3Enabled",
            "IsSftpEnabled",
            "KeyExpirationPeriodInDays",
            "LargeFileSharesState",
            "MinimumTlsVersion",
            "NetworkRuleSet",
            "PublicNetworkAccess",
            "RoutingPreference",
            "SasPolicy"
        ];
        Dictionary<string, IBicepValue> properties = new(ProvisionableProperties);
        ProvisionableProperties.Clear();
        foreach (string propertyName in propertyOrder)
        {
            if (properties.TryGetValue(propertyName, out IBicepValue property))
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
}

public partial class StorageAccountEncryption
{
    // TypeSpec marks these encryption settings as response-only. Preserve the shipped setters
    // because provisioning callers author all five values.
    private StorageAccountEncryptionServices _compatServices;
    private BicepValue<StorageAccountKeySource> _compatKeySource;
    private BicepValue<bool> _compatRequireInfrastructureEncryption;
    private StorageAccountKeyVaultProperties _compatKeyVaultProperties;
    private StorageAccountEncryptionIdentity _compatEncryptionIdentity;

    /// <summary> Gets or sets the encryption services. </summary>
    public StorageAccountEncryptionServices Services
    {
        get { Initialize(); return _compatServices; }
        set { Initialize(); AssignOrReplace(ref _compatServices, value); }
    }

    /// <summary> Gets or sets the encryption key source. </summary>
    public BicepValue<StorageAccountKeySource> KeySource
    {
        get { Initialize(); return _compatKeySource; }
        set { Initialize(); _compatKeySource.Assign(value); }
    }

    /// <summary> Gets or sets whether infrastructure encryption is required. </summary>
    public BicepValue<bool> RequireInfrastructureEncryption
    {
        get { Initialize(); return _compatRequireInfrastructureEncryption; }
        set { Initialize(); _compatRequireInfrastructureEncryption.Assign(value); }
    }

    /// <summary> Gets or sets the key vault properties. </summary>
    public StorageAccountKeyVaultProperties KeyVaultProperties
    {
        get { Initialize(); return _compatKeyVaultProperties; }
        set { Initialize(); AssignOrReplace(ref _compatKeyVaultProperties, value); }
    }

    /// <summary> Gets or sets the encryption identity. </summary>
    public StorageAccountEncryptionIdentity EncryptionIdentity
    {
        get { Initialize(); return _compatEncryptionIdentity; }
        set { Initialize(); AssignOrReplace(ref _compatEncryptionIdentity, value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatServices = DefineModelProperty<StorageAccountEncryptionServices>(nameof(Services), ["services"]);
        _compatKeySource = DefineProperty<StorageAccountKeySource>(nameof(KeySource), ["keySource"]);
        _compatRequireInfrastructureEncryption = DefineProperty<bool>(nameof(RequireInfrastructureEncryption), ["requireInfrastructureEncryption"]);
        _compatKeyVaultProperties = DefineModelProperty<StorageAccountKeyVaultProperties>(nameof(KeyVaultProperties), ["keyvaultproperties"]);
        _compatEncryptionIdentity = DefineModelProperty<StorageAccountEncryptionIdentity>(nameof(EncryptionIdentity), ["identity"]);
    }
}

public partial class StorageAccountEncryptionIdentity
{
    // TypeSpec marks encryption identity inputs as read-only. Preserve their shipped setters.
    private BicepValue<string> _compatEncryptionUserAssignedIdentity;
    private BicepValue<string> _compatEncryptionFederatedIdentityClientId;

    /// <summary> Gets or sets the encryption user-assigned identity. </summary>
    public BicepValue<string> EncryptionUserAssignedIdentity
    {
        get { Initialize(); return _compatEncryptionUserAssignedIdentity; }
        set { Initialize(); _compatEncryptionUserAssignedIdentity.Assign(value); }
    }

    /// <summary> Gets or sets the encryption federated identity client identifier. </summary>
    public BicepValue<string> EncryptionFederatedIdentityClientId
    {
        get { Initialize(); return _compatEncryptionFederatedIdentityClientId; }
        set { Initialize(); _compatEncryptionFederatedIdentityClientId.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatEncryptionUserAssignedIdentity = DefineProperty<string>(nameof(EncryptionUserAssignedIdentity), ["userAssignedIdentity"]);
        _compatEncryptionFederatedIdentityClientId = DefineProperty<string>(nameof(EncryptionFederatedIdentityClientId), ["federatedIdentityClientId"]);
    }
}

public partial class StorageAccountEncryptionServices
{
    // TypeSpec marks service encryption models as read-only. Preserve the shipped setters used
    // to configure encryption independently for each storage service.
    private StorageEncryptionService _compatBlob;
    private StorageEncryptionService _compatFile;
    private StorageEncryptionService _compatTable;
    private StorageEncryptionService _compatQueue;

    /// <summary> Gets or sets blob encryption. </summary>
    public StorageEncryptionService Blob
    {
        get { Initialize(); return _compatBlob; }
        set { Initialize(); AssignOrReplace(ref _compatBlob, value); }
    }

    /// <summary> Gets or sets file encryption. </summary>
    public StorageEncryptionService File
    {
        get { Initialize(); return _compatFile; }
        set { Initialize(); AssignOrReplace(ref _compatFile, value); }
    }

    /// <summary> Gets or sets table encryption. </summary>
    public StorageEncryptionService Table
    {
        get { Initialize(); return _compatTable; }
        set { Initialize(); AssignOrReplace(ref _compatTable, value); }
    }

    /// <summary> Gets or sets queue encryption. </summary>
    public StorageEncryptionService Queue
    {
        get { Initialize(); return _compatQueue; }
        set { Initialize(); AssignOrReplace(ref _compatQueue, value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatBlob = DefineModelProperty<StorageEncryptionService>(nameof(Blob), ["blob"]);
        _compatFile = DefineModelProperty<StorageEncryptionService>(nameof(File), ["file"]);
        _compatTable = DefineModelProperty<StorageEncryptionService>(nameof(Table), ["table"]);
        _compatQueue = DefineModelProperty<StorageEncryptionService>(nameof(Queue), ["queue"]);
    }
}

public partial class StorageAccountIPRule
{
    // TypeSpec marks IP rule inputs as read-only. Preserve the shipped setters.
    private BicepValue<string> _compatIPAddressOrRange;
    private BicepValue<StorageAccountNetworkRuleAction> _compatAction;

    /// <summary> Gets or sets the IP address or range. </summary>
    public BicepValue<string> IPAddressOrRange
    {
        get { Initialize(); return _compatIPAddressOrRange; }
        set { Initialize(); _compatIPAddressOrRange.Assign(value); }
    }

    /// <summary> Gets or sets the network rule action. </summary>
    public BicepValue<StorageAccountNetworkRuleAction> Action
    {
        get { Initialize(); return _compatAction; }
        set { Initialize(); _compatAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatIPAddressOrRange = DefineProperty<string>(nameof(IPAddressOrRange), ["value"]);
        _compatAction = DefineProperty<StorageAccountNetworkRuleAction>(nameof(Action), ["action"]);
    }
}

public partial class StorageAccountKeyVaultProperties
{
    // TypeSpec marks key vault identifiers as read-only. Preserve the shipped setters used to
    // configure customer-managed keys.
    private BicepValue<string> _compatKeyName;
    private BicepValue<string> _compatKeyVersion;
    private BicepValue<Uri> _compatKeyVaultUri;

    /// <summary> Gets or sets the key name. </summary>
    public BicepValue<string> KeyName
    {
        get { Initialize(); return _compatKeyName; }
        set { Initialize(); _compatKeyName.Assign(value); }
    }

    /// <summary> Gets or sets the key version. </summary>
    public BicepValue<string> KeyVersion
    {
        get { Initialize(); return _compatKeyVersion; }
        set { Initialize(); _compatKeyVersion.Assign(value); }
    }

    /// <summary> Gets or sets the key vault URI. </summary>
    public BicepValue<Uri> KeyVaultUri
    {
        get { Initialize(); return _compatKeyVaultUri; }
        set { Initialize(); _compatKeyVaultUri.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatKeyName = DefineProperty<string>(nameof(KeyName), ["keyname"]);
        _compatKeyVersion = DefineProperty<string>(nameof(KeyVersion), ["keyversion"]);
        _compatKeyVaultUri = DefineProperty<Uri>(nameof(KeyVaultUri), ["keyvaulturi"]);
    }
}

public partial class StorageAccountNetworkRuleSet
{
    // TypeSpec marks network ACL inputs as read-only. Preserve all shipped setters and paths.
    private BicepValue<StorageNetworkBypass> _compatBypass;
    private BicepList<StorageAccountResourceAccessRule> _compatResourceAccessRules;
    private BicepList<StorageAccountVirtualNetworkRule> _compatVirtualNetworkRules;
    private BicepList<StorageAccountIPRule> _compatIPRules;
    private BicepList<StorageAccountIPRule> _compatIPv6Rules;
    private BicepValue<StorageNetworkDefaultAction> _compatDefaultAction;

    /// <summary> Gets or sets the services bypassing network rules. </summary>
    public BicepValue<StorageNetworkBypass> Bypass
    {
        get { Initialize(); return _compatBypass; }
        set { Initialize(); _compatBypass.Assign(value); }
    }

    /// <summary> Gets or sets resource access rules. </summary>
    public BicepList<StorageAccountResourceAccessRule> ResourceAccessRules
    {
        get { Initialize(); return _compatResourceAccessRules; }
        set { Initialize(); _compatResourceAccessRules.Assign(value); }
    }

    /// <summary> Gets or sets virtual network rules. </summary>
    public BicepList<StorageAccountVirtualNetworkRule> VirtualNetworkRules
    {
        get { Initialize(); return _compatVirtualNetworkRules; }
        set { Initialize(); _compatVirtualNetworkRules.Assign(value); }
    }

    /// <summary> Gets or sets IPv4 rules. </summary>
    public BicepList<StorageAccountIPRule> IPRules
    {
        get { Initialize(); return _compatIPRules; }
        set { Initialize(); _compatIPRules.Assign(value); }
    }

    /// <summary> Gets or sets IPv6 rules. </summary>
    public BicepList<StorageAccountIPRule> IPv6Rules
    {
        get { Initialize(); return _compatIPv6Rules; }
        set { Initialize(); _compatIPv6Rules.Assign(value); }
    }

    /// <summary> Gets or sets the default network action. </summary>
    public BicepValue<StorageNetworkDefaultAction> DefaultAction
    {
        get { Initialize(); return _compatDefaultAction; }
        set { Initialize(); _compatDefaultAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatBypass = DefineProperty<StorageNetworkBypass>(nameof(Bypass), ["bypass"]);
        _compatResourceAccessRules = DefineListProperty<StorageAccountResourceAccessRule>(nameof(ResourceAccessRules), ["resourceAccessRules"]);
        _compatVirtualNetworkRules = DefineListProperty<StorageAccountVirtualNetworkRule>(nameof(VirtualNetworkRules), ["virtualNetworkRules"]);
        _compatIPRules = DefineListProperty<StorageAccountIPRule>(nameof(IPRules), ["ipRules"]);
        _compatIPv6Rules = DefineListProperty<StorageAccountIPRule>(nameof(IPv6Rules), ["ipv6Rules"]);
        _compatDefaultAction = DefineProperty<StorageNetworkDefaultAction>(nameof(DefaultAction), ["defaultAction"]);
    }
}

public partial class StorageAccountResourceAccessRule
{
    // TypeSpec marks resource access rule inputs as read-only. Preserve the shipped setters.
    private BicepValue<Guid> _compatTenantId;
    private BicepValue<ResourceIdentifier> _compatResourceId;

    /// <summary> Gets or sets the tenant identifier. </summary>
    public BicepValue<Guid> TenantId
    {
        get { Initialize(); return _compatTenantId; }
        set { Initialize(); _compatTenantId.Assign(value); }
    }

    /// <summary> Gets or sets the resource identifier. </summary>
    public BicepValue<ResourceIdentifier> ResourceId
    {
        get { Initialize(); return _compatResourceId; }
        set { Initialize(); _compatResourceId.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatTenantId = DefineProperty<Guid>(nameof(TenantId), ["tenantId"]);
        _compatResourceId = DefineProperty<ResourceIdentifier>(nameof(ResourceId), ["resourceId"]);
    }
}

public partial class StorageAccountSasPolicy
{
    // TypeSpec marks SAS policy inputs as read-only. Preserve the shipped setters.
    private BicepValue<string> _compatSasExpirationPeriod;
    private BicepValue<ExpirationAction> _compatExpirationAction;

    /// <summary> Gets or sets the SAS expiration period. </summary>
    public BicepValue<string> SasExpirationPeriod
    {
        get { Initialize(); return _compatSasExpirationPeriod; }
        set { Initialize(); _compatSasExpirationPeriod.Assign(value); }
    }

    /// <summary> Gets or sets the SAS expiration action. </summary>
    public BicepValue<ExpirationAction> ExpirationAction
    {
        get { Initialize(); return _compatExpirationAction; }
        set { Initialize(); _compatExpirationAction.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatSasExpirationPeriod = DefineProperty<string>(nameof(SasExpirationPeriod), ["sasExpirationPeriod"]);
        _compatExpirationAction = DefineProperty<ExpirationAction>(nameof(ExpirationAction), ["expirationAction"]);
    }
}

public partial class StorageAccountVirtualNetworkRule
{
    // TypeSpec marks virtual network rule inputs as read-only. Preserve the shipped setters.
    private BicepValue<ResourceIdentifier> _compatVirtualNetworkResourceId;
    private BicepValue<StorageAccountNetworkRuleAction> _compatAction;
    private BicepValue<StorageAccountNetworkRuleState> _compatState;

    /// <summary> Gets or sets the virtual network resource identifier. </summary>
    public BicepValue<ResourceIdentifier> VirtualNetworkResourceId
    {
        get { Initialize(); return _compatVirtualNetworkResourceId; }
        set { Initialize(); _compatVirtualNetworkResourceId.Assign(value); }
    }

    /// <summary> Gets or sets the network rule action. </summary>
    public BicepValue<StorageAccountNetworkRuleAction> Action
    {
        get { Initialize(); return _compatAction; }
        set { Initialize(); _compatAction.Assign(value); }
    }

    /// <summary> Gets or sets the virtual network rule state. </summary>
    public BicepValue<StorageAccountNetworkRuleState> State
    {
        get { Initialize(); return _compatState; }
        set { Initialize(); _compatState.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatVirtualNetworkResourceId = DefineProperty<ResourceIdentifier>(nameof(VirtualNetworkResourceId), ["id"]);
        _compatAction = DefineProperty<StorageAccountNetworkRuleAction>(nameof(Action), ["action"]);
        _compatState = DefineProperty<StorageAccountNetworkRuleState>(nameof(State), ["state"]);
    }
}

public partial class StorageCustomDomain
{
    // TypeSpec marks custom domain inputs as read-only. Preserve the shipped setters.
    private BicepValue<string> _compatName;
    private BicepValue<bool> _compatIsUseSubDomainNameEnabled;

    /// <summary> Gets or sets the custom domain name. </summary>
    public BicepValue<string> Name
    {
        get { Initialize(); return _compatName; }
        set { Initialize(); _compatName.Assign(value); }
    }

    /// <summary> Gets or sets whether indirect CNAME validation is enabled. </summary>
    public BicepValue<bool> IsUseSubDomainNameEnabled
    {
        get { Initialize(); return _compatIsUseSubDomainNameEnabled; }
        set { Initialize(); _compatIsUseSubDomainNameEnabled.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatName = DefineProperty<string>(nameof(Name), ["name"]);
        _compatIsUseSubDomainNameEnabled = DefineProperty<bool>(nameof(IsUseSubDomainNameEnabled), ["useSubDomainName"]);
    }
}

public partial class StorageEncryptionService
{
    // TypeSpec marks encryption service inputs as read-only. Preserve the shipped setters.
    private BicepValue<bool> _compatIsEnabled;
    private BicepValue<StorageEncryptionKeyType> _compatKeyType;

    /// <summary> Gets or sets whether encryption is enabled. </summary>
    public BicepValue<bool> IsEnabled
    {
        get { Initialize(); return _compatIsEnabled; }
        set { Initialize(); _compatIsEnabled.Assign(value); }
    }

    /// <summary> Gets or sets the encryption key type. </summary>
    public BicepValue<StorageEncryptionKeyType> KeyType
    {
        get { Initialize(); return _compatKeyType; }
        set { Initialize(); _compatKeyType.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatIsEnabled = DefineProperty<bool>(nameof(IsEnabled), ["enabled"]);
        _compatKeyType = DefineProperty<StorageEncryptionKeyType>(nameof(KeyType), ["keyType"]);
    }
}

public partial class StorageSku
{
    // TypeSpec marks the SKU name as read-only. Preserve the shipped setter used by all
    // storage account provisioning examples.
    private BicepValue<StorageSkuName> _compatName;

    /// <summary> Gets or sets the SKU name. </summary>
    public BicepValue<StorageSkuName> Name
    {
        get { Initialize(); return _compatName; }
        set { Initialize(); _compatName.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _compatName = DefineProperty<StorageSkuName>(nameof(Name), ["name"]);
    }
}
