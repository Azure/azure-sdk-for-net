// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample4Snippets
{
    #region Snippet:A2A_Sample4_Work
    public interface IReportWriter
    {
        Task<string> WriteAsync(string input, CancellationToken cancellationToken);
    }

    public class ReportWriter : IReportWriter
    {
        public async Task<string> WriteAsync(string input, CancellationToken cancellationToken)
        {
            // Stand in for a slow application service.
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            return $"Report: {input}";
        }
    }
    #endregion

    #region Snippet:A2A_Sample4_Handler
    public class ReportAgent(IReportWriter writer) : IAgentHandler
    {
        public async Task ExecuteAsync(
            global::A2A.RequestContext context,
            AgentEventQueue eventQueue,
            CancellationToken cancellationToken)
        {
            var task = new TaskUpdater(eventQueue, context.TaskId, context.ContextId);
            await task.SubmitAsync(cancellationToken: cancellationToken);
            await task.StartWorkAsync(cancellationToken: cancellationToken);
            string report = await writer.WriteAsync(context.UserText ?? string.Empty, cancellationToken);
            await task.AddArtifactAsync([Part.FromText(report)], cancellationToken: cancellationToken);
            await task.CompleteAsync(cancellationToken: cancellationToken);
        }
    }
    #endregion

    [Test]
    [Explicit("Starts a server; the handler is exercised by SampleEndToEndTests.")]
    public void StartServer()
    {
        #region Snippet:A2A_Sample4_Start
        var builder = AgentHost.CreateBuilder();
        builder.Services.AddSingleton<IReportWriter, ReportWriter>();
        builder.AddA2A<ReportAgent>(CreateCard());
        builder.Build().Run();
        #endregion
    }
}
