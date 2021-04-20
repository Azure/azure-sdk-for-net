// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Options to override default GetManifests() behavior.
    /// </summary>
    public class GetArtifactManifestsOptions
    {
        /// <summary>
        /// Construct an instance of GetManifestsOptions.
        /// </summary>
        /// <param name="orderBy"></param>
        public GetArtifactManifestsOptions(ManifestOrderBy orderBy)
        {
            this.OrderBy = orderBy;
        }

        /// <summary>
        /// Get the option specified for ordering registry artifacts in the returned collection.
        /// </summary>
        public ManifestOrderBy OrderBy { get; }
    }
}
