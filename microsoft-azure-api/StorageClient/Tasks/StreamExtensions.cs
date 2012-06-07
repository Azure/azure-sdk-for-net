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
// <summary>
//    Contains code for the StreamExtensions class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Tasks
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography;

    using TaskSequence = System.Collections.Generic.IEnumerable<ITask>;

    /// <summary>
    /// Provides extensions for the stream object to support asynchronous operations.
    /// </summary>
    internal static class StreamExtensions
    {
        /// <summary>
        /// Buffer size needs to be page-aligned.
        /// </summary>
        private const int BufferSize = 64 * 1024;

        /// <summary>
        /// Asynchronously reads data from a stream using BeginRead.
        /// </summary>
        /// <param name="stream">The stream on which the method is called.</param>
        /// <param name="buffer">The buffer to read the data into.</param>
        /// <param name="offset">Byte offset in the buffer.</param>
        /// <param name="count">Maximum number of bytes to read.</param>
        /// <returns>Returns non-zero if there are still some data to read.</returns>
        [DebuggerNonUserCode]
        internal static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            return new APMTask<int>(
                (callback, st) => stream.BeginRead(buffer, offset, count, callback, st),
                stream.EndRead);
        }

        /// <summary>
        /// Reads asynchronously the entire content of the stream and returns it 
        /// as a string using StreamReader.
        /// </summary>
        /// <param name="stream">The stream on which the method is called.</param>
        /// <param name="encoding">The text encoding used for converting bytes read into string.</param>
        /// <param name="result">The action to be performed with the resulting string.</param>
        /// <returns>Returns a task sequence that must be performed to get result string using the 'Result' callback.</returns>
        [DebuggerNonUserCode]
        internal static TaskSequence ReadToString(this Stream stream, System.Text.Encoding encoding, Action<string> result)
        {
            using (var ms = new SmallBlockMemoryStream())
            {
                int read = -1;
                while (read != 0)
                {
                    byte[] buffer = new byte[1024];
                    Task<int> count = stream.ReadAsync(buffer, 0, 1024);
                    yield return count;

                    ms.Write(buffer, 0, count.Result);
                    read = count.Result;
                }

                ms.Seek(0, SeekOrigin.Begin);
                using (var strm = new StreamReader(ms, encoding))
                {
                    result(strm.ReadToEnd());
                }
            }
        }

        /// <summary>
        /// Asynchronously writes data from a stream using BeginWrite.
        /// </summary>
        /// <param name="stream">The stream on which the method is called.</param>
        /// <param name="buffer">The buffer to write the data from.</param>
        /// <param name="offset">Byte offset in the buffer.</param>
        /// <param name="count">Maximum number of bytes to write.</param>
        /// <returns>A task with no return value.</returns>
        [DebuggerNonUserCode]
        internal static Task<NullTaskReturn> WriteAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            return new APMTask(
                (callback, st) => stream.BeginWrite(buffer, offset, count, callback, st),
                (res) => { stream.EndWrite(res); });
        }

        /// <summary>
        /// Reads asynchronously the entire content of the stream and writes it to the given output stream.
        /// </summary>
        /// <param name="stream">The origin stream.</param>
        /// <param name="toStream">The destination stream.</param>
        /// <returns>The sequence that when invoked results in an asynchronous copy.</returns>
        [DebuggerNonUserCode]
        internal static TaskSequence WriteTo(this Stream stream, Stream toStream)
        {
            int readCount;
            do
            {
                byte[] buffer = new byte[BufferSize];
                var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
                yield return readTask;
                readCount = readTask.Result;

                var writeTask = toStream.WriteAsync(buffer, 0, readCount);
                yield return writeTask;
                var scratch = writeTask.Result;
            }
            while (readCount != 0);
        }

        /// <summary>
        /// Compute the MD5 hash of the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="setResult">A delegate for setting the resulting MD5 hash as a string.</param>
        /// <returns>The sequence that when invoked results in an asynchronous MD5 computation.</returns>
        [DebuggerNonUserCode]
        internal static TaskSequence ComputeMD5(this Stream stream, Action<string> setResult)
        {
            int readCount;
            MD5 md5 = MD5.Create();
            do
            {
                byte[] buffer = new byte[BufferSize];
                var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
                yield return readTask;
                readCount = readTask.Result;

                StreamUtilities.ComputeHash(buffer, 0, readCount, md5);
            }
            while (readCount != 0);

            setResult(StreamUtilities.GetHashValue(md5));
        }

        /// <summary>
        /// Reads synchronously the entire content of the stream and writes it to the given output stream.
        /// </summary>
        /// <param name="stream">The origin stream.</param>
        /// <param name="toStream">The destination stream.</param>       
        [DebuggerNonUserCode]
        internal static void WriteToSync(this Stream stream, Stream toStream)
        {
            int readCount;
            do
            {
                byte[] buffer = new byte[BufferSize];
                readCount = stream.EndRead(stream.BeginRead(buffer, 0, buffer.Length, null /* Callback */, null /* State */));
                toStream.Write(buffer, 0, readCount);
            }
            while (readCount != 0);
        }

        /// <summary>
        /// Reads asynchronously the entire content of the stream and writes it to the given output stream.
        /// Closes the output stream at the end.
        /// </summary>
        /// <param name="stream">The origin stream.</param>
        /// <param name="toStream">The destination stream.</param>
        /// <returns>The sequence that when invoked results in an asynchronous copy.</returns>
        [DebuggerNonUserCode]
        internal static TaskSequence WriteToAndCloseOutput(this Stream stream, Stream toStream)
        {
            int readCount;
            try
            {
                do
                {
                    byte[] buffer = new byte[BufferSize];
                    var readTask = stream.ReadAsync(buffer, 0, buffer.Length);
                    yield return readTask;
                    readCount = readTask.Result;

                    var writeTask = toStream.WriteAsync(buffer, 0, readCount);
                    yield return writeTask;
                    var scratch = writeTask.Result;
                }
                while (readCount != 0);
            }
            finally
            {
                toStream.Close();
                toStream.Dispose();
            }
        }
    }
}
