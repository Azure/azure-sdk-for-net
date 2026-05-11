// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: @@clientName produces Tls10/Tls11/Tls12/Tls13 but old GA had Tls1_0/Tls1_1/Tls1_2/Tls1_3.
// The generator strips underscores during PascalCase transform, so @@clientName alone cannot produce
// the old names. These hidden aliases preserve backward compatibility.

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct StorageMinimumTlsVersion
    {
        // Backward-compatible alias for Tls10.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_0 { get; } = new StorageMinimumTlsVersion("TLS1_0");
        // Backward-compatible alias for Tls11.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_1 { get; } = new StorageMinimumTlsVersion("TLS1_1");
        // Backward-compatible alias for Tls12.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_2 { get; } = new StorageMinimumTlsVersion("TLS1_2");
        // Backward-compatible alias for Tls13.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_3 { get; } = new StorageMinimumTlsVersion("TLS1_3");
    }
}
