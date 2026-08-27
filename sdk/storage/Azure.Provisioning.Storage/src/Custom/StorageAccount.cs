// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Storage;

public partial class StorageAccount : ProvisionableResource
{
    public static partial class ResourceVersions
    {
        /// <summary>2024-01-01.</summary>
        public static readonly string V2024_01_01 = "2024-01-01";
        /// <summary>2023-05-01.</summary>
        public static readonly string V2023_05_01 = "2023-05-01";
        /// <summary>2023-04-01.</summary>
        public static readonly string V2023_04_01 = "2023-04-01";
        /// <summary>2023-01-01.</summary>
        public static readonly string V2023_01_01 = "2023-01-01";
        /// <summary>2022-09-01.</summary>
        public static readonly string V2022_09_01 = "2022-09-01";
        /// <summary>2022-05-01.</summary>
        public static readonly string V2022_05_01 = "2022-05-01";
        /// <summary>2021-09-01.</summary>
        public static readonly string V2021_09_01 = "2021-09-01";
        /// <summary>2021-08-01.</summary>
        public static readonly string V2021_08_01 = "2021-08-01";
        /// <summary>2021-06-01.</summary>
        public static readonly string V2021_06_01 = "2021-06-01";
        /// <summary>2021-05-01.</summary>
        public static readonly string V2021_05_01 = "2021-05-01";
        /// <summary>2021-04-01.</summary>
        public static readonly string V2021_04_01 = "2021-04-01";
        /// <summary>2021-02-01.</summary>
        public static readonly string V2021_02_01 = "2021-02-01";
        /// <summary>2021-01-01.</summary>
        public static readonly string V2021_01_01 = "2021-01-01";
        /// <summary>2019-06-01.</summary>
        public static readonly string V2019_06_01 = "2019-06-01";
        /// <summary>2019-04-01.</summary>
        public static readonly string V2019_04_01 = "2019-04-01";
        /// <summary>2018-11-01.</summary>
        public static readonly string V2018_11_01 = "2018-11-01";
        /// <summary>2018-07-01.</summary>
        public static readonly string V2018_07_01 = "2018-07-01";
        /// <summary>2018-02-01.</summary>
        public static readonly string V2018_02_01 = "2018-02-01";
        /// <summary>2017-10-01.</summary>
        public static readonly string V2017_10_01 = "2017-10-01";
        /// <summary>2017-06-01.</summary>
        public static readonly string V2017_06_01 = "2017-06-01";
        /// <summary>2016-12-01.</summary>
        public static readonly string V2016_12_01 = "2016-12-01";
        /// <summary>2016-05-01.</summary>
        public static readonly string V2016_05_01 = "2016-05-01";
        /// <summary>2016-01-01.</summary>
        public static readonly string V2016_01_01 = "2016-01-01";
        /// <summary>2015-06-15.</summary>
        public static readonly string V2015_06_15 = "2015-06-15";
    }

    // TypeSpec names the flattened resource list PrivateEndpointConnections, while the shipped new API uses PrivateEndpointConnectionResources.
    /// <summary> Gets the private endpoint connection resources associated with the storage account. </summary>
    public BicepList<StoragePrivateEndpointConnection> PrivateEndpointConnectionResources
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            return Properties.PrivateEndpointConnectionResources;
        }
    }

    // Preserve the shipped old data-model list separately from the generated resource-list type.
    /// <summary> Gets the private endpoint connections associated with the storage account. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsoleted and will be removed in a future version. Please use PrivateEndpointConnectionResources instead.")]
    public BicepList<StoragePrivateEndpointConnectionData> PrivateEndpointConnections
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StorageAccountProperties();
            }
            return Properties.PrivateEndpointConnections;
        }
    }

    /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsoleted and will be removed in a future version. Please use StorageAccountProvisioningState instead.")]
#pragma warning disable CS0618 // Compatibility property intentionally uses the obsolete shipped enum.
    public BicepValue<StorageProvisioningState> ProvisioningState
#pragma warning restore CS0618
    {
        get
        {
            Properties ??= new StorageAccountProperties();
            return Properties.LegacyProvisioningState;
        }
    }

    /// <summary> Gets the status of the storage account at the time the operation was called. </summary>
    [CodeGenMember("ProvisioningState")]
    public BicepValue<StorageAccountProvisioningState> StorageAccountProvisioningState
    {
        get
        {
            Properties ??= new StorageAccountProperties();
            return Properties.ProvisioningState;
        }
    }

    /// <summary> Gets or sets the custom domain assigned to this storage account. </summary>
    [CodeGenMember("CustomDomain")]
    public StorageCustomDomain CustomDomain
    {
        get => Properties is null ? default! : Properties.CustomDomain;
        set
        {
            Properties ??= new StorageAccountProperties();
            Properties.CustomDomain = value;
        }
    }

    /// <summary> Gets or sets the SAS policy assigned to the storage account. </summary>
    [CodeGenMember("SasPolicy")]
    public StorageAccountSasPolicy SasPolicy
    {
        get => Properties is null ? default! : Properties.SasPolicy;
        set
        {
            Properties ??= new StorageAccountProperties();
            Properties.SasPolicy = value;
        }
    }

    /// <summary> Gets or sets the encryption settings on the storage account. </summary>
    [CodeGenMember("Encryption")]
    public StorageAccountEncryption Encryption
    {
        get => Properties is null ? default! : Properties.Encryption;
        set
        {
            Properties ??= new StorageAccountProperties();
            Properties.Encryption = value;
        }
    }

    /// <summary> Gets or sets the access tier. </summary>
    [CodeGenMember("AccessTier")]
    public BicepValue<StorageAccountAccessTier> AccessTier
    {
        get
        {
            Properties ??= new StorageAccountProperties();
            return Properties.AccessTier;
        }
        set
        {
            Properties ??= new StorageAccountProperties();
            Properties.AccessTier = value;
        }
    }

    /// <summary> Gets or sets the network rule set. </summary>
    [CodeGenMember("NetworkRuleSet")]
    public StorageAccountNetworkRuleSet NetworkRuleSet
    {
        get => Properties is null ? default! : Properties.NetworkRuleSet;
        set
        {
            Properties ??= new StorageAccountProperties();
            Properties.NetworkRuleSet = value;
        }
    }

    /// <summary> Gets or sets the key expiration period in days. </summary>
    [CodeGenMember("KeyExpirationPeriodInDays")]
    public BicepValue<int> KeyExpirationPeriodInDays
    {
        get
        {
            Properties ??= new StorageAccountProperties();
            return Properties.KeyExpirationPeriodInDays;
        }
        set
        {
            Properties ??= new StorageAccountProperties();
            Properties.KeyExpirationPeriodInDays = value;
        }
    }

    // Provisioning generation does not emit custom ARM actions yet. Keep the shipped listKeys helper
    // until the generator can produce it: https://github.com/Azure/azure-sdk-for-net/issues/56753.
    /// <summary>
    /// Get access keys for this StorageAccount resource.
    /// </summary>
    /// <returns>The keys for this StorageAccount resource.</returns>
    public BicepList<StorageAccountKey> GetKeys()
    {
        return BicepList<StorageAccountKey>.FromExpression(
            expression =>
            {
                StorageAccountKey key = new();
                ((IBicepValue)key).Expression = expression;
                return key;
            },
            new MemberExpression(
                new FunctionCallExpression(
                    new MemberExpression(
                        new IdentifierExpression(BicepIdentifier),
                        "listKeys")),
                "keys"));
    }
}
