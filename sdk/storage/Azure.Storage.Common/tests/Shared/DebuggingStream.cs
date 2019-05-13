// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.IO;

namespace Azure.Storage.Test.Shared
{
    class DebuggingStream : Stream
    {
        readonly Stream innerStream;

        public DebuggingStream(Stream innerStream) => this.innerStream = innerStream;

        public override bool CanRead => this.innerStream.CanRead;

        public override bool CanSeek => this.innerStream.CanSeek;

        public override bool CanWrite => this.innerStream.CanWrite;

        public override long Length => this.innerStream.Length;

        public override long Position { get => this.innerStream.Position; set => this.innerStream.Position = value; }

        public override void Flush() => this.innerStream.Flush();

        public override int Read(byte[] buffer, int offset, int count) => this.innerStream.Read(buffer, offset, count);

        public override long Seek(long offset, SeekOrigin origin) => this.innerStream.Seek(offset, origin);

        public override void SetLength(long value) => this.innerStream.SetLength(value);

        public override void Write(byte[] buffer, int offset, int count) => this.innerStream.Write(buffer, offset, count);

        protected override void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
