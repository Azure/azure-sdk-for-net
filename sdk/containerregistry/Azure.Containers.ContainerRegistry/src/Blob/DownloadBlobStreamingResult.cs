// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The result from downloading a blob from the registry.
    /// </summary>
    public class DownloadBlobStreamingResult : IDisposable
    {
        internal DownloadBlobStreamingResult(string digest, Stream content)
        {
            Digest = digest;
            Content = content;
        }

        /// <summary>
        /// The blob's digest, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// The blob content.
        /// </summary>
        public Stream Content { get; }

        /// <summary>
        /// Disposes the <see cref="DownloadBlobStreamingResult"/> by calling Dispose on the underlying <see cref="Content"/> stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
