// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    [CodeGenModel("ContentType")]
    public enum ManifestMediaType
    {
        /// <summary> Content type for upload. </summary>
        /// <summary> Content Type &apos;application/vnd.docker.distribution.manifest.v2+json&apos;. </summary>
        [CodeGenMember("ApplicationVndDockerDistributionManifestV2Json")]
        DockerManifestV2,

        /// <summary> Content Type &apos;application/vnd.oci.image.manifest.v1+json&apos;. </summary>
        [CodeGenMember("ApplicationVndOciImageManifestV1Json")]
        OciManifestV1
    }
}
