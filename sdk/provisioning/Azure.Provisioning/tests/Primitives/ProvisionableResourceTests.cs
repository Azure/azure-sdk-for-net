// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Primitives
{
    public class ProvisionableResourceTests
    {
        [Test]
        public void ValidateNormalProperties()
        {
            using var test = new StandaloneTrycep();

            test.Define(
                ctx =>
                {
                    Infrastructure infra = new();

                    // Create our comprehensive test resource with various property types
                    var testResource = new TestResource("testResource")
                    {
                        // Test basic string property
                        Name = "test-name",

                        // Test location property
                        Location = AzureLocation.WestUS2,

                        // Test enum property
                        TestKind = TestResourceKind.Standard,

                        // Test boolean properties
                        IsEnabled = true,
                        AllowPublicAccess = false,

                        // Test integer property
                        MaxConnections = 100,

                        // Test complex object property
                        Configuration = new TestConfiguration
                        {
                            Timeout = 30,
                            RetryCount = 3,
                            IsSecure = true
                        },

                        // Test dictionary property
                        Tags = new BicepDictionary<string>
                        {
                            ["Environment"] = "Test",
                            ["Owner"] = "TestTeam"
                        },

                        // Test list property
                        AllowedIPs = ["192.168.1.0/24", "10.0.0.0/8"],

                        // Test list of models property
                        NetworkRules =
                        [
                            new NetworkRule
                            {
                                Name = "allow-web",
                                Protocol = NetworkProtocol.Https,
                                Port = 443,
                                IsEnabled = true
                            },
                            new NetworkRule
                            {
                                Name = "allow-ssh",
                                Protocol = NetworkProtocol.Tcp,
                                Port = 22,
                                IsEnabled = false
                            }
                        ]
                    };

                    infra.Add(testResource);
                    return infra;
                })
                .Compare(
                    """
                    resource testResource 'Test.Provider/testResources@2024-01-01' = {
                      name: 'test-name'
                      location: 'westus2'
                      properties: {
                        kind: 'Standard'
                        isEnabled: true
                        allowPublicAccess: false
                        maxConnections: 100
                        configuration: {
                          timeout: 30
                          retryCount: 3
                          isSecure: true
                        }
                        allowedIPs: [
                          '192.168.1.0/24'
                          '10.0.0.0/8'
                        ]
                        networkRules: [
                          {
                            name: 'allow-web'
                            protocol: 'Https'
                            port: 443
                            isEnabled: true
                          }
                          {
                            name: 'allow-ssh'
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

        /// <summary>
        /// Private nested class that implements a comprehensive test resource
        /// to validate various property types supported by the library
        /// </summary>
        private class TestResource : ProvisionableResource
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
            public BicepValue<TestResourceKind> TestKind
            {
                get { Initialize(); return _testKind!; }
                set { Initialize(); _testKind!.Assign(value); }
            }
            private BicepValue<TestResourceKind>? _testKind;

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
            public TestConfiguration Configuration
            {
                get { Initialize(); return _configuration!; }
                set { Initialize(); AssignOrReplace(ref _configuration, value); }
            }
            private TestConfiguration? _configuration;

            // Dictionary property
            public BicepDictionary<string> Tags
            {
                get { Initialize(); return _tags!; }
                set { Initialize(); _tags!.Assign(value); }
            }
            private BicepDictionary<string>? _tags;

            // List property
            public BicepList<string> AllowedIPs
            {
                get { Initialize(); return _allowedIPs!; }
                set { Initialize(); _allowedIPs!.Assign(value); }
            }
            private BicepList<string>? _allowedIPs;

            // List of models property
            public BicepList<NetworkRule> NetworkRules
            {
                get { Initialize(); return _networkRules!; }
                set { Initialize(); _networkRules!.Assign(value); }
            }
            private BicepList<NetworkRule>? _networkRules;

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

            public TestResource(string bicepIdentifier, string? resourceVersion = default)
                : base(bicepIdentifier, "Test.Provider/testResources", resourceVersion ?? "2024-01-01")
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                // Define all properties with their Bicep paths
                _name = DefineProperty<string>("Name", ["name"], isRequired: true);
                _location = DefineProperty<AzureLocation>("Location", ["location"], isRequired: true);
                _testKind = DefineProperty<TestResourceKind>("TestKind", ["properties", "kind"]);
                _isEnabled = DefineProperty<bool>("IsEnabled", ["properties", "isEnabled"]);
                _allowPublicAccess = DefineProperty<bool>("AllowPublicAccess", ["properties", "allowPublicAccess"]);
                _maxConnections = DefineProperty<int>("MaxConnections", ["properties", "maxConnections"]);
                _configuration = DefineModelProperty<TestConfiguration>("Configuration", ["properties", "configuration"]);
                _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
                _allowedIPs = DefineListProperty<string>("AllowedIPs", ["properties", "allowedIPs"]);
                _networkRules = DefineListProperty<NetworkRule>("NetworkRules", ["properties", "networkRules"]);

                // Output-only properties
                _id = DefineProperty<ResourceIdentifier>("Id", ["id"], isOutput: true);
                _provisioningState = DefineProperty<string>("ProvisioningState", ["properties", "provisioningState"], isOutput: true);
            }
        }

        /// <summary>
        /// Test enum for resource kind
        /// </summary>
        private enum TestResourceKind
        {
            Basic,
            Standard,
            Premium
        }

        /// <summary>
        /// Test configuration object for complex property testing
        /// </summary>
        private class TestConfiguration : ProvisionableConstruct
        {
            public BicepValue<int> Timeout
            {
                get { Initialize(); return _timeout!; }
                set { Initialize(); _timeout!.Assign(value); }
            }
            private BicepValue<int>? _timeout;

            public BicepValue<int> RetryCount
            {
                get { Initialize(); return _retryCount!; }
                set { Initialize(); _retryCount!.Assign(value); }
            }
            private BicepValue<int>? _retryCount;

            public BicepValue<bool> IsSecure
            {
                get { Initialize(); return _isSecure!; }
                set { Initialize(); _isSecure!.Assign(value); }
            }
            private BicepValue<bool>? _isSecure;

            public TestConfiguration()
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                _timeout = DefineProperty<int>("Timeout", ["timeout"]);
                _retryCount = DefineProperty<int>("RetryCount", ["retryCount"]);
                _isSecure = DefineProperty<bool>("IsSecure", ["isSecure"]);
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
        /// Test network rule model for list of models property testing
        /// </summary>
        private class NetworkRule : ProvisionableConstruct
        {
            public BicepValue<string> Name
            {
                get { Initialize(); return _name!; }
                set { Initialize(); _name!.Assign(value); }
            }
            private BicepValue<string>? _name;

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

            public NetworkRule()
            {
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();

                _name = DefineProperty<string>("Name", ["name"]);
                _protocol = DefineProperty<NetworkProtocol>("Protocol", ["protocol"]);
                _port = DefineProperty<int>("Port", ["port"]);
                _isEnabled = DefineProperty<bool>("IsEnabled", ["isEnabled"]);
            }
        }
    }
}
