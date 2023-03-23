// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// Media type values for Docker and OCI Manifests.
    /// </summary>
    public readonly struct ManifestMediaType : IEquatable<ManifestMediaType>
    {
        /// <summary>
        /// The media type for an OCI Image Manifest.  This format is described at https://github.com/opencontainers/image-spec/blob/main/manifest.md.
        /// </summary>
        public static readonly ManifestMediaType OciImageManifest = new ManifestMediaType("application/vnd.oci.image.manifest.v1+json");

        /// <summary>
        /// The media type for a Docker Image Manifest, Version 2, Schema 2.  This format is described at https://docs.docker.com/registry/spec/manifest-v2-2/.
        /// </summary>
        public static readonly ManifestMediaType DockerManifest = new ManifestMediaType("application/vnd.docker.distribution.manifest.v2+json");

        internal static readonly ManifestMediaType OciIndex = new ManifestMediaType("application/vnd.oci.image.index.v1+json");
        internal static readonly ManifestMediaType DockerManifestList = new ManifestMediaType("application/vnd.docker.distribution.manifest.list.v2+json");
        internal static readonly ManifestMediaType DockerManifestV1 = new ManifestMediaType("application/vnd.docker.container.image.v1+json");
        internal static readonly ManifestMediaType OrasArtifactV1 = new ManifestMediaType("application/vnd.cncf.oras.artifact.manifest.v1+json");

        private readonly string _value;

        private ManifestMediaType(string mediaType)
        {
            _value = mediaType;
        }

        /// <summary> Converts a string to a <see cref="ManifestMediaType"/>. </summary>
        public static implicit operator ManifestMediaType(string mediaType) => new ManifestMediaType(mediaType);

        /// <summary> Converts a <see cref="ManifestMediaType"/> to a string. </summary>
        public static explicit operator string(ManifestMediaType mediaType) => mediaType._value;

        /// <summary> Determines if two <see cref="ManifestMediaType"/> values are the same. </summary>
        public static bool operator ==(ManifestMediaType left, ManifestMediaType right) => Equals(left, right);

        /// <summary> Determines if two <see cref="ManifestMediaType"/> values are different. </summary>
        public static bool operator !=(ManifestMediaType left, ManifestMediaType right) => !Equals(left, right);

        /// <inheritdoc />
        public bool Equals(ManifestMediaType other) => _value == other._value;

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ManifestMediaType mediaType && Equals(mediaType);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
