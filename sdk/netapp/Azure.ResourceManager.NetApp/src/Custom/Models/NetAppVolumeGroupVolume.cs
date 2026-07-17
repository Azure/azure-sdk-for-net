// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat wrapper for the GA IsRestoring setter. Other VolumeProperties
// members are flattened by TypeSpec.

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppVolumeGroupVolume
    {
        private NetAppVolumeLanguage? _language;
        private NetAppLdapServerType? _ldapServerType;
        private LargeVolumeType? _largeVolumeType;
        private BreakthroughMode? _breakthroughMode;

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
    }
}
