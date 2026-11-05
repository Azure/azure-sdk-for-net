// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.WorkloadManager.Tests
{
    public class PaginationBehaviorTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

        private static IEnumerable<TestCaseData> ListCases()
        {
            foreach (string list in new[] { "Bindings", "Links", "Capabilities", "ResourceGroup", "Subscription" })
            foreach (bool cancelMethod in new[] { false, true })
                yield return new TestCaseData(list, cancelMethod);
        }

        [TestCaseSource(nameof(ListCases))]
        public async Task CancellationBetweenPages(string list, bool cancelMethod)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumerationSource = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200).SetContent("{\"value\":[],\"nextLink\":\"https://management.azure.com/next?$skiptoken=next\"}");
            });
            var client = CreateClient(transport);
            await RunPages(client, list, methodSource.Token, enumerationSource.Token, async nextPage =>
            {
                Assert.That(await nextPage(), Is.True);
                (cancelMethod ? methodSource : enumerationSource).Cancel();
                Assert.CatchAsync<OperationCanceledException>(async () => await nextPage());
            });
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        }

        [TestCaseSource(nameof(ListCases))]
        public async Task CancellationDuringHttpRequest(string list, bool cancelMethod)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumerationSource = new CancellationTokenSource();
            var transport = new BlockingTransport();
            using var abort = transport.Abort;
            var client = CreateClient(transport);
            Task operation = PaginationTests.EnumerateList(client, list, false, methodSource.Token, enumerationSource.Token);
            try
            {
                await transport.Started.Task.TimeoutAfter(TimeSpan.FromSeconds(5));
                (cancelMethod ? methodSource : enumerationSource).Cancel();
                Assert.CatchAsync<OperationCanceledException>(async () => await operation.TimeoutAfter(TimeSpan.FromSeconds(5)));
                Assert.That(transport.ObservedToken.IsCancellationRequested, Is.True);
            }
            finally
            {
                transport.Abort.Cancel();
                try { await operation; }
                catch (OperationCanceledException) { }
            }
        }

        [TestCase("Bindings")]
        [TestCase("Links")]
        [TestCase("Capabilities")]
        [TestCase("ResourceGroup")]
        [TestCase("Subscription")]
        public async Task DisposingOneEnumerationDoesNotAffectAnother(string list)
        {
            using var methodSource = new CancellationTokenSource();
            using var firstSource = new CancellationTokenSource();
            using var secondSource = new CancellationTokenSource();
            var transport = MockTransport.FromMessageCallback(message =>
            {
                message.CancellationToken.ThrowIfCancellationRequested();
                return new MockResponse(200).SetContent("{\"value\":[]}");
            });
            var client = CreateClient(transport);
            // Reuse the same pageable so replacing/mutating its captured context would be detected.
            var space = client.GetWorkloadSpaceResource(WorkloadSpaceResource.CreateResourceIdentifier(SubscriptionId, "rg", "space"));
            switch (list)
            {
                case "Bindings": await CheckIndependent(space.GetRuntimeBindings().GetAllAsync(methodSource.Token), firstSource, secondSource.Token); break;
                case "Links": await CheckIndependent(space.GetRuntimeLinks().GetAllAsync(methodSource.Token), firstSource, secondSource.Token); break;
                case "Capabilities": await CheckIndependent(space.GetWorkloadCapabilities().GetAllAsync(methodSource.Token), firstSource, secondSource.Token); break;
                case "ResourceGroup": await CheckIndependent(client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "rg")).GetWorkloadSpaces().GetAllAsync(methodSource.Token), firstSource, secondSource.Token); break;
                case "Subscription": await CheckIndependent(client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId)).GetWorkloadSpacesAsync(methodSource.Token), firstSource, secondSource.Token); break;
            }
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(methodSource.IsCancellationRequested, Is.False);
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        public async Task PagingHelperPreservesContext(bool noThrow, bool classifyAsSuccess)
        {
            var policy = new CountingPolicy();
            var context = new RequestContext { ErrorOptions = noThrow ? ErrorOptions.NoThrow : ErrorOptions.Default };
            context.AddPolicy(policy, HttpPipelinePosition.PerCall);
            if (classifyAsSuccess)
                context.AddClassifier(500, false);
            var options = new ArmClientOptions { Transport = new MockTransport(new MockResponse(500).SetContent("{\"error\":{\"code\":\"Failure\",\"message\":\"test\"}}")) };
            options.Retry.MaxRetries = 0;
            var pipeline = HttpPipelineBuilder.Build(options);
            var pages = CancellationAwarePageableHelpers.GetPagesAsync<WorkloadSpaceData>(
                pipeline, new ClientDiagnostics("Azure.ResourceManager.Compute.WorkloadManager", "Microsoft.Compute", options.Diagnostics),
                "PagingHelperPreservesContext", context,
                _ =>
                {
                    var message = pipeline.CreateMessage(context, pipeline.ResponseClassifier);
                    message.Request.Uri.Reset(new Uri("https://management.azure.com/test"));
                    message.Request.Method = RequestMethod.Get;
                    return message;
                },
                _ => (Array.Empty<WorkloadSpaceData>(), null), null, context.CancellationToken);
            async Task Read()
            {
                await foreach (var page in pages) { }
            }
            if (noThrow || classifyAsSuccess)
                await Read();
            else
                Assert.CatchAsync<RequestFailedException>(Read);
            Assert.That(policy.Requests, Is.EqualTo(1));
            Assert.That(context.CancellationToken, Is.EqualTo(CancellationToken.None));
            Assert.That(context.ErrorOptions, Is.EqualTo(noThrow ? ErrorOptions.NoThrow : ErrorOptions.Default));
        }

        [Test]
        public async Task RequestDiagnosticScopeEndsBeforePageIsYielded()
        {
            Activity requestActivity = null;
            using var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllData,
                ActivityStarted = activity =>
                {
                    if (activity.OperationName == "RuntimeBindingCollection.GetAll")
                        requestActivity = activity;
                }
            };
            ActivitySource.AddActivityListener(listener);
            var client = CreateClient(new MockTransport(new MockResponse(200).SetContent("{\"value\":[]}")));
            var space = client.GetWorkloadSpaceResource(WorkloadSpaceResource.CreateResourceIdentifier(SubscriptionId, "rg", "space"));
            await using var pages = space.GetRuntimeBindings().GetAllAsync().AsPages().GetAsyncEnumerator();
            Assert.That(await pages.MoveNextAsync(), Is.True);
            Assert.That(requestActivity, Is.Not.Null);
            Assert.That(requestActivity.Duration, Is.GreaterThan(TimeSpan.Zero));
        }

        private static ArmClient CreateClient(MockTransport transport)
            => new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });

        private static Task RunPages(ArmClient client, string list, CancellationToken methodToken, CancellationToken enumerationToken, Func<Func<ValueTask<bool>>, Task> action)
        {
            var space = client.GetWorkloadSpaceResource(WorkloadSpaceResource.CreateResourceIdentifier(SubscriptionId, "rg", "space"));
            return list switch
            {
                "Bindings" => UsePages(space.GetRuntimeBindings().GetAllAsync(methodToken), enumerationToken, action),
                "Links" => UsePages(space.GetRuntimeLinks().GetAllAsync(methodToken), enumerationToken, action),
                "Capabilities" => UsePages(space.GetWorkloadCapabilities().GetAllAsync(methodToken), enumerationToken, action),
                "ResourceGroup" => UsePages(client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "rg")).GetWorkloadSpaces().GetAllAsync(methodToken), enumerationToken, action),
                "Subscription" => UsePages(client.GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId)).GetWorkloadSpacesAsync(methodToken), enumerationToken, action),
                _ => throw new ArgumentException("Unknown list", nameof(list))
            };
        }

        private static async Task UsePages<T>(AsyncPageable<T> source, CancellationToken token, Func<Func<ValueTask<bool>>, Task> action)
        {
            await using var pages = source.AsPages().GetAsyncEnumerator(token);
            await action(pages.MoveNextAsync);
        }

        private static async Task CheckIndependent<T>(AsyncPageable<T> source, CancellationTokenSource first, CancellationToken second)
        {
            await using (var pages = source.AsPages().GetAsyncEnumerator(first.Token))
                Assert.That(await pages.MoveNextAsync(), Is.True);
            first.Cancel();
            await foreach (var page in source.AsPages().WithCancellation(second)) { }
        }

        private sealed class CountingPolicy : HttpPipelineSynchronousPolicy
        {
            public int Requests { get; private set; }
            public override void OnSendingRequest(HttpMessage message) => Requests++;
        }

        private sealed class BlockingTransport : MockTransport
        {
            public TaskCompletionSource<bool> Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
            public CancellationTokenSource Abort { get; } = new();
            public CancellationToken ObservedToken { get; private set; }

            protected override async Task<MockResponse> GetNextResponseAsync(MockRequest request, HttpMessage message)
            {
                ObservedToken = message.CancellationToken;
                Started.TrySetResult(true);
                using var linked = CancellationTokenSource.CreateLinkedTokenSource(message.CancellationToken, Abort.Token);
                await Task.Delay(Timeout.Infinite, linked.Token);
                return new MockResponse(200);
            }
        }
    }
}
