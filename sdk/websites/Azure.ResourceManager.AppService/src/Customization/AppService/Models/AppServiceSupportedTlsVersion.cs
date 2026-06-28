// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.AppService;

namespace Azure.ResourceManager.AppService.Models
{
    public readonly partial struct AppServiceSupportedTlsVersion : IEquatable<AppServiceSupportedTlsVersion>
    {
        /// <summary> 1.3. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceSupportedTlsVersion One3 { get => Tls1_3; }
    }
}
