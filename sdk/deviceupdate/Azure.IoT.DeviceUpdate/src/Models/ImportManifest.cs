// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.IoT.DeviceUpdate.Models
{
    /// <summary>
    /// Import Manifest model.
    /// </summary>
    public sealed class ImportManifest
    {
        public ImportManifest(UpdateId updateId, string updateType, string installedCriteria, List<ImportManifestCompatibilityInfo> compatibility, DateTime createdDateTime, Version manifestVersion, List<ImportManifestFile> files)
        {
            UpdateId = updateId;
            UpdateType = updateType;
            InstalledCriteria = installedCriteria;
            Compatibility = compatibility;
            CreatedDateTime = createdDateTime;
            ManifestVersion = manifestVersion;
            Files = files;
        }

        /// <summary>
        /// Update identity.
        /// </summary>
        public UpdateId UpdateId { get; private set; }

        /// <summary>
        /// Update type.
        /// </summary>
        public string UpdateType { get; private set; }

        /// <summary>
        /// Installed Criteria.
        /// </summary>
        public string InstalledCriteria { get; private set; }

        /// <summary>
        /// Content compatibility data.
        /// </summary>
        public List<ImportManifestCompatibilityInfo> Compatibility { get; private set; }

        /// <summary>
        /// Date and time when content import manifest was created.
        /// </summary>
        public DateTime CreatedDateTime { get; private set; }

        /// <summary>
        /// Import manifest version.
        /// </summary>
        public Version ManifestVersion { get; private set; }

        /// <summary>
        /// Dictionary of fileId to file entity.
        /// </summary>
        public List<ImportManifestFile> Files { get; private set; }
    }
}
