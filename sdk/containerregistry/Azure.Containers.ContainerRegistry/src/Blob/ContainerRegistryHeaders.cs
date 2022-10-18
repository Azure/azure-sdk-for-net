// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Containers.ContainerRegistry
{
    internal class ContainerRegistryHeaders
    {
        public static string DockerContentDigest => "Docker-Content-Digest";

        public static string Location => "Location";
    }
}
