// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Azure.Management.HybridCompute.Models;
using Microsoft.Azure.Management.HybridCompute.Tests.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.HybridCompute.Tests
{
    public class HybridMachineExtensionTests : TestBase,IDisposable
    {
        private const string CUSTOM_SCRIPT_EXTENSION_NAME = "customScript";
        private const string DEPENDENCY_AGENT_EXTENSION_NAME = "dependencyAgent";
        private readonly MockContext _context;

        private HybridComputeManagementClient _client;
        private Machine _machine;
        private string _resourceGroupName;
        private string _machineName;
        private bool _isLinux;

        public HybridMachineExtensionTests()
        {
            _context = MockContext.Start(GetType().FullName);
        }

        private void Initialize()
        {
            _client = this.GetHybridComputeManagementClient(_context);
            foreach (Machine machine in _client.Machines.ListBySubscription())
            {
                if (machine.Status == "Connected" && machine.Extensions.Count == 0)
                {
                    _machine = machine;

                    // Get resource group name
                    machine.Id.Split("resourceGroups/")[1].Split("/providers");
                    _resourceGroupName = new Regex("resourceGroups/(.*)/providers").Match(machine.Id).Groups[1].Value;

                    // save additional useful properties
                    _machineName = machine.Name;
                    _isLinux = _machine.OsName.IndexOf("linux", StringComparison.OrdinalIgnoreCase) >= 0;
                    break;
                }
            }
        }

        private void PopulateExtensions()
        {
            // Create two extensions
            if (_isLinux)
            {
                MachineExtension extension = new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "2.1",
                    Publisher = "Microsoft.Compute.Extensions",
                    MachineExtensionType = "CustomScript",
                };
                _client.MachineExtensions.CreateOrUpdate(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME, extension);

                extension = new MachineExtension
                {
                    Location = _machine.Location,
                    Publisher = "Microsoft.Azure.Monitoring.DependencyAgent",
                    MachineExtensionType = "DependencyAgentLinux",
                };
                _client.MachineExtensions.CreateOrUpdate(_resourceGroupName, _machineName, DEPENDENCY_AGENT_EXTENSION_NAME, extension);
            }
            else
            {
                MachineExtension extension = new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                };
                _client.MachineExtensions.CreateOrUpdate(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME, extension);

                extension = new MachineExtension
                {
                    Location = _machine.Location,
                    Publisher = "Microsoft.Azure.Monitoring.DependencyAgent",
                    MachineExtensionType = "DependencyAgentWindows",
                };
                _client.MachineExtensions.CreateOrUpdate(_resourceGroupName, _machineName, DEPENDENCY_AGENT_EXTENSION_NAME, extension);
            }
        }

        public void Dispose()
        {
            foreach (MachineExtension extension in _client.MachineExtensions.List(_resourceGroupName, _machineName))
            {
                _client.MachineExtensions.Delete(_resourceGroupName, _machineName, extension.Name);
            }
            _context.Dispose();
        }

        [Fact]
        public void MachineExtensions_Get()
        {
            Initialize();
            PopulateExtensions();
            MachineExtension extension = _client.MachineExtensions.Get(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME);
            Assert.Equal(CUSTOM_SCRIPT_EXTENSION_NAME, extension.Name);
            Assert.Equal(_machine.Location, extension.Location);
            Assert.NotNull(extension.Settings);
        }

        [Fact]
        public async Task MachineExtensions_GetAsync()
        {
            Initialize();
            PopulateExtensions();
            MachineExtension extension = await _client.MachineExtensions.GetAsync(_resourceGroupName, _machineName, DEPENDENCY_AGENT_EXTENSION_NAME).ConfigureAwait(false);
            Assert.Equal(DEPENDENCY_AGENT_EXTENSION_NAME, extension.Name);
            Assert.Equal(_machine.Location, extension.Location);
            Assert.Equal("Microsoft.Azure.Monitoring.DependencyAgent", extension.Publisher);
        }

        [Fact]
        public void MachineExtensions_List()
        {
            Initialize();
            PopulateExtensions();
            IPage<MachineExtension> extensions = _client.MachineExtensions.List(_resourceGroupName, _machineName);
            Assert.Collection(extensions,
                customScript => {
                    Assert.Equal(CUSTOM_SCRIPT_EXTENSION_NAME, customScript.Name);
                    Assert.Equal(_machine.Location, customScript.Location);
                    Assert.NotNull(customScript.Settings);
                },
                dependencyAgent => {
                    Assert.Equal(DEPENDENCY_AGENT_EXTENSION_NAME, dependencyAgent.Name);
                    Assert.Equal(_machine.Location, dependencyAgent.Location);
                    Assert.Equal("Microsoft.Azure.Monitoring.DependencyAgent", dependencyAgent.Publisher);
                });
        }

        [Fact]
        public async Task MachineExtensions_ListAsync()
        {
            Initialize();
            PopulateExtensions();
            IPage<MachineExtension> extensions = await _client.MachineExtensions.ListAsync(_resourceGroupName, _machineName).ConfigureAwait(false);
            Assert.Collection(extensions,
                customScript => {
                    Assert.Equal(CUSTOM_SCRIPT_EXTENSION_NAME, customScript.Name);
                    Assert.Equal(_machine.Location, customScript.Location);
                    Assert.NotNull(customScript.Settings);
                },
                dependencyAgent => {
                    Assert.Equal(DEPENDENCY_AGENT_EXTENSION_NAME, dependencyAgent.Name);
                    Assert.Equal(_machine.Location, dependencyAgent.Location);
                    Assert.Equal("Microsoft.Azure.Monitoring.DependencyAgent", dependencyAgent.Publisher);
                });
        }

        [Fact]
        public void MachineExtensions_CreateOrUpdate()
        {
            Initialize();
            const string extensionName = "custom";

            MachineExtension extension = _isLinux
                ? new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                }
                : new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                };

            MachineExtension extensionFromCreate = _client.MachineExtensions.CreateOrUpdate(_resourceGroupName, _machineName, extensionName, extension);
            Assert.Equal(extensionName, extensionFromCreate.Name);
            Assert.Equal(_machine.Location, extensionFromCreate.Location);
            Assert.Equal("echo 'hi'", ((IDictionary) extensionFromCreate.Settings)["commandToExecute"]);

            MachineExtension extensionFromGet = _client.MachineExtensions.Get(_resourceGroupName, _machineName, extensionName);
            Assert.Equal(extensionName, extensionFromGet.Name);
            Assert.Equal(_machine.Location, extensionFromGet.Location);
            Assert.Equal("echo 'hi'", ((IDictionary) extensionFromGet.Settings)["commandToExecute"]);
        }

        [Fact]
        public async Task MachineExtensions_CreateOrUpdateAsync()
        {
            Initialize();
            const string extensionName = "custom";

            MachineExtension extension = _isLinux
                ? new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                }
                : new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                };

            MachineExtension extensionFromCreate = await _client.MachineExtensions.CreateOrUpdateAsync(_resourceGroupName, _machineName, extensionName, extension).ConfigureAwait(false);
            Assert.Equal(extensionName, extensionFromCreate.Name);
            Assert.Equal(_machine.Location, extensionFromCreate.Location);
            Assert.Equal("echo 'hi'", ((IDictionary) extensionFromCreate.Settings)["commandToExecute"]);

            MachineExtension extensionFromGet = await _client.MachineExtensions.GetAsync(_resourceGroupName, _machineName, extensionName).ConfigureAwait(false);
            Assert.Equal(extensionName, extensionFromGet.Name);
            Assert.Equal(_machine.Location, extensionFromGet.Location);
            Assert.Equal("echo 'hi'", ((IDictionary) extensionFromGet.Settings)["commandToExecute"]);
        }

        [Fact]
        public void MachineExtensions_Delete()
        {
            Initialize();
            PopulateExtensions();
            _client.MachineExtensions.Delete(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME);
            Assert.Throws<Exception>(() => _client.MachineExtensions.Get(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME));
        }

        [Fact]
        public async Task MachineExtensions_DeleteAsync()
        {
            Initialize();
            PopulateExtensions();
            await _client.MachineExtensions.DeleteAsync(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME).ConfigureAwait(false);
            Assert.Throws<Exception>(() => _client.MachineExtensions.Get(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME));
        }

        [Fact]
        public void MachineExtensions_Update()
        {
            Initialize();
            PopulateExtensions();
            const string newCommand = "echo 'goodbye'";
            MachineExtensionUpdate extensionUpdate = _isLinux
                ? new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                }
                : new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                };

            MachineExtension extension = _client.MachineExtensions.Update(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME, extensionUpdate);
            Assert.Equal(newCommand, ((IDictionary) extension.Settings)["commandToExecute"]);
        }

        [Fact]
        public async Task MachineExtensions_UpdateAsync()
        {
            Initialize();
            PopulateExtensions();
            const string newCommand = "echo 'goodbye'";
            MachineExtensionUpdate extensionUpdate = _isLinux
                ? new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                }
                : new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                };

            MachineExtension extension = await _client.MachineExtensions.UpdateAsync(_resourceGroupName, _machineName, CUSTOM_SCRIPT_EXTENSION_NAME, extensionUpdate).ConfigureAwait(false);
            Assert.Equal(newCommand, ((IDictionary) extension.Settings)["commandToExecute"]);
        }
    }
}
