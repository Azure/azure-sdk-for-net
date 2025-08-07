// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.IO;

namespace System.ClientModel.Tests.Message;

public class PipelineResponseTests
{
    [Test]
    public void ContentPropertyGetsContent()
    {
        var response = new MockPipelineResponse(200);
        Assert.AreEqual(0, response.Content.ToArray().Length);

        var responseWithBody = new MockPipelineResponse(200);
        responseWithBody.SetContent("body content");
        Assert.AreEqual("body content", responseWithBody.Content.ToString());

        // Ensure that the BinaryData is formed over the used portion of the memory stream, not the entire buffer.
        MemoryStream ms = new MemoryStream(50);
        var responseWithEmptyBody = new MockPipelineResponse(200);
        responseWithEmptyBody.ContentStream = ms;
        Assert.AreEqual(0, response.Content.ToArray().Length);

        // Ensure that even if the stream has been read and the cursor is sitting at the end of stream, the
        // `Content` property still contains the entire response.
        var responseWithBodyFullyRead = new MockPipelineResponse(200);
        responseWithBodyFullyRead.SetContent("body content");
        responseWithBodyFullyRead.ContentStream!.Seek(0, SeekOrigin.End);
        Assert.AreEqual("body content", responseWithBody.Content.ToString());
    }

    [Test]
    public void ContentPropertyThrowsForNonMemoryStream()
    {
        var response = new MockPipelineResponse(200);
        response.ContentStream = new ThrowingStream();

        Assert.Throws<InvalidOperationException>(() => { BinaryData d = response.Content; });
    }

    #region Helpers

    internal class ThrowingStream : Stream
    {
        public override bool CanRead => throw new System.NotImplementedException();

        public override bool CanSeek => throw new System.NotImplementedException();

        public override bool CanWrite => throw new System.NotImplementedException();

        public override long Length => throw new System.NotImplementedException();

        public override long Position { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override void Flush()
        {
            throw new System.NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new System.NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new System.NotImplementedException();
        }
    }

    #endregion
}
