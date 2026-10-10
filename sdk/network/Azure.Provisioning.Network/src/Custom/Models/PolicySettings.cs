// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Network;

public partial class PolicySettings
{
    // Preserve the original Bicep path for callers targeting API versions before 2025-07-01.
    /// <summary> Gets or sets the Web Application Firewall CAPTCHA cookie expiration time in minutes. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use CaptchaExpirationInMins instead.")]
    public BicepValue<int> CaptchaCookieExpirationInMins
    {
        get { Initialize(); return _captchaCookieExpirationInMins; }
        set { Initialize(); _captchaCookieExpirationInMins.Assign(value); }
    }
    private BicepValue<int> _captchaCookieExpirationInMins;

    partial void DefineAdditionalProperties()
    {
#pragma warning disable CS0618 // Register the retained legacy property under its released name.
        _captchaCookieExpirationInMins = DefineProperty<int>(nameof(CaptchaCookieExpirationInMins), new string[] { "captchaCookieExpirationInMins" });
#pragma warning restore CS0618
    }
}
