// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("Platform")]
    public partial class ManifestPlatform
    {
        /// <summary> Specifies the CPU architecture, for example amd64 or ppc64le. </summary>
        [CodeGenMember("Architecture")]
        public ArtifactArchitecture Architecture { get; set; }

        /// <summary> The os field specifies the operating system, for example linux or windows. </summary>
        [CodeGenMember("Os")]
        public ArtifactOperatingSystem OperatingSystem { get; set; }
    }
}
