// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryFrontEnd.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Unit tests for the  class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Management.DataLake.StoreUploader.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   using Microsoft.Azure.Management.DataLake.StoreUploader;

    /// <summary>
    /// Test front-end, fully in-memory.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    internal class InMemoryFrontEnd : IFrontEndAdapter
    {

        private readonly Dictionary<string, StreamData> _streams = new Dictionary<string, StreamData>();

        public void CreateStream(string streamPath, bool overwrite, byte[] data, int byteCount)
        {
            if (overwrite)
            {
                _streams[streamPath] = new StreamData(streamPath);
            }
            else
            {
                if (StreamExists(streamPath))
                {
                    throw new Exception("stream exists");
                }
                _streams.Add(streamPath, new StreamData(streamPath));
            }

            // if there is data passed in, we should do the same operation as in append
            if (data != null)
            {
                if (byteCount > data.Length)
                {
                    throw new Exception("invalid byteCount");
                }

                var stream = _streams[streamPath];

                //always make a copy of the original buffer since it is reused
                byte[] toAppend = new byte[byteCount];
                Array.Copy(data, toAppend, byteCount);

                stream.Append(toAppend);
            }
        }

        public void DeleteStream(string streamPath, bool recurse = false)
        {
            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }
            _streams.Remove(streamPath);
        }

        public void AppendToStream(string streamPath, byte[] data, long offset, int byteCount)
        {
            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }

            if (byteCount > data.Length)
            {
                throw new Exception("invalid byteCount");
            }

            var stream = _streams[streamPath];
            if (stream.Length != offset)
            {
                throw new InvalidOperationException("offset != stream.length");
            }

            //always make a copy of the original buffer since it is reused
            byte[] toAppend = new byte[byteCount];
            Array.Copy(data, toAppend, byteCount);

            stream.Append(toAppend);
        }

        public bool StreamExists(string streamPath)
        {
            return _streams.ContainsKey(streamPath);
        }

        public long GetStreamLength(string streamPath)
        {
            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }

            return _streams[streamPath].Length;            
        }

        public void Concatenate(string targetStreamPath, string[] inputStreamPaths)
        {
            if (StreamExists(targetStreamPath))
            {
                throw new Exception("target stream exists");
            }

            const int bufferSize = 4 * 1024 * 1024;
            byte[] buffer = new byte[bufferSize];

            try
            {
                CreateStream(targetStreamPath, true, null, 0);
                var targetStream = _streams[targetStreamPath];

                foreach (var inputStreamPath in inputStreamPaths)
                {
                    if (!StreamExists(inputStreamPath))
                    {
                        throw new Exception("input stream does not exist");
                    }

                    var stream = _streams[inputStreamPath];
                    foreach (var chunk in stream.GetDataChunks())
                    {
                        targetStream.Append(chunk);
                    }
                }
            }
            catch
            {
                if (StreamExists(targetStreamPath))
                {
                    DeleteStream(targetStreamPath);
                }
                throw;
            }

            foreach (var inputStreamPath in inputStreamPaths)
            {
                DeleteStream(inputStreamPath);
            }
        }

        public IEnumerable<byte[]> GetAppendBlocks(string streamPath)
        {
            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }

            var sd = _streams[streamPath];
            return sd.GetDataChunks();
        }

        public byte[] GetStreamContents(string streamPath)
        {
            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }

            var sd = _streams[streamPath];

            if (sd.Length > Int32.MaxValue)
            {
                throw new OutOfMemoryException("Stream has too much data and cannot be fit into a single array");
            }

            byte[] result = new byte[sd.Length];
            int position = 0;
            foreach (var chunk in sd.GetDataChunks())
            {
                chunk.CopyTo(result, position);
                position += chunk.Length;
            }

            return result;
        }

        public int StreamCount
        {
            get { return _streams.Count; }
        }

        private class StreamData
        {
            private readonly LinkedList<byte[]> _data;

            public StreamData(string name)
            {
                _data = new LinkedList<byte[]>();
                this.Name = name;
                this.Length = 0;
            }

            public string Name { get; private set; }
            public long Length { get; private set; }

            public void Append(byte[] data)
            {
                _data.AddLast(data);
                this.Length += data.Length;
            }

            public IEnumerable<byte[]> GetDataChunks()
            {
                return _data;
            }
        }
    }
}
