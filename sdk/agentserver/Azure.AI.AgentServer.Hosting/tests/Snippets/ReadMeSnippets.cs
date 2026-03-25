// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Hosting.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the Hosting README.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class ReadMeSnippets
    {
        [Test]
        public void Tier1_Startup()
        {
            #region Snippet:Hosting_ReadMe_Tier1

#if SNIPPET
            using Azure.AI.AgentServer.Responses;

            AgentHost.Run<MyHandler>(args);
#else
            AgentHost.Run<MyHandler>(args: null);
#endif

            #endregion
        }

        [Test]
        public void Tier2_Builder()
        {
            #region Snippet:Hosting_ReadMe_Tier2

#if SNIPPET
            using Azure.AI.AgentServer.Responses;

            var builder = AgentHost.CreateBuilder(args);
#else
            var builder = AgentHost.CreateBuilder();
#endif
            builder.AddResponses<MyHandler>();
            var app = builder.Build();
            app.Run();

            #endregion
        }

        // Minimal handler for snippet compilation.
        private class MyHandler : IResponseHandler
        {
            public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                IResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                await Task.CompletedTask;
                yield break;
            }
        }
    }
}
