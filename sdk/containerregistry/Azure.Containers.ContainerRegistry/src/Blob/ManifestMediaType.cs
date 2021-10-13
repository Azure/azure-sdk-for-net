// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// Media type of the manifest files.
    /// </summary>
    public readonly struct ManifestMediaType : IEquatable<ManifestMediaType>
    {
        /// <summary>
        /// Oci manifest.
        /// </summary>
        public static readonly ManifestMediaType OciManifest = new ManifestMediaType("application/vnd.oci.image.manifest.v1+json");

        /// <summary>
        /// Docker manifest v2.
        /// </summary>
        public static readonly ManifestMediaType DockerManifestV2 = new ManifestMediaType("application/vnd.docker.distribution.manifest.v2+json");

        // The below manifest types will be added in in a later v1.1.0 library version -- keeping them here for when needed.
        //
        // public static readonly ManifestMediaType OciIndex = new ManifestMediaType("application/vnd.oci.image.index.v1+json");
        // public static readonly ManifestMediaType DockerManifestV1 = new ManifestMediaType("application/vnd.docker.container.image.v1+json");
        // public static readonly ManifestMediaType DockerManifestList = new ManifestMediaType("application/vnd.docker.distribution.manifest.list.v2+json");

        private readonly string _value;

        private ManifestMediaType(string mediaType)
        {
            _value = mediaType;
        }

        /// <summary>
        /// Converts a string representation of a media type into a <see cref="ManifestMediaType"/>
        /// </summary>
        /// <param name="mediaType">Media type.</param>
        public static implicit operator ManifestMediaType(string mediaType) => new ManifestMediaType(mediaType);

        /// <summary>
        /// Converts a <see cref="ManifestMediaType"/> into its string representation.
        /// </summary>
        /// <param name="mediaType">Manifest media type</param>
        public static explicit operator string(ManifestMediaType mediaType) => mediaType._value;

        /// <summary>
        /// Compares two <see cref="ManifestMediaType" /> structs for equality.
        /// </summary>
        /// <param name="left">The left <see cref="ManifestMediaType"/>.</param>
        /// <param name="right">The right <see cref="ManifestMediaType"/>.</param>
        /// <returns></returns>
        public static bool operator ==(ManifestMediaType left, ManifestMediaType right) => Equals(left, right);

        /// <summary>
        /// Compares two <see cref="ManifestMediaType" /> structs for inequality.
        /// </summary>
        /// <param name="left">The left <see cref="ManifestMediaType"/>.</param>
        /// <param name="right">The right <see cref="ManifestMediaType"/>.</param>
        /// <returns></returns>
        public static bool operator !=(ManifestMediaType left, ManifestMediaType right) => !Equals(left, right);

        /// <inheritdoc/>
        public bool Equals(ManifestMediaType other) => _value == other._value;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ManifestMediaType mediaType && Equals(mediaType);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}
