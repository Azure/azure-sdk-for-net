// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Shared;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Local File Storage Resource
    /// </summary>
    public class LocalFileStorageResource : StorageResource
    {
        private List<string> _path;
        private string _originalPath;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public LocalFileStorageResource(string path)
        {
            _originalPath = path;
            _path = path.Split('/').ToList();
        }

        /// <summary>
        /// Can consume readable stream
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override StreamReadableOptions CanConsumeReadableStream()
        {
            return StreamReadableOptions.Consumable;
        }

        /// <summary>
        /// Can produce URL
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override ProduceUriOptions CanProduceUri()
        {
            return ProduceUriOptions.ProducesUri;
        }

        /// <summary>
        /// Cannot produce consumable stream
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Stream ConsumableStream()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Can produce readable stream
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task ConsumeReadableStream(Stream stream)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cannot produce URL
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Task ConsumeUri(Uri uri)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get length of the file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal Task<long?> GetLength()
        {
            FileInfo fileInfo = new FileInfo(_originalPath);

            if (fileInfo.Exists)
            {
                return Task.FromResult<long?>(fileInfo.Length);
            }
            // File does not exist, no length.
            return Task.FromResult<long?>(default);
        }

        /// <summary>
        /// Get Path of the file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override List<string> GetPath()
        {
            return _path;
        }

        /// <summary>
        /// Get the Uri
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Uri GetUri()
        {
            return new Uri(_originalPath);
        }

        /// <summary>
        /// Gets the readable input stream
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Stream ReadableInputStream()
        {
            return new FileStream(_originalPath, FileMode.Open, FileAccess.Read);
        }
    }
}
