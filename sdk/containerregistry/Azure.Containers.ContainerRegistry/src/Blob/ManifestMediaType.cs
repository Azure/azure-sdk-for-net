// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public readonly struct ManifestMediaType : IEquatable<ManifestMediaType>
    {
        /// <summary>
        /// </summary>
        public static readonly ManifestMediaType OciManifest = new ManifestMediaType("application/vnd.oci.image.manifest.v1+json");
        //public static readonly ManifestMediaType OciIndex = new ManifestMediaType("application/vnd.oci.image.index.v1+json");
        //public static readonly ManifestMediaType DockerManifestV1 = new ManifestMediaType("application/vnd.docker.container.image.v1+json");
        //public static readonly ManifestMediaType DockerManifestV2 = new ManifestMediaType("application/vnd.docker.distribution.manifest.v2+json");
        //public static readonly ManifestMediaType DockerManifestList = new ManifestMediaType("application/vnd.docker.distribution.manifest.list.v2+json");

        private readonly string _value;

        private ManifestMediaType(string mediaType)
        {
            _value = mediaType;
        }

        /// <summary>
        /// </summary>
        /// <param name="mediaType"></param>
        public static implicit operator ManifestMediaType(string mediaType) => new ManifestMediaType(mediaType);

        /// <summary>
        /// </summary>
        /// <param name="mediaType"></param>
        public static explicit operator string(ManifestMediaType mediaType) => mediaType._value;

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ManifestMediaType left, ManifestMediaType right) => Equals(left, right);

        /// <summary>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ManifestMediaType left, ManifestMediaType right) => !Equals(left, right);

        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ManifestMediaType other) => _value == other._value;

        /// <summary>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ManifestMediaType mediaType && Equals(mediaType);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString() => _value;
    }
}
