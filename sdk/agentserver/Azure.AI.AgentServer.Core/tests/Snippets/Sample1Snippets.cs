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
    /// Code snippets backing Sample1_GettingStarted.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample1Snippets
    {
        [Test]
        public void CreateAndRun()
        {
            #region Snippet:Core_Sample1_CreateAndRun

            var builder = AgentHost.CreateBuilder();

            // Register a custom protocol endpoint directly.
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
