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
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    public class PageableCancellationTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

        [Test]
        public async Task WrapperCancellation(
            [Values(false, true)] bool pages,
            [Values("method", "enumeration", "combinedMethod", "combinedEnumeration", "same")] string mode,
            [Values("before", "inFlight", "betweenPages")] string timing)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            var (methodToken, enumerationToken, cancel) = Tokens(mode, method, enumeration);
            var source = new TestPageable(methodToken) { Block = timing == "inFlight" };
            var wrapper = Wrap(source);
            await using var iterator = Enumerate(wrapper, pages, enumerationToken).GetAsyncEnumerator();
            if (timing == "betweenPages")
            {
                Assert.That(await iterator.MoveNextAsync(), Is.True);
            }
            if (timing != "inFlight")
            {
                cancel.Cancel();
            }
            var move = iterator.MoveNextAsync().AsTask();
            if (timing == "inFlight")
            {
                await source.Started.Task.WaitAsync(TimeSpan.FromSeconds(10));
            }
            cancel.Cancel();
            Assert.CatchAsync<OperationCanceledException>(async () => await move.WaitAsync(TimeSpan.FromSeconds(10)));
            Assert.That(source.Disposals, Is.EqualTo(1));
        }

        [Test]
        public async Task ArrayCancellation(
            [Values(false, true)] bool pages,
            [Values("method", "enumeration", "combinedMethod", "combinedEnumeration", "same")] string mode,
            [Values(false, true)] bool inFlight)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            var (methodToken, enumerationToken, cancel) = Tokens(mode, method, enumeration);
            using var handler = new TestHandler { Block = inFlight };
            var pageable = CreateResource(handler).GetDependenciesAsync(methodToken);
            await using var iterator = Enumerate(pageable, pages, enumerationToken).GetAsyncEnumerator();
            if (!inFlight)
            {
                cancel.Cancel();
            }
            var move = iterator.MoveNextAsync().AsTask();
            if (inFlight)
            {
                await handler.Started.Task.WaitAsync(TimeSpan.FromSeconds(10));
                cancel.Cancel();
            }
            Assert.CatchAsync<OperationCanceledException>(async () => await move.WaitAsync(TimeSpan.FromSeconds(10)));
        }

        [Test]
        public async Task WrapperPreservesPagesAndDisposesSource()
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            var source = new TestPageable(method.Token);
            var wrapper = Wrap(source);
            var iterator = wrapper.AsPages("resume", 7).GetAsyncEnumerator(enumeration.Token);
            Assert.That(await iterator.MoveNextAsync(), Is.True);
            Assert.That(iterator.Current.Values, Is.EqualTo(new[] { "1" }));
            Assert.That(iterator.Current.ContinuationToken, Is.EqualTo("next"));
            Assert.That(iterator.Current.GetRawResponse(), Is.SameAs(source.Response));
            Assert.That(source.ContinuationToken, Is.EqualTo("resume"));
            Assert.That(source.PageSizeHint, Is.EqualTo(7));
            await iterator.DisposeAsync();
            Assert.That(source.Disposals, Is.EqualTo(1));
            method.Cancel();
            enumeration.Cancel();
            Assert.That(source.EffectiveToken.IsCancellationRequested, Is.False, "Disposal must unlink the iterator token.");
        }

        [Test]
        public async Task EnumerationsAreIndependent([Values(false, true)] bool array, [Values(false, true)] bool pages)
        {
            using var method = new CancellationTokenSource();
            using var canceled = new CancellationTokenSource();
            using var handler = new TestHandler();
            IAsyncEnumerable<object> first;
            IAsyncEnumerable<object> second;
            if (array)
            {
                var pageable = CreateResource(handler).GetDependenciesAsync(method.Token);
                first = Enumerate(pageable, pages, canceled.Token);
                second = Enumerate(pageable, pages, default);
            }
            else
            {
                var pageable = Wrap(new TestPageable(method.Token));
                first = Enumerate(pageable, pages, canceled.Token);
                second = Enumerate(pageable, pages, default);
            }
            await using var firstIterator = first.GetAsyncEnumerator();
            await using var secondIterator = second.GetAsyncEnumerator();
            Assert.That(await firstIterator.MoveNextAsync(), Is.True);
            canceled.Cancel();
            if (!array)
            {
                Assert.ThrowsAsync<OperationCanceledException>(async () => await firstIterator.MoveNextAsync());
            }
            Assert.That(await secondIterator.MoveNextAsync(), Is.True);
            Assert.That(method.IsCancellationRequested, Is.False);
        }

        [Test]
        public async Task ArrayCompletesAndReleasesRequestToken([Values(false, true)] bool pages)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            using var handler = new TestHandler();
            var pageable = CreateResource(handler).GetDependenciesAsync(method.Token);
            await using var iterator = Enumerate(pageable, pages, enumeration.Token).GetAsyncEnumerator();
            Assert.That(await iterator.MoveNextAsync(), Is.True);
            var value = pages ? ((Page<FooDependency>)iterator.Current).Values.Single() : (FooDependency)iterator.Current;
            Assert.That(value.DependencyName, Is.EqualTo("dependency"));
            Assert.That(await iterator.MoveNextAsync(), Is.False);
            method.Cancel();
            enumeration.Cancel();
            Assert.That(handler.EffectiveToken.IsCancellationRequested, Is.False);
            Assert.That(handler.Requests, Is.EqualTo(1));
        }

        [Test]
        public async Task ArrayPreservesRequestContext([Values(false, true)] bool nullContext)
        {
            using var method = new CancellationTokenSource();
            using var enumeration = new CancellationTokenSource();
            using var handler = new TestHandler { Status = nullContext ? HttpStatusCode.OK : HttpStatusCode.BadRequest };
            var resource = CreateResource(handler);
            var client = typeof(FooResource).GetField("_foosRestClient", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(resource);
            var context = nullContext ? null : new RequestContext { CancellationToken = method.Token, ErrorOptions = ErrorOptions.NoThrow };
            var type = typeof(FooResource).Assembly.GetType("Azure.Generator.MgmtTypeSpec.Tests.FooResourceGetDependenciesAsyncCollectionResultOfT")!;
            var pageable = (AsyncPageable<FooDependency>)Activator.CreateInstance(
                type, client, Guid.Parse(SubscriptionId), "group", "foo", context, "Test.GetDependencies")!;
            await using var iterator = pageable.AsPages().GetAsyncEnumerator(enumeration.Token);
            Assert.That(await iterator.MoveNextAsync(), Is.True);
            Assert.That(iterator.Current.GetRawResponse().Status, Is.EqualTo((int)handler.Status));
            if (context != null)
            {
                Assert.That(context.CancellationToken, Is.EqualTo(method.Token));
                Assert.That(context.ErrorOptions, Is.EqualTo(ErrorOptions.NoThrow));
            }
        }

        [Test]
        public async Task NoCancellationTokensComplete([Values(false, true)] bool array, [Values(false, true)] bool pages)
        {
            using var handler = new TestHandler();
            var values = array
                ? Enumerate(CreateResource(handler).GetDependenciesAsync(), pages, default)
                : Enumerate(Wrap(new TestPageable(default)), pages, default);
            int count = 0;
            await foreach (var value in values)
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(array ? 1 : 2));
        }

        private static (CancellationToken Method, CancellationToken Enumeration, CancellationTokenSource Cancel) Tokens(
            string mode, CancellationTokenSource method, CancellationTokenSource enumeration) => mode switch
            {
                "method" => (method.Token, default, method),
                "enumeration" => (default, enumeration.Token, enumeration),
                "combinedMethod" => (method.Token, enumeration.Token, method),
                "combinedEnumeration" => (method.Token, enumeration.Token, enumeration),
                "same" => (method.Token, method.Token, method),
                _ => throw new ArgumentException(nameof(mode))
            };

        private static async IAsyncEnumerable<object> Enumerate<T>(
            AsyncPageable<T> pageable, bool pages, [EnumeratorCancellation] CancellationToken cancellationToken) where T : notnull
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

        private static FooResource CreateResource(TestHandler handler)
        {
            var options = new ArmClientOptions { Transport = new HttpClientTransport(new HttpClient(handler)) };
            options.Retry.MaxRetries = 0;
            return new ArmClient(new TestCredential(), SubscriptionId, options)
                .GetFooResource(FooResource.CreateResourceIdentifier(SubscriptionId, "group", "foo"));
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new("test", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new(GetToken(requestContext, cancellationToken));
        }

        private sealed class TestHandler : HttpMessageHandler
        {
            public bool Block { get; init; }
            public HttpStatusCode Status { get; init; } = HttpStatusCode.OK;
            public int Requests { get; private set; }
            public CancellationToken EffectiveToken { get; private set; }
            public TaskCompletionSource<bool> Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests++;
                EffectiveToken = cancellationToken;
                Started.TrySetResult(true);
                cancellationToken.ThrowIfCancellationRequested();
                if (Block)
                {
                    await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
                }
                return new HttpResponseMessage(Status)
                {
                    Content = new StringContent("""[{"dependencyName":"dependency","version":"1"}]""")
                };
            }
        }

        private sealed class TestPageable(CancellationToken methodToken) : AsyncPageable<int>
        {
            public bool Block { get; init; }
            public int Disposals { get; private set; }
            public string? ContinuationToken { get; private set; }
            public int? PageSizeHint { get; private set; }
            public CancellationToken EffectiveToken { get; private set; }
            public Response Response { get; } = Mock.Of<Response>();
            public TaskCompletionSource<bool> Started { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

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
                    for (int i = 1; i <= 2; i++)
                    {
                        Started.TrySetResult(true);
                        cancellationToken.ThrowIfCancellationRequested();
                        if (Block)
                        {
                            await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
                        }
                        yield return Page<int>.FromValues(new[] { i }, i == 1 ? "next" : null, Response);
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
