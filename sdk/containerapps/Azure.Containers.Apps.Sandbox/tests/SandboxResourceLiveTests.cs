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
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient sandboxClient = sandboxGroup.GetSandboxesClient();

            Response<SandboxProperties> getResponse = await sandboxClient.GetPropertiesAsync(sandbox.Id);
            Response<SandboxCountResult> countResponse = await sandboxClient.GetSandboxCountAsync();
            bool found = false;

            await foreach (SandboxProperties item in sandboxClient.GetSandboxesAsync())
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
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient sandboxClient = sandboxGroup.GetSandboxesClient();

            Response<SandboxProperties> disabled = await sandboxClient.DisableAsync(sandbox.Id);
            Response<SandboxProperties> enabled = await sandboxClient.EnableAsync(sandbox.Id);

            Assert.That(disabled.Value.Id, Is.EqualTo(sandbox.Id));
            Assert.That(enabled.Value.Id, Is.EqualTo(sandbox.Id));
        }

        [RecordedTest]
        public async Task GetSandboxStats()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);

            Response<SandboxStatsResult> response = await sandboxGroup
                .GetSandboxesClient()
                .GetStatsAsync(sandbox.Id);

            Assert.That(response.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task SetSandboxLifecyclePolicy()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxLifecyclePolicy policy = new SandboxLifecyclePolicy(
                new SandboxAutoSuspendPolicy(false),
                new SandboxAutoDeletePolicy(false));

            Response<SandboxProperties> response = await sandboxGroup
                .GetSandboxesClient()
                .SetLifecyclePolicyAsync(sandbox.Id, policy);

            Assert.That(response.Value.Id, Is.EqualTo(sandbox.Id));
        }

        [RecordedTest]
        public async Task SetEgressPolicyAndGetDecisions()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient networking = sandboxGroup.GetSandboxesClient();
            SandboxEgressPolicy policy = new SandboxEgressPolicy
            {
                DefaultAction = EgressPolicyAction.Allow
            };

            Response<SandboxEgressPolicy> setResponse = await networking.SetEgressPolicyAsync(sandbox.Id, policy);
            Response<EgressDecisionsResult> decisionsResponse = await networking.GetEgressDecisionsAsync(sandbox.Id);

            Assert.That(setResponse.Value.DefaultAction, Is.EqualTo(EgressPolicyAction.Allow));
            Assert.That(decisionsResponse.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ExecuteCommandAndShellCommand()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient sandboxClient = sandboxGroup.GetSandboxesClient();
            ExecuteSandboxCommandContent command = new ExecuteSandboxCommandContent("/bin/echo");
            command.Arguments.Add("sandbox-command");
            ExecuteSandboxShellCommandContent shellCommand = new ExecuteSandboxShellCommandContent("echo sandbox-shell");

            Response<SandboxExecuteCommandResult> commandResponse = await sandboxClient.ExecuteCommandAsync(sandbox.Id, command);
            Response<SandboxExecuteShellCommandResult> shellResponse = await sandboxClient.ExecuteShellCommandAsync(sandbox.Id, shellCommand);

            Assert.That(commandResponse.Value, Is.Not.Null);
            Assert.That(shellResponse.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ManageSandboxPorts()
        {
            SandboxGroupClient sandboxGroup = CreateSandboxGroupClient();
            SandboxProperties sandbox = await CreateSandboxAsync(sandboxGroup);
            SandboxesClient networking = sandboxGroup.GetSandboxesClient();
            CreateSandboxPortContent port = new CreateSandboxPortContent(8080)
            {
                Name = "http"
            };

            Response<PortsListResult> added = await networking.AddPortAsync(sandbox.Id, port);
            Response<PortsListResult> listed = await networking.GetPortsAsync(sandbox.Id);

            Assert.That(added.Value, Is.Not.Null);
            Assert.That(listed.Value, Is.Not.Null);

            Response partialUpdate = await networking.UpdatePortAsync(
                sandbox.Id,
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
                sandbox.Id,
                new UpdatePortsContent(new[] { updatedPort }));
            Assert.That(setResponse.Value.Ports, Has.Count.EqualTo(1));

            RemovePortContent remove = new RemovePortContent
            {
                Name = "http",
                Port = 8080
            };
            Response<PortsListResult> removed = await networking.RemovePortAsync(sandbox.Id, remove);

            Assert.That(removed.Value, Is.Not.Null);
        }
    }
}
