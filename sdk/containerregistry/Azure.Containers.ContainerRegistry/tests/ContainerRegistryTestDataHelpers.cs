// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.Specialized;

namespace Azure.Containers.ContainerRegistry.Tests
{
    internal static class ContainerRegistryTestDataHelpers
    {
        /// <summary>
        /// Create an OciImageManifest type that matches the contents of the manifest.json test data file.
        /// </summary>
        /// <returns></returns>
        internal static OciImageManifest CreateManifest()
        {
            OciImageManifest manifest = new OciImageManifest()
            {
                SchemaVersion = 2,
                Config = new OciBlobDescriptor()
                {
                    MediaType = "application/vnd.acme.rocket.config",
                    Digest = "sha256:d25b42d3dbad5361ed2d909624d899e7254a822c9a632b582ebd3a44f9b0dbc8",
                    SizeInBytes = 171
                }
            };
            manifest.Layers.Add(new OciBlobDescriptor()
            {
                MediaType = "application/vnd.oci.image.layer.v1.tar",
                Digest = "sha256:654b93f61054e4ce90ed203bb8d556a6200d5f906cf3eca0620738d6dc18cbed",
                SizeInBytes = 28,
                Annotations = new OciAnnotations()
                {
                    Name = "artifact.txt"
                }
            });

            return manifest;
        }
    }
}
