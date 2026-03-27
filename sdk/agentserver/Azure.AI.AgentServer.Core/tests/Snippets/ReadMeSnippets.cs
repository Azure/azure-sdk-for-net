// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
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
        public void Tier2_Builder()
        {
            #region Snippet:Hosting_ReadMe_Tier2

            var builder = AgentHost.CreateBuilder();
            builder.AddResponses<MyHandler>();
            var app = builder.Build();
            app.Run();

            #endregion
        }

        // Minimal handler for snippet compilation.
        private class MyHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                yield break;
            }
        }
    }
}
