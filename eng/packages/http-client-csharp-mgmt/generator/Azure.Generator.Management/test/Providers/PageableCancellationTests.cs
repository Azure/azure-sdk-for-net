// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    public class PageableCancellationTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string FooId = "/subscriptions/" + SubscriptionId + "/resourceGroups/group/providers/MgmtTypeSpec/foos/foo";

        public enum Path { Wrapper, Resource, Array }
        public enum Tokens { Method, Enumeration, CombinedMethod, CombinedEnumeration, Same }
        public enum Timing { Before, InFlight, BetweenPages, InFlightNextPage }

        private static IEnumerable<TestCaseData> CancellationCases()
        {
            foreach (Path path in Enum.GetValues<Path>())
                foreach (bool pages in new[] { false, true })
                    foreach (Tokens tokens in Enum.GetValues<Tokens>())
                        foreach (Timing timing in Enum.GetValues<Timing>())
                        {
                            if (path == Path.Array && timing is Timing.BetweenPages or Timing.InFlightNextPage)
                            {
                                continue;
                            }
                            yield return new TestCaseData(path, pages, tokens, timing);
                        }
        }

        [TestCaseSource(nameof(CancellationCases))]
        public async Task CancellationReachesSource(Path path, bool pages, Tokens tokens, Timing timing)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            var methodToken = tokens == Tokens.Enumeration ? default : method.Token;
            var enumerationToken = tokens == Tokens.Method ? default : tokens == Tokens.Same ? method.Token : enumeration.Token;
            var canceled = tokens is Tokens.Enumeration or Tokens.CombinedEnumeration ? enumeration : method;
            int blockRequest = timing == Timing.InFlight ? 1 : timing == Timing.InFlightNextPage ? 2 : 0;
            using var handler = new TestHandler { BlockRequest = blockRequest };
            using var httpClient = new HttpClient(handler);
            var source = new TestPageable(methodToken) { BlockRequest = blockRequest };
            var values = CreateValues(path, pages, methodToken, httpClient, source);
            await using var iterator = values.GetAsyncEnumerator(enumerationToken);
            if (timing is Timing.BetweenPages or Timing.InFlightNextPage)
            {
                Assert.That(await iterator.MoveNextAsync(), Is.True);
            }
            if (blockRequest == 0)
            {
                canceled.Cancel();
            }
            var pending = iterator.MoveNextAsync().AsTask();
            var started = path == Path.Wrapper ? source.Started : handler.Started;
            var release = path == Path.Wrapper ? source.Release : handler.Release;
            try
            {
                if (blockRequest != 0)
                {
                    Assert.That(await Task.WhenAny(started.Task, pending, Task.Delay(TimeSpan.FromSeconds(10))),
                        Is.SameAs(started.Task), "The request did not reach the blocking source.");
                    canceled.Cancel();
                }
                Assert.That(await Task.WhenAny(pending, Task.Delay(TimeSpan.FromSeconds(10))), Is.SameAs(pending),
                    "Cancellation did not interrupt enumeration.");
                Assert.CatchAsync<OperationCanceledException>(async () => await pending);
                if (path == Path.Wrapper)
                {
                    Assert.That(source.Disposals, Is.EqualTo(1));
                }
            }
            finally
            {
                release.TrySetResult(true);
                try
                {
                    await pending;
                }
                catch (OperationCanceledException)
                {
                    // Cancellation is the expected test outcome; release also bounds failing negative controls.
                }
            }
        }

        [TestCase(Path.Resource, false)]
        [TestCase(Path.Resource, true)]
        [TestCase(Path.Array, false)]
        [TestCase(Path.Array, true)]
        public async Task PreCanceledEnumerationIsObserved(Path path, bool pages)
        {
            using var canceled = new CancellationTokenSource();
            canceled.Cancel();
            using var handler = new TestHandler();
            using var httpClient = new HttpClient(handler);
            await using var iterator = CreateValues(path, pages, default, httpClient).GetAsyncEnumerator(canceled.Token);
            Assert.CatchAsync<OperationCanceledException>(async () => await iterator.MoveNextAsync());
        }

        [Test]
        public async Task IndependentAndRepeatedEnumerations([Values] Path path, [Values] bool pages)
        {
            using var method = new CancellationTokenSource();
            using var canceled = new CancellationTokenSource();
            using var handler = new TestHandler();
            using var httpClient = new HttpClient(handler);
            var values = CreateValues(path, pages, method.Token, httpClient);
            await using var first = values.GetAsyncEnumerator(canceled.Token);
            await using var second = values.GetAsyncEnumerator();
            canceled.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await first.MoveNextAsync());
            Assert.That(await second.MoveNextAsync(), Is.True);
            await using var later = values.GetAsyncEnumerator();
            Assert.That(await later.MoveNextAsync(), Is.True);
            Assert.That(method.IsCancellationRequested, Is.False);
        }

        [TestCase(Path.Wrapper, false)]
        [TestCase(Path.Wrapper, true)]
        [TestCase(Path.Resource, false)]
        [TestCase(Path.Resource, true)]
        public async Task CancelingActiveEnumerationDoesNotCancelOthers(Path path, bool pages)
        {
            using var method = new CancellationTokenSource();
            using var canceled = new CancellationTokenSource();
            using var handler = new TestHandler();
            using var httpClient = new HttpClient(handler);
            var values = CreateValues(path, pages, method.Token, httpClient);
            await using var first = values.GetAsyncEnumerator(canceled.Token);
            await using var second = values.GetAsyncEnumerator();
            Assert.That(await first.MoveNextAsync(), Is.True);
            Assert.That(await second.MoveNextAsync(), Is.True);
            canceled.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await first.MoveNextAsync());
            Assert.That(await second.MoveNextAsync(), Is.True);
            Assert.That(await second.MoveNextAsync(), Is.False);
            await using var later = values.GetAsyncEnumerator();
            Assert.That(await later.MoveNextAsync(), Is.True);
        }

        [Test]
        public async Task ReusingPageEnumerableDoesNotRetainCancellation([Values] Path path)
        {
            using var canceled = new CancellationTokenSource();
            using var handler = new TestHandler();
            using var httpClient = new HttpClient(handler);
            var client = CreateClient(httpClient);
            IAsyncEnumerable<object> values = path switch
            {
                Path.Wrapper => EnumeratePages(Wrap(new TestPageable(default)).AsPages()),
                Path.Resource => EnumeratePages(client.GetResourceGroupResource(
                    ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "group")).GetFoos().GetAllAsync().AsPages()),
                Path.Array => EnumeratePages(client.GetFooResource(new ResourceIdentifier(FooId)).GetDependenciesAsync().AsPages()),
                _ => throw new ArgumentOutOfRangeException(nameof(path))
            };
            canceled.Cancel();
            await using var first = values.GetAsyncEnumerator(canceled.Token);
            Assert.CatchAsync<OperationCanceledException>(async () => await first.MoveNextAsync());
            await using var later = values.GetAsyncEnumerator();
            Assert.That(await later.MoveNextAsync(), Is.True);
        }

        [Test]
        public async Task DisposalUnlinksCombinedTokens([Values] Path path, [Values] bool pages, [Values] bool complete)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            using var handler = new TestHandler { HasNextPage = !complete };
            using var httpClient = new HttpClient(handler);
            var capture = new CapturePolicy();
            var source = new TestPageable(method.Token) { PageCount = complete ? 1 : 2 };
            var values = CreateValues(path, pages, method.Token, httpClient, source, capture);
            await using (var iterator = values.GetAsyncEnumerator(enumeration.Token))
            {
                Assert.That(await iterator.MoveNextAsync(), Is.True);
                if (complete)
                {
                    Assert.That(await iterator.MoveNextAsync(), Is.False);
                }
            }
            var effective = path == Path.Wrapper ? source.EffectiveToken : capture.Tokens.Single();
            Assert.That(effective.CanBeCanceled, Is.True);
            Assert.That(effective, Is.Not.EqualTo(method.Token));
            Assert.That(effective, Is.Not.EqualTo(enumeration.Token));
            method.Cancel();
            enumeration.Cancel();
            Assert.That(effective.IsCancellationRequested, Is.False, "Disposed enumeration retained linked-token registrations.");
            if (path == Path.Wrapper)
            {
                Assert.That(source.Disposals, Is.EqualTo(1));
            }
        }

        [Test]
        public async Task WrapperPreservesPageMetadata()
        {
            var source = new TestPageable(default);
            var wrapper = Wrap(source);
            await using var iterator = wrapper.AsPages("resume", 7).GetAsyncEnumerator();
            Assert.That(await iterator.MoveNextAsync(), Is.True);
            Assert.That(iterator.Current.Values, Is.EqualTo(new[] { "1" }));
            Assert.That(iterator.Current.ContinuationToken, Is.EqualTo("next"));
            Assert.That(iterator.Current.GetRawResponse(), Is.SameAs(source.Response));
            Assert.That(source.ContinuationToken, Is.EqualTo("resume"));
            Assert.That(source.PageSizeHint, Is.EqualTo(7));
        }

        [Test]
        public async Task NoTokensComplete([Values] Path path, [Values] bool pages)
        {
            using var handler = new TestHandler();
            using var httpClient = new HttpClient(handler);
            int count = 0;
            await foreach (var value in CreateValues(path, pages, default, httpClient))
            {
                if (path == Path.Resource)
                {
                    var resource = pages ? ((Page<FooResource>)value).Values.Single() : (FooResource)value;
                    Assert.That(resource.Id.ToString(), Is.EqualTo(FooId));
                    Assert.That(resource.Data.Name, Is.EqualTo("foo"));
                }
                else if (path == Path.Array)
                {
                    var dependency = pages ? ((Page<FooDependency>)value).Values.Single() : (FooDependency)value;
                    Assert.That(dependency.DependencyName, Is.EqualTo("dependency"));
                }
                count++;
            }
            Assert.That(count, Is.EqualTo(path == Path.Array ? 1 : 2));
        }

        [Test]
        public async Task ArrayPreservesContextAndPipelineBehavior(
            [Values] bool pages,
            [Values("null", "nullError", "noThrow", "throw", "classifier")] string behavior)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            using var handler = new TestHandler { Status = behavior == "null" ? HttpStatusCode.OK : HttpStatusCode.BadRequest };
            using var httpClient = new HttpClient(handler);
            var perCall = new CapturePolicy();
            var perRetry = new CapturePolicy { AcceptError = behavior == "classifier" };
            var client = CreateClient(httpClient, perCall, perRetry);
            var resource = client.GetFooResource(new ResourceIdentifier(FooId));
            var restClient = typeof(FooResource).GetField("_foosRestClient", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(resource);
            var context = behavior is "null" or "nullError" ? null : new RequestContext
            {
                CancellationToken = method.Token,
                ErrorOptions = behavior == "noThrow" ? ErrorOptions.NoThrow : ErrorOptions.Default
            };
            var type = typeof(FooResource).Assembly.GetType("Azure.Generator.MgmtTypeSpec.Tests.FooResourceGetDependenciesAsyncCollectionResultOfT")!;
            var pageable = (AsyncPageable<FooDependency>)Activator.CreateInstance(
                type, restClient, Guid.Parse(SubscriptionId), "group", "foo", context, "Test.GetDependencies")!;
            await using var iterator = Enumerate(pageable, pages).GetAsyncEnumerator(enumeration.Token);
            if (behavior is "throw" or "nullError")
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await iterator.MoveNextAsync());
            }
            else
            {
                Assert.That(await iterator.MoveNextAsync(), Is.True);
                if (pages)
                {
                    Assert.That(((Page<FooDependency>)iterator.Current).GetRawResponse().Status, Is.EqualTo((int)handler.Status));
                }
            }
            Assert.That(perCall.Tokens, Has.Count.EqualTo(1));
            Assert.That(perRetry.Tokens, Has.Count.EqualTo(1));
            Assert.That(perCall.Tokens[0], Is.EqualTo(perRetry.Tokens[0]));
            Assert.That(perCall.Tokens[0].CanBeCanceled, Is.True);
            if (context != null)
            {
                Assert.That(context.CancellationToken, Is.EqualTo(method.Token));
                Assert.That(context.ErrorOptions, Is.EqualTo(behavior == "noThrow" ? ErrorOptions.NoThrow : ErrorOptions.Default));
            }
        }

        private static IAsyncEnumerable<object> CreateValues(
            Path path, bool pages, CancellationToken methodToken, HttpClient httpClient,
            TestPageable? source = null, CapturePolicy? capture = null)
        {
            var client = CreateClient(httpClient, capture);
            return path switch
            {
                Path.Wrapper => Enumerate(Wrap(source ?? new TestPageable(methodToken)), pages),
                Path.Resource => Enumerate(client.GetResourceGroupResource(
                    ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "group")).GetFoos().GetAllAsync(methodToken), pages),
                Path.Array => Enumerate(client.GetFooResource(new ResourceIdentifier(FooId)).GetDependenciesAsync(methodToken), pages),
                _ => throw new ArgumentOutOfRangeException(nameof(path))
            };
        }

        private static async IAsyncEnumerable<object> Enumerate<T>(
            AsyncPageable<T> pageable, bool pages, [EnumeratorCancellation] CancellationToken cancellationToken = default) where T : notnull
        {
            if (pages)
            {
                await foreach (var page in pageable.AsPages().WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    yield return page;
                }
            }
            else
            {
                await foreach (var item in pageable.WithCancellation(cancellationToken).ConfigureAwait(false))
                {
                    yield return item;
                }
            }
        }

        private static AsyncPageable<string> Wrap(AsyncPageable<int> source)
        {
            var type = typeof(FooResource).Assembly.GetType("Azure.Generator.MgmtTypeSpec.Tests.AsyncPageableWrapper`2")!
                .MakeGenericType(typeof(int), typeof(string));
            return (AsyncPageable<string>)Activator.CreateInstance(type, source, (Func<int, string>)(value => value.ToString()))!;
        }

        private static async IAsyncEnumerable<object> EnumeratePages<T>(
            IAsyncEnumerable<Page<T>> pages, [EnumeratorCancellation] CancellationToken cancellationToken = default) where T : notnull
        {
            await foreach (var page in pages.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return page;
            }
        }

        private static ArmClient CreateClient(HttpClient httpClient, CapturePolicy? perCall = null, CapturePolicy? perRetry = null)
        {
            var options = new ArmClientOptions { Transport = new HttpClientTransport(httpClient) };
            options.Retry.MaxRetries = 0;
            if (perCall != null)
            {
                options.AddPolicy(perCall, HttpPipelinePosition.PerCall);
            }
            if (perRetry != null)
            {
                options.AddPolicy(perRetry, HttpPipelinePosition.PerRetry);
            }
            return new ArmClient(new TestCredential(), SubscriptionId, options);
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new("test", DateTimeOffset.MaxValue);
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new(GetToken(requestContext, cancellationToken));
        }

        private sealed class CapturePolicy : HttpPipelineSynchronousPolicy
        {
            public List<CancellationToken> Tokens { get; } = [];
            public bool AcceptError { get; init; }
            public override void OnSendingRequest(HttpMessage message)
            {
                Tokens.Add(message.CancellationToken);
                if (AcceptError)
                {
                    message.ResponseClassifier = new AcceptClassifier();
                }
            }
        }

        private sealed class AcceptClassifier : ResponseClassifier
        {
            public override bool IsErrorResponse(HttpMessage message) => false;
        }

        private sealed class TestHandler : HttpMessageHandler
        {
            public int BlockRequest { get; init; }
            public bool HasNextPage { get; init; } = true;
            public HttpStatusCode Status { get; init; } = HttpStatusCode.OK;
            public int Requests { get; private set; }
            public TaskCompletionSource<bool> Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
            public TaskCompletionSource<bool> Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests++;
                cancellationToken.ThrowIfCancellationRequested();
                if (Requests == BlockRequest)
                {
                    Started.TrySetResult(true);
                    await Release.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
                }
                string body;
                if (request.RequestUri!.AbsolutePath.EndsWith("/listDependencies"))
                {
                    body = """[{"dependencyName":"dependency","version":"1"}]""";
                }
                else
                {
                    string nextLink = HasNextPage && !request.RequestUri.AbsolutePath.EndsWith("/next")
                        ? ""","nextLink":"https://management.azure.com/next" """ : "";
                    body = $$"""{"value":[{"id":"{{FooId}}","name":"foo","type":"MgmtTypeSpec/foos","location":"westus"}]{{nextLink}}}""";
                }
                return new HttpResponseMessage(Status) { Content = new StringContent(body) };
            }
        }

        private sealed class TestPageable(CancellationToken methodToken) : AsyncPageable<int>
        {
            public int BlockRequest { get; init; }
            public int PageCount { get; init; } = 2;
            public int Disposals { get; private set; }
            public string? ContinuationToken { get; private set; }
            public int? PageSizeHint { get; private set; }
            public CancellationToken EffectiveToken { get; private set; }
            public Response Response { get; } = Mock.Of<Response>();
            public TaskCompletionSource<bool> Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
            public TaskCompletionSource<bool> Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

            public override IAsyncEnumerable<Page<int>> AsPages(string? continuationToken = null, int? pageSizeHint = null)
            {
                ContinuationToken = continuationToken;
                PageSizeHint = pageSizeHint;
                return Pages(methodToken);
            }

            private async IAsyncEnumerable<Page<int>> Pages([EnumeratorCancellation] CancellationToken cancellationToken)
            {
                EffectiveToken = cancellationToken;
                try
                {
                    for (int i = 1; i <= PageCount; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        if (i == BlockRequest)
                        {
                            Started.TrySetResult(true);
                            await Release.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
                        }
                        yield return Page<int>.FromValues(new[] { i }, i < PageCount ? "next" : null, Response);
                    }
                }
                finally
                {
                    Disposals++;
                }
            }
        }
    }
}
