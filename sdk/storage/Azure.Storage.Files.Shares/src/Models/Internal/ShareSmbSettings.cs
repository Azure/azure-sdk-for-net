// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Settings for SMB protocol.
    /// </summary>
    public partial class ShareSmbSettings
    {
        /// <summary>
        /// Creates a new ShareSmbSettings instance.
        /// </summary>
        public ShareSmbSettings()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new ShareSmbSettings instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal ShareSmbSettings(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Multichannel = new Azure.Storage.Files.Shares.Models.SmbMultichannel();
            }
        }
    }
}
