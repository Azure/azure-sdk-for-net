// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Protocol settings.
    /// </summary>
    public partial class ShareProtocolSettings
    {
        /// <summary>
        /// Creates a new ShareProtocolSettings instance.
        /// </summary>
        public ShareProtocolSettings()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareProtocolSettings instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareProtocolSettings(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Smb = new Azure.Storage.Files.Shares.Models.ShareSmbSettings();
            }
        }
    }
}
