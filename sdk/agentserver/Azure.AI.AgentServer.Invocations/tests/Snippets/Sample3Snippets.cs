// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Invocations Sample3_Streaming.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample3Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Invocations_Sample3_StartServer

            InvocationsServer.Run<CodeGenHandler>();

            #endregion
        }

        [Test]
        public void Implement_CodeGenHandler()
        {
            var handler = new CodeGenHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_Sample3_CodeGenHandler

        public class CodeGenHandler : InvocationHandler
        {
            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await request.ReadFromJsonAsync<CodeGenInput>(cancellationToken);
                var prompt = input?.Prompt ?? "// no prompt provided";

                // Stream the response as Server-Sent Events.
                response.ContentType = "text/event-stream";
                response.Headers.CacheControl = "no-cache";

                // In a real agent, call a code model and stream tokens as they arrive.
                var codeTokens = new[]
                {
                    "public class ",
                    "Calculator\n",
                    "{\n",
                    "    public int ",
                    "Add(int a, int b)",
                    " => a + b;\n",
                    "}\n"
                };

                foreach (var token in codeTokens)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    var data = JsonSerializer.Serialize(new { type = "token", content = token });
                    await response.WriteAsync($"data: {data}\n\n", cancellationToken);
                    await response.Body.FlushAsync(cancellationToken);

                    // Simulate model generation latency.
                    await Task.Delay(150, cancellationToken);
                }

                // Signal completion.
                var done = JsonSerializer.Serialize(new
                {
                    type = "done",
                    invocation_id = context.InvocationId
                });
                await response.WriteAsync($"data: {done}\n\n", cancellationToken);
                await response.Body.FlushAsync(cancellationToken);
            }
        }

        public record CodeGenInput(string Prompt);

        #endregion
    }
}
