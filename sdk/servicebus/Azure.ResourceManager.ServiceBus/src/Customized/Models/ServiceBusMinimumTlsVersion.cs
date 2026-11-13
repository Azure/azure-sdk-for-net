// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.ServiceBus.Models
{
    /// <summary>
    /// Backward compatibility: The previous SDK used underscore-separated names (Tls1_0)
    /// while the TypeSpec generator produces names without underscores (Tls10).
    /// </summary>
    public partial struct ServiceBusMinimumTlsVersion
    {
        /// <summary> TLS 1.0 </summary>
        public static ServiceBusMinimumTlsVersion Tls1_0 { get; } = Tls10;
        /// <summary> TLS 1.1 </summary>
        public static ServiceBusMinimumTlsVersion Tls1_1 { get; } = Tls11;
        /// <summary> TLS 1.2 </summary>
        public static ServiceBusMinimumTlsVersion Tls1_2 { get; } = Tls12;
        /// <summary> TLS 1.3 </summary>
        public static ServiceBusMinimumTlsVersion Tls1_3 { get; } = Tls13;
    }
}
