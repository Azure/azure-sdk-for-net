// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    public partial class SsoUri
    {
        // Backward compatibility: old API exposed Uri AvailableSsoUri, new uses string SsoUriValue
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri AvailableSsoUri => SsoUriValue != null ? new Uri(SsoUriValue) : null;
    }
}
