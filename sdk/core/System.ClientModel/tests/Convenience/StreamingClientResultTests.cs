// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class StreamingClientResultTests
{
    [Test]
    public void ProtocolResultExposesRawResponseAndOwnsDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult result = new TestProtocolStreamingClientResult(response);

        Assert.AreSame(response, result.GetRawResponse());

        result.Dispose();

        Assert.IsNull(response.ContentStream);
        Assert.DoesNotThrow(result.Dispose);
    }

    [Test]
    public async Task AsyncProtocolResultExposesRawResponseAndOwnsDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult result = new TestAsyncProtocolStreamingClientResult(response);

        Assert.AreSame(response, result.GetRawResponse());

        await result.DisposeAsync();

        Assert.IsNull(response.ContentStream);
        Assert.DoesNotThrowAsync(async () => await result.DisposeAsync());
    }

    [Test]
    public void ExposesRawResponse()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1], response);

        Assert.AreSame(response, result.GetRawResponse());
    }

    [Test]
    public void EnumeratesValuesAndDisposesResponse()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1, 2, 3], response);

        Assert.AreEqual(new[] { 1, 2, 3 }, result.ToArray());
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void DisposesResponseWhenEnumerationStopsEarly()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1, 2, 3], response);

        using (IEnumerator<int> enumerator = result.GetEnumerator())
        {
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(1, enumerator.Current);
        }

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void DisposesResponseWhenEnumeratorIsDisposedBeforeStarting()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1], response);

        result.GetEnumerator().Dispose();

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void DisposesActiveEnumeratorWhenResultIsDisposed()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1], response);
        result.GetEnumerator();

        result.Dispose();

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void ResultDisposalWaitsForConcurrentEnumeratorDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        BlockingDisposeEnumerable values = new();
        StreamingClientResult<int> result = new BlockingStreamingClientResult(values, response);
        IEnumerator<int> enumerator = result.GetEnumerator();
        Assert.IsTrue(enumerator.MoveNext());

        Task enumeratorDisposal = Task.Run(enumerator.Dispose);
        Assert.IsTrue(values.DisposeStarted.Wait(TimeSpan.FromSeconds(5)));

        Task resultDisposal = Task.Run(result.Dispose);
        Assert.IsFalse(resultDisposal.Wait(TimeSpan.FromMilliseconds(100)));

        values.AllowDispose.Set();
        Task.WaitAll(enumeratorDisposal, resultDisposal);

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void ConcurrentResultDisposalsShareEnumeratorCleanup()
    {
        MockPipelineResponse response = CreateResponse();
        BlockingDisposeEnumerable values = new();
        StreamingClientResult<int> result = new BlockingStreamingClientResult(values, response);
        IEnumerator<int> enumerator = result.GetEnumerator();
        Assert.IsTrue(enumerator.MoveNext());

        Task firstDisposal = Task.Run(result.Dispose);
        Assert.IsTrue(values.DisposeStarted.Wait(TimeSpan.FromSeconds(5)));

        Task secondDisposal = Task.Run(result.Dispose);
        Assert.IsFalse(secondDisposal.Wait(TimeSpan.FromMilliseconds(100)));
        Assert.IsNotNull(response.ContentStream);

        values.AllowDispose.Set();
        Task.WaitAll(firstDisposal, secondDisposal);

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void ReentrantResultDisposalDefersResponseDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        ReentrantDisposeEnumerable values = new();
        StreamingClientResult<int> result = new BlockingStreamingClientResult(values, response);
        values.DisposeResult = result.Dispose;
        values.IsResponseDisposed = () => response.ContentStream is null;
        IEnumerator<int> enumerator = result.GetEnumerator();
        Assert.IsTrue(enumerator.MoveNext());

        Assert.DoesNotThrow(enumerator.Dispose);

        Assert.IsFalse(values.ResponseDisposedDuringCleanup);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void DisposesResponseWhenEnumerationThrows()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1], response, throwAfterValues: true);

        Assert.Throws<InvalidOperationException>(() => result.ToArray());
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void CanDisposeWithoutEnumerating()
    {
        MockPipelineResponse response = CreateResponse();
        StreamingClientResult<int> result = new TestStreamingClientResult([1], response);

        result.Dispose();

        Assert.IsNull(response.ContentStream);
        Assert.Throws<ObjectDisposedException>(() => result.GetEnumerator());
    }

    [Test]
    public void DisposeIsIdempotentAfterEnumeration()
    {
        StreamingClientResult<int> result = new TestStreamingClientResult([1], CreateResponse());

        Assert.AreEqual(new[] { 1 }, result.ToArray());
        Assert.DoesNotThrow(result.Dispose);
        Assert.DoesNotThrow(result.Dispose);
    }

    [Test]
    public void CannotEnumerateMoreThanOnce()
    {
        StreamingClientResult<int> result = new TestStreamingClientResult([1], CreateResponse());

        Assert.AreEqual(new[] { 1 }, result.ToArray());
        Assert.Throws<InvalidOperationException>(() => result.GetEnumerator());
    }

    [Test]
    public async Task AsyncExposesRawResponse()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], response);

        Assert.AreSame(response, result.GetRawResponse());
        await result.DisposeAsync();
    }

    [Test]
    public async Task AsyncEnumeratesValuesAndDisposesResponse()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1, 2, 3], response);

        Assert.AreEqual(new[] { 1, 2, 3 }, await ToArrayAsync(result));
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncDisposesResponseWhenEnumerationStopsEarly()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1, 2, 3], response);

        await using (IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator())
        {
            Assert.IsTrue(await enumerator.MoveNextAsync());
            Assert.AreEqual(1, enumerator.Current);
        }

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncDisposesResponseWhenEnumeratorIsDisposedBeforeStarting()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], response);

        await result.GetAsyncEnumerator().DisposeAsync();

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncDisposesActiveEnumeratorWhenResultIsDisposed()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], response);
        result.GetAsyncEnumerator();

        await result.DisposeAsync();

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncResultDisposalWaitsForConcurrentEnumeratorDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        BlockingAsyncDisposeEnumerable values = new();
        AsyncStreamingClientResult<int> result = new BlockingAsyncStreamingClientResult(values, response);
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());

        Task enumeratorDisposal = enumerator.DisposeAsync().AsTask();
        await values.DisposeStarted.Task;

        Task resultDisposal = result.DisposeAsync().AsTask();
        Assert.AreNotSame(resultDisposal, await Task.WhenAny(resultDisposal, Task.Delay(100)));

        values.AllowDispose.SetResult(null);
        await Task.WhenAll(enumeratorDisposal, resultDisposal);

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncConcurrentResultDisposalsShareEnumeratorCleanup()
    {
        MockPipelineResponse response = CreateResponse();
        BlockingAsyncDisposeEnumerable values = new();
        AsyncStreamingClientResult<int> result = new BlockingAsyncStreamingClientResult(values, response);
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());

        Task firstDisposal = result.DisposeAsync().AsTask();
        await values.DisposeStarted.Task;

        Task secondDisposal = result.DisposeAsync().AsTask();
        Assert.AreNotSame(secondDisposal, await Task.WhenAny(secondDisposal, Task.Delay(100)));
        Assert.IsNotNull(response.ContentStream);

        values.AllowDispose.SetResult(null);
        await Task.WhenAll(firstDisposal, secondDisposal);

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncReentrantResultDisposalDefersResponseDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        ReentrantAsyncDisposeEnumerable values = new();
        AsyncStreamingClientResult<int> result = new BlockingAsyncStreamingClientResult(values, response);
        values.DisposeResult = result.DisposeAsync;
        values.IsResponseDisposed = () => response.ContentStream is null;
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());

        await enumerator.DisposeAsync();

        Assert.IsFalse(values.ResponseDisposedDuringCleanup);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void AsyncDisposesResponseWhenEnumerationThrows()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], response, throwAfterValues: true);

        Assert.ThrowsAsync<InvalidOperationException>(async () => await ToArrayAsync(result));
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task AsyncCanDisposeWithoutEnumerating()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], response);

        await result.DisposeAsync();

        Assert.IsNull(response.ContentStream);
        Assert.Throws<ObjectDisposedException>(() => result.GetAsyncEnumerator());
    }

    [Test]
    public async Task AsyncDisposeIsIdempotentAfterEnumeration()
    {
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], CreateResponse());

        Assert.AreEqual(new[] { 1 }, await ToArrayAsync(result));
        Assert.DoesNotThrowAsync(async () => await result.DisposeAsync());
        Assert.DoesNotThrowAsync(async () => await result.DisposeAsync());
    }

    [Test]
    public async Task AsyncCannotEnumerateMoreThanOnce()
    {
        AsyncStreamingClientResult<int> result = new TestAsyncStreamingClientResult([1], CreateResponse());

        Assert.AreEqual(new[] { 1 }, await ToArrayAsync(result));
        Assert.Throws<InvalidOperationException>(() => result.GetAsyncEnumerator());
    }

    [Test]
    public void AsyncPassesEnumeratorCancellationAndDisposesResponse()
    {
        MockPipelineResponse response = CreateResponse();
        TestAsyncStreamingClientResult result = new([1], response);
        using CancellationTokenSource cts = new();
        cts.Cancel();

        Assert.ThrowsAsync<OperationCanceledException>(
            async () => await ToArrayAsync(result, cts.Token));
        Assert.AreEqual(cts.Token, result.EnumerationCancellationToken);
        Assert.IsNull(response.ContentStream);
    }

    private static MockPipelineResponse CreateResponse()
        => new MockPipelineResponse(200).SetContent("stream");

    private static async Task<int[]> ToArrayAsync(
        IAsyncEnumerable<int> values,
        CancellationToken cancellationToken = default)
    {
        List<int> result = [];
        await foreach (int value in values.WithCancellation(cancellationToken))
        {
            result.Add(value);
        }
        return result.ToArray();
    }

    private sealed class TestStreamingClientResult(
        IEnumerable<int> values,
        PipelineResponse response,
        bool throwAfterValues = false)
        : StreamingClientResult<int>(response)
    {
        protected override IEnumerable<int> GetValues()
        {
            foreach (int value in values)
            {
                yield return value;
            }

            if (throwAfterValues)
            {
                throw new InvalidOperationException();
            }
        }
    }

    private sealed class TestProtocolStreamingClientResult(PipelineResponse response)
        : StreamingClientResult(response)
    {
    }

    private sealed class TestAsyncProtocolStreamingClientResult(PipelineResponse response)
        : AsyncStreamingClientResult(response)
    {
    }

    private sealed class BlockingStreamingClientResult(
        IEnumerable<int> values,
        PipelineResponse response) : StreamingClientResult<int>(response)
    {
        protected override IEnumerable<int> GetValues() => values;
    }

    private sealed class BlockingAsyncStreamingClientResult(
        IAsyncEnumerable<int> values,
        PipelineResponse response) : AsyncStreamingClientResult<int>(response)
    {
        protected override IAsyncEnumerable<int> GetValuesAsync(
            CancellationToken cancellationToken = default) => values;
    }

    private sealed class BlockingDisposeEnumerable : IEnumerable<int>
    {
        public ManualResetEventSlim DisposeStarted { get; } = new();
        public ManualResetEventSlim AllowDispose { get; } = new();

        public IEnumerator<int> GetEnumerator() => new Enumerator(this);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        private sealed class Enumerator(BlockingDisposeEnumerable owner) : IEnumerator<int>
        {
            public int Current => 1;
            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext() => true;
            public void Reset() => throw new NotSupportedException();

            public void Dispose()
            {
                owner.DisposeStarted.Set();
                owner.AllowDispose.Wait();
            }
        }
    }

    private sealed class BlockingAsyncDisposeEnumerable : IAsyncEnumerable<int>
    {
        public TaskCompletionSource<object?> DisposeStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource<object?> AllowDispose { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public IAsyncEnumerator<int> GetAsyncEnumerator(
            CancellationToken cancellationToken = default) => new Enumerator(this);

        private sealed class Enumerator(BlockingAsyncDisposeEnumerable owner)
            : IAsyncEnumerator<int>
        {
            public int Current => 1;

            public ValueTask<bool> MoveNextAsync() => new(true);

            public async ValueTask DisposeAsync()
            {
                owner.DisposeStarted.SetResult(null);
                await owner.AllowDispose.Task;
            }
        }
    }

    private sealed class ReentrantDisposeEnumerable : IEnumerable<int>
    {
        public Action DisposeResult { get; set; } = null!;
        public Func<bool> IsResponseDisposed { get; set; } = null!;
        public bool ResponseDisposedDuringCleanup { get; private set; }

        public IEnumerator<int> GetEnumerator() => new Enumerator(this);

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();

        private sealed class Enumerator(ReentrantDisposeEnumerable owner) : IEnumerator<int>
        {
            public int Current => 1;
            object System.Collections.IEnumerator.Current => Current;

            public bool MoveNext() => true;
            public void Reset() => throw new NotSupportedException();

            public void Dispose()
            {
                owner.DisposeResult();
                owner.ResponseDisposedDuringCleanup = owner.IsResponseDisposed();
            }
        }
    }

    private sealed class ReentrantAsyncDisposeEnumerable : IAsyncEnumerable<int>
    {
        public Func<ValueTask> DisposeResult { get; set; } = null!;
        public Func<bool> IsResponseDisposed { get; set; } = null!;
        public bool ResponseDisposedDuringCleanup { get; private set; }

        public IAsyncEnumerator<int> GetAsyncEnumerator(
            CancellationToken cancellationToken = default) => new Enumerator(this);

        private sealed class Enumerator(ReentrantAsyncDisposeEnumerable owner)
            : IAsyncEnumerator<int>
        {
            public int Current => 1;

            public ValueTask<bool> MoveNextAsync() => new(true);

            public async ValueTask DisposeAsync()
            {
                await owner.DisposeResult();
                owner.ResponseDisposedDuringCleanup = owner.IsResponseDisposed();
            }
        }
    }

    private sealed class TestAsyncStreamingClientResult(
        IEnumerable<int> values,
        PipelineResponse response,
        bool throwAfterValues = false)
        : AsyncStreamingClientResult<int>(response)
    {
        public CancellationToken EnumerationCancellationToken { get; private set; }

        protected override async IAsyncEnumerable<int> GetValuesAsync(
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            EnumerationCancellationToken = cancellationToken;
            cancellationToken.ThrowIfCancellationRequested();

            foreach (int value in values)
            {
                await Task.Yield();
                yield return value;
            }

            if (throwAfterValues)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
