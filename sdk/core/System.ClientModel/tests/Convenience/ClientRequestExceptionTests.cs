// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.IO;
using System.Threading.Tasks;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Exceptions;

public class ClientResultExceptionTests
{
    [Test]
    public void CanCreateFromResponse()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");

        ClientResultException exception = new ClientResultException(response);

        Assert.That(exception.Status, Is.EqualTo(response.Status));
        Assert.That(exception.GetRawResponse(), Is.EqualTo(response));
        Assert.That(
            exception.Message,
            Is.EqualTo($"Service request failed.{Environment.NewLine}Status: 200 (MockReason){Environment.NewLine}"));
    }

    [Test]
    public async Task CanCreateFromAsyncFactory()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");

        ClientResultException exception = await ClientResultException.CreateAsync(response);

        Assert.That(exception.Status, Is.EqualTo(response.Status));
        Assert.That(exception.GetRawResponse(), Is.EqualTo(response));
        Assert.That(
            exception.Message,
            Is.EqualTo($"Service request failed.{Environment.NewLine}Status: 200 (MockReason){Environment.NewLine}"));
    }

    [Test]
    public void PassingMessageOverridesResponseMessage()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");
        string message = "Override Message";

        ClientResultException exception = new ClientResultException(message, response);

        Assert.That(exception.Status, Is.EqualTo(response.Status));
        Assert.That(exception.GetRawResponse(), Is.EqualTo(response));
        Assert.That(exception.Message, Is.EqualTo(message));
    }

    [Test]
    public void CanCreateFromMessage()
    {
        string message = "Override Message";

        ClientResultException exception = new ClientResultException(message);

        Assert.That(exception.Status, Is.EqualTo(0));
        Assert.That(exception.GetRawResponse(), Is.Null);
        Assert.That(exception.Message, Is.EqualTo(message));
    }

    [Test]
    public void UnbufferedResponseIsBuffered()
    {
        byte[] content = new byte[] { 0 };

        PipelineResponse response = new MockPipelineResponse(200, "MockReason");
        response.ContentStream = new UnbufferedStream(content);

        ClientResultException exception = new ClientResultException(response);

        Assert.That(exception.Status, Is.EqualTo(response.Status));
        Assert.That(exception.GetRawResponse(), Is.EqualTo(response));

        // Accessing Content would throw if it hadn't been buffered.
        Assert.That(response.Content.ToArray(), Is.EqualTo(content));
    }

    #region

    internal class UnbufferedStream : Stream
    {
        private readonly byte[] _bytes;
        private long _position;

        public UnbufferedStream(byte[] bytes)
        {
            _bytes = bytes;
            _position = 0;
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _bytes.Length;

        public override long Position
        {
            get => _position;
            set => _position = value;
        }

        public override void Flush() { }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (_position >= _bytes.Length)
            {
                return 0;
            }

            // Assumes we copy everything on the first read
            Array.Copy(_bytes, offset, buffer, offset, _bytes.Length);
            _position += _bytes.Length;
            return _bytes.Length;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return 0;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }

    #endregion
}
