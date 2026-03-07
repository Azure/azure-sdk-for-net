// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public readonly partial struct StorageMinimumTlsVersion
    {
        /// <summary> TLS1_0. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_0 => Tls10;

        /// <summary> TLS1_1. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_1 => Tls11;

        /// <summary> TLS1_2. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_2 => Tls12;

        /// <summary> TLS1_3. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageMinimumTlsVersion Tls1_3 => Tls13;
    }
}
