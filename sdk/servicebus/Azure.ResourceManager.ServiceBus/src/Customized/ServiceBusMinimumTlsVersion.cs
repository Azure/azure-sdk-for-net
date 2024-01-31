// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus.Models
{
    /// <summary> The minimum TLS version for the cluster to support, e.g. &apos;1.2&apos;. </summary>
    public readonly partial struct ServiceBusMinimumTlsVersion : IEquatable<ServiceBusMinimumTlsVersion>
    {
#pragma warning disable CA1707
        /// <summary> 1.0. </summary>
        [CodeGenMember("One0")]
        public static ServiceBusMinimumTlsVersion Tls1_0 { get; } = new ServiceBusMinimumTlsVersion(Tls1_0Value);
        /// <summary> 1.1. </summary>
        [CodeGenMember("One1")]
        public static ServiceBusMinimumTlsVersion Tls1_1 { get; } = new ServiceBusMinimumTlsVersion(Tls1_1Value);
        /// <summary> 1.2. </summary>
        [CodeGenMember("One2")]
        public static ServiceBusMinimumTlsVersion Tls1_2 { get; } = new ServiceBusMinimumTlsVersion(Tls1_2Value);
#pragma warning restore CA1707
    }
}
