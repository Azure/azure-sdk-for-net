// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the Core README.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class ReadMeSnippets
    {
        #region Snippet:Core_ReadMe_SnapshotLifecycle

        public sealed class DatabaseSnapshotLifecycle : IAgentSnapshotLifecycle
        {
            public Task BeforeSnapshotAsync(CancellationToken cancellationToken = default)
            {
                // Close connections and release state that must not be captured.
                return Task.CompletedTask;
            }

            public Task AfterRestoreAsync(
                AgentRestoreContext context,
                CancellationToken cancellationToken = default)
            {
                // Environment overrides are already applied. Recreate clients
                // or other state that was initialized before the snapshot.
                return Task.CompletedTask;
            }
        }

        #endregion

        [Test]
        public void CreateBuilder()
        {
            #region Snippet:Core_ReadMe_CreateBuilder

            var builder = AgentHost.CreateBuilder();

            // Register protocol endpoints (protocol packages provide extension methods).
            builder.RegisterProtocol("MyProtocol", endpoints =>
            {
                endpoints.MapGet("/hello", () => "Hello from the agent server!");
            });

            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void Tier3Setup()
        {
            #region Snippet:Core_ReadMe_Tier3Setup

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddAgentServerCore();

            var app = builder.Build();
            app.UseAgentServerCore();
            app.MapGet("/hello", () => "Hello!");
            app.Run();

            #endregion
        }

        [Test]
        public void ConfigureSnapshotLifecycle()
        {
            #region Snippet:Core_ReadMe_ConfigureSnapshotLifecycle

            var builder = AgentHost.CreateBuilder();
            builder.Services.AddSingleton<IAgentSnapshotLifecycle, DatabaseSnapshotLifecycle>();

            #endregion
        }
    }
}
