// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Container
{
    using System;
    using System.IO;
    using System.IO.Compression;

    /// <summary>
    /// Wrapper around a stream supporting decompression on read.
    /// </summary>
    internal sealed class DecompressionStream : Stream
    {
        private readonly DeflateStream decompressed;

        public DecompressionStream(Stream compressed)
        {
            this.decompressed = new DeflateStream(compressed, CompressionMode.Decompress, true);
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void Flush()
        {
            this.decompressed.Close();
        }

        public override long Length
        {
            get { return this.decompressed.Length; }
        }

        public override long Position
        {
            get
            {
                return this.decompressed.Position;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Validated in base", MessageId = "0")]
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.decompressed.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", Justification = "Validated in base", MessageId = "0")]
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                this.decompressed.Dispose();
            }
        }
    }
}
