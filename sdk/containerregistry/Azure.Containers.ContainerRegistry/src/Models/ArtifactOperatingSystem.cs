// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The artifact platform's operating system.
    /// </summary>
    public readonly partial struct ArtifactOperatingSystem : IEquatable<ArtifactOperatingSystem>
    {
        /// <summary> iOS. </summary>
        [CodeGenMember("IOS")]
        public static ArtifactOperatingSystem iOS { get; } = new ArtifactOperatingSystem(iOSValue);
    }
}
