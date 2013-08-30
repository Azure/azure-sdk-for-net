//-----------------------------------------------------------------------
// <copyright file="SyncMemoryStream.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Core
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// This class provides APM Read/Write overrides for memory stream to improve performance.
    /// </summary>
    internal class SyncMemoryStream : MemoryStream
    {
        /// <summary>
        /// Initializes a new instance of the SyncMemoryStream class with an expandable capacity initialized to zero.
        /// </summary>
        public SyncMemoryStream()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new non-resizable instance of the SyncMemoryStream class based on the specified byte array. 
        /// </summary>
        /// <param name="buffer">The array of unsigned bytes from which to create the current stream.</param>
        public SyncMemoryStream(byte[] buffer)
            : base(buffer)
        {
        }

        /// <summary>
        /// Initializes a new non-resizable instance of the SyncMemoryStream class based on the specified region (index) of a byte array. 
        /// </summary>
        /// <param name="buffer">The array of unsigned bytes from which to create the current stream.</param>
        /// <param name="index">The index into buffer at which the stream begins.</param>
        public SyncMemoryStream(byte[] buffer, int index)
            : base(buffer, index, buffer.Length - index)
        {
        }

        /// <summary>
        /// Initializes a new non-resizable instance of the SyncMemoryStream class based on the specified region (index) of a byte array. 
        /// </summary>
        /// <param name="buffer">The array of unsigned bytes from which to create the current stream.</param>
        /// <param name="index">The index into buffer at which the stream begins.</param>
        /// <param name="count">The length of the stream in bytes.</param>
        public SyncMemoryStream(byte[] buffer, int index, int count)
            : base(buffer, index, count)
        {
        }

#if !WINDOWS_RT
        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="buffer">When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous read, which could still be pending.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            StorageAsyncResult<int> result = new StorageAsyncResult<int>(callback, state);

            try
            {
                result.Result = this.Read(buffer, offset, count);
                result.OnComplete();
            }
            catch (Exception e)
            {
                result.OnComplete(e);
            }

            return result;
        }

        /// <summary>
        /// Waits for the pending asynchronous read to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero if the end of the stream has been reached.</returns>
        public override int EndRead(IAsyncResult asyncResult)
        {
            StorageAsyncResult<int> result = (StorageAsyncResult<int>)asyncResult;
            result.End();
            return result.Result;
        }

        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to write.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous write, which could still be pending.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads")]
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            StorageAsyncResult<NullType> result = new StorageAsyncResult<NullType>(callback, state);

            try
            {
                this.Write(buffer, offset, count);
                result.OnComplete();
            }
            catch (Exception e)
            {
                result.OnComplete(e);
            }

            return result;
        }

        /// <summary>
        /// Ends an asynchronous write operation.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> result = (StorageAsyncResult<NullType>)asyncResult;
            result.End();
        }
#endif
    }
}
