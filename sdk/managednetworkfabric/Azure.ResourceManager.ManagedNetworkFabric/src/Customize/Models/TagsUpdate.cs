// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.ManagedNetworkFabric;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenSuppress("TagsUpdate")]
    [CodeGenSuppress("TagsUpdate", typeof(IDictionary<string, string>), typeof(IDictionary<string, BinaryData>))]
    [CodeGenSuppress("Tags")]
    public partial class TagsUpdate : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="TagsUpdate"/>. </summary>
        public TagsUpdate()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TagsUpdate"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal TagsUpdate(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(tags, additionalBinaryDataProperties)
        {
        }
    }
}
