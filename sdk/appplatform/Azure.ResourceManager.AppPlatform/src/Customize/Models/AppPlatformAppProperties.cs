// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppPlatform.Models
{
    /// <summary> App resource properties payload. </summary>
    public partial class AppPlatformAppProperties
    {
        /// <summary> URL of the App. </summary>
        [Obsolete("'Uri' is deprecated. Use 'UriString' instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Uri { get; }
    }
}