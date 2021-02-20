// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("Descriptor")]
    public partial class ContentDescriptor
    {
        public ContentDescriptor(string mediaType)
        {
            MediaType = mediaType;

            // TODO: Set Size and Digest from MediaType
            // TODO: what if Size passed is null?
            // TODO: See https://github.com/sajayantony/acr-cli/blob/main/Services/ContentStore.cs#L134 for details
        }

        /// <summary> Layer media type. </summary>
        public string MediaType { get; }
        /// <summary> Layer size. </summary>
        public long? Size { get; }
        /// <summary> Layer digest. </summary>
        public string Digest { get; }
    }
}
