// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> MinTlsVersion: configures the minimum version of TLS required for SSL requests. </summary>
    public readonly partial struct AppServiceSupportedTlsVersion : IEquatable<AppServiceSupportedTlsVersion>
    {
#pragma warning disable CA1707

        /// <summary> 1.0. </summary>
        [CodeGenMember("One0")]
        public static AppServiceSupportedTlsVersion Tls1_0 { get; } = new AppServiceSupportedTlsVersion(Tls1_0Value);
        /// <summary> 1.1. </summary>
        [CodeGenMember("One1")]
        public static AppServiceSupportedTlsVersion Tls1_1 { get; } = new AppServiceSupportedTlsVersion(Tls1_1Value);
        /// <summary> 1.2. </summary>
        [CodeGenMember("One2")]
        public static AppServiceSupportedTlsVersion Tls1_2 { get; } = new AppServiceSupportedTlsVersion(Tls1_2Value);
#pragma warning restore CA1707
    }
}
