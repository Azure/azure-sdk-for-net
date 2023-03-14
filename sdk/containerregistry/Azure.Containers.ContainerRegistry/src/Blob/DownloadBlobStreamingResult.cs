// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// The result from downloading a blob from the registry.
    /// </summary>
    public class DownloadBlobStreamingResult
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
    }
}
