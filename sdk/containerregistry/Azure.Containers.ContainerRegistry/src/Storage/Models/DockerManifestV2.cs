// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("V2Manifest")]
    public partial class DockerManifestV2
    {
        public static Task<DockerManifestV2> FromStreamAsync(Stream stream)
        {
            throw new NotImplementedException();

            // TODO: Deserialize, and then additionally compute digest to cache for later
        }

        public static DockerManifestV2 FromStream(Stream stream)
        {
            throw new NotImplementedException();

            // TODO: Deserialize, and then additionally compute digest to cache for later
        }

        /// <summary> V2 image config descriptor. </summary>
        [CodeGenMember("Config")]
        public ContentDescriptor ConfigDescriptor { get; set; }
    }
}
