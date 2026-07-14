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
