// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests
{
    public class SandboxResourceLiveTests : SandboxClientTestBase
    {
        public SandboxResourceLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateGetListCountAndDeleteSandbox()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandbox sandboxClient = sandboxGroup.GetSandboxGroupSandboxClient(sandbox.Id);

            Response<ContainerAppsSandbox> getResponse = await sandboxClient.GetPropertiesAsync();
            Response<SandboxCountResult> countResponse = await sandboxGroup.GetSandboxCountAsync();
            bool found = false;

            await foreach (ContainerAppsSandbox item in sandboxGroup.GetSandboxesAsync())
            {
                if (item.Id == sandbox.Id)
                {
                    found = true;
                    break;
                }
            }

            Assert.That(getResponse.Value.Id, Is.EqualTo(sandbox.Id));
            Assert.That(countResponse.Value.Count, Is.GreaterThanOrEqualTo(1));
            Assert.That(found, Is.True);

            await DeleteSandboxIfExistsAsync(sandboxGroup, sandbox.Id);
        }

        [RecordedTest]
        public async Task DisableAndEnableSandbox()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandbox sandboxClient = sandboxGroup.GetSandboxGroupSandboxClient(sandbox.Id);

            Response<ContainerAppsSandbox> disabled = await sandboxClient.DisableAsync();
            Response<ContainerAppsSandbox> enabled = await sandboxClient.EnableAsync();

            Assert.That(disabled.Value.Id, Is.EqualTo(sandbox.Id));
            Assert.That(enabled.Value.Id, Is.EqualTo(sandbox.Id));
        }

        [RecordedTest]
        public async Task GetSandboxStats()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);

            Response<SandboxStatsResult> response = await sandboxGroup
                .GetSandboxGroupSandboxClient(sandbox.Id)
                .GetStatsAsync();

            Assert.That(response.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task SetSandboxLifecyclePolicy()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxLifecyclePolicy policy = new SandboxLifecyclePolicy(
                new SandboxAutoSuspendPolicy(false),
                new SandboxAutoDeletePolicy(false));

            Response<ContainerAppsSandbox> response = await sandboxGroup
                .GetSandboxGroupSandboxClient(sandbox.Id)
                .SetLifecyclePolicyAsync(policy);

            Assert.That(response.Value.Id, Is.EqualTo(sandbox.Id));
        }

        [RecordedTest]
        public async Task SetEgressPolicyAndGetDecisions()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandboxNetworking networking = sandboxGroup
                .GetSandboxGroupSandboxClient(sandbox.Id)
                .GetSandboxGroupSandboxNetworkingClient();
            SandboxEgressPolicy policy = new SandboxEgressPolicy
            {
                DefaultAction = EgressPolicyAction.Allow
            };

            Response<SandboxEgressPolicy> setResponse = await networking.SetEgressPolicyAsync(policy);
            Response<EgressDecisionsResult> decisionsResponse = await networking.GetEgressDecisionsAsync();

            Assert.That(setResponse.Value.DefaultAction, Is.EqualTo(EgressPolicyAction.Allow));
            Assert.That(decisionsResponse.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ExecuteCommandAndShellCommand()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandbox sandboxClient = sandboxGroup.GetSandboxGroupSandboxClient(sandbox.Id);
            ExecuteSandboxCommandContent command = new ExecuteSandboxCommandContent("/bin/echo");
            command.Arguments.Add("sandbox-command");
            ExecuteSandboxShellCommandContent shellCommand = new ExecuteSandboxShellCommandContent("echo sandbox-shell");

            Response<SandboxExecuteCommandResult> commandResponse = await sandboxClient.ExecuteCommandAsync(command);
            Response<SandboxExecuteShellCommandResult> shellResponse = await sandboxClient.ExecuteShellCommandAsync(shellCommand);

            Assert.That(commandResponse.Value, Is.Not.Null);
            Assert.That(shellResponse.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ManageSandboxPorts()
        {
            SandboxGroup sandboxGroup = CreateSandboxGroupClient();
            ContainerAppsSandbox sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxGroupSandboxNetworking networking = sandboxGroup
                .GetSandboxGroupSandboxClient(sandbox.Id)
                .GetSandboxGroupSandboxNetworkingClient();
            CreateSandboxPortContent port = new CreateSandboxPortContent(8080)
            {
                Name = "http"
            };

            Response<PortsListResult> added = await networking.AddPortAsync(port);
            Response<PortsListResult> listed = await networking.GetPortsAsync();

            Assert.That(added.Value, Is.Not.Null);
            Assert.That(listed.Value, Is.Not.Null);

            Response partialUpdate = await networking.UpdatePortAsync(
                RequestContent.Create(BinaryData.FromString(
                    """
                    {
                      "name": "http",
                      "port": 8080,
                      "activationMode": "OnDemand"
                    }
                    """)));
            Assert.That(partialUpdate.Status, Is.InRange(200, 299));

            SandboxPort currentPort = listed.Value.Ports[0];
            SandboxPortUpdate updatedPort = new SandboxPortUpdate(currentPort.Port, currentPort.Url)
            {
                Name = currentPort.Name
            };
            Response<PortsListResult> setResponse = await networking.SetPortsAsync(
                new UpdatePortsContent(new[] { updatedPort }));
            Assert.That(setResponse.Value.Ports, Has.Count.EqualTo(1));

            RemovePortContent remove = new RemovePortContent
            {
                Name = "http",
                Port = 8080
            };
            Response<PortsListResult> removed = await networking.RemovePortAsync(remove);

            Assert.That(removed.Value, Is.Not.Null);
        }
    }
}
