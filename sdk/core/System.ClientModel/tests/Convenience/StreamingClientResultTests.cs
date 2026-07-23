// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Results;

public class StreamingClientResultTests
{
    [Test]
    public async Task ExposesResponseMetadataWithoutExposingResponse()
    {
        MockPipelineResponse response = CreateResponse();
        response.SetReasonPhrase("OK");
        response.SetHeader("x-test", "value");
        AsyncStreamingClientResult<int> result = CreateResult([1], response);

        Assert.AreEqual(200, result.Status);
        Assert.AreEqual("OK", result.ReasonPhrase);
        Assert.IsTrue(result.Headers.TryGetValue("x-test", out string? value));
        Assert.AreEqual("value", value);
        Assert.IsFalse(typeof(ClientResult).IsAssignableFrom(result.GetType()));
        Assert.IsNull(result.GetType().GetMethod("GetRawResponse"));
        Assert.IsNull(result.GetType().GetProperty("ContentStream"));

        await result.DisposeAsync();
    }

    [Test]
    public async Task EnumeratesValuesAndDisposesResponse()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = CreateResult([1, 2, 3], response);

        Assert.AreEqual(new[] { 1, 2, 3 }, await ToArrayAsync(result));
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task DisposesResponseWhenEnumerationStopsEarly()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = CreateResult([1, 2, 3], response);

        await using (IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator())
        {
            Assert.IsTrue(await enumerator.MoveNextAsync());
            Assert.AreEqual(1, enumerator.Current);
        }

        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task DisposesBeforeEnumeration()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = CreateResult([1], response);

        await result.DisposeAsync();

        Assert.IsNull(response.ContentStream);
        Assert.Throws<ObjectDisposedException>(() => result.GetAsyncEnumerator());
    }

    [Test]
    public async Task CanBeEnumeratedOnlyOnce()
    {
        AsyncStreamingClientResult<int> result = CreateResult([1], CreateResponse());

        Assert.AreEqual(new[] { 1 }, await ToArrayAsync(result));
        Assert.Throws<InvalidOperationException>(() => result.GetAsyncEnumerator());
    }

    [Test]
    public void DisposesResponseWhenProducerFails()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create<int>(
            response,
            static (_, _) => throw new InvalidOperationException());

        Assert.Throws<InvalidOperationException>(() => result.GetAsyncEnumerator());
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public void DisposesResponseWhenEnumerationFails()
    {
        MockPipelineResponse response = CreateResponse();
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            static (_, cancellationToken) => ThrowAfterValue(cancellationToken));

        Assert.ThrowsAsync<InvalidOperationException>(
            async () => await ToArrayAsync(result));
        Assert.IsNull(response.ContentStream);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void EitherCancellationTokenInterruptsProducer(bool cancelOperationToken)
    {
        MockPipelineResponse response = CreateResponse();
        using CancellationTokenSource operation = new();
        using CancellationTokenSource enumeration = new();
        CancellationToken receivedToken = default;
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            (_, cancellationToken) =>
            {
                receivedToken = cancellationToken;
                return WaitForCancellation(cancellationToken);
            },
            operation.Token);
        IAsyncEnumerator<int> enumerator =
            result.GetAsyncEnumerator(enumeration.Token);
        Task<bool> moveNext = enumerator.MoveNextAsync().AsTask();

        if (cancelOperationToken)
        {
            operation.Cancel();
        }
        else
        {
            enumeration.Cancel();
        }

        Assert.IsTrue(receivedToken.CanBeCanceled);
        Assert.CatchAsync<OperationCanceledException>(async () => await moveNext);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task ConcurrentResultDisposalsShareEnumeratorCleanup()
    {
        MockPipelineResponse response = CreateResponse();
        BlockingAsyncDisposeEnumerable values = new();
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            (_, _) => values);
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());

        Task firstDisposal = result.DisposeAsync().AsTask();
        await values.DisposeStarted.Task;
        Task secondDisposal = result.DisposeAsync().AsTask();
        Assert.AreNotSame(
            secondDisposal,
            await Task.WhenAny(secondDisposal, Task.Delay(100)));

        values.AllowDispose.SetResult(null);
        await Task.WhenAll(firstDisposal, secondDisposal);

        Assert.AreEqual(1, values.DisposeCount);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task ReentrantDisposalDefersResponseDisposal()
    {
        MockPipelineResponse response = CreateResponse();
        ReentrantAsyncDisposeEnumerable values = new();
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            (_, _) => values);
        values.DisposeResult = result.DisposeAsync;
        values.IsResponseDisposed = () => response.ContentStream is null;
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());

        await enumerator.DisposeAsync();

        Assert.IsFalse(values.ResponseDisposedDuringCleanup);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task ResultDisposalCancelsAndWaitsForInFlightMoveNext()
    {
        MockPipelineResponse response = CreateResponse();
        TaskCompletionSource<object?> moveNextStarted =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskCompletionSource<object?> moveNextCompleted =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            (_, cancellationToken) => BlockingIterator(
                moveNextStarted,
                moveNextCompleted,
                cancellationToken));
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Task<bool> moveNext = enumerator.MoveNextAsync().AsTask();
        await moveNextStarted.Task;

        Task disposal = result.DisposeAsync().AsTask();
        Task timeout = Task.Delay(TimeSpan.FromSeconds(5));
        Assert.AreSame(disposal, await Task.WhenAny(disposal, timeout));
        Assert.DoesNotThrowAsync(async () => await disposal);
        Assert.CatchAsync<OperationCanceledException>(async () => await moveNext);

        Assert.IsTrue(moveNextCompleted.Task.IsCompleted);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task ConcurrentResultDisposalsWaitForInFlightMoveNext()
    {
        MockPipelineResponse response = CreateResponse();
        TaskCompletionSource<object?> moveNextStarted =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskCompletionSource<object?> moveNextCompleted =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            (_, cancellationToken) => BlockingIterator(
                moveNextStarted,
                moveNextCompleted,
                cancellationToken));
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Task<bool> moveNext = enumerator.MoveNextAsync().AsTask();
        await moveNextStarted.Task;

        Task firstDisposal = result.DisposeAsync().AsTask();
        Task secondDisposal = result.DisposeAsync().AsTask();
        Task disposals = Task.WhenAll(firstDisposal, secondDisposal);
        Assert.AreSame(
            disposals,
            await Task.WhenAny(disposals, Task.Delay(TimeSpan.FromSeconds(5))));
        Assert.DoesNotThrowAsync(async () => await disposals);
        Assert.CatchAsync<OperationCanceledException>(async () => await moveNext);

        Assert.IsTrue(moveNextCompleted.Task.IsCompleted);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task ConcurrentDisposalsBeforeEnumerationShareCompletion()
    {
        BlockingDisposeStream stream = new();
        MockPipelineResponse response = new(200)
        {
            ContentStream = stream
        };
        AsyncStreamingClientResult<int> result = CreateResult([1], response);

        Task firstDisposal = Task.Run(async () => await result.DisposeAsync());
        await stream.DisposeStarted.Task;
        Task secondDisposal = result.DisposeAsync().AsTask();

        Assert.IsFalse(secondDisposal.IsCompleted);
        stream.AllowDispose.Set();
        await Task.WhenAll(firstDisposal, secondDisposal);
        Assert.Throws<ObjectDisposedException>(() => result.GetAsyncEnumerator());
        Assert.IsTrue(stream.IsDisposed);
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task MoveNextCannotStartAfterResultDisposalBegins()
    {
        MockPipelineResponse response = CreateResponse();
        BlockingAsyncDisposeEnumerable values = new();
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            (_, _) => values);
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Assert.IsTrue(await enumerator.MoveNextAsync());

        Task disposal = result.DisposeAsync().AsTask();
        await values.DisposeStarted.Task;

        Assert.ThrowsAsync<ObjectDisposedException>(
            async () => await enumerator.MoveNextAsync());

        values.AllowDispose.TrySetResult(null);
        await disposal;
        Assert.IsNull(response.ContentStream);
    }

    [Test]
    public async Task ResultDisposalClosesStreamToInterruptNonCooperativeRead()
    {
        BlockingReadStream stream = new();
        MockPipelineResponse response = new(200)
        {
            ContentStream = stream
        };
        AsyncStreamingClientResult<int> result = AsyncStreamingClientResult.Create(
            response,
            static (content, cancellationToken) =>
                ReadIgnoringCancellation(content, cancellationToken));
        IAsyncEnumerator<int> enumerator = result.GetAsyncEnumerator();
        Task<bool> moveNext = enumerator.MoveNextAsync().AsTask();
        await stream.ReadStarted.Task;

        Task disposal = result.DisposeAsync().AsTask();
        Assert.AreSame(
            disposal,
            await Task.WhenAny(disposal, Task.Delay(TimeSpan.FromSeconds(5))));
        await disposal;

        Assert.CatchAsync<OperationCanceledException>(async () => await moveNext);
        Assert.IsTrue(stream.IsDisposed);
        Assert.IsNull(response.ContentStream);
    }

    private static MockPipelineResponse CreateResponse()
        => new MockPipelineResponse(200).SetContent("stream");

    private static AsyncStreamingClientResult<int> CreateResult(
        IEnumerable<int> values,
        PipelineResponse response)
        => AsyncStreamingClientResult.Create(
            response,
            (_, cancellationToken) => GetValues(values, cancellationToken));

    private static async IAsyncEnumerable<int> GetValues(
        IEnumerable<int> values,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.Yield();
        foreach (int value in values)
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return value;
        }
    }

    private static async IAsyncEnumerable<int> ThrowAfterValue(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.Yield();
        cancellationToken.ThrowIfCancellationRequested();
        yield return 1;
        throw new InvalidOperationException();
    }

    private static async IAsyncEnumerable<int> WaitForCancellation(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.Delay(Timeout.Infinite, cancellationToken);
        yield break;
    }

    private static async IAsyncEnumerable<int> BlockingIterator(
        TaskCompletionSource<object?> moveNextStarted,
        TaskCompletionSource<object?> moveNextCompleted,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        moveNextStarted.TrySetResult(null);
        try
        {
            await Task.Delay(Timeout.Infinite, cancellationToken);
            yield return 1;
        }
        finally
        {
            moveNextCompleted.TrySetResult(null);
        }
    }

    private static async IAsyncEnumerable<int> ReadIgnoringCancellation(
        Stream stream,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        byte[] buffer = new byte[1];
        int bytesRead = await stream.ReadAsync(
            buffer,
            0,
            buffer.Length,
            CancellationToken.None);
        cancellationToken.ThrowIfCancellationRequested();
        if (bytesRead > 0)
        {
            yield return buffer[0];
        }
    }

    private static async Task<int[]> ToArrayAsync(IAsyncEnumerable<int> values)
    {
        List<int> result = [];
        await foreach (int value in values)
        {
            result.Add(value);
        }
        return result.ToArray();
    }

    private sealed class BlockingAsyncDisposeEnumerable : IAsyncEnumerable<int>
    {
        private int _disposeCount;

        public TaskCompletionSource<object?> DisposeStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource<object?> AllowDispose { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        public int DisposeCount => _disposeCount;

        public IAsyncEnumerator<int> GetAsyncEnumerator(
            CancellationToken cancellationToken = default) => new Enumerator(this);

        private sealed class Enumerator(BlockingAsyncDisposeEnumerable owner)
            : IAsyncEnumerator<int>
        {
            public int Current => 1;

            public ValueTask<bool> MoveNextAsync() => new(true);

            public async ValueTask DisposeAsync()
            {
                Interlocked.Increment(ref owner._disposeCount);
                owner.DisposeStarted.TrySetResult(null);
                await owner.AllowDispose.Task;
            }
        }
    }

    private sealed class ReentrantAsyncDisposeEnumerable : IAsyncEnumerable<int>
    {
        public Func<ValueTask>? DisposeResult { get; set; }
        public Func<bool>? IsResponseDisposed { get; set; }
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
                await owner.DisposeResult!();
                owner.ResponseDisposedDuringCleanup = owner.IsResponseDisposed!();
            }
        }
    }

    private sealed class BlockingReadStream : Stream
    {
        private readonly TaskCompletionSource<int> _readCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<object?> ReadStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        public bool IsDisposed { get; private set; }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override Task<int> ReadAsync(
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
        {
            ReadStarted.TrySetResult(null);
            return _readCompletion.Task;
        }

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing && !IsDisposed)
            {
                IsDisposed = true;
                _readCompletion.TrySetResult(0);
            }
            base.Dispose(disposing);
        }
    }

    private sealed class BlockingDisposeStream : Stream
    {
        private int _disposeStarted;

        public TaskCompletionSource<object?> DisposeStarted { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        public ManualResetEventSlim AllowDispose { get; } = new();
        public bool IsDisposed { get; private set; }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => 0;
        public override long Position
        {
            get => 0;
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count) => 0;

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        protected override void Dispose(bool disposing)
        {
            if (disposing && Interlocked.Exchange(ref _disposeStarted, 1) == 0)
            {
                DisposeStarted.TrySetResult(null);
                AllowDispose.Wait();
                IsDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
