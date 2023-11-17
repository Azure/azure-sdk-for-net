// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests;

[TestFixture]
public class StreamingResponseTests
{
    [Test]
    public async Task SingleEnumeration()
    {
        byte[] responseCharacters = Encoding.UTF8.GetBytes("abcde");
        using Stream responseStream = new MemoryStream(responseCharacters);

        StreamingResponse<char> response = StreamingResponse<char>.CreateFromResponse(
            response: new TestResponse(responseStream),
            asyncEnumerableProcessor: (r) => EnumerateCharactersFromResponse(r));

        int index = 0;
        await foreach (char characterInResponse in response)
        {
            Assert.That(index < responseCharacters.Length);
            Assert.That((char)responseCharacters[index] == characterInResponse);
            index++;
        }
        Assert.That(index == responseCharacters.Length);
    }

    [Test]
    public async Task CancellationViaParameter()
    {
        byte[] responseCharacters = Encoding.UTF8.GetBytes("abcdefg");
        using Stream responseStream = new MemoryStream(responseCharacters);

        var cancelSource = new CancellationTokenSource();

        StreamingResponse<char> response = StreamingResponse<char>.CreateFromResponse(
            response: new TestResponse(responseStream),
            asyncEnumerableProcessor: (r) => EnumerateCharactersFromResponse(r, cancelSource.Token));

        int index = 0;
        await foreach (char characterInResponse in response)
        {
            Assert.That(index < responseCharacters.Length);
            Assert.That((char)responseCharacters[index] == characterInResponse);
            if (index == 2)
            {
                cancelSource.Cancel();
            }
            index++;
        }
        Assert.That(index == 3);
    }

    [Test]
    public async Task CancellationViaWithCancellation()
    {
        byte[] responseCharacters = Encoding.UTF8.GetBytes("abcdefg");
        using Stream responseStream = new MemoryStream(responseCharacters);

        async static IAsyncEnumerable<char> EnumerateViaWithCancellation(
            Response response,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            ConfiguredCancelableAsyncEnumerable<char> enumerable
                = EnumerateCharactersFromResponse(response).WithCancellation(cancellationToken);
            await foreach (var character in enumerable)
            {
                yield return character;
            }
        }

        var cancelSource = new CancellationTokenSource();

        StreamingResponse<char> response = StreamingResponse<char>.CreateFromResponse(
            response: new TestResponse(responseStream),
            asyncEnumerableProcessor: (r) => EnumerateViaWithCancellation(r, cancelSource.Token));

        int index = 0;
        await foreach (char characterInResponse in response)
        {
            Assert.That(index < responseCharacters.Length);
            Assert.That((char)responseCharacters[index] == characterInResponse);
            if (index == 2)
            {
                cancelSource.Cancel();
            }
            index++;
        }
        Assert.That(index == 3);
    }

    [Test]
    public async Task CancellationWhenThrowing()
    {
        byte[] responseCharacters = Encoding.UTF8.GetBytes("abcdefg");
        using Stream responseStream = new MemoryStream(responseCharacters);

        var cancelSource = new CancellationTokenSource();

        StreamingResponse<char> response = StreamingResponse<char>.CreateFromResponse(
            response: new TestResponse(responseStream),
            asyncEnumerableProcessor: (r) => EnumerateCharactersFromResponse(r, cancelSource.Token));

        int index = 0;
        await foreach (char characterInResponse in response)
        {
            Assert.That(index < responseCharacters.Length);
            Assert.That((char)responseCharacters[index] == characterInResponse);
            if (index == 2)
            {
                cancelSource.Cancel();
            }
            index++;
        }
        Assert.That(index == 3);

        Exception exception = null;
        try
        {
            cancelSource.Token.ThrowIfCancellationRequested();
        }
        catch (Exception ex)
        {
            exception = ex;
        }

        Assert.That(exception, Is.InstanceOf<OperationCanceledException>());
    }

    private static async IAsyncEnumerable<char> EnumerateCharactersFromResponse(
        Response responseToEnumerate,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        if (responseToEnumerate?.ContentStream?.CanRead == true)
        {
            byte[] buffer = new byte[1];
            while (
                !cancellationToken.IsCancellationRequested
                    && (await responseToEnumerate.ContentStream.ReadAsync(buffer, 0, 1)) == 1)
            {
                yield return (char)buffer[0];
            }
        }
    }

    private class TestResponse : Response
    {
        public override int Status => throw new NotImplementedException();

        public override string ReasonPhrase => throw new NotImplementedException();

        public override Stream ContentStream
        {
            get => _contentStream;
            set => throw new NotImplementedException();
        }

        public override string ClientRequestId
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        private Stream _contentStream { get; }

        public TestResponse(Stream stream)
        {
            _contentStream = stream;
        }

        public override void Dispose() => _contentStream?.Dispose();

        protected override bool ContainsHeader(string name) => throw new NotImplementedException();

        protected override IEnumerable<HttpHeader> EnumerateHeaders()
            => throw new NotImplementedException();

        protected override bool TryGetHeader(string name, out string value)
            => throw new NotImplementedException();

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            => throw new NotImplementedException();
    }
}
