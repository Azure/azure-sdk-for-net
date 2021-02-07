// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Models
{
    public partial class ManifestAttributes
    {
        public string Digest { get { return Attributes.Digest; } }

        // TODO: Why is this nullable?  does it need to be?
        // TODO: Size in Bytes?
        public long ImageSize { get { return Attributes.ImageSize.Value; } }

        // TODO: Why is this nullable?  does it need to be?
        public DateTimeOffset CreatedTime { get { return Attributes.CreatedTime.Value; } }

        // TODO: Why is this nullable?  does it need to be?
        public DateTimeOffset LastUpdateTime { get { return Attributes.LastUpdateTime.Value; } }

        public string CpuArchitecture { get { return Attributes.Architecture; } }

        public string OperatingSystem { get { return Attributes.Os; } }

        public ManifestMediaType MediaType { get { return Attributes.MediaType; } }

        public ConfigMediaType ConfigMediaType { get { return Attributes.ConfigMediaType; } }

        // TODO: Ok to have this as a list and not a pageable?
        public IReadOnlyList<string> Tags { get { return Attributes.Tags; } }

        public ContentPermissions Permissions { get { return Attributes.ChangeableAttributes; } }

        /// <summary> Manifest attributes. </summary>
        internal ManifestAttributesBase Attributes { get; }
    }
}
