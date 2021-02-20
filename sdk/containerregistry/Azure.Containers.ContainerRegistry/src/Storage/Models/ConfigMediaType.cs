// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    public readonly struct ConfigMediaType : IEquatable<ConfigMediaType>
    {
        // TODO: confirm this list is complete
        // See: https://github.com/opencontainers/image-spec/blob/28462ef6944123de00cf27e812309cbf5d82da71/media-types.md
        public static readonly ConfigMediaType DockerImageV1 = new ConfigMediaType("application/vnd.docker.container.image.v1+json");
        public static readonly ConfigMediaType OciImageConfigV1 = new ConfigMediaType("application/vnd.oci.image.config.v1+json");

        private readonly string _value;

        private ConfigMediaType(string mediaType)
        {
            _value = mediaType;
        }

        public static implicit operator ConfigMediaType(string mediaType) => new ConfigMediaType(mediaType);

        public static explicit operator string(ConfigMediaType mediaType) => mediaType._value;

        public static bool operator ==(ConfigMediaType left, ConfigMediaType right) => Equals(left, right);

        public static bool operator !=(ConfigMediaType left, ConfigMediaType right) => !Equals(left, right);

        public bool Equals(ConfigMediaType other) => _value == other._value;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConfigMediaType mediaType && Equals(mediaType);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        public override string ToString() => _value;
    }
}
