// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class TagList
    {
        /// <summary> List of tag attribute details. </summary>
        public IReadOnlyList<ArtifactTagProperties> Tags
        {
            get
            {
                List<ArtifactTagProperties> tags = new List<ArtifactTagProperties>(this.TagAttributeBases.Count);
                foreach (var tag in this.TagAttributeBases)
                {
                    tags.Add(FromTagAttributesBase(this.RegistryLoginServer, this.Repository, tag));
                }
                return tags.AsReadOnly();
            }
        }

        internal static ArtifactTagProperties FromTagAttributesBase(string registry, string repository, TagAttributesBase attributesBase)
        {
            return new ArtifactTagProperties(
                registry,
                repository,
                attributesBase.Name,
                attributesBase.Digest,
                attributesBase.CreatedOn,
                attributesBase.LastUpdatedOn,
                attributesBase.CanDelete,
                attributesBase.CanWrite,
                attributesBase.CanList,
                attributesBase.CanRead);
        }
    }
}
