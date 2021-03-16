// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// </summary>
    [CodeGenModel("RepositoryAttributes")]
    public partial class RepositoryProperties
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("ImageName")]
        public string Name { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("ChangeableAttributes")]
        public ContentProperties ModifiableProperties { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("ManifestCount")]
        public int RegistryArtifactCount { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("CreatedTime")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("LastUpdateTime")]
        public DateTimeOffset LastUpdatedOn { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("TagCount")]
        public int TagCount { get; }
    }
}
