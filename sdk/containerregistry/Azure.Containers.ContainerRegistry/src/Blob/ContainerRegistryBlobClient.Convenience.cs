// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    public partial class ContainerRegistryBlobClient
    {
        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="RequestFailedException"></exception>
        public virtual Response DownloadTo(string path, ArtifactDownloadToOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="RequestFailedException"></exception>
        public virtual Response DownloadTo(ArtifactStreams destination, ArtifactDownloadToOptions options = default, CancellationToken cancellationToken = default )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="RequestFailedException"></exception>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public virtual async Task<Response> DownloadToAsync(string path, ArtifactDownloadToOptions options = default, CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="RequestFailedException"></exception>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public virtual async Task<Response> DownloadToAsync(ArtifactStreams destination, ArtifactDownloadToOptions options = default, CancellationToken cancellationToken = default)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }
    }
}
