// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files
{
    /// <summary>
    /// A reference to a task or job output file in persistent storage.
    /// </summary>
    public sealed class OutputFileReference
    {
        internal OutputFileReference(IListBlobItem blob)
            : this((ICloudBlob)blob)
        {
        }

        internal OutputFileReference(ICloudBlob blob)
        {
            CloudBlob = blob;
        }

        /// <summary>
        /// Gets the path under which the file was stored.
        /// </summary>
        /// <remarks>If the file was stored under a directory path, the FilePath property uses the directory
        /// separator of the underlying blob storage (for example, mydirectory/myfile.txt). Such paths may
        /// not be directly usable as Windows paths.</remarks>
        public string FilePath
        {
            get
            {
                var storagePath = Uri.AbsolutePath;  // /container/$kind/path or /container/taskid/$kind/path
                var pathFromContainer = storagePath.Substring(storagePath.IndexOf('/', 1) + 1);
                var kindAndRelativePath = pathFromContainer.Substring(pathFromContainer.IndexOf('$'));
                var relativePath = kindAndRelativePath.Substring(kindAndRelativePath.IndexOf('/') + 1);
                return relativePath;
            }
        }

        /// <summary>
        /// Gets the URI of the file in persistent storage.
        /// </summary>
        public Uri Uri => CloudBlob.Uri;

        /// <summary>
        /// Gets a reference to the underlying <see cref="ICloudBlob"/> object representing the
        /// file in persistent storage. This can be used to invoke blob methods or overloads not surfaced
        /// by the <see cref="OutputFileReference"/> abstraction.
        /// </summary>
        public ICloudBlob CloudBlob { get; }

        /// <summary>
        /// Downloads the contents of the file to a specified path.
        /// </summary>
        /// <param name="path">The path to which to download the file.</param>
        /// <param name="mode">Specifies how to open or create the file.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <seealso cref="ICloudBlob.DownloadToFileAsync(string, FileMode)"/>
        public async Task DownloadToFileAsync(string path, FileMode mode, CancellationToken cancellationToken = default(CancellationToken))
        {
#if FullNetFx
            await CloudBlob.DownloadToFileAsync(path, mode, cancellationToken).ConfigureAwait(false);
#else
            await CloudBlob.DownloadToFileAsync(path, mode).ConfigureAwait(false);
#endif

        }

        /// <summary>
        /// Downloads the contents of the file to a stream.
        /// </summary>
        /// <param name="target">The target stream.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <seealso cref="ICloudBlob.DownloadToStreamAsync(Stream)"/>
        public async Task DownloadToStreamAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken))
        {
#if FullNetFx
            await CloudBlob.DownloadToStreamAsync(target, cancellationToken).ConfigureAwait(false);
#else
            await CloudBlob.DownloadToStreamAsync(target).ConfigureAwait(false);
#endif
        }

        /// <summary>
        /// Downloads the contents of the file to a byte array.
        /// </summary>
        /// <param name="target">The target byte array.</param>
        /// <param name="index">The starting offset in the byte array</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>The total number of bytes read into the buffer.</returns>
        /// <seealso cref="ICloudBlob.DownloadToByteArrayAsync(byte[], int)"/>
        public async Task<int> DownloadToByteArrayAsync(byte[] target, int index, CancellationToken cancellationToken = default(CancellationToken))
        {
#if FullNetFx
            return await CloudBlob.DownloadToByteArrayAsync(target, index, cancellationToken).ConfigureAwait(false);
#else
            return await CloudBlob.DownloadToByteArrayAsync(target, index).ConfigureAwait(false);
#endif
        }

        /// <summary>
        /// Deletes the file from persistent storage.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <seealso cref="ICloudBlob.DeleteAsync()"/>
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
#if FullNetFx
            await CloudBlob.DeleteAsync(cancellationToken).ConfigureAwait(false);
#else
            await CloudBlob.DeleteAsync().ConfigureAwait(false);
#endif
        }

        /// <summary>
        /// Opens a stream for reading from the file in persistent storage.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A stream to be used for reading from the blob.</returns>
        /// <seealso cref="ICloudBlob.OpenReadAsync(WindowsAzure.Storage.AccessCondition, BlobRequestOptions, WindowsAzure.Storage.OperationContext)"/>
        public async Task<Stream> OpenReadAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
#if FullNetFx
            return await CloudBlob.OpenReadAsync(cancellationToken).ConfigureAwait(false);
#else
            return await CloudBlob.OpenReadAsync(null, null, null).ConfigureAwait(false);
#endif
        }
    }
}
