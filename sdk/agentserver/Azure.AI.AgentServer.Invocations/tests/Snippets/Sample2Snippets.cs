// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Invocations Sample2_LongRunning.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample2Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Invocations_Sample2_StartServer

#if SNIPPET
            AgentHost.Run<DocumentAnalysisHandler>(args);
#else
            AgentHost.Run<DocumentAnalysisHandler>(args: null);
#endif

            #endregion
        }

        [Test]
        public void Implement_DocumentAnalysisHandler()
        {
            var handler = new DocumentAnalysisHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_Sample2_DocumentAnalysisHandler

        public class DocumentAnalysisHandler : InvocationHandler
        {
            private JobState? _currentJob;

            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await request.ReadFromJsonAsync<AnalysisInput>(cancellationToken);

                // Store the job and kick off background work.
                _currentJob = new JobState(context.InvocationId, input?.DocumentUrl ?? "", Status: "running");

                _ = Task.Run(() => AnalyzeInBackground(), CancellationToken.None);

                // Return 202 Accepted — the caller should poll GET /invocations/{id}.
                response.StatusCode = 202;
                response.Headers["Retry-After"] = "2";
                await response.WriteAsJsonAsync(new
                {
                    invocation_id = context.InvocationId,
                    status = "running"
                }, cancellationToken);
            }

            public override async Task GetAsync(
                string invocationId,
                HttpRequest request,
                HttpResponse response,
                CancellationToken cancellationToken)
            {
                if (_currentJob is null || _currentJob.InvocationId != invocationId)
                {
                    response.StatusCode = 404;
                    return;
                }

                if (_currentJob.Status == "running")
                {
                    response.Headers["Retry-After"] = "2";
                }

                await response.WriteAsJsonAsync(new
                {
                    invocation_id = invocationId,
                    status = _currentJob.Status,
                    result = _currentJob.Result
                }, cancellationToken);
            }

            public override Task CancelAsync(
                string invocationId,
                HttpRequest request,
                HttpResponse response,
                CancellationToken cancellationToken)
            {
                if (_currentJob is not null && _currentJob.InvocationId == invocationId)
                {
                    _currentJob = _currentJob with { Status = "cancelled" };
                    response.StatusCode = 200;
                }
                else
                {
                    response.StatusCode = 404;
                }

                return Task.CompletedTask;
            }

            private async Task AnalyzeInBackground()
            {
                // Simulate analysis work.
                await Task.Delay(TimeSpan.FromSeconds(5));

                if (_currentJob is not null && _currentJob.Status == "running")
                {
                    _currentJob = _currentJob with
                    {
                        Status = "completed",
                        Result = $"Analysis of {_currentJob.DocumentUrl}: 3 pages, 2 tables, 1 chart detected."
                    };
                }
            }
        }

        public record AnalysisInput(string DocumentUrl);
        public record JobState(string InvocationId, string DocumentUrl, string Status, string? Result = null);

        #endregion
    }
}
