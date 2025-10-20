// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Primitives
{
    public class ProvisionableResourceTests
    {
        [Test]
        public async Task ValidateNormalProperties()
        {
            await using var test = new Trycep();

            test.Define(
                ctx =>
                {
                    Infrastructure infra = new();

                    // Create our comprehensive test resource with various property types
                    var storageAccount = new StorageAccount("storageAccount")
                    {
                        // Test basic string property
                        Name = "test-storage",

                        // Test location property
                        Location = AzureLocation.WestUS2,

                        // Test enum property
                        StorageTier = StorageTier.Standard,

                        // Test boolean properties
                        IsEnabled = true,
                        AllowPublicAccess = false,

                        // Test integer property
                        MaxConnections = 100,

                        // Test complex object property
                        StorageConfiguration = new StorageConfiguration
                        {
                            BackupRetentionDays = 30,
                            MaxRetryAttempts = 3,
                            EnableEncryption = true
                        },

                        // Test dictionary property
                        Tags = new BicepDictionary<string>
                        {
                            ["Environment"] = "Test",
                            ["Owner"] = "TestTeam"
                        },

                        // Test list property
                        AllowedSubnets = ["192.168.1.0/24", "10.0.0.0/8"],

                        // Test list of models property
                        AccessRules =
                        [
                            new AccessRule
                            {
                                RuleName = "allow-web",
                                Protocol = NetworkProtocol.Https,
                                Port = 443,
                                IsEnabled = true
                            },
                            new AccessRule
                            {
                                RuleName = "allow-ssh",
                                Protocol = NetworkProtocol.Tcp,
                                Port = 22,
                                IsEnabled = false
                            }
                        ]
                    };

                    infra.Add(storageAccount);
                    return infra;
                })
                .Compare(
                    """
                    resource storageAccount 'Test.Provider/storageAccounts@2024-01-01' = {
                      name: 'test-storage'
                      location: 'westus2'
                      properties: {
                        tier: 'Standard'
                        isEnabled: true
                        allowPublicAccess: false
                        maxConnections: 100
                        storageConfiguration: {
                          backupRetentionDays: 30
                          maxRetryAttempts: 3
                          enableEncryption: true
                        }
                        allowedSubnets: [
                          '192.168.1.0/24'
                          '10.0.0.0/8'
                        ]
                        accessRules: [
                          {
                            ruleName: 'allow-web'
                            protocol: 'Https'
                            port: 443
                            isEnabled: true
                          }
                          {
                            ruleName: 'allow-ssh'
                            protocol: 'Tcp'
                            port: 22
                            isEnabled: false
                          }
                        ]
                      }
                      tags: {
                        Environment: 'Test'
                        Owner: 'TestTeam'
                      }
                    }
                    """);
        }

        [Test]
        public async Task ValidateListProperties_Unset()
        {
            await using var test = new Trycep();

            test.Define(
                ctx =>
                {
                    Infrastructure infra = new();

                    // Create our comprehensive test resource with various property types
                    var storageAccount = new StorageAccount("storageAccount")
                    {
                        // Test basic string property
                        Name = "test-storage",

                        // Test location property
                        Location = AzureLocation.WestUS2,

                        // Test enum property
                        StorageTier = StorageTier.Standard
                    };

                    infra.Add(storageAccount);
                    return infra;
                })
                .Compare(
                    """
                    resource storageAccount 'Test.Provider/storageAccounts@2024-01-01' = {
                      name: 'test-storage'
                      location: 'westus2'
                      properties: {
                        tier: 'Standard'
                      }
                    }
                    """);
        }

        [Test]
        public async Task ValidateResourceReference()
        {
            await using var test = new Trycep();

            test.Define(
                ctx =>
                {
                    Infrastructure infra = new();

                    // Create a ComputeResource that references different StorageAccount instances
                    var computeResource = new ComputeResource("computeResource")
                    {
                        Name = "test-compute",
                        Location = AzureLocation.EastUS,
                        ComputeType = ComputeType.Virtual,
                        CpuCores = 4,
                        MemoryGB = 16,

                        // Reference to another resource - inline definition
                        PrimaryStorage = new StorageAccount("primaryStorage")
                        {
                            Name = "primary-storage",
                            Location = AzureLocation.EastUS,
                            StorageTier = StorageTier.Premium,
                            IsEnabled = true,
                            AllowPublicAccess = false,
                            MaxConnections = 200
                        },

                        // List of resource references - inline definitions
                        AdditionalStorages =
                        [
                            new StorageAccount("additionalStorage")
                            {
                                Name = "additional-storage",
                                Location = AzureLocation.EastUS,
                                StorageTier = StorageTier.Standard,
                                IsEnabled = true,
                                AllowPublicAccess = true,
                                MaxConnections = 150
                            }
                        ],

                        // Complex configuration with nested resource reference - inline definition
                        ComputeSettings = new ComputeSettings
                        {
                            EnableAutoShutdown = true,
                            MaxIdleMinutes = 30,
                            BackupStorage = new StorageAccount("backupStorage")
                            {
                                Name = "backup-storage",
                                Location = AzureLocation.EastUS,
                                StorageTier = StorageTier.Basic,
                                IsEnabled = false,
                                AllowPublicAccess = false,
                                MaxConnections = 100
                            }
                        }
                    };

                    infra.Add(computeResource);
                    return infra;
                })
                .Compare(
                    """
                    resource computeResource 'Test.Provider/computeResources@2024-01-01' = {
                      name: 'test-compute'
                      location: 'eastus'
                      properties: {
                        computeType: 'Virtual'
                        cpuCores: 4
                        memoryGB: 16
                        primaryStorage: {
                          name: 'primary-storage'
                          location: 'eastus'
                          properties: {
                            tier: 'Premium'
                            isEnabled: true
                            allowPublicAccess: false
                            maxConnections: 200
                          }
                        }
                        additionalStorages: [
                          {
                            name: 'additional-storage'
                            location: 'eastus'
                            properties: {
                              tier: 'Standard'
                              isEnabled: true
                              allowPublicAccess: true
                              maxConnections: 150
                            }
                          }
                        ]
                        computeSettings: {
                          enableAutoShutdown: true
                          maxIdleMinutes: 30
                          backupStorage: {
                            name: 'backup-storage'
                            location: 'eastus'
                            properties: {
                              tier: 'Basic'
                              isEnabled: false
                              allowPublicAccess: false
                              maxConnections: 100
                            }
                          }
                        }
                      }
                    }
                    """);
        }

        [Test]
        public async Task ValidateConstructFromBicepExpression_LowLevelApi()
        {
            await using var test = new Trycep();
            test.Define(
                ctx =>
                {
                    Infrastructure infra = new();
                    ProvisioningParameter useConfig = new(nameof(useConfig), typeof(bool))
                    {
                        Value = true
                    };
                    infra.Add(useConfig);
                    StorageAccount storageAccount = new(nameof(storageAccount), "2024-01-01")
                    {
                        Location = AzureLocation.CentralUS,
                        StorageTier = StorageTier.Standard,
                        IsEnabled = true,
                        AllowPublicAccess = false,
                        MaxConnections = 100,
                    };
                    // we would like to assign an expression to `storageAccount.StorageConfiguration`.
                    // but now we cannot do it in the normal way until this issue was fixed: https://github.com/Azure/azure-sdk-for-net/issues/52300
                    var config = (IBicepValue)storageAccount.StorageConfiguration;
                    IBicepValue configValue = new StorageConfiguration
                    {
                        BackupRetentionDays = 30,
                        MaxRetryAttempts = 3,
                        EnableEncryption = true
                    };
                    config.Expression = new ConditionalExpression(
                        new IdentifierExpression(useConfig.BicepIdentifier),
                        configValue.Compile(),
                        new NullLiteralExpression());
                    infra.Add(storageAccount);
                    return infra;
                })
                .Compare(
                    """
                    param useConfig bool = true

                    resource storageAccount 'Test.Provider/storageAccounts@2024-01-01' = {
                      name: take('storageaccount${uniqueString(resourceGroup().id)}', 24)
                      location: 'centralus'
                      properties: {
                        tier: 'Standard'
                        isEnabled: true
                        allowPublicAccess: false
                        maxConnections: 100
                        storageConfiguration: useConfig ? {
                          backupRetentionDays: 30
                          maxRetryAttempts: 3
                          enableEncryption: true
                        } : null
                      }
                    }
                    """);
        }

        /// <summary>
        /// Private nested class that implements a storage account resource
        /// to validate various property types supported by the library
        /// </summary>
        private class StorageAccount : ProvisionableResource
        {
            // Basic string property (required)
            public BicepValue<string> Name
            {
                get { Initialize(); return _name!; }
                set { Initialize(); _name!.Assign(value); }
            }
            private BicepValue<string>? _name;

            // Location property (required)
            public BicepValue<AzureLocation> Location
            {
                get { Initialize(); return _location!; }
                set { Initialize(); _location!.Assign(value); }
            }
            private BicepValue<AzureLocation>? _location;

            // Enum property
            public BicepValue<StorageTier> StorageTier
            {
                get { Initialize(); return _storageTier!; }
                set { Initialize(); _storageTier!.Assign(value); }
            }
            private BicepValue<StorageTier>? _storageTier;

            // Boolean properties
            public BicepValue<bool> IsEnabled
            {
                get { Initialize(); return _isEnabled!; }
                set { Initialize(); _isEnabled!.Assign(value); }
            }
            private BicepValue<bool>? _isEnabled;

            public BicepValue<bool> AllowPublicAccess
            {
                get { Initialize(); return _allowPublicAccess!; }
                set { Initialize(); _allowPublicAccess!.Assign(value); }
            }
            private BicepValue<bool>? _allowPublicAccess;

            // Integer property
            public BicepValue<int> MaxConnections
            {
                get { Initialize(); return _maxConnections!; }
                set { Initialize(); _maxConnections!.Assign(value); }
            }
            private BicepValue<int>? _maxConnections;

            // Complex object property
            public StorageConfiguration StorageConfiguration
            {
                get { Initialize(); return _storageConfiguration!; }
                set { Initialize(); AssignOrReplace(ref _storageConfiguration, value); }
            }
            private StorageConfiguration? _storageConfiguration;

            // Dictionary property
            public BicepDictionary<string> Tags
            {
                get { Initialize(); return _tags!; }
                set { Initialize(); _tags!.Assign(value); }
            }
            private BicepDictionary<string>? _tags;

            // List property
            public BicepList<string> AllowedSubnets
            {
                get { Initialize(); return _allowedSubnets!; }
                set { Initialize(); _allowedSubnets!.Assign(value); }
            }
            private BicepList<string>? _allowedSubnets;

            // List of models property
            public BicepList<AccessRule> AccessRules
            {
                get { Initialize(); return _accessRules!; }
                set { Initialize(); _accessRules!.Assign(value); }
            }
            private BicepList<AccessRule>? _accessRules;

            // Read-only output properties
            public BicepValue<ResourceIdentifier> Id
            {
                get { Initialize(); return _id!; }
            }
            private BicepValue<ResourceIdentifier>? _id;

            public BicepValue<string> ProvisioningState
            {
                get { Initialize(); return _provisioningState!; }
            }
            private BicepValue<string>? _provisioningState;

            public StorageAccount(string bicepIdentifier, string? resourceVersion = default)
                : base(bicepIdentifier, "Test.Provider/storageAccounts", resourceVersion ?? "2024-01-01")
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                // Define all properties with their Bicep paths
                _name = DefineProperty<string>("Name", ["name"], isRequired: true);
                _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
                _storageTier = DefineProperty<StorageTier>("StorageTier", ["properties", "tier"]);
                _isEnabled = DefineProperty<bool>("IsEnabled", ["properties", "isEnabled"]);
                _allowPublicAccess = DefineProperty<bool>("AllowPublicAccess", ["properties", "allowPublicAccess"]);
                _maxConnections = DefineProperty<int>("MaxConnections", ["properties", "maxConnections"]);
                _storageConfiguration = DefineModelProperty<StorageConfiguration>("StorageConfiguration", ["properties", "storageConfiguration"]);
                _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
                _allowedSubnets = DefineListProperty<string>("AllowedSubnets", ["properties", "allowedSubnets"]);
                _accessRules = DefineListProperty<AccessRule>("AccessRules", ["properties", "accessRules"]);

                // Output-only properties
                _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
                _provisioningState = DefineProperty<string>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);
            }
        }

        /// <summary>
        /// Test compute resource that references other resources
        /// </summary>
        private class ComputeResource : ProvisionableResource
        {
            // Basic string property (required)
            public BicepValue<string> Name
            {
                get { Initialize(); return _name!; }
                set { Initialize(); _name!.Assign(value); }
            }
            private BicepValue<string>? _name;

            // Location property (required)
            public BicepValue<AzureLocation> Location
            {
                get { Initialize(); return _location!; }
                set { Initialize(); _location!.Assign(value); }
            }
            private BicepValue<AzureLocation>? _location;

            // Enum property
            public BicepValue<ComputeType> ComputeType
            {
                get { Initialize(); return _computeType!; }
                set { Initialize(); _computeType!.Assign(value); }
            }
            private BicepValue<ComputeType>? _computeType;

            // Integer properties
            public BicepValue<int> CpuCores
            {
                get { Initialize(); return _cpuCores!; }
                set { Initialize(); _cpuCores!.Assign(value); }
            }
            private BicepValue<int>? _cpuCores;

            public BicepValue<int> MemoryGB
            {
                get { Initialize(); return _memoryGB!; }
                set { Initialize(); _memoryGB!.Assign(value); }
            }
            private BicepValue<int>? _memoryGB;

            // Resource reference property - use the resource type directly
            public StorageAccount PrimaryStorage
            {
                get { Initialize(); return _primaryStorage!; }
                set { Initialize(); AssignOrReplace(ref _primaryStorage, value); }
            }
            private StorageAccount? _primaryStorage;

            // List of resource references - use the resource type directly
            public BicepList<StorageAccount> AdditionalStorages
            {
                get { Initialize(); return _additionalStorages!; }
                set { Initialize(); _additionalStorages!.Assign(value); }
            }
            private BicepList<StorageAccount>? _additionalStorages;

            // Complex object with resource reference
            public ComputeSettings ComputeSettings
            {
                get { Initialize(); return _computeSettings!; }
                set { Initialize(); AssignOrReplace(ref _computeSettings, value); }
            }
            private ComputeSettings? _computeSettings;

            // Read-only output properties
            public BicepValue<ResourceIdentifier> Id
            {
                get { Initialize(); return _id!; }
            }
            private BicepValue<ResourceIdentifier>? _id;

            public ComputeResource(string bicepIdentifier, string? resourceVersion = default)
                : base(bicepIdentifier, "Test.Provider/computeResources", resourceVersion ?? "2024-01-01")
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                // Define all properties with their Bicep paths
                _name = DefineProperty<string>("Name", ["name"], isRequired: true);
                _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
                _computeType = DefineProperty<ComputeType>("ComputeType", ["properties", "computeType"]);
                _cpuCores = DefineProperty<int>("CpuCores", ["properties", "cpuCores"]);
                _memoryGB = DefineProperty<int>("MemoryGB", ["properties", "memoryGB"]);
                _primaryStorage = DefineModelProperty<StorageAccount>("PrimaryStorage", ["properties", "primaryStorage"], new StorageAccount("storageAccount"));
                _additionalStorages = DefineListProperty<StorageAccount>("AdditionalStorages", ["properties", "additionalStorages"]);
                _computeSettings = DefineModelProperty<ComputeSettings>("ComputeSettings", ["properties", "computeSettings"]);

                // Output-only properties
                _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
            }
        }

        /// <summary>
        /// Test enum for storage tier
        /// </summary>
        private enum StorageTier
        {
            Basic,
            Standard,
            Premium
        }

        /// <summary>
        /// Test enum for compute type
        /// </summary>
        private enum ComputeType
        {
            Container,
            Virtual,
            Serverless
        }

        /// <summary>
        /// Storage configuration object for complex property testing
        /// </summary>
        private class StorageConfiguration : ProvisionableConstruct
        {
            public BicepValue<int> BackupRetentionDays
            {
                get { Initialize(); return _backupRetentionDays!; }
                set { Initialize(); _backupRetentionDays!.Assign(value); }
            }
            private BicepValue<int>? _backupRetentionDays;

            public BicepValue<int> MaxRetryAttempts
            {
                get { Initialize(); return _maxRetryAttempts!; }
                set { Initialize(); _maxRetryAttempts!.Assign(value); }
            }
            private BicepValue<int>? _maxRetryAttempts;

            public BicepValue<bool> EnableEncryption
            {
                get { Initialize(); return _enableEncryption!; }
                set { Initialize(); _enableEncryption!.Assign(value); }
            }
            private BicepValue<bool>? _enableEncryption;

            public StorageConfiguration()
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                _backupRetentionDays = DefineProperty<int>("BackupRetentionDays", ["backupRetentionDays"]);
                _maxRetryAttempts = DefineProperty<int>("MaxRetryAttempts", ["maxRetryAttempts"]);
                _enableEncryption = DefineProperty<bool>("EnableEncryption", ["enableEncryption"]);
            }
        }

        /// <summary>
        /// Compute settings with resource reference
        /// </summary>
        private class ComputeSettings : ProvisionableConstruct
        {
            public BicepValue<bool> EnableAutoShutdown
            {
                get { Initialize(); return _enableAutoShutdown!; }
                set { Initialize(); _enableAutoShutdown!.Assign(value); }
            }
            private BicepValue<bool>? _enableAutoShutdown;

            public BicepValue<int> MaxIdleMinutes
            {
                get { Initialize(); return _maxIdleMinutes!; }
                set { Initialize(); _maxIdleMinutes!.Assign(value); }
            }
            private BicepValue<int>? _maxIdleMinutes;

            // Resource reference within a nested object - use the resource type directly
            public StorageAccount BackupStorage
            {
                get { Initialize(); return _backupStorage!; }
                set { Initialize(); AssignOrReplace(ref _backupStorage, value); }
            }
            private StorageAccount? _backupStorage;

            public ComputeSettings()
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                _enableAutoShutdown = DefineProperty<bool>("EnableAutoShutdown", ["enableAutoShutdown"]);
                _maxIdleMinutes = DefineProperty<int>("MaxIdleMinutes", ["maxIdleMinutes"]);
                _backupStorage = DefineModelProperty<StorageAccount>("BackupStorage", ["backupStorage"], new StorageAccount("storageAccount"));
            }
        }

        /// <summary>
        /// Test enum for network protocol
        /// </summary>
        private enum NetworkProtocol
        {
            Http,
            Https,
            Tcp,
            Udp
        }

        /// <summary>
        /// Access rule model for list of models property testing
        /// </summary>
        private class AccessRule : ProvisionableConstruct
        {
            public BicepValue<string> RuleName
            {
                get { Initialize(); return _ruleName!; }
                set { Initialize(); _ruleName!.Assign(value); }
            }
            private BicepValue<string>? _ruleName;

            public BicepValue<NetworkProtocol> Protocol
            {
                get { Initialize(); return _protocol!; }
                set { Initialize(); _protocol!.Assign(value); }
            }
            private BicepValue<NetworkProtocol>? _protocol;

            public BicepValue<int> Port
            {
                get { Initialize(); return _port!; }
                set { Initialize(); _port!.Assign(value); }
            }
            private BicepValue<int>? _port;

            public BicepValue<bool> IsEnabled
            {
                get { Initialize(); return _isEnabled!; }
                set { Initialize(); _isEnabled!.Assign(value); }
            }
            private BicepValue<bool>? _isEnabled;

            public AccessRule()
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                _ruleName = DefineProperty<string>("RuleName", ["ruleName"]);
                _protocol = DefineProperty<NetworkProtocol>("Protocol", ["protocol"]);
                _port = DefineProperty<int>("Port", ["port"]);
                _isEnabled = DefineProperty<bool>("IsEnabled", ["isEnabled"]);
            }
        }
    }
}
