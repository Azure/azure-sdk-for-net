// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.AppContainers
{
    public partial class ContainerAppCustomDomainConfiguration
    {
        /// <summary> Gets the certificate expiration date and time. </summary>
        // The TypeSpec generator uses the improved ExpiresOn name instead of the legacy ExpireOn name.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExpiresOn instead.")]
        public BicepValue<DateTimeOffset> ExpireOn => ExpiresOn;
    }
}
