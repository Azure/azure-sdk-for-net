// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Storage.Blobs
{
    // TODO: Make public again
    internal struct CustomerProvidedKeyInfo : IEquatable<CustomerProvidedKeyInfo>
    {
        public string EncryptionKey { get; set; }
        public string EncryptionKeySha256 { get; set; }

        public override bool Equals(object obj)
            => obj is CustomerProvidedKeyInfo other && this.Equals(other);

        public override int GetHashCode()
            => this.EncryptionKey.GetHashCode()
            ^ this.EncryptionKeySha256.GetHashCode()
            ;

        public static bool operator ==(CustomerProvidedKeyInfo left, CustomerProvidedKeyInfo right) => left.Equals(right);

        public static bool operator !=(CustomerProvidedKeyInfo left, CustomerProvidedKeyInfo right) => !(left == right);

        public bool Equals(CustomerProvidedKeyInfo other)
         => this.EncryptionKey == other.EncryptionKey
            && this.EncryptionKeySha256 == other.EncryptionKeySha256
            ;

        public override string ToString()
            => $"[{nameof(CustomerProvidedKeyInfo)}:{nameof(this.EncryptionKey)}={this.EncryptionKey};{nameof(this.EncryptionKeySha256)}={this.EncryptionKeySha256}]";
    }
}
