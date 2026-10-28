// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class ReadMeSnippets
{
    #region Snippet:A2A_AgentCard
    public static AgentCard CreateCard() => new()
    {
        Name = "echo",
        Description = "A native A2A echo agent",
        Version = "1.0",
        SupportedInterfaces =
        [
            new AgentInterface
            {
                Url = "http://localhost:8088/a2a",
                ProtocolBinding = "JSONRPC",
                ProtocolVersion = "1.0",
            },
        ],
        Capabilities = new AgentCapabilities { Streaming = true },
        DefaultInputModes = ["text/plain"],
        DefaultOutputModes = ["text/plain"],
        Skills = [new AgentSkill { Id = "echo", Name = "Echo", Description = "Echoes input", Tags = ["echo"] }],
    };
    #endregion

    #region Snippet:A2A_EchoAgent
    public class EchoAgent : IAgentHandler
    {
        public async Task ExecuteAsync(
            global::A2A.RequestContext context,
            AgentEventQueue eventQueue,
            CancellationToken cancellationToken)
        {
            await new MessageResponder(eventQueue, context.ContextId)
                .ReplyAsync($"Echo: {context.UserText}", cancellationToken: cancellationToken);
        }
    }
    #endregion

    [Test]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public void StartServer()
    {
        #region Snippet:A2A_Run
        A2AAgentServer.Run<EchoAgent>(CreateCard());
        #endregion
    }

    [Test]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public void ComposeHost()
    {
        #region Snippet:A2A_Builder
        var builder = AgentHost.CreateBuilder();
        builder.AddA2A<EchoAgent>(CreateCard());
        builder.Build().Run();
        #endregion
    }

    [Test]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public void ExistingAspNetHost()
    {
        #region Snippet:A2A_Standalone
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddFoundryA2A<EchoAgent>(CreateCard());
        var app = builder.Build();
        app.MapFoundryA2A();
        app.Run();
        #endregion
    }

    #region Snippet:A2A_TaskAgent
    public class TaskAgent : IAgentHandler
    {
        public async Task ExecuteAsync(
            global::A2A.RequestContext context,
            AgentEventQueue eventQueue,
            CancellationToken cancellationToken)
        {
            var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
            await task.SubmitAsync(cancellationToken: cancellationToken);
            await task.AddArtifactAsync(
                [Part.FromText($"Echo: {context.UserText}")],
                cancellationToken: cancellationToken);
            await task.CompleteAsync(cancellationToken: cancellationToken);
        }
    }
    #endregion
}
