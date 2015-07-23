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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a stream Avro writer.
    /// </summary>
    /// <typeparam name="T">The type of Avro objects to be written into the output stream.</typeparam>
    internal sealed class StreamWriter<T> : IAvroWriter<T>
    {
        private readonly IEncoder encoder;
        private readonly IAvroSerializer<T> serializer;
        private readonly Codec codec;
        private readonly Stream resultStream;
        private readonly ObjectContainerHeader header;
        private readonly object locker;
        private volatile bool isHeaderWritten;

        public StreamWriter(Stream stream, bool leaveOpen, IAvroSerializer<T> serializer, Codec codec)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            if (codec == null)
            {
                throw new ArgumentNullException("codec");
            }

            this.codec = codec;
            this.serializer = serializer;
            this.resultStream = stream;
            this.encoder = new BinaryEncoder(this.resultStream, leaveOpen);
            this.isHeaderWritten = false;
            this.locker = new object();

            var syncMarker = new byte[16];
            new Random().NextBytes(syncMarker);
            this.header = new ObjectContainerHeader(syncMarker) { CodecName = this.codec.Name, Schema = this.serializer.WriterSchema.ToString() };
        }

        /// <summary>
        ///     Closes this instance.
        /// </summary>
        public void Close()
        {
            this.encoder.Dispose();
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }

        public void SetMetadata(IDictionary<string, byte[]> metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            foreach (var record in metadata)
            {
                this.header.AddMetadata(record.Key, record.Value);
            }
        }

        [SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "Disposable is returned as the result of this operation.")]
        public Task<IAvroWriterBlock<T>> CreateBlockAsync()
        {
            var taskSource = new TaskCompletionSource<IAvroWriterBlock<T>>();
            AvroBufferWriterBlock<T> block = null;
            try
            {
                block = new AvroBufferWriterBlock<T>(this.serializer, this.codec);
                taskSource.SetResult(block);
                return taskSource.Task;
            }
            catch
            {
                if (block != null)
                {
                    block.Dispose();
                }
                throw;
            }
        }

        public Task<long> WriteBlockAsync(IAvroWriterBlock<T> block)
        {
            if (block == null)
            {
                throw new ArgumentNullException("block");
            }

            var taskSource = new TaskCompletionSource<long>();
            block.Flush();

            long result;
            lock (this.locker)
            {
                if (!this.isHeaderWritten)
                {
                    this.header.Write(this.encoder);
                    this.isHeaderWritten = true;
                }

                result = this.resultStream.Position;
                if (block.ObjectCount != 0)
                {
                    this.encoder.Encode(block.ObjectCount);
                    this.encoder.Encode(block.Content);
                    this.encoder.EncodeFixed(this.header.SyncMarker);
                }
            }

            taskSource.SetResult(result);
            return taskSource.Task;
        }

        public IAvroWriterBlock<T> CreateBlock()
        {
            return this.CreateBlockAsync().Result;
        }

        public long WriteBlock(IAvroWriterBlock<T> block)
        {
            return this.WriteBlockAsync(block).Result;
        }
    }
}
