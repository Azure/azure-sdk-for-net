// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.IO;

namespace System.ClientModel.Tests.Exceptions;

public class ClientRequestExceptionTests
{
    [Test]
    public void CanCreateFromResponse()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");

        ClientRequestException exception = new ClientRequestException(response);

        Assert.AreEqual(response.Status, exception.Status);
        Assert.AreEqual(response, exception.GetRawResponse());
        Assert.AreEqual("Service request failed.\r\nStatus: 200 (MockReason)\r\n", exception.Message);
    }

    [Test]
    public void PassingMessageOverridesResponseMessage()
    {
        PipelineResponse response = new MockPipelineResponse(200, "MockReason");
        string message = "Override Message";

        ClientRequestException exception = new ClientRequestException(response, message);

        Assert.AreEqual(response.Status, exception.Status);
        Assert.AreEqual(response, exception.GetRawResponse());
        Assert.AreEqual(message, exception.Message);
    }

    [Test]
    public void CanCreateFromMessage()
    {
        string message = "Override Message";

        ClientRequestException exception = new ClientRequestException(message);

        Assert.AreEqual(0, exception.Status);
        Assert.IsNull(exception.GetRawResponse());
        Assert.AreEqual(message, exception.Message);
    }

    [Test]
    public void UnbufferedResponseIsBuffered()
    {
        byte[] content = new byte[] { 0 };

        PipelineResponse response = new MockPipelineResponse(200, "MockReason");
        response.ContentStream = new UnbufferedStream(content);

        ClientRequestException exception = new ClientRequestException(response);

        Assert.AreEqual(response.Status, exception.Status);
        Assert.AreEqual(response, exception.GetRawResponse());

        // Accessing Content would throw if it hadn't been buffered.
        Assert.AreEqual(content, response.Content.ToArray());
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
