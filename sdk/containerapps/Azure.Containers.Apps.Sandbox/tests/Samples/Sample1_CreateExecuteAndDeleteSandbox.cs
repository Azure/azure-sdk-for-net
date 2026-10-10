// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests.Samples
{
    public class Sample1_CreateExecuteAndDeleteSandbox
    {
        [Test]
        public void CreateExecuteAndDeleteSandbox()
        {
            MockTransport transport = CreateTransport();

            #region Snippet:Azure_Containers_Apps_Sandbox_CreateExecuteAndDelete
#if SNIPPET
            var sandboxGroup = new SandboxGroupClient(
                new Uri("<sandbox-group-endpoint>"),
                "<subscription-id>",
                "<resource-group-name>",
                "<sandbox-group-name>",
                new DefaultAzureCredential());
#else
            SandboxGroupClient sandboxGroup = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);
#endif
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
                },
                Resources = new SandboxResources("1000m", "2048Mi")
            };

            SandboxResource sandbox = sandboxGroup.CreateSandbox(content).Value;
            try
            {
                ExecuteSandboxCommandContent command = new ExecuteSandboxCommandContent("/bin/echo");
                command.Arguments.Add("sandbox-command");
                SandboxExecuteCommandResult result = sandbox.ExecuteCommand(command).Value;
                if (result.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Command failed with exit code {result.ExitCode}: {result.StandardError}");
                }
                Console.WriteLine(result.StandardOutput);
            }
            finally
            {
                sandbox.Delete();
            }
            #endregion

            Assert.That(transport.Requests, Has.Count.EqualTo(3));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[1]), Does.Contain("\"command\":\"/bin/echo\""));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[1]), Does.Contain("sandbox-command"));
        }

        [Test]
        public async Task CreateExecuteAndDeleteSandboxAsync()
        {
            MockTransport transport = CreateTransport();

            #region Snippet:Azure_Containers_Apps_Sandbox_CreateExecuteAndDeleteAsync
#if SNIPPET
            var sandboxGroup = new SandboxGroupClient(
                new Uri("<sandbox-group-endpoint>"),
                "<subscription-id>",
                "<resource-group-name>",
                "<sandbox-group-name>",
                new DefaultAzureCredential());
#else
            SandboxGroupClient sandboxGroup = SandboxClientTestHelpers.CreateSandboxGroupClient(transport);
#endif
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
                },
                Resources = new SandboxResources("1000m", "2048Mi")
            };

            SandboxResource sandbox = (await sandboxGroup.CreateSandboxAsync(content)).Value;
            try
            {
                ExecuteSandboxCommandContent command = new ExecuteSandboxCommandContent("/bin/echo");
                command.Arguments.Add("sandbox-command");
                SandboxExecuteCommandResult result = (await sandbox.ExecuteCommandAsync(command)).Value;
                if (result.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Command failed with exit code {result.ExitCode}: {result.StandardError}");
                }
                Console.WriteLine(result.StandardOutput);
            }
            finally
            {
                await sandbox.DeleteAsync();
            }
            #endregion

            Assert.That(transport.Requests, Has.Count.EqualTo(3));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[1]), Does.Contain("\"command\":\"/bin/echo\""));
            Assert.That(SandboxClientTestHelpers.ReadContent(transport.Requests[1]), Does.Contain("sandbox-command"));
        }

        private static MockTransport CreateTransport()
        {
            const string sandbox = """
                {
                  "id": "sandbox-id",
                  "sourcesRef": { "diskImage": { "name": "ubuntu", "isPublic": true } },
                  "resources": { "cpu": "1000m", "memory": "2048Mi" },
                  "state": "Running"
                }
                """;
            return new MockTransport(
                SandboxClientTestHelpers.CreateJsonResponse(201, sandbox),
                SandboxClientTestHelpers.CreateJsonResponse(200,
                    """{"exitCode":0,"stdout":"sandbox-command\n","stderr":"","executionTimeMs":1}"""),
                new MockResponse(204));
        }
    }
}
