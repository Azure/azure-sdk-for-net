// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class ArtifactBlobProperties
    {
        internal ArtifactBlobProperties(string repositoryName, string digest, string fileName = default)
        {
            RepositoryName = repositoryName;
            Digest = digest;
            FileName = fileName;
        }

        /// <summary>
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// </summary>
        public string RepositoryName { get;  }

        /// <summary>
        /// Optional property - use Digest if FileName is null.
        /// </summary>
        public string FileName { get; }
    }
}
