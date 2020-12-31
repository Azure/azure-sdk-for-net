// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Core.TestFramework
{
    public class NonSeekableMemoryStream : MemoryStream
    {
        public NonSeekableMemoryStream()
        {
        }

        public NonSeekableMemoryStream(byte[] buffer) : base(buffer)
        {
        }

        public override bool CanSeek => false;

        public override long Seek(long offset, SeekOrigin loc)
        {
            throw new NotImplementedException();
        }

        public override long Position
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public void Reset()
        {
            base.Position = 0;
        }
    }
}
