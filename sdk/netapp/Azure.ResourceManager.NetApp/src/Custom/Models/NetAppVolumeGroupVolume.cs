// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat wrapper for the GA IsRestoring setter. Other VolumeProperties
// members are flattened by TypeSpec.

#nullable disable

using System;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        private NetAppVolumeLanguage? _language;
        private NetAppLdapServerType? _ldapServerType;
        private LargeVolumeType? _largeVolumeType;
        private BreakthroughMode? _breakthroughMode;
        private BreakthroughMode? _breakthroughModeOld;

        // The current service API omits this field; retain it for callers using older versions.
        /// <summary> Gets or sets whether subvolumes are enabled. </summary>
        public EnableNetAppSubvolume? EnableSubvolumes
        {
            get => Properties?.EnableSubvolumes;
            set => (Properties ??= new VolumeProperties()).EnableSubvolumes = value;
        }

        /// <summary> Restoring. </summary>
        public bool? IsRestoring
        {
            get => Properties is null ? default : Properties.IsRestoring;
            set { /* setter kept for backward compat; value is read-only from service */ }
        }

        /// <summary> Language supported for volume. </summary>
        public NetAppVolumeLanguage? Language
        {
            get => _language;
            set => _language = value;
        }

        /// <summary> The type of the LDAP server. </summary>
        public NetAppLdapServerType? LdapServerType
        {
            get => _ldapServerType;
            set => _ldapServerType = value;
        }

        /// <summary> Specifies whether volume is a Large Volume or Regular Volume. </summary>
        public LargeVolumeType? LargeVolumeType
        {
            get => _largeVolumeType;
            set => _largeVolumeType = value;
        }

        /// <summary> Breakthrough mode. </summary>
        public BreakthroughMode? BreakthroughMode
        {
            get => _breakthroughMode;
            set => _breakthroughMode = value;
        }

        /// <summary>
        /// Legacy breakthrough mode field retained for service-compatibility.
        /// Use <see cref="BreakthroughMode"/> for new code.
        /// </summary>
        [Obsolete("Use BreakthroughMode instead.")]
        public BreakthroughMode? BreakthroughModeOld
        {
            get => _breakthroughModeOld;
            set => _breakthroughModeOld = value;
        }
    }
}
