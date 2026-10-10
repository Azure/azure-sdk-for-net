// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Defines contents of a web application firewall global configuration. </summary>
    public partial class PolicySettings
    {
        // The service replaced the old wire property in API version 2025-07-01.
        /// <inheritdoc cref="CaptchaExpirationInMins"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use CaptchaExpirationInMins instead.")]
        public int? CaptchaCookieExpirationInMins
        {
            get => CaptchaExpirationInMins;
            set => CaptchaExpirationInMins = value;
        }
    }
}
