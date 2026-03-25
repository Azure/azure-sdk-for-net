// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Hosting;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing the Invocations README.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class ReadMeSnippets
    {
        [Test]
        public void Builder_Setup()
        {
            #region Snippet:Invocations_ReadMe_Builder

#if SNIPPET
            var builder = AgentHost.CreateBuilder(args);
#else
            var builder = AgentHost.CreateBuilder();
#endif
            builder.AddInvocations<MyHandler>();
            var app = builder.Build();
            app.Run();

            #endregion
        }

        [Test]
        public void Tier1_Startup()
        {
            #region Snippet:Invocations_ReadMe_Tier1

#if SNIPPET
            AgentHost.Run<MyHandler>(args);
#else
            AgentHost.Run<MyHandler>(args: null);
#endif

            #endregion
        }

        [Test]
        public void Implement_Handler()
        {
            var handler = new MyHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_ReadMe_Handler

        public class MyHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                response.ContentType = "application/json";
                await response.WriteAsync("{\"status\":\"ok\"}", cancellationToken);
            }
        }

        #endregion
    }
}
