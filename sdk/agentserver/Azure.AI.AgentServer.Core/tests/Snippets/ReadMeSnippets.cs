// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
    }
}
