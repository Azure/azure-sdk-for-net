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
        public IReadOnlyList<TagProperties> Tags
        {
            get
            {
                List<TagProperties> tags = new List<TagProperties>();
                foreach (var tag in this.TagAttributeBases)
                {
                    tags.Add(FromTagAttributesBase(this.Repository, tag));
                }
                return tags.AsReadOnly();
            }
        }

        internal static TagProperties FromTagAttributesBase(string repository, TagAttributesBase attributesBase)
        {
            return new TagProperties(
                repository,
                attributesBase.Name,
                attributesBase.Digest,
                attributesBase.CreatedOn,
                attributesBase.LastUpdatedOn,
                attributesBase.WriteableProperties);
        }
    }
}
