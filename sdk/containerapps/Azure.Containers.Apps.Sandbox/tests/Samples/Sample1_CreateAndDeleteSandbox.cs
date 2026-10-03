// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Containers.Apps.Sandbox.Tests.Samples
{
    public class Sample1_CreateAndDeleteSandbox
    {
        [Test]
        public void CreateAndDeleteSandbox()
        {
            MockTransport transport = CreateTransport();

            #region Snippet:Azure_Containers_Apps_Sandbox_CreateAndDelete
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
            SandboxesClient sandboxes = sandboxGroup.GetSandboxesClient();
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
                },
                Resources = new SandboxResources("1000m", "2048Mi")
            };

            SandboxProperties created = sandboxes.CreateSandbox(content).Value;
            try
            {
                SandboxProperties current = sandboxes.GetProperties(created.Id).Value;
                Console.WriteLine($"Sandbox {current.Id}: {current.State}");
            }
            finally
            {
                sandboxes.Delete(created.Id);
            }
            #endregion

            Assert.That(transport.Requests, Has.Count.EqualTo(3));
        }

        [Test]
        public async Task CreateAndDeleteSandboxAsync()
        {
            MockTransport transport = CreateTransport();

            #region Snippet:Azure_Containers_Apps_Sandbox_CreateAndDeleteAsync
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
            SandboxesClient sandboxes = sandboxGroup.GetSandboxesClient();
            CreateSandboxContent content = new CreateSandboxContent
            {
                SourcesRef = new SandboxSource
                {
                    DiskImage = new SandboxSourceDiskImage { Name = "ubuntu", IsPublic = true }
                },
                Resources = new SandboxResources("1000m", "2048Mi")
            };

            SandboxProperties created = (await sandboxes.CreateSandboxAsync(content)).Value;
            try
            {
                SandboxProperties current = (await sandboxes.GetPropertiesAsync(created.Id)).Value;
                Console.WriteLine($"Sandbox {current.Id}: {current.State}");
            }
            finally
            {
                await sandboxes.DeleteAsync(created.Id);
            }
            #endregion

            Assert.That(transport.Requests, Has.Count.EqualTo(3));
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
                SandboxClientTestHelpers.CreateJsonResponse(200, sandbox),
                new MockResponse(204));
        }
    }
}
