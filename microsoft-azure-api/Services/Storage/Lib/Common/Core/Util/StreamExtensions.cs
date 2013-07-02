//-----------------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

#if RT
    using System.Threading.Tasks;
    using System.Threading;
#endif

    /// <summary>
    /// Provides stream helper methods that allow us to copy streams and measure the stream size.
    /// </summary>
    internal static class StreamExtensions
    {
        [DebuggerNonUserCode]
        internal static int GetBufferSize(Stream inStream)
        {
            if (inStream.CanSeek && inStream.Length - inStream.Position > 0)
            {
                return (int)Math.Min(inStream.Length - inStream.Position, (long)Constants.DefaultBufferSize);
            }
            else
            {
                return Constants.DefaultBufferSize;
            }
        }

#if !RT
        /// <summary>
        /// Reads synchronously the entire content of the stream and writes it to the given output stream.
        /// </summary>
        /// <param name="stream">The origin stream.</param>
        /// <param name="toStream">The destination stream.</param>
        /// <param name="maxLength">Maximum length of the stream to write.</param>
        /// <param name="expiryTime">DateTime indicating the expiry time.</param>
        /// <param name="calculateMd5">Bool value indicating whether the Md5 should be calculated.</param>
        /// <param name="syncRead">A boolean indicating whether the write happens synchronously.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="streamCopyState">State of the stream copy.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">stream</exception>
        [DebuggerNonUserCode]
        internal static void WriteToSync(this Stream stream, Stream toStream, long? maxLength, DateTime? expiryTime, bool calculateMd5, bool syncRead, OperationContext operationContext, StreamDescriptor streamCopyState)
        {
            byte[] buffer = new byte[GetBufferSize(stream)];

            if (streamCopyState != null && calculateMd5 && streamCopyState.Md5HashRef == null)
            {
                streamCopyState.Md5HashRef = new MD5Wrapper();
            }

            int readCount;
            do
            {
                if (expiryTime.HasValue && DateTime.Now.CompareTo(expiryTime.Value) > 0)
                {
                    throw Exceptions.GenerateTimeoutException(operationContext.LastResult, null);
                }

                if (syncRead)
                {
                    readCount = stream.Read(buffer, 0, buffer.Length);
                }
                else
                {
                    // Use an async read since Sync read on ConnectStream will not throw for prematurely closed connections 
                    readCount = stream.EndRead(stream.BeginRead(buffer, 0, buffer.Length, null /* Callback */, null /* State */));
                }

                toStream.Write(buffer, 0, readCount);

                // Update the StreamDescriptor after the bytes are successfully committed to the output stream
                if (streamCopyState != null)
                {
                    streamCopyState.Length += readCount;

                    if (maxLength.HasValue && streamCopyState.Length > maxLength.Value)
                    {
                        throw new ArgumentOutOfRangeException("stream");
                    }

                    if (streamCopyState.Md5HashRef != null)
                    {
                        streamCopyState.Md5HashRef.UpdateHash(buffer, 0, readCount);
                    }
                }
            }
            while (readCount != 0);

            if (streamCopyState != null && streamCopyState.Md5HashRef != null)
            {
                streamCopyState.Md5 = streamCopyState.Md5HashRef.ComputeHash();
                streamCopyState.Md5HashRef = null;
            }
        }
#endif

#if RT
        internal static async Task WriteToAsync(this Stream stream, Stream toStream, long? maxLength, bool calculateMd5, OperationContext operationContext, StreamDescriptor streamCopyState, CancellationToken token)
        {
            byte[] buffer = new byte[GetBufferSize(stream)];

            if (streamCopyState != null && calculateMd5 && streamCopyState.Md5HashRef == null)
            {
                streamCopyState.Md5HashRef = new MD5Wrapper();
            }

            int readCount;
            do
            {
                readCount = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                await toStream.WriteAsync(buffer, 0, readCount, token);

                // Update the StreamDescriptor after the bytes are successfully committed to the output stream
                if (streamCopyState != null)
                {
                    streamCopyState.Length += readCount;

                    if (maxLength.HasValue && streamCopyState.Length > maxLength.Value)
                    {
                        throw new ArgumentOutOfRangeException("stream");
                    }

                    if (streamCopyState.Md5HashRef != null)
                    {
                        streamCopyState.Md5HashRef.UpdateHash(buffer, 0, readCount);
                    }
                }
            }
            while (readCount != 0);

            if (streamCopyState != null && streamCopyState.Md5HashRef != null)
            {
                streamCopyState.Md5 = streamCopyState.Md5HashRef.ComputeHash();
                streamCopyState.Md5HashRef = null;
            }
        }

#elif DNCP
        /// <summary>
        /// Reads synchronously the entire content of the stream and writes it to the given output stream.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream">The origin stream.</param>
        /// <param name="toStream">The destination stream.</param>
        /// <param name="maxLength">Maximum length of the stream to write.</param>
        /// <param name="expiryTime">DateTime indicating the expiry time.</param>
        /// <param name="calculateMd5">Bool value indicating whether the Md5 should be calculated.</param>
        /// <param name="executionState">StorageCommand that stores state about its execution.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="streamCopyState">State of the stream copy.</param>
        /// <param name="completed">The action taken when the execution is completed.</param>
        [DebuggerNonUserCode]
        internal static void WriteToAsync<T>(this Stream stream, Stream toStream, long? maxLength, DateTime? expiryTime, bool calculateMd5, ExecutionState<T> executionState, OperationContext operationContext, StreamDescriptor streamCopyState, Action<ExecutionState<T>> completed)
        {
            AsyncStreamCopier<T> copier = new AsyncStreamCopier<T>(stream, toStream, executionState, GetBufferSize(stream), calculateMd5, operationContext, streamCopyState);
            copier.StartCopyStream(completed, maxLength, expiryTime);
        }
#endif
    }
}
