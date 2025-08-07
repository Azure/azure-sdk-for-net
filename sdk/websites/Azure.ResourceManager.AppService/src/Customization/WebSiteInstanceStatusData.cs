// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService
{
    public partial class WebSiteInstanceStatusData
    {
        /// <summary> The ARM URI to the Service Bus relay. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release, please use `HealthCheckUriString` instead", false)]
        public Uri HealthCheckUri { get; set; }
    }
}
