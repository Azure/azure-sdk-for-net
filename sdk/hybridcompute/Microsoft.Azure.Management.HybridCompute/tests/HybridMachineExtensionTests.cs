// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.Azure.Management.HybridCompute.Models;
using Microsoft.Azure.Management.HybridCompute.Tests.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Microsoft.Azure.Management.HybridCompute.Tests
{
    public class HybridMachineExtensionTests : TestBase,IDisposable
    {
        private const string CUSTOM_SCRIPT_EXTENSION_NAME = "customScript";
        private const string DEPENDENCY_AGENT_EXTENSION_NAME = "dependencyAgent";
        private const string RESOURCE_GROUP_NAME = "csharp-sdk-test";
        private const string MACHINE_NAME = "thinkpad";
        private MockContext _context;

        private HybridComputeManagementClient _client;
        private Machine _machine;
        private bool _isLinux;

        private void Initialize()
        {
            _client = this.GetHybridComputeManagementClient(_context);
            _machine = _client.Machines.Get(RESOURCE_GROUP_NAME, MACHINE_NAME);
            _isLinux = _machine.OsName.IndexOf("linux", StringComparison.OrdinalIgnoreCase) >= 0;
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
                    Publisher = "Microsoft.Azure.Extensions",
                    MachineExtensionType = "CustomScript",
                };
                _client.MachineExtensions.CreateOrUpdate(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME, extension);

                extension = new MachineExtension
                {
                    Location = _machine.Location,
                    Publisher = "Microsoft.Azure.Monitoring.DependencyAgent",
                    MachineExtensionType = "DependencyAgentLinux",
                };
                _client.MachineExtensions.CreateOrUpdate(RESOURCE_GROUP_NAME, MACHINE_NAME, DEPENDENCY_AGENT_EXTENSION_NAME, extension);
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
                _client.MachineExtensions.CreateOrUpdate(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME, extension);

                extension = new MachineExtension
                {
                    Location = _machine.Location,
                    Publisher = "Microsoft.Azure.Monitoring.DependencyAgent",
                    MachineExtensionType = "DependencyAgentWindows",
                };
                _client.MachineExtensions.CreateOrUpdate(RESOURCE_GROUP_NAME, MACHINE_NAME, DEPENDENCY_AGENT_EXTENSION_NAME, extension);
            }
        }

        public void Dispose()
        {
            foreach (MachineExtension extension in _client.MachineExtensions.List(RESOURCE_GROUP_NAME, MACHINE_NAME))
            {
                _client.MachineExtensions.Delete(RESOURCE_GROUP_NAME, MACHINE_NAME, extension.Name);
            }
            _context.Dispose();
        }

        [Fact]
        public void MachineExtensions_Get()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            MachineExtension extension = _client.MachineExtensions.Get(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME);
            Assert.Equal(CUSTOM_SCRIPT_EXTENSION_NAME, extension.Name);
            Assert.Equal(_machine.Location, extension.Location);
            Assert.NotNull(extension.Settings);
        }

        [Fact]
        public async Task MachineExtensions_GetAsync()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            MachineExtension extension = await _client.MachineExtensions.GetAsync(RESOURCE_GROUP_NAME, MACHINE_NAME, DEPENDENCY_AGENT_EXTENSION_NAME).ConfigureAwait(false);
            Assert.Equal(DEPENDENCY_AGENT_EXTENSION_NAME, extension.Name);
            Assert.Equal(_machine.Location, extension.Location);
            Assert.Equal("Microsoft.Azure.Monitoring.DependencyAgent", extension.Publisher);
        }

        [Fact]
        public void MachineExtensions_List()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            IPage<MachineExtension> extensions = _client.MachineExtensions.List(RESOURCE_GROUP_NAME, MACHINE_NAME);
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
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            IPage<MachineExtension> extensions = await _client.MachineExtensions.ListAsync(RESOURCE_GROUP_NAME, MACHINE_NAME).ConfigureAwait(false);
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
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            const string extensionName = "custom";

            MachineExtension extension = _isLinux
                ? new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "2.1",
                    Publisher = "Microsoft.Azure.Extensions",
                    MachineExtensionType = "CustomScript",
                }
                : new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                };

            MachineExtension extensionFromCreate = _client.MachineExtensions.CreateOrUpdate(RESOURCE_GROUP_NAME, MACHINE_NAME, extensionName, extension);
            Assert.Equal(extensionName, extensionFromCreate.Name);
            Assert.Equal(_machine.Location, extensionFromCreate.Location);
            Assert.Equal("echo 'hi'", ((JObject) extensionFromCreate.Settings).Value<string>("commandToExecute"));

            MachineExtension extensionFromGet = _client.MachineExtensions.Get(RESOURCE_GROUP_NAME, MACHINE_NAME, extensionName);
            Assert.Equal(extensionName, extensionFromGet.Name);
            Assert.Equal(_machine.Location, extensionFromGet.Location);
            Assert.Equal("echo 'hi'", ((JObject) extensionFromGet.Settings).Value<string>("commandToExecute"));
        }

        [Fact]
        public async Task MachineExtensions_CreateOrUpdateAsync()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            const string extensionName = "custom";

            MachineExtension extension = _isLinux
                ? new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "2.1",
                    Publisher = "Microsoft.Azure.Extensions",
                    MachineExtensionType = "CustomScript",
                }
                : new MachineExtension
                {
                    Location = _machine.Location,
                    Settings = new Hashtable { { "commandToExecute", "echo 'hi'" }, },
                    TypeHandlerVersion = "1.10",
                    Publisher = "Microsoft.Compute",
                    MachineExtensionType = "CustomScriptExtension",
                };

            MachineExtension extensionFromCreate = await _client.MachineExtensions.CreateOrUpdateAsync(RESOURCE_GROUP_NAME, MACHINE_NAME, extensionName, extension).ConfigureAwait(false);
            Assert.Equal(extensionName, extensionFromCreate.Name);
            Assert.Equal(_machine.Location, extensionFromCreate.Location);
            Assert.Equal("echo 'hi'", ((JObject) extensionFromCreate.Settings).Value<string>("commandToExecute"));

            MachineExtension extensionFromGet = await _client.MachineExtensions.GetAsync(RESOURCE_GROUP_NAME, MACHINE_NAME, extensionName).ConfigureAwait(false);
            Assert.Equal(extensionName, extensionFromGet.Name);
            Assert.Equal(_machine.Location, extensionFromGet.Location);
            Assert.Equal("echo 'hi'", ((JObject) extensionFromGet.Settings).Value<string>("commandToExecute"));
        }

        [Fact]
        public void MachineExtensions_Delete()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            _client.MachineExtensions.Delete(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME);
            Assert.Throws<CloudException>(() => _client.MachineExtensions.Get(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME));
        }

        [Fact]
        public async Task MachineExtensions_DeleteAsync()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            await _client.MachineExtensions.DeleteAsync(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME).ConfigureAwait(false);
            Assert.Throws<CloudException>(() => _client.MachineExtensions.Get(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME));
        }

        [Fact]
        public void MachineExtensions_Update()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            const string newCommand = "echo 'goodbye'";
            MachineExtensionUpdate extensionUpdate = _isLinux
                ? new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                }
                : new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                };

            MachineExtension extension = _client.MachineExtensions.Update(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME, extensionUpdate);
            Assert.Equal(newCommand, ((JObject) extension.Settings).Value<string>("commandToExecute"));
        }

        [Fact]
        public async Task MachineExtensions_UpdateAsync()
        {
            _context = MockContext.Start(GetType().FullName);
            Initialize();
            PopulateExtensions();
            const string newCommand = "echo 'goodbye'";
            MachineExtensionUpdate extensionUpdate = _isLinux
                ? new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                }
                : new MachineExtensionUpdate
                {
                    Settings = new Hashtable { { "commandToExecute", newCommand }, },
                };

            MachineExtension extension = await _client.MachineExtensions.UpdateAsync(RESOURCE_GROUP_NAME, MACHINE_NAME, CUSTOM_SCRIPT_EXTENSION_NAME, extensionUpdate).ConfigureAwait(false);
            Assert.Equal(newCommand, ((JObject) extension.Settings).Value<string>("commandToExecute"));
        }
    }
}
