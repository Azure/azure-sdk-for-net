// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace BasicTypeSpec.Tests
{
    public class PaginationCancellationTests
    {
        public enum Tokens
        {
            Method,
            Enumeration,
            CombinedCancelMethod,
            CombinedCancelEnumeration,
            Same
        }

        public enum Timing
        {
            BeforeEnumeration,
            InFlight,
            InFlightNextPage,
            BetweenPages
        }

        [Test]
        public async Task CancellationReachesRequests(
            [Values] bool protocol,
            [Values] bool pages,
            [Values] Tokens tokens,
            [Values] Timing timing)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumerationSource = new CancellationTokenSource();
            CancellationToken methodToken = tokens == Tokens.Enumeration ? default : methodSource.Token;
            CancellationToken enumerationToken = tokens == Tokens.Method ? default :
                tokens == Tokens.Same ? methodSource.Token : enumerationSource.Token;
            CancellationTokenSource canceledSource = tokens == Tokens.Enumeration || tokens == Tokens.CombinedCancelEnumeration
                ? enumerationSource : methodSource;
            bool inFlight = timing == Timing.InFlight || timing == Timing.InFlightNextPage;
            using var handler = new CancellationHandler
            {
                BlockRequest = timing == Timing.InFlight ? 1 : timing == Timing.InFlightNextPage ? 2 : 0
            };
            using var httpClient = new HttpClient(handler);
            BasicTypeSpecClient client = CreateClient(httpClient);
            var context = new RequestContext { CancellationToken = methodToken };
            IAsyncEnumerable<object> values = protocol
                ? Enumerate(client.GetWithNextLinkAsync(context), pages)
                : Enumerate(client.GetWithNextLinkAsync(methodToken), pages);
            await using IAsyncEnumerator<object> enumerator = values.GetAsyncEnumerator(enumerationToken);

            if (timing == Timing.BetweenPages || timing == Timing.InFlightNextPage)
            {
                Assert.That(await enumerator.MoveNextAsync(), Is.True);
            }

            if (!inFlight)
            {
                canceledSource.Cancel();
            }

            Task<bool> pending = enumerator.MoveNextAsync().AsTask();
            try
            {
                if (inFlight)
                {
                    Assert.That(await Task.WhenAny(handler.Entered.Task, pending, Task.Delay(TimeSpan.FromSeconds(10))),
                        Is.SameAs(handler.Entered.Task), "The request did not reach the mock handler.");
                    canceledSource.Cancel();
                }

                Assert.That(await Task.WhenAny(pending, Task.Delay(TimeSpan.FromSeconds(10))), Is.SameAs(pending),
                    "Canceling the caller's token did not interrupt the request.");
                Assert.CatchAsync<OperationCanceledException>(async () => await pending);
                Assert.That(context.CancellationToken, Is.EqualTo(methodToken));
                if (timing == Timing.BetweenPages)
                {
                    Assert.That(handler.Requests.Count, Is.LessThanOrEqualTo(2));
                }
            }
            finally
            {
                handler.Release.TrySetResult(true);
                try
                {
                    await pending;
                }
                catch (OperationCanceledException)
                {
                }
            }
        }

        [Test]
        public async Task EnumerationsHaveIndependentCancellation([Values] bool protocol, [Values] bool pages)
        {
            using var methodSource = new CancellationTokenSource();
            using var firstSource = new CancellationTokenSource();
            using var secondSource = new CancellationTokenSource();
            using var handler = new CancellationHandler();
            using var httpClient = new HttpClient(handler);
            BasicTypeSpecClient client = CreateClient(httpClient);
            IAsyncEnumerable<object> values = protocol
                ? Enumerate(client.GetWithNextLinkAsync(new RequestContext { CancellationToken = methodSource.Token }), pages)
                : Enumerate(client.GetWithNextLinkAsync(methodSource.Token), pages);
            await using IAsyncEnumerator<object> first = values.GetAsyncEnumerator(firstSource.Token);
            await using IAsyncEnumerator<object> second = values.GetAsyncEnumerator(secondSource.Token);

            Assert.That(await first.MoveNextAsync(), Is.True);
            Assert.That(await second.MoveNextAsync(), Is.True);
            firstSource.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await first.MoveNextAsync());
            Assert.That(await second.MoveNextAsync(), Is.True, "One enumeration canceled another.");

            await using IAsyncEnumerator<object> later = values.GetAsyncEnumerator();
            Assert.That(await later.MoveNextAsync(), Is.True, "Cancellation leaked into a later enumeration.");
        }

        [Test]
        public async Task EnumerationDisposesLinkedToken(
            [Values] bool protocol,
            [Values] bool pages,
            [Values] bool complete)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumerationSource = new CancellationTokenSource();
            using var handler = new CancellationHandler { HasNextPage = !complete };
            using var httpClient = new HttpClient(handler);
            var capture = new CaptureTokenPolicy();
            BasicTypeSpecClient client = CreateClient(httpClient, capture);
            IAsyncEnumerable<object> values = protocol
                ? Enumerate(client.GetWithNextLinkAsync(new RequestContext { CancellationToken = methodSource.Token }), pages)
                : Enumerate(client.GetWithNextLinkAsync(methodSource.Token), pages);
            await using (IAsyncEnumerator<object> enumerator = values.GetAsyncEnumerator(enumerationSource.Token))
            {
                Assert.That(await enumerator.MoveNextAsync(), Is.True);
                if (complete)
                {
                    Assert.That(await enumerator.MoveNextAsync(), Is.False);
                }
            }

            Assert.That(capture.Tokens, Has.Count.EqualTo(1));
            CancellationToken effectiveToken = capture.Tokens[0];
            Assert.That(effectiveToken.CanBeCanceled, Is.True);
            Assert.That(effectiveToken, Is.Not.EqualTo(methodSource.Token));
            Assert.That(effectiveToken, Is.Not.EqualTo(enumerationSource.Token));
            methodSource.Cancel();
            enumerationSource.Cancel();
            Assert.That(effectiveToken.IsCancellationRequested, Is.False, "The disposed enumeration retained its token registrations.");
        }

        [Test]
        public async Task ProtocolPreservesRequestContext(
            [Values] bool pages,
            [Values("status", "handler", "noThrow", "throw")] string behavior)
        {
            using var methodSource = new CancellationTokenSource();
            using var enumerationSource = new CancellationTokenSource();
            using var handler = new CancellationHandler { Status = 418 };
            using var httpClient = new HttpClient(handler);
            var context = new RequestContext
            {
                CancellationToken = methodSource.Token,
                ErrorOptions = behavior == "noThrow" ? ErrorOptions.NoThrow : ErrorOptions.Default
            };
            var perCall = new CaptureTokenPolicy();
            var perRetry = new CaptureTokenPolicy();
            var classifier = new AcceptResponseHandler();
            context.AddPolicy(perCall, HttpPipelinePosition.PerCall);
            context.AddPolicy(perRetry, HttpPipelinePosition.PerRetry);
            if (behavior == "status")
            {
                context.AddClassifier(418, false);
            }
            else if (behavior == "handler")
            {
                context.AddClassifier(classifier);
            }

            BasicTypeSpecClient client = CreateClient(httpClient);
            await using IAsyncEnumerator<object> enumerator = Enumerate(client.GetWithNextLinkAsync(context), pages)
                .GetAsyncEnumerator(enumerationSource.Token);
            if (behavior == "throw")
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await enumerator.MoveNextAsync());
            }
            else
            {
                Assert.That(await enumerator.MoveNextAsync(), Is.True);
                Assert.That(await enumerator.MoveNextAsync(), Is.True);
            }

            int requests = behavior == "throw" ? 1 : 2;
            Assert.That(perCall.Tokens, Has.Count.EqualTo(requests));
            Assert.That(perRetry.Tokens, Has.Count.EqualTo(requests));
            Assert.That(context.CancellationToken, Is.EqualTo(methodSource.Token));
            Assert.That(context.ErrorOptions, Is.EqualTo(behavior == "noThrow" ? ErrorOptions.NoThrow : ErrorOptions.Default));
            if (behavior == "handler")
            {
                Assert.That(classifier.Calls, Is.GreaterThanOrEqualTo(requests));
            }
        }

        [Test]
        public async Task NoCancellationTokensStillEnumerate([Values] bool protocol, [Values] bool pages)
        {
            using var handler = new CancellationHandler { HasNextPage = false };
            using var httpClient = new HttpClient(handler);
            BasicTypeSpecClient client = CreateClient(httpClient);
            IAsyncEnumerable<object> values = protocol
                ? Enumerate(client.GetWithNextLinkAsync((RequestContext)null!), pages)
                : Enumerate(client.GetWithNextLinkAsync(), pages);
            await using IAsyncEnumerator<object> enumerator = values.GetAsyncEnumerator();
            Assert.That(await enumerator.MoveNextAsync(), Is.True);
            Assert.That(await enumerator.MoveNextAsync(), Is.False);
            Assert.That(handler.Requests, Has.Count.EqualTo(1));
        }

        private static BasicTypeSpecClient CreateClient(HttpClient httpClient, HttpPipelinePolicy? policy = null)
        {
            var options = new BasicTypeSpecClientOptions { Transport = new HttpClientTransport(httpClient) };
            options.Retry.MaxRetries = 0;
            if (policy != null)
            {
                options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            }
            return new BasicTypeSpecClient(new Uri("https://example.test"), new AzureKeyCredential("test-key"), options);
        }

        private static async IAsyncEnumerable<object> Enumerate<T>(
            AsyncPageable<T> pageable,
            bool pages,
            [EnumeratorCancellation] CancellationToken cancellationToken = default) where T : notnull
        {
            if (pages)
            {
                await foreach (Page<T> page in pageable.AsPages().WithCancellation(cancellationToken))
                {
                    yield return page;
                }
            }
            else
            {
                await foreach (T item in pageable.WithCancellation(cancellationToken))
                {
                    yield return item;
                }
            }
        }

        private sealed class CancellationHandler : HttpMessageHandler
        {
            public List<HttpRequestMessage> Requests { get; } = new();
            public TaskCompletionSource<bool> Entered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
            public TaskCompletionSource<bool> Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
            public int BlockRequest { get; set; }
            public bool HasNextPage { get; set; } = true;
            public int Status { get; set; } = 200;

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(request);
                if (Requests.Count == BlockRequest)
                {
                    using CancellationTokenRegistration registration = cancellationToken.Register(() => Release.TrySetResult(true));
                    Entered.TrySetResult(true);
                    await Release.Task;
                }
                cancellationToken.ThrowIfCancellationRequested();
                return new HttpResponseMessage((HttpStatusCode)Status)
                {
                    Content = new StringContent("{\"things\":[{\"name\":\"one\",\"requiredUnion\":\"value\",\"requiredBadDescription\":\"value\",\"requiredNullableList\":[]}],\"next\":" +
                        (HasNextPage ? "\"https://example.test/next\"" : "null") + "}")
                };
            }
        }

        private sealed class CaptureTokenPolicy : HttpPipelineSynchronousPolicy
        {
            public List<CancellationToken> Tokens { get; } = new();

            public override void OnSendingRequest(HttpMessage message) => Tokens.Add(message.CancellationToken);
        }

        private sealed class AcceptResponseHandler : ResponseClassificationHandler
        {
            public int Calls { get; private set; }

            public override bool TryClassify(HttpMessage message, out bool isError)
            {
                Calls++;
                isError = false;
                return true;
            }
        }
    }
}
