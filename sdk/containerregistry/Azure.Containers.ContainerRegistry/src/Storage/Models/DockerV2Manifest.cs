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
    public partial class DockerV2Manifest
    {
        public static Task<DockerV2Manifest> FromStreamAsync(Stream stream)
        {
            throw new NotImplementedException();

            // TODO: Deserialize, and then additionally compute digest to cache for later
        }

        public static DockerV2Manifest FromStream(Stream stream)
        {
            throw new NotImplementedException();

            // TODO: Deserialize, and then additionally compute digest to cache for later
        }
    }
}
