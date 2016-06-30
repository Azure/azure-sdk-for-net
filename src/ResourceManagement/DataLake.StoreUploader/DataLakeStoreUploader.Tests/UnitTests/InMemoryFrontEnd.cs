// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InMemoryFrontEnd.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Unit tests for the  class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;

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

        public void DeleteStream(string streamPath, bool recurse = false, bool isDownload = false)
        {
            if (isDownload)
            {
                File.Delete(streamPath);
            }
            else
            {
                if (!StreamExists(streamPath, isDownload))
                {
                    throw new Exception("stream does not exist");
                }
                _streams.Remove(streamPath);
            }
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

        public bool StreamExists(string streamPath, bool isDownload = false)
        {
            if (isDownload)
            {
                return File.Exists(streamPath) || Directory.Exists(streamPath);
            }
            else
            {
                bool result = _streams.ContainsKey(streamPath);
                if(!result)
                {
                    // check to see if it is a folder by splitting on "/"
                    // because we only support (currently) one level of folders
                    // we will check the first index and if we find the folder return true.
                    foreach(var entry in _streams.Keys)
                    {
                        if (entry.Split('/')[0].Equals(streamPath, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                    }
                }

                return result;
            }
        }

        public long GetStreamLength(string streamPath, bool isDownload = false)
        {
            if(isDownload)
            {
                return new FileInfo(streamPath).Length;
            }

            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }

            return _streams[streamPath].Length;            
        }

        public void Concatenate(string targetStreamPath, string[] inputStreamPaths, bool isDownload = false)
        {
            if (isDownload)
            {
                using (var targetStream = new FileStream(targetStreamPath, FileMode.CreateNew))
                {
                    foreach (var inputPath in inputStreamPaths)
                    {
                        using (var inputStream = File.OpenRead(inputPath))
                        {
                            inputStream.CopyTo(targetStream);
                        }
                    }
                }

                // clean up all the files only in the event of success.
                foreach (var inputPath in inputStreamPaths)
                {
                    File.Delete(inputPath);
                }
            }
            else
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
        }

        public Stream ReadStream(string streamPath, long offset, long length, bool isDownload = false)
        {
            if (!isDownload)
            {
                // note that length is not used here since we will automatically stop reading once we reach the end of the stream.
                var stream = new FileStream(streamPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                if (offset >= stream.Length)
                {
                    throw new ArgumentException("StartOffset is beyond the end of the input file", "StartOffset");
                }

                stream.Seek(offset, SeekOrigin.Begin);
                return stream;
            }
            else
            {
                if (!StreamExists(streamPath))
                {
                    throw new Exception("stream does not exist");
                }
                
                if(offset > _streams[streamPath].Length || offset + length > _streams[streamPath].Length)
                {
                    throw new Exception(string.Format("Offset: {0} and Length: {1} results in going out of bounds of the current stream of length: {2}", offset, length, _streams[streamPath].Length));
                }

                var bytes = new List<byte>();
                foreach(var chunk in _streams[streamPath].GetDataChunks())
                {
                    bytes.AddRange(chunk);
                }

                return new MemoryStream(bytes.ToArray(), (int)offset, (int)length);
            }
        }

        #region helper methods
        public IEnumerable<byte[]> GetAppendBlocks(string streamPath)
        {
            if (!StreamExists(streamPath))
            {
                throw new Exception("stream does not exist");
            }

            var sd = _streams[streamPath];
            return sd.GetDataChunks();
        }

        public byte[] GetStreamContents(string streamPath, bool isDownload = false)
        {
            if (!StreamExists(streamPath, isDownload))
            {
                throw new Exception("stream does not exist");
            }

            if(isDownload)
            {
                return File.ReadAllBytes(streamPath);
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

        public bool IsDirectory(string streamPath)
        {
            // no directory download tests by default.
            // if running directory download tests this
            // needs to be overwritten by the mock.
            return false;
        }

        public IDictionary<string, long> ListDirectory(string directoryPath, bool recursive)
        {
            // TODO: support recursive tests.
            var toReturn = new Dictionary<string, long>();
            foreach (var entry in _streams)
            {
                toReturn.Add(entry.Key, entry.Value.Length);
            }

            return toReturn;
        }

        public int StreamCount
        {
            get { return _streams.Count; }
        }

        #endregion

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
