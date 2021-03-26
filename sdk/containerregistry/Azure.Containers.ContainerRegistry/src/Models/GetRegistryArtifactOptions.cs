// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Options to override default GetRegistryArtifact() behavior.
    /// </summary>
    public class GetRegistryArtifactOptions
    {
        /// <summary>
        /// Construct an instance of GetRegistryArtifactOptions.
        /// </summary>
        /// <param name="orderBy"></param>
        public GetRegistryArtifactOptions(RegistryArtifactOrderBy orderBy)
        {
            this.OrderBy = orderBy;
        }

        /// <summary>
        /// Get the option specified for ordering registry artifacts in the returned collection.
        /// </summary>
        public RegistryArtifactOrderBy OrderBy { get; }
    }
}
