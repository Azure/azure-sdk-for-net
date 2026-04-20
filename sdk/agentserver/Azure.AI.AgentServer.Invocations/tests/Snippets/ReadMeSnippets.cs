// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public void Tier1_Startup()
        {
            #region Snippet:Invocations_ReadMe_Tier1

            InvocationsServer.Run<EchoHandler>();

            #endregion
        }

        [Test]
        public void ManualSetup()
        {
            #region Snippet:Invocations_ReadMe_ManualSetup

            var builder = AgentHost.CreateBuilder();
            builder.AddInvocations<EchoHandler>();
            builder.Build().Run();

            #endregion
        }

        [Test]
        public void Implement_EchoHandler()
        {
            var handler = new EchoHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_ReadMe_EchoHandler

        public class EchoHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request, HttpResponse response,
                InvocationContext context, CancellationToken cancellationToken)
            {
                var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
                await response.WriteAsync($"You said: {input}", cancellationToken);
            }
        }

        #endregion
    }
}
