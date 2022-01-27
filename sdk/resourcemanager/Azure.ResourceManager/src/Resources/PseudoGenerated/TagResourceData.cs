// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> Wrapper resource for tags API requests and responses. </summary>
    public partial class TagResourceData : Resource
    {
        /// <summary> Initializes a new instance of TagsResourceData. </summary>
        /// <param name="properties"> The set of tags. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public TagResourceData(Tag properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            Properties = properties;
        }

        /// <summary> Initializes a new instance of TagsResource. </summary>
        /// <param name="id"> The ID of the tags wrapper resource. </param>
        /// <param name="name"> The name of the tags wrapper resource. </param>
        /// <param name="type"> The type of the tags wrapper resource. </param>
        /// <param name="properties"> The set of tags. </param>
        internal TagResourceData(ResourceIdentifier id, string name, string type, Tag properties): base(id, name, type)
        {
            Properties = properties;
        }

        /// <summary> The set of tags. </summary>
        public Tag Properties { get; set; }
    }
}
