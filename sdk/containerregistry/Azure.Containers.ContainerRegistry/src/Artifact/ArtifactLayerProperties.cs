// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// </summary>
    public class ArtifactLayerProperties
    {
        internal ArtifactLayerProperties(string repositoryName, string digest, string fileName = default)
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
        /// </summary>
        public string FileName { get; }
    }
}
