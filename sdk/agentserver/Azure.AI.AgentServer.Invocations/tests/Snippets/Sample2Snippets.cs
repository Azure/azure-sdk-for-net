// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
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

            InvocationsServer.Run<DocumentAnalysisHandler>();

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
            // Handlers are scoped (new instance per request), so state must live
            // outside the handler. Use a static store here for simplicity; in
            // production, use a database or distributed cache.
            private static readonly ConcurrentDictionary<string, JobState> s_jobs = new();

            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                var input = await request.ReadFromJsonAsync<AnalysisInput>(cancellationToken);

                // Store the job and kick off background work.
                var job = new JobState(context.InvocationId, input?.DocumentUrl ?? "", Status: "running");
                s_jobs[context.InvocationId] = job;

                _ = Task.Run(() => AnalyzeInBackground(context.InvocationId), CancellationToken.None);

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
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                if (!s_jobs.TryGetValue(invocationId, out var job))
                {
                    response.StatusCode = 404;
                    return;
                }

                if (job.Status == "running")
                {
                    response.Headers["Retry-After"] = "2";
                }

                await response.WriteAsJsonAsync(new
                {
                    invocation_id = invocationId,
                    status = job.Status,
                    result = job.Result
                }, cancellationToken);
            }

            public override Task CancelAsync(
                string invocationId,
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                if (s_jobs.TryGetValue(invocationId, out var job))
                {
                    s_jobs[invocationId] = job with { Status = "cancelled" };
                    response.StatusCode = 200;
                }
                else
                {
                    response.StatusCode = 404;
                }

                return Task.CompletedTask;
            }

            private static async Task AnalyzeInBackground(string invocationId)
            {
                // Simulate analysis work.
                await Task.Delay(TimeSpan.FromSeconds(5));

                if (s_jobs.TryGetValue(invocationId, out var job) && job.Status == "running")
                {
                    s_jobs[invocationId] = job with
                    {
                        Status = "completed",
                        Result = $"Analysis of {job.DocumentUrl}: 3 pages, 2 tables, 1 chart detected."
                    };
                }
            }
        }

        public record AnalysisInput(string DocumentUrl);
        public record JobState(string InvocationId, string DocumentUrl, string Status, string? Result = null);

        #endregion
    }
}
